using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MySqlOroklesPeldaJarmukolcsonzo
{
    public partial class Form1 : Form
    {
        List<Kolcsonzo> kolcsonzok;

        public Form1()
        {
            InitializeComponent();
            kolcsonzok = new List<Kolcsonzo>();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                kolcsonzok = ABKezeloMySQL.TeljesBeolvasas();
                LBFrissit();
                lsv.View = View.Details;
                lsv.FullRowSelect = true;
                lsv.MultiSelect = false;
                foreach (PropertyInfo item in typeof(Jarmu).GetProperties())
                {
                    lsv.Columns.Add(item.Name);
                }
                timer1.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LBFrissit()
        {
            int kijelolt = lsb.SelectedIndex;
            lsb.DataSource = null;
            lsb.DataSource = kolcsonzok;
            if (kijelolt < lsb.Items.Count && kijelolt >= 0)
            {
                lsb.SelectedIndex = kijelolt;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                kolcsonzok = ABKezeloMySQL.TeljesBeolvasas();
                LBFrissit();
            }
            catch (Exception ex)
            {
                statusStrip1.Text = DateTime.Now + " - " + ex.Message;
            }
        }

        private void lsb_SelectedIndexChanged(object sender, EventArgs e)
        {
            lsv.Items.Clear();
            if (lsb.SelectedIndex >= 0)
            {
                foreach (Jarmu item in (lsb.SelectedItem as Kolcsonzo).Jarmuvek)
                {
                    string[] adatok = new string[typeof(Jarmu).GetProperties().Count()];
                    for (int i = 0; i < adatok.Length; ++i)
                    {
                        adatok[i] = typeof(Jarmu).GetProperties()[i].GetValue(item).ToString();
                    }
                    lsv.Items.Add(new ListViewItem(adatok));
                }
            }
        }

        private void btnKolcsonzoTorles_Click(object sender, EventArgs e)
        {
            if (lsb.SelectedIndex >= 0 && MessageBox.Show("Valóban törli a kijelölt kölcsönzőt?", "Töröl", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    ABKezeloMySQL.KolcsonzoTorles((Kolcsonzo)lsb.SelectedItem);
                    kolcsonzok.Remove((Kolcsonzo)lsb.SelectedItem);
                    LBFrissit();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnJarmuTorles_Click(object sender, EventArgs e)
        {
            if (lsv.SelectedIndices.Count > 0)
            {
                try
                {
                    Jarmu kivalasztott = (lsb.SelectedItem as Kolcsonzo).Jarmuvek[lsv.SelectedIndices[0]];
                    ABKezeloMySQL.JarmuTorles(kivalasztott);
                    (lsb.SelectedItem as Kolcsonzo).Jarmuvek.Remove(kivalasztott);
                    LBFrissit();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Hiba!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnKolcsonzoFelvetel_Click(object sender, EventArgs e)
        {
            KolcsonzoForm form = new KolcsonzoForm();
            if (form.ShowDialog() == DialogResult.OK)
            {
                kolcsonzok.Add(form.Kolcsonzo);
                LBFrissit();
            }
        }

        private void btnJarmuFelvetel_Click(object sender, EventArgs e)
        {
            if (lsb.SelectedIndices.Count > 0)
            {
                JarmuForm form = new JarmuForm((Kolcsonzo)lsb.SelectedItem);
                if (form.ShowDialog() == DialogResult.OK)
                {
                    (lsb.SelectedItem as Kolcsonzo).Jarmuvek.Add(form.Jarmu);
                    LBFrissit();
                }
            }

        }

        private void btnKolcsonzoModosit_Click(object sender, EventArgs e)
        {
            if (lsb.SelectedIndex >= 0)
            {
                KolcsonzoForm form = new KolcsonzoForm((Kolcsonzo)lsb.SelectedItem);
                form.ShowDialog();
                LBFrissit();
            }
        }

        private void btnJarmuModosit_Click(object sender, EventArgs e)
        {
            if (lsv.SelectedIndices.Count > 0)
            {
                Jarmu modositando = (lsb.SelectedItem as Kolcsonzo).Jarmuvek[lsv.SelectedIndices[0]];
                JarmuForm form = new JarmuForm(modositando);
                form.ShowDialog();
                LBFrissit();
            }
        }







        //Video_2025_12_13 2:43-ig
    }
}
