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
    public partial class KolcsonzoForm : Form
    {
        internal Kolcsonzo Kolcsonzo { get; private set; }

        public KolcsonzoForm()
        {
            InitializeComponent();
        }
        internal KolcsonzoForm(Kolcsonzo kolcsonzo) : this()
        {
            txbNev.Text = kolcsonzo.Nev;
            txbCim.Text = kolcsonzo.Cim;
            numMaxJarmu.Value = kolcsonzo.MaxJarmu;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Mentsük a változásokat?", "Kolcsonző", MessageBoxButtons.OK, MessageBoxIcon.Question);
            try
            {
                if (result == DialogResult.OK)
                {
                    if (Kolcsonzo == null)
                    {
                        Kolcsonzo = new Kolcsonzo(txbNev.Text, txbCim.Text, (byte)numMaxJarmu.Value);
                        ABKezeles.KolcsonzoHozzaadas(Kolcsonzo);
                    }
                    else
                    {
                        Kolcsonzo = new Kolcsonzo(txbNev.Text, txbCim.Text, (byte)numMaxJarmu.Value);
                        ABKezeles.KolcsonzoModositas(Kolcsonzo);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Hiba!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                DialogResult = DialogResult.None;
                Log.Bejegyzes(ex);
            }
        }
    }
}
