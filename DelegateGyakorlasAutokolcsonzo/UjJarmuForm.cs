using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static DelegateGyakorlasAutokolcsonzo.Auto;

namespace DelegateGyakorlasAutokolcsonzo
{
    public partial class UjJarmuForm : Form
    {
        internal Auto Auto { get; private set; }
        internal Motor Motor { get; private set; }
        internal bool IsAuto { get; private set; }

        public UjJarmuForm()
        {
            InitializeComponent();
            cmbMotorTipusa.DataSource = Enum.GetValues(typeof(Auto.MotorTipusok));
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            IsAuto = rdbAuto.Checked;
            try
            {
                if (IsAuto)
                {
                    Auto = new Auto(txbRendszam.Text, (int)numKmOra.Value, chbKolcsonozheto.Checked, (Auto.MotorTipusok)cmbMotorTipusa.SelectedItem);
                }
                else
                {
                    Motor = new Motor(txbRendszam.Text, (int)numKmOra.Value, chbKolcsonozheto.Checked, (int)numKobcenti.Value);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Hibás jármű paraméterek!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                DialogResult = DialogResult.Cancel;
            }
        }

        private void rdbAuto_CheckedChanged(object sender, EventArgs e)
        {
            grbAuto.Enabled = rdbAuto.Checked;
            grbMotor.Enabled = rdbMotor.Checked;
        }

    }
}
