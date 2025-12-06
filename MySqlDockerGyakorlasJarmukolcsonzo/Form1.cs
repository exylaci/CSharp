using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MySqlDockerGyakorlasJarmukolcsonzo
{
    public partial class FormMain : Form
    {
        List<Kolcsonzo> kolcsonzok = new List<Kolcsonzo>();

        public FormMain()
        {
            InitializeComponent();
            KolcsonzoAdatokBeolvasasa();
            JarmuvekListboxFrissitese();
        }


        private void btnUjJarmu_Click(object sender, EventArgs e)
        {
            if (lsbKolcsonzok.SelectedIndex < 0)
            {
                MessageBox.Show("Előbb válasszon ki egy kölcsönzőt!");
                return;
            }
            JarmuForm form = new JarmuForm(null, kolcsonzok.ElementAt(lsbKolcsonzok.SelectedIndex));
            if (form.ShowDialog() == DialogResult.OK)
            {
                kolcsonzok.ElementAt(lsbKolcsonzok.SelectedIndex).Jarmuvek.Add(form.Jarmu);
                lsbJarmuvek.Items.Add(form.Jarmu);
                lsbJarmuvek.SelectedIndex = lsbJarmuvek.Items.Count - 1;
                JarmuvekListboxFrissitese();
            }
        }

        private void btnJarmuModositas_Click(object sender, EventArgs e)
        {
            if (lsbKolcsonzok.SelectedIndex < 0)
            {
                MessageBox.Show("Előbb válasszon ki egy kölcsönzőt a módosításhoz!");
                return;
            }
            if (lsbJarmuvek.SelectedIndex < 0)
            {
                MessageBox.Show("Előbb válasszon ki egy járművet a módosításhoz!");
                return;
            }
            Kolcsonzo kolcsonzo = kolcsonzok.ElementAt(lsbKolcsonzok.SelectedIndex);
            JarmuForm form = new JarmuForm(kolcsonzo.Jarmuvek.ElementAt(lsbJarmuvek.SelectedIndex), kolcsonzo);
            if (form.ShowDialog() == DialogResult.OK)
            {
                kolcsonzo.Jarmuvek[lsbJarmuvek.SelectedIndex] = form.Jarmu;
                ListBoxFrissites();
            }
        }

        private void btnJarmuTorles_Click(object sender, EventArgs e)
        {
            if (lsbKolcsonzok.SelectedIndex < 0)
            {
                MessageBox.Show("Előbb ki kell választani egy kölcsönzőt a törléshez!");
                return;
            }
            if (lsbJarmuvek.SelectedIndex < 0)
            {
                MessageBox.Show("Előbb ki kell választani egy járművet a törléshez!");
                return;
            }
            try
            {
                ABKezelo.JarmuTorlese(kolcsonzok.ElementAt(lsbKolcsonzok.SelectedIndex).Jarmuvek[lsbJarmuvek.SelectedIndex]);
                kolcsonzok.ElementAt(lsbKolcsonzok.SelectedIndex).Jarmuvek.RemoveAt(lsbJarmuvek.SelectedIndex);
                --lsbJarmuvek.SelectedIndex;
                JarmuvekListboxFrissitese();
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

        private void btnUjKolcsonzo_Click(object sender, EventArgs e)
        {
            KolcsonzoForm form = new KolcsonzoForm(null);
            if (form.ShowDialog() == DialogResult.OK)
            {
                kolcsonzok.Add(form.Kolcsonzo);
                lsbKolcsonzok.Items.Add(form.Kolcsonzo);
                lsbKolcsonzok.SelectedIndex = lsbKolcsonzok.Items.Count - 1;
                JarmuvekListboxFrissitese();
            }
        }

        private void btnKolcsonzoModositas_Click(object sender, EventArgs e)
        {
            int index = lsbKolcsonzok.SelectedIndex;
            if (index > -1)
            {
                KolcsonzoForm form = new KolcsonzoForm(kolcsonzok[index]);
                if (form.ShowDialog() == DialogResult.OK)
                {
                    kolcsonzok[index] = form.Kolcsonzo;
                    ListBoxFrissites();
                }
            }
            else
            {
                MessageBox.Show("Előbb ki kell választani egy kölcsönzőt a módosításhoz!");
            }
        }

        private void btnKolcsonzoTorles_Click(object sender, EventArgs e)
        {
            int index = lsbKolcsonzok.SelectedIndex;
            if (index > -1)
            {
                try
                {
                    ABKezelo.KolcsonzoTorléseJarmuveivel(kolcsonzok[index]);
                    kolcsonzok.RemoveAt(index);
                    --lsbKolcsonzok.SelectedIndex;
                    KolcsonzokListboxFrissitese();
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
            else
            {
                MessageBox.Show("Nincs törlésre kiválasztott kölcsönző!");
            }
        }

        private void lsbKolcsonzok_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = lsbKolcsonzok.SelectedIndex;
            if (index >= 0)
            {
                JarmuvekListboxFrissitese();
            }
        }


        private void KolcsonzoAdatokBeolvasasa()
        {
            try
            {
                kolcsonzok = ABKezelo.KolcsonzokLekerdezese();
            }
            catch (ABKivetel ex)
            {
                MessageBox.Show(ex.Message, "Hiba!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Figyelem!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Bejegyzes(ex);
            }
        }

        private void KolcsonzokListboxFrissitese()
        {
            int kolcsonzoIndex = lsbKolcsonzok.SelectedIndex;
            lsbKolcsonzok.Items.Clear();
            foreach (Kolcsonzo kolcsonzo in kolcsonzok)
            {
                lsbKolcsonzok.Items.Add(kolcsonzo);
            }
            lsbKolcsonzok.SelectedIndex = kolcsonzoIndex;
            JarmuvekListboxFrissitese();
        }

        private void JarmuvekListboxFrissitese()
        {
            int kolcsonzoIndex = lsbKolcsonzok.SelectedIndex;
            int jarmuIndex = lsbJarmuvek.SelectedIndex;
            lsbJarmuvek.Items.Clear();

            if (kolcsonzoIndex >= 0 && kolcsonzok[kolcsonzoIndex].Jarmuvek.Count > 0)
            {
                foreach (Jarmu jarmu in kolcsonzok[kolcsonzoIndex].Jarmuvek)
                {
                    lsbJarmuvek.Items.Add(jarmu);
                }
                if (jarmuIndex < lsbJarmuvek.Items.Count)
                {
                    lsbJarmuvek.SelectedIndex = jarmuIndex;
                }
                else
                {
                    lsbJarmuvek.SelectedIndex = -1;
                }
            }
            else
            {
                lsbJarmuvek.SelectedIndex = -1;
            }
        }

        private void ListBoxFrissites()
        {
            if (lsbKolcsonzok.SelectedIndex >= 0)
            {
                int index = lsbKolcsonzok.SelectedIndex;
                Kolcsonzo kolcsonzo = kolcsonzok.ElementAt(index);
                lsbKolcsonzok.Items.RemoveAt(index);
                lsbKolcsonzok.Items.Insert(index, kolcsonzo);
                lsbKolcsonzok.SelectedIndex = index;

                if (lsbJarmuvek.SelectedIndex >= 0)
                {
                    int jindex = lsbJarmuvek.SelectedIndex;
                    Jarmu jarmu = kolcsonzo.Jarmuvek.ElementAt(jindex);
                    lsbJarmuvek.Items.RemoveAt(jindex);
                    lsbJarmuvek.Items.Insert(jindex, jarmu);
                    lsbJarmuvek.SelectedIndex = jindex;
                }
                else
                {
                    lsbJarmuvek.SelectedIndex = -1;
                    lsbJarmuvek.Items.Clear();
                }
            }
            else
            {
                lsbJarmuvek.SelectedIndex = -1;
                lsbJarmuvek.Items.Clear();
            }
        }
    }
}
