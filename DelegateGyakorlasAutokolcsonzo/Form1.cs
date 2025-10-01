using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DelegateGyakorlasAutokolcsonzo
{
    public partial class Form1 : Form
    {
        internal List<Jarmu> jarmuvek = new List<Jarmu>();
        internal List<string> ugyfelek = new List<string>();
        delegate void KolcsonzesiAllpotValtozas(string rendszam, bool kolcsonozheto);
        KolcsonzesiAllpotValtozas KolcsonozhetoAllapotValtozott;

        public Form1()
        {
            //kezdő adatfeltöltés
            jarmuvek.Add(new Motor("XBCD123", 50));
            jarmuvek.Add(new Motor("YABC234", 3000, false, 500));
            jarmuvek.Add(new Auto("ABCD123", Auto.MotorTipusok.Benzin));
            jarmuvek.Add(new Auto("BCDE567", 4000, false, Auto.MotorTipusok.Diesel));
            //jarmuvek.Add(new Jarmu("AAAA111"));       //Jarmu osztály abstract
            //jarmuvek.Add(new Motor("AbAA111",50));    //kisbetű sérti a regex-et

            InitializeComponent();
            AutoListaFrissitese();
        }


        private void txbRendszam_TextChanged(object sender, EventArgs e)
        {
            if (Regex.IsMatch(txbRendszam.Text, Jarmu.RendszamPattern))
            {
                Jarmu jarmu = jarmuvek.FirstOrDefault(j => j.Rendszam == txbRendszam.Text);
                if (jarmu != null)
                {
                    chbKolcsonozheto.Checked = jarmu.Kolcsonozheto;
                    chbKolcsonozheto.Enabled = true;
                    btnAllapotMegvaltoztatasa.Enabled = true;
                }
                else
                {
                    chbKolcsonozheto.Enabled = false;
                    btnAllapotMegvaltoztatasa.Enabled = false;
                }
            }
            else
            {
                chbKolcsonozheto.Enabled = false;
                btnAllapotMegvaltoztatasa.Enabled = false;
            }
        }

        private void btnAllapotMegvaltoztatasa_Click(object sender, EventArgs e)
        {
            KolcsonozhetoAllapotValtozott = KolcsonozhetosegModositasa;

            DialogResult result = MessageBox.Show("Biztosan megváltoztassuk a(z) " + txbRendszam.Text + " rendszámú jármű állapotát " + (chbKolcsonozheto.Checked ? "" : "nem ") + "kölcsönezhetőre?", "Állapotváltoztatás", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                KolcsonozhetoAllapotValtozott(txbRendszam.Text, chbKolcsonozheto.Checked);
            }
        }

        public void AutoListaFrissitese()
        {
            lsbAutok.Items.Clear();
            foreach (var jarmu in jarmuvek)
            {
                lsbAutok.Items.Add(jarmu);
            }

        }
        public void KolcsonozhetosegModositasa(string rendszam, bool kolcsonozheto)
        {
            int index = jarmuvek.FindIndex(j => j.Rendszam == rendszam);
            if (index >= 0)
            {
                jarmuvek.ElementAt(index).Kolcsonozheto = kolcsonozheto;
                AutoListaFrissitese();
            }

        }

        private void button6_Click(object sender, EventArgs e)
        {
            UjUgyfelForm form = new UjUgyfelForm();
            if (form.ShowDialog() == DialogResult.OK)
            {
                if (form.Nev != string.Empty)
                {
                    ugyfelek.Add(form.Nev);
                }
                else
                {
                    MessageBox.Show("A név nem lehet üres!", "Hibás névmegadás!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            MessageBox.Show("Ügyféllista hossza: " + ugyfelek.Count(), "Ügyfél hozzáadása", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnUjAuto_Click(object sender, EventArgs e)
        {
            UjJarmuForm form = new UjJarmuForm();
            if (form.ShowDialog() == DialogResult.OK)
            {
                jarmuvek.Add(form.IsAuto ? form.Auto : form.Motor);
                AutoListaFrissitese();
            }
        }

        private void btnJarmuTorlese_Click(object sender, EventArgs e)
        {
            JarmuTorlesForm form = new JarmuTorlesForm();
            if (form.ShowDialog() == DialogResult.OK)
                try
                {
                    if (jarmuvek.Contains(new Auto(form.Rendszam, Auto.MotorTipusok.Benzin)))
                    {
                        DialogResult valasz = MessageBox.Show("Biztos, hogy töröljem a " + form.Rendszam + " forgalmi rendszámú járművet?", "Jarmű törlése", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (valasz == DialogResult.Yes)
                        {
                            jarmuvek.Remove(new Motor(form.Rendszam, 1));
                            AutoListaFrissitese();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Nincs ilyen rendszámű jármű!", "Hiba!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex) { }
        }

        private void btnUgyfelTorles_Click(object sender, EventArgs e)
        {
            UgyfelTorlesForm form = new UgyfelTorlesForm();
            if (form.ShowDialog() == DialogResult.OK)
            {
                if (ugyfelek.Contains(form.Nev))
                {
                    DialogResult valasz = MessageBox.Show("Biztos, hogy töröljem " + form.Nev + " ügyfelet?", "Ügyfél törlése", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (valasz == DialogResult.Yes)
                    {
                        ugyfelek.Remove(form.Nev);
                    }
                }
                else
                {
                    MessageBox.Show("Nincs " + form.Nev + " nevü ügyfél!", "Hiba!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            MessageBox.Show("Ügyféllista hossza: " + ugyfelek.Count(), "Ügyfél törlés", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
