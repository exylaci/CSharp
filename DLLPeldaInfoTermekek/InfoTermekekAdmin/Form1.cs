using InfoTermekekDLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InfoTermekekAdmin
{
    public partial class Form1 : Form
    {
        LogoltLista termekek;
        public Form1()
        {
            InitializeComponent();
            termekek = new LogoltLista();
        }

        void LBFrissit()
        {
            lsbTermekek.DataSource = null;
            lsbTermekek.DataSource = termekek;
        }

        private void btnUj_Click(object sender, EventArgs e)
        {
            UjTermekForm form = new UjTermekForm();
            if (form.ShowDialog() == DialogResult.OK)
            {
                termekek.Add(form.Termek);
                LBFrissit();
            }
        }

        private void btnModositas_Click(object sender, EventArgs e)
        {
            if (lsbTermekek.SelectedIndex != -1)
            {
                UjTermekForm form = new UjTermekForm((InfoTermek)lsbTermekek.SelectedItem);
                form.ShowDialog();
                LBFrissit();
            }
        }

        private void btnTorles_Click(object sender, EventArgs e)
        {
            if (lsbTermekek.SelectedIndex != -1 &&
                MessageBox.Show("Biztosan törli a kijelölt terméket?", "Törlés", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                termekek.RemoveAt(lsbTermekek.SelectedIndex);
                LBFrissit();
            }
        }

        private void btnMentes_Click(object sender, EventArgs e)
        {
            string fajl = "";
            foreach (InfoTermek item in termekek)
            {
                if (item is Alaplap)
                {
                    fajl += (int)TermekTipusok.Alaplap + ";";
                }
                else if (item is Memoria)
                {
                    fajl += (int)TermekTipusok.Memoria + ";";
                }
                else if (item is Processzor)
                {
                    fajl += (int)TermekTipusok.Processzor + ";";
                }
                fajl += item.ToCSV() + Environment.NewLine;
            }
            try
            {
                File.WriteAllText("termekek.csv", fajl);
                MessageBox.Show("Sikeres mentés", "Mentés", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (File.Exists("termekek.csv"))
            {
                try
                {
                    foreach (string sor in File.ReadAllLines("termekek.csv"))
                    {
                        string[] mezok = sor.Split(';');
                        switch ((TermekTipusok)int.Parse(mezok[0]))
                        {
                            case TermekTipusok.Alaplap:
                                termekek.Add(new Alaplap(
                                    mezok[1],
                                    mezok[2],
                                    mezok[3],
                                    int.Parse(mezok[4]),
                                    (ProcesszorTokozas)int.Parse(mezok[5]),
                                    (MemoriaTipus)int.Parse(mezok[6])));
                                break;
                            case TermekTipusok.Memoria:
                                termekek.Add(new Memoria(
                                    mezok[1],
                                    mezok[2],
                                    mezok[3],
                                    int.Parse(mezok[4]),
                                    (MemoriaTipus)int.Parse(mezok[5])));
                                break;
                            case TermekTipusok.Processzor:
                                termekek.Add(new Processzor(
                                    mezok[1],
                                    mezok[2],
                                    mezok[3],
                                    int.Parse(mezok[4]),
                                    (ProcesszorTokozas)int.Parse(mezok[5])));
                                break;
                        }
                    }
                    LBFrissit();
                }
                catch (Exception)
                {
                    MessageBox.Show("Hiba a fájl beolvasásakor", "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
