using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MySqlOroklesPeldaJarmukolcsonzo
{
    public partial class JarmuForm : Form
    {
        Kolcsonzo kolcsonzo;
        internal Jarmu Jarmu { get; private set; }
        public enum JarmuTipus
        {
            Szemelyauto,
            Kishaszongepjarmu
        }

        public JarmuForm()
        {
            InitializeComponent();
            cmbJarmuTipus.DataSource = Enum.GetValues(typeof(JarmuTipus));
            cmbAutoTipus.DataSource = Enum.GetValues(typeof(SzemelyGepjarmuTipus));
        }
        internal JarmuForm(Kolcsonzo kolcsonzo) : this()
        {
            this.kolcsonzo = kolcsonzo;
        }
        internal JarmuForm(Jarmu jarmu) : this()
        {
            Jarmu = jarmu;
            txbRendszam.Text = Jarmu.Rendszam;
            txbRendszam.ReadOnly = true;
            txbMarka.Text = Jarmu.Marka;
            txbMarka.ReadOnly = true;
            txbTipus.Text = Jarmu.Tipus;
            txbTipus.ReadOnly = true;
            chbFoglalt.Checked = Jarmu.Foglalt;
            if (Jarmu is SzemelyGepjarmu szemely)
            {
                cmbJarmuTipus.SelectedItem = JarmuTipus.Szemelyauto;
                numSzemelyek.Value = szemely.MaxSzemely;
                numSzemelyek.Enabled = true;
                cmbAutoTipus.Enabled = false;
            }
            else
            {
                cmbJarmuTipus.SelectedItem = JarmuTipus.Kishaszongepjarmu;
                numTeher.Value = (decimal)(Jarmu as KishaszonGepjarmu).MaxTeher;
            }
            cmbJarmuTipus.Enabled = false;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                if (Jarmu == null)
                {
                    switch ((JarmuTipus)cmbJarmuTipus.SelectedItem)
                    {
                        case JarmuTipus.Szemelyauto:
                            Jarmu = new SzemelyGepjarmu(txbRendszam.Text, txbMarka.Text, txbTipus.Text, chbFoglalt.Checked, (byte)numSzemelyek.Value, (SzemelyGepjarmuTipus)cmbAutoTipus.SelectedIndex);
                            break;
                        case JarmuTipus.Kishaszongepjarmu:
                            Jarmu = new KishaszonGepjarmu(txbRendszam.Text, txbMarka.Text, txbTipus.Text, chbFoglalt.Checked, (float)numTeher.Value);
                            break;
                    }
                    ABKezeloMySQL.UjJarmuFelvetel(Jarmu, kolcsonzo);
                }
                else
                {
                    Jarmu.Foglalt = chbFoglalt.Checked;
                    if (Jarmu is KishaszonGepjarmu teher)
                    {
                        teher.MaxTeher = (float)numTeher.Value;
                    }
                    ABKezeloMySQL.JarmuModositas(Jarmu);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
                DialogResult = DialogResult.None;
            }
        }

        private void cmbJarmuTipus_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch ((JarmuTipus)cmbJarmuTipus.SelectedItem)
            {
                case JarmuTipus.Szemelyauto:
                    numSzemelyek.Enabled = true;
                    cmbAutoTipus.Enabled = true;
                    numTeher.Enabled = false;
                    break;
                case JarmuTipus.Kishaszongepjarmu:
                    numTeher.Enabled = true;
                    numSzemelyek.Enabled = false;
                    cmbAutoTipus.Enabled = false;
                    break;
            }
        }
    }
}
