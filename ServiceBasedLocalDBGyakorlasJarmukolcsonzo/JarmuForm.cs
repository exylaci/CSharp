using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ServiceBasedLocalDBGyakorlasJarmukolcsonző
{
    public partial class JarmuForm : Form
    {
        internal Kolcsonzo kolcsonzo;
        internal Jarmu jarmu;
        private List<Kolcsonzo> kolcsonzok;

        public JarmuForm()
        {
            InitializeComponent();
        }
        internal JarmuForm(Jarmu jarmu, Kolcsonzo kolcsonzo, List<Kolcsonzo> kolcsonzok) : this()
        {
            this.kolcsonzo = kolcsonzo;
            this.jarmu = jarmu;
            this.kolcsonzok = kolcsonzok;

            cmbKategoria.DataSource = Enum.GetValues(typeof(Kategoria));
            cmbKialakitas.DataSource = Enum.GetValues(typeof(Kialakitas));
            cmbNev.DataSource = kolcsonzok.Select(k => k.Nev).Distinct().ToList();
            cmbCim.DataSource = kolcsonzok.Select(k => k.Cim).Distinct().ToList();

            if (jarmu == null)
            {
                cmbKategoria.SelectedItem = Kategoria.Autó;
                lblKialakitasKobcenti.Text = "Kialakítás:";
                cmbKialakitas.Visible = true;
                cmbKialakitas.SelectedItem = Kialakitas.suv;
                numKobcenti.Visible = false;
            }
            else
            {
                cmbNev.Text = kolcsonzo.Nev;
                //cmbCim.Text = kolcsonzo.Cim;
                txbRendszam.Text = jarmu.Rendszam;
                cmbKategoria.SelectedItem = (jarmu is Auto) ? Kategoria.Autó : Kategoria.Motor;
                txbMarka.Text = jarmu.Marka;
                if (jarmu is Auto)
                {
                    lblKialakitasKobcenti.Text = "Kialakítás:";
                    cmbKialakitas.Text = ((Auto)jarmu).Kialakitas.ToString();
                    numKobcenti.Visible = false;

                }
                else
                {
                    lblKialakitasKobcenti.Text = " Köbcenti:";
                    numKobcenti.Value = ((Motor)jarmu).Kobcenti;
                    cmbKialakitas.Visible = false;
                }
                cmbKategoria.Enabled = false;
                chbFoglalt.Checked = !jarmu.Foglalt;
            }
        }

        private void cmbNev_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbNev.SelectedIndex >= 0)
            {
                string nev = cmbNev.SelectedItem.ToString();
                cmbCim.SelectedItem = kolcsonzok.Where(k => k.Nev == nev).First().Cim;
                cmbNev.SelectedItem = nev;
            }

        }
        private void cmbCim_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbCim.SelectedIndex >= 0)
            {
                string cim = cmbCim.SelectedItem.ToString();
                cmbNev.SelectedItem = kolcsonzok.Where(k => k.Cim == cim).First().Nev;
                cmbCim.SelectedItem = cim;
            }
        }
        private void btnOK_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Elmentsem?", "Jarmű kezelése", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
            {
                DialogResult = DialogResult.None;
                return;
            }

            try
            {
                kolcsonzo = new Kolcsonzo(cmbNev.SelectedItem.ToString(), cmbCim.SelectedItem.ToString(), 1);
                if (cmbKategoria.SelectedItem.ToString().Equals(Kategoria.Autó.ToString()))
                {
                    jarmu = new Auto(txbRendszam.Text, txbMarka.Text, !chbFoglalt.Checked, (Kialakitas)cmbKialakitas.SelectedItem);
                }
                else
                {
                    jarmu = new Motor(txbRendszam.Text, txbMarka.Text, !chbFoglalt.Checked, Convert.ToInt16(numKobcenti.Text));
                }
            }
            catch (ABKivetel ex)
            {
                MessageBox.Show(ex.Message, "Hiba!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                DialogResult = DialogResult.None;
                Log.Bejegyzes(ex);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Hiba!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                DialogResult = DialogResult.None;
                Log.Bejegyzes(ex);
            }
        }
        private void cmbKategoria_SelectedValueChanged(object sender, EventArgs e)
        {
            switch ((Kategoria)(cmbKategoria.SelectedItem))
            {
                case Kategoria.Autó:
                    lblKialakitasKobcenti.Text = "Kialakítás:";
                    cmbKialakitas.Visible = true;
                    numKobcenti.Visible = false;
                    break;
                case Kategoria.Motor:
                    lblKialakitasKobcenti.Text = " Köbcenti:";
                    numKobcenti.Visible = true;
                    cmbKialakitas.Visible = false;
                    break;
                default:
                    lblKialakitasKobcenti.Text = "";
                    cmbKialakitas.Visible = false;
                    numKobcenti.Visible = false;
                    break;
            }
        }
    }
}
