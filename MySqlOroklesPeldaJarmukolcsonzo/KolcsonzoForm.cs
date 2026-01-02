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
    public partial class KolcsonzoForm : Form
    {
        internal Kolcsonzo Kolcsonzo { get; private set; }

        public KolcsonzoForm()
        {
            InitializeComponent();
        }
        internal KolcsonzoForm(Kolcsonzo kolcsonzo) : this()
        {
            Kolcsonzo = kolcsonzo;
            txbMegnevezes.Text = Kolcsonzo.Megnevezes;
            txbMegnevezes.ReadOnly = true;
            txbCim.Text = Kolcsonzo.Cim;
            txbTulajdonos.Text = Kolcsonzo.Tulajdonos;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                if (Kolcsonzo == null)
                {
                    Kolcsonzo = new Kolcsonzo(txbMegnevezes.Text, txbCim.Text, txbTulajdonos.Text);
                    ABKezeloMySQL.UjKolcsonzoFelvetel(Kolcsonzo);
                }
                else
                {
                    Kolcsonzo.Cim = txbCim.Text;
                    Kolcsonzo.Tulajdonos = txbTulajdonos.Text;
                    ABKezeloMySQL.KolcsonzoModositas(Kolcsonzo);
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
