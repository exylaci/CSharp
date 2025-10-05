using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EventPeldaJarmukolcsonzo
{
    public partial class UjJarmuForm : Form
    {
        public enum JarmuTipus
        {
            Auto,
            Motor
        }

        internal Jarmu Jarmu { get; private set; }

        public UjJarmuForm()
        {
            InitializeComponent();
            cmbJarmuTipus.DataSource = Enum.GetValues(typeof(JarmuTipus));
            cmbMotorTipus.DataSource = Enum.GetNames(typeof(MotorTipus));
        }

        internal UjJarmuForm(Jarmu modosit) : this()
        {
            Jarmu = modosit;
            txbRendszam.Text = modosit.Rendszam;
            txbRendszam.ReadOnly = true;
            numKm.Value = modosit.FutottKm;
            if (modosit is Auto)
            {
                cmbJarmuTipus.SelectedIndex = (int)JarmuTipus.Auto;
                cmbMotorTipus.SelectedIndex = (int)(modosit as Auto).Tipus;
                cmbJarmuTipus.Enabled = false;
                cmbMotorTipus.Enabled = false;
            }
            else
            {
                cmbJarmuTipus.SelectedIndex = (int)JarmuTipus.Motor;
                numHenger.Value = (modosit as Motor).Hengerurtartalom;
                cmbMotorTipus.Enabled = false;
                numHenger.Enabled = false;
            }
        }

        private void cmbJarmuTipus_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch ((JarmuTipus)cmbJarmuTipus.SelectedIndex)
            {
                case JarmuTipus.Auto:
                    cmbMotorTipus.Enabled = true;
                    numKm.Enabled = false;
                    break;
                case JarmuTipus.Motor:
                    cmbMotorTipus.Enabled = false;
                    numKm.Enabled = true;
                    break;
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                if (Jarmu == null)
                {
                    switch ((JarmuTipus)cmbJarmuTipus.SelectedIndex)
                    {
                        case JarmuTipus.Auto:
                            Jarmu = new Auto(
                                txbRendszam.Text,
                                (int)numKm.Value,
                                (MotorTipus)cmbMotorTipus.SelectedIndex);
                            break;
                        case JarmuTipus.Motor:
                            Jarmu = new Motor(
                                txbRendszam.Text,
                                (int)numKm.Value,
                                (uint)numHenger.Value);
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
                DialogResult = DialogResult.None;
            }
        }
    }
}
