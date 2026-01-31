using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VizsgaMunkafolyamatok
{
    public partial class Form1 : Form
    {
        private List<Szemely> szemelyek;
        private List<Munkafolyamat> munkafolyamatok;

        public Form1()
        {
            InitializeComponent();
            szemelyek = new List<Szemely>();
            munkafolyamatok = new List<Munkafolyamat>();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnGeneralas_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();
            for (int i = 0; i < 5; ++i)
            {
                szemelyek.Add(new Szemely(
                     new[] { "Kovács", "Sípos", "Tóth", "Kis", "Nagy", "Erős", "Lovas" }[rnd.Next(7)]
                     + " "
                     + new[] { "Attila", "Sándor", "Tamás", "Károly", "Norbert", "Endre", "László" }[rnd.Next(7)],
                     new[] { "Budapest", "Eger", "Tatabánya", "Keszthely", "Debrecen", "Érd", "Szeged" }[rnd.Next(7)],
                     rnd.Next(10000000).ToString()));
            }
            LBFrissit();
        }

        private void LBFrissit()
        {
            int selected = lsbSzemelyek.SelectedIndex;
            lsbSzemelyek.DataSource = null;
            lsbSzemelyek.DataSource = szemelyek;
            if (selected >= 0 && selected < szemelyek.Count)
            {
                lsbSzemelyek.SelectedIndex = selected;
            }
        }

        private void btnTorles_Click(object sender, EventArgs e)
        {
            szemelyek.RemoveAt(lsbSzemelyek.SelectedIndex);
            LBFrissit();
        }

        private void lsbSzemelyek_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnTorles.Enabled = lsbSzemelyek.SelectedIndex >= 0;
            btnSzamlazas.Enabled = cmbMunkafolyamatok.SelectedIndex >= 0;
        }

        private void lsbSzemelyek_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            MessageBox.Show(((Szemely)lsbSzemelyek.SelectedValue).Information(),"SZemély asatai:",MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
