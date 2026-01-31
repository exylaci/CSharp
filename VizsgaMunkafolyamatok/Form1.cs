using System;
using System.Collections.Generic;
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
            cmbMunkafolyamatok_SelectedIndexChanged(sender, e);
        }

        private void lsbSzemelyek_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            MessageBox.Show(((Szemely)lsbSzemelyek.SelectedValue).Information(), "SZemély asatai:", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnUjMunkafolyamat_Click(object sender, EventArgs e)
        {
            MunkafolyamatForm form = new MunkafolyamatForm();
            if (form.ShowDialog() == DialogResult.OK)
            {
                munkafolyamatok.Add(form.munkafolyamat);
                cmbMunkafolyamatok.DataSource = null;
                cmbMunkafolyamatok.DataSource = munkafolyamatok;
            }
        }

        private void cmbMunkafolyamatok_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnSzamlazas.Enabled = cmbMunkafolyamatok.SelectedIndex >= 0 && lsbSzemelyek.SelectedIndex >= 0;
        }

        private void btnSzamlazas_Click(object sender, EventArgs e)
        {
            Munkafolyamat munkafolyamat = (Munkafolyamat)cmbMunkafolyamatok.SelectedItem;
            MessageBox.Show($"Megrendelő:\t{((Szemely)lsbSzemelyek.SelectedItem).Nev}{Environment.NewLine}Munka:    \t{munkafolyamat.Megnevezes}{Environment.NewLine}Bruttó ár:   \t{munkafolyamat.BruttoAr():0.##} forint", "Számla adatai", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
