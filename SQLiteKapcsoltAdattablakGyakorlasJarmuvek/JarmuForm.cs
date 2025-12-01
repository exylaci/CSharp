using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SQLiteKapcsoltAdattablakGyakorlasJarmuvek
{
    public partial class JarmuForm : Form
    {
        internal Jarmu Jarmu { get; private set; }
        public JarmuForm()
        {
            InitializeComponent();
            cmbAutoTipus.DataSource = Enum.GetValues(typeof(AutoTipus));
        }

        internal JarmuForm(Jarmu jarmu) : this()
        {
            txbRendszam.ReadOnly = true;
            txbMarka.ReadOnly = true;
            txbTipus.ReadOnly = true;
            txbSzin.Focus();
            Jarmu = jarmu;
            txbRendszam.Text = jarmu.Rendszam;
            txbMarka.Text = jarmu.Marka;
            txbTipus.Text = jarmu.Tipus;
            txbSzin.Text = jarmu.Szin;
            numKm.Value = jarmu.FutottKm;
            if (jarmu is Auto auto)
            {
                rdbAuto.Checked = true;
                rdbMotor.Enabled = false;
                cmbAutoTipus.SelectedItem = auto.AutoTipus;
                cmbAutoTipus.Visible = true;
                cmbAutoTipus.Enabled = false;
                lblCm3.Text = "Autó típusa:";
                lblCm3.Visible = true;
            }
            else if (jarmu is Motor motor)
            {
                rdbMotor.Checked = true;
                rdbAuto.Enabled = false;
                numCm3.Value = (decimal)motor.HengerUrtartalom;
                numCm3.Visible = true;
                lblCm3.Text = "Hengerűrtartalom:";
                lblCm3.Visible = true;
            }
        }

        private void rdbAuto_CheckedChanged(object sender, EventArgs e)
        {
            lblCm3.Text = "Autó típus:";
            lblCm3.Visible = true;
            numCm3.Visible = false;
            cmbAutoTipus.Visible = true;
        }
        private void rdbMotor_CheckedChanged(object sender, EventArgs e)
        {
            lblCm3.Text = "Hengerűrtartalom:";
            lblCm3.Visible = true;
            cmbAutoTipus.Visible = false;
            numCm3.Visible = true;
        }
        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                if (Jarmu == null)
                {
                    if (rdbMotor.Checked)
                    {
                        Jarmu = new Motor(txbRendszam.Text, txbMarka.Text, txbTipus.Text, txbSzin.Text, (int)numKm.Value, (float)numCm3.Value);
                        ABKezelo.UjJarmu(Jarmu);
                    }
                    else if (rdbAuto.Checked)
                    {
                        Jarmu = new Auto(txbRendszam.Text, txbMarka.Text, txbTipus.Text, txbSzin.Text, (int)numKm.Value, (AutoTipus)cmbAutoTipus.SelectedIndex);
                        ABKezelo.UjJarmu(Jarmu);
                    }
                }
                else
                {
                    Jarmu.Szin = txbSzin.Text;
                    Jarmu.FutottKm = (int)numKm.Value;
                    if (Jarmu is Auto)
                    {
                        (Jarmu as Auto).AutoTipus = (AutoTipus)cmbAutoTipus.SelectedIndex;
                    }
                    else
                    {
                        (Jarmu as Motor).HengerUrtartalom = (float)numCm3.Value;
                    }
                    ABKezelo.Modositas(Jarmu);
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
