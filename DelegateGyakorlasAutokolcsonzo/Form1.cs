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
        internal List<string> ugyfel = new List<string>();
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
    }
}
