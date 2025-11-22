using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SQLitePeldaFelhasznalokForms
{
    public partial class FelhasznaloForm : Form
    {
        internal Felhasznalo Felhasznalo { get; private set; }

        public FelhasznaloForm()
        {
            InitializeComponent();
        }
        internal FelhasznaloForm(Felhasznalo felhasznalo) : this()
        {
            Felhasznalo = felhasznalo;
            txbID.Text = felhasznalo.Id.ToString();
            txbNev.Text = felhasznalo.FelhasznaloNev.ToString();
            txbJelszo.Text = felhasznalo.Jelszo.ToString();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                if (Felhasznalo == null)
                {
                    Felhasznalo = new Felhasznalo(txbNev.Text, txbJelszo.Text, DateTime.Now, chbAktiv.Checked);
                    ABKezelo.Hozzaadas(Felhasznalo);
                }
                else
                {
                    Felhasznalo.FelhasznaloNev = txbNev.Text;
                    Felhasznalo.Jelszo = txbJelszo.Text;
                    Felhasznalo.Aktiv = chbAktiv.Checked;
                    ABKezelo.Modositas(Felhasznalo);
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
