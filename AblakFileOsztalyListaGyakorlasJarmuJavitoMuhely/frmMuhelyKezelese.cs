using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AblakFileOsztalyListaGyakorlasJarmuJavitoMuhely
{
    public partial class frmMuhelyKezelese : Form
    {

        Muhely kezelendoMuhely;

        internal Muhely KezelendoMuhely { get => kezelendoMuhely; }

        List<Jarmu> meglevoJarmuvek;


        public frmMuhelyKezelese(string muhelySorszam)
        {
            InitializeComponent();
            meglevoJarmuvek = new List<Jarmu>();
            txtMuhelySzam.Text = muhelySorszam;
            ActiveControl = numIranyitoSzam;
        }

        internal frmMuhelyKezelese(Muhely modositando, bool megtekintes = false)
        {
            InitializeComponent();
            meglevoJarmuvek = new List<Jarmu>();
            txtMuhelySzam.Text = modositando.MuhelySzam;
            numIranyitoSzam.Value = modositando.MuhelyCim.IranyitoSzam;
            tbHelyseg.Text = modositando.MuhelyCim.Helyseg;
            tbUtcaHazszam.Text = modositando.MuhelyCim.Cim;
            numJarmuvekMaxSzama.Value = modositando.JarmuMaxSzam;
            cbVasarnap.Checked = modositando.Vasarnap;
            foreach (Jarmu item in modositando.Jarmuvek)
            {
                meglevoJarmuvek.Add(item);
            }
            ActiveControl = numIranyitoSzam;
            if (megtekintes)
            {
                foreach (Control item in groupBox1.Controls)
                {
                    if (!(item is Label))
                    {
                        item.Enabled = false;
                    }
                }
                btnOk.Enabled = false;
                ActiveControl = btnCancel;
            }
        }


        private void btnOk_Click(object sender, EventArgs e)
        {
            if (tbHelyseg.Text.Trim() != String.Empty && tbUtcaHazszam.Text.Trim() != string.Empty)
            {
                MuhelyCim muhelyCim = new MuhelyCim((short)numIranyitoSzam.Value, tbHelyseg.Text, tbUtcaHazszam.Text);
                kezelendoMuhely = new Muhely(txtMuhelySzam.Text, muhelyCim, (byte)numJarmuvekMaxSzama.Value, cbVasarnap.Checked);
            }
            else
            {
                MessageBox.Show("Minden mezo kitoltese kotelezo!", "Figyelem!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.None;
            }
        }
    }
}
