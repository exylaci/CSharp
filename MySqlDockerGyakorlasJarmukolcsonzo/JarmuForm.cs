using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MySqlDockerGyakorlasJarmukolcsonzo
{
    public partial class JarmuForm : Form
    {
        internal Jarmu Jarmu { get; private set; }
        internal int KolcsonzoId { get; private set; }

        public JarmuForm()
        {
            InitializeComponent();
            cmbTipus.DataSource = Enum.GetValues(typeof(JarmuTipus));
            cmbKialakitas.DataSource = Enum.GetValues(typeof(SzemelyautoTipus));
        }
        internal JarmuForm(Jarmu jarmu, Kolcsonzo kolcsonzo) : this()
        {
            KolcsonzoId = kolcsonzo.Id;
            txbKolcsonzo.Text = kolcsonzo.ToString();
            if (jarmu != null)
            {
                Jarmu = jarmu;
                txbId.Text = jarmu.Id.ToString();
                txbRendszam.Text = jarmu.Rendszam;
                txbRendszam.ReadOnly = true;
                txbMarka.Text = jarmu.Marka;
                txbMarka.ReadOnly = true;
                cmbTipus.SelectedItem = jarmu.Jarmutipus;
                cmbTipus.Enabled = false;
                chbFoglalt.Checked = jarmu.Foglalt;
                ShowJarmutipus((JarmuTipus)cmbTipus.SelectedItem);
                if (jarmu is Szemelyauto szemelyauto)
                {
                    cmbKialakitas.SelectedItem = szemelyauto.Szemelyautotipus;
                    cmbKialakitas.Enabled = false;
                    num.Value = szemelyauto.MaxSzemely;
                    num.ReadOnly = true;
                }
                else
                {
                    cmbKialakitas.Enabled = false;
                    cmbKialakitas.Visible = false;
                    num.Value = ((Kisteherauto)jarmu).MaxTeher;
                    num.ReadOnly = false;
                }
            }
        }

        private void ShowJarmutipus(JarmuTipus jarmutipus)
        {
            if (jarmutipus == JarmuTipus.Szemelyauto)
            {
                lblSzallithatoTeherheto.Text = "Szállítható személyek száma:";
                lblMertekegyseg.Text = "fő";
                lblKialakitas.Visible = true;
                cmbKialakitas.Enabled = true;
                cmbKialakitas.Visible = true;
            }
            else
            {
                lblSzallithatoTeherheto.Text = "Maximális terhelhetőség:";
                lblMertekegyseg.Text = "kg";
                lblKialakitas.Visible = false;
                cmbKialakitas.Enabled = false;
                cmbKialakitas.Visible = false;
            }
        }

        private void cmbTipus_SelectedIndexChanged(object sender, EventArgs e)
        {
            ShowJarmutipus((JarmuTipus)cmbTipus.SelectedItem);
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            try
            {
                if (Jarmu == null)
                {
                    if (cmbTipus.SelectedItem.Equals(JarmuTipus.Szemelyauto))
                    {
                        Jarmu = new Szemelyauto(txbRendszam.Text, txbMarka.Text, (JarmuTipus)cmbTipus.SelectedItem, chbFoglalt.Checked, (SzemelyautoTipus)cmbKialakitas.SelectedItem, (byte)num.Value);
                    }
                    else
                    {
                        Jarmu = new Kisteherauto(txbRendszam.Text, txbMarka.Text, (JarmuTipus)cmbTipus.SelectedItem, chbFoglalt.Checked, (byte)num.Value);
                    }
                    ABKezelo.UjJarmuFelvetele(Jarmu, KolcsonzoId);
                }
                else
                {
                    Jarmu.Foglalt = chbFoglalt.Checked;
                    ABKezelo.JarmuModositasa(Jarmu);
                }

            }
            catch (ABKivetel ex)
            {
                MessageBox.Show(ex.Message, "Hiba!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                DialogResult = DialogResult.None;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Figyelem!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                DialogResult = DialogResult.None;
                Log.Bejegyzes(ex);
            }
        }
    }
}
