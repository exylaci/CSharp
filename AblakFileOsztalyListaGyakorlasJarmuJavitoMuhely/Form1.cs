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

namespace AblakFileOsztalyListaGyakorlasJarmuJavitoMuhely
{
    public partial class Form1 : Form
    {

        List<Muhely> muhelyFeltolt;
        public Form1()
        {
            InitializeComponent();
            muhelyFeltolt = new List<Muhely>();
            LogKezeles.LogNyitas(Environment.UserDomainName, DateTime.Now.ToString());
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (MessageBox.Show("Szeretne kezdőállományt importálni?", "Importálás...", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                openFileDialog1.InitialDirectory = Environment.CurrentDirectory;
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    ImportFeltoltes();
                    ButtonsEnabled();
                }
            }
            else
            {
                openFileDialog1.FileName = string.Empty;
            }
            this.Activate();
        }
        private void ImportFeltoltes()
        {
            string muhelyString = string.Empty;
            List<string> jarmuvekString = new List<string>();
            Muhely muhelyTmp;
            foreach (string item in File.ReadAllLines(openFileDialog1.FileName, Encoding.UTF8))
            {
                if (muhelyString == string.Empty && item.StartsWith("M"))
                {
                    muhelyString = item;
                }
                else if (muhelyString != string.Empty && item.StartsWith("M"))
                {
                    muhelyTmp = new Muhely(muhelyString);
                    foreach (string jarmuItem in jarmuvekString)
                    {
                        if (jarmuItem.StartsWith("S"))
                        {
                            muhelyTmp.UjJarmu(new SzemelyAuto(jarmuItem));
                        }
                        else if (jarmuItem.StartsWith("T"))
                        {
                            muhelyTmp.UjJarmu(new Teherauto(jarmuItem));
                        }
                    }
                    muhelyFeltolt.Add(muhelyTmp);
                    muhelyString = item;
                    jarmuvekString.Clear();
                }
                else if (item.StartsWith("S") || item.StartsWith("T"))
                {
                    jarmuvekString.Add(item);
                }
            }
            if (muhelyString != string.Empty)
            {
                muhelyTmp = new Muhely(muhelyString);
                foreach (string jarmuItem in jarmuvekString)
                {
                    if (jarmuItem.StartsWith("S"))
                    {
                        muhelyTmp.UjJarmu(new SzemelyAuto(jarmuItem));
                    }
                    else if (jarmuItem.StartsWith("T"))
                    {
                        muhelyTmp.UjJarmu(new Teherauto(jarmuItem));
                    }
                }
                muhelyFeltolt.Add(muhelyTmp);
                foreach (Muhely item in muhelyFeltolt)
                {
                    lsbMuhelyek.Items.Add(item);
                }
                lsbMuhelyek.SelectedIndex = 0;
                LSBMuhelyRefresh();
                LSBJarmuvekRefresh();
            }
            ButtonsEnabled();
        }
        private void ExportLetoltes(string fileName)
        {
            StreamWriter export = new StreamWriter(fileName, false, Encoding.UTF8);
            foreach (Muhely item in lsbMuhelyek.Items)
            {
                string muhelySor = item.ToCSV();
                export.WriteLine(muhelySor);
                string jarmuSor = string.Empty;
                foreach (Jarmu jarmuItem in item.Jarmuvek)
                {
                    if (jarmuItem is SzemelyAuto)
                    {
                        jarmuSor = (jarmuItem as SzemelyAuto).ToCSV();
                    }
                    else if (jarmuItem is Teherauto)
                    {
                        jarmuSor = (jarmuItem as Teherauto).ToCSV();
                    }
                    export.WriteLine(jarmuSor);
                }
            }
            export.Close();
        }

        private void ButtonsEnabled()
        {
            if (lsbMuhelyek.Items.Count == 0)
            {
                foreach (Control item in groupBox1.Controls)
                {
                    if (item.Name != "btnMuhelyUj")
                    {
                        item.Enabled = false;
                    }
                }
                foreach (Control item in groupBox2.Controls)
                {
                    item.Enabled = false;
                }
            }
            else if (lsbMuhelyek.Items.Count != 0)
            {
                foreach (Control item in groupBox1.Controls)
                {
                    item.Enabled = true;
                }
                foreach (Control item in groupBox2.Controls)
                {
                    if (item.Name == "btnJarmuUj")
                    {
                        item.Enabled = true;
                    }
                    else
                    {
                        item.Enabled = false;
                    }
                }
                if (lsbSzemelyAutok.SelectedIndex != -1 || lsbTeherAutok.SelectedIndex != -1)
                {
                    foreach (Control item in groupBox2.Controls)
                    {
                        item.Enabled = true;
                    }
                }
            }
        }
        private void LSBJarmuvekRefresh()
        {
            lsbSzemelyAutok.DataSource = null;
            lsbTeherAutok.DataSource = null;
            List<SzemelyAuto> szemelyAutoTmp = new List<SzemelyAuto>();
            List<Teherauto> teherAutoTmp = new List<Teherauto>();
            if (lsbMuhelyek.SelectedIndex != -1)
            {
                foreach (Jarmu item in (lsbMuhelyek.SelectedItem as Muhely).Jarmuvek)
                {
                    if (item is SzemelyAuto)
                    {
                        szemelyAutoTmp.Add(item as SzemelyAuto);
                    }
                    else if (item is Teherauto)
                    {
                        teherAutoTmp.Add(item as Teherauto);
                    }
                }
                lsbSzemelyAutok.DataSource = szemelyAutoTmp;
                lsbTeherAutok.DataSource = teherAutoTmp;
                lsbSzemelyAutok.SelectedIndex = -1;
                lsbTeherAutok.SelectedIndex = -1;
            }
        }

        private void LSBMuhelyRefresh()
        {
            if (lsbMuhelyek.SelectedIndex != -1)
            {
                int index = lsbMuhelyek.SelectedIndex;
                Muhely tmp = (Muhely)lsbMuhelyek.SelectedItem;
                lsbMuhelyek.Items.RemoveAt(index);
                lsbMuhelyek.Items.Insert(index, tmp);
                lsbMuhelyek.SelectedIndex = index;
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Biztosan ki akar lépni?", "Kilépés", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.Cancel)
            {
                e.Cancel = true;
            }
            else if (lsbMuhelyek.Items.Count != 0)
            {
                if (openFileDialog1.FileName == String.Empty)
                {
                    if (MessageBox.Show("Szeretne exportálni adatokat?", "Exportálás...", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    {
                        if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                        {
                            Mentes();
                        }
                    }
                }
                else
                {
                    Mentes();
                }
                LogKezeles.LogZaras(Environment.UserDomainName, DateTime.Now.ToString());
            }
        }
        private void Mentes()
        {
            try
            {
                ExportLetoltes(saveFileDialog1.FileName);
                MessageBox.Show("Mentés sikeresen megtörtént! ", "Mentés...", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(" A mentés sikertelen! " + ex.Message, "Hiba...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void btnMuhelyUj_Click(object sender, EventArgs e)
        {
            string muhelyszam = string.Empty;
            if (lsbMuhelyek.Items.Count != 0)
            {
                lsbMuhelyek.SelectedIndex = lsbMuhelyek.Items.Count - 1;
                muhelyszam = (lsbMuhelyek.SelectedItem as Muhely).MuhelySzamMeghatarozas((lsbMuhelyek.SelectedItem as Muhely).MuhelySzam);
            }
            else
            {
                muhelyszam = Muhely.UjMuhelySzamMeghatarozas();
            }
            frmMuhelyKezelese dialogus = new frmMuhelyKezelese(muhelyszam);
            if (dialogus.ShowDialog() == DialogResult.OK)
            {
                lsbMuhelyek.Items.Add(dialogus.KezelendoMuhely);
                lsbMuhelyek.SelectedIndex = lsbMuhelyek.Items.Count - 1;
                LogKezeles.LogIrasa(Funkcio.Letrehozas, dialogus.KezelendoMuhely);
            }
            ButtonsEnabled();
        }

        private void btnMuhelyModosit_Click(object sender, EventArgs e)
        {
            if (lsbMuhelyek.SelectedIndex != -1)
            {
                frmMuhelyKezelese dialogus = new frmMuhelyKezelese((Muhely)lsbMuhelyek.SelectedItem);
                if (dialogus.ShowDialog() == DialogResult.OK)
                {
                    int index = lsbMuhelyek.SelectedIndex;
                    lsbMuhelyek.Items.RemoveAt(index);
                    lsbMuhelyek.Items.Insert(index, dialogus.KezelendoMuhely);
                    lsbMuhelyek.SelectedIndex = index;
                    LogKezeles.LogIrasa(Funkcio.Modositas, (Muhely)lsbMuhelyek.SelectedItem);
                }
            }
        }

        private void btnMuhelyMegjelenit_Click(object sender, EventArgs e)
        {
            if (lsbMuhelyek.SelectedIndex != -1)
            {
                frmMuhelyKezelese dialogus = new frmMuhelyKezelese((Muhely)lsbMuhelyek.SelectedItem);
                dialogus.ShowDialog();
                LogKezeles.LogIrasa(Funkcio.Megjelenites, (Muhely)lsbMuhelyek.SelectedItem);
            }
        }

        private void btnMuhelyTorol_Click(object sender, EventArgs e)
        {
            if (lsbMuhelyek.SelectedIndex != -1 && MessageBox.Show("Biztosan törölni szeretné a műhelyt?", "Műhely törlése...", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                LogKezeles.LogIrasa(Funkcio.Torles, (Muhely)lsbMuhelyek.SelectedItem);
                lsbMuhelyek.Items.RemoveAt(lsbMuhelyek.SelectedIndex);
                if (lsbMuhelyek.SelectedIndex != 0)
                {
                    lsbMuhelyek.SelectedIndex = 0;
                }
                LSBJarmuvekRefresh();
                ButtonsEnabled();
            }
        }

        private void btnJarmuUj_Click(object sender, EventArgs e)
        {
            if (lsbMuhelyek.SelectedIndex != -1 && (lsbMuhelyek.SelectedItem as Muhely).JarmuMaxSzam - (lsbMuhelyek.SelectedItem as Muhely).TaroltJarmuvekSzama > 0)
            {
                frmJarmuKezeles dialogus = new frmJarmuKezeles((Muhely)lsbMuhelyek.SelectedItem);
                if (dialogus.ShowDialog() == DialogResult.OK)
                {
                    LSBMuhelyRefresh();
                    LSBJarmuvekRefresh();
                    LogKezeles.LogIrasa(Funkcio.Letrehozas, (Muhely)lsbMuhelyek.SelectedItem, (lsbMuhelyek.SelectedItem as Muhely).Jarmuvek.Last());
                }
            }
            else if (lsbMuhelyek.SelectedIndex != -1)
            {
                MessageBox.Show("A műhely elérte az egyszerre felvehető járművek maximális számát!", "Figyelem!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                MessageBox.Show("Nincs kiválasztva műhely, válasszon ki egyet!", "Figyelem!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnJarmuModosit_Click(object sender, EventArgs e)
        {
            if (lsbMuhelyek.SelectedIndex != -1)
            {
                foreach (Control item in Controls)
                {
                    if (item is ListBox && item != lsbMuhelyek && (item as ListBox).SelectedIndex != -1)
                    {
                        frmJarmuKezeles dialogus = new frmJarmuKezeles((Muhely)lsbMuhelyek.SelectedItem, (item as ListBox).SelectedItem as Jarmu, lsbMuhelyek.SelectedIndex);
                        if (dialogus.ShowDialog() == DialogResult.OK)
                        {
                            LSBMuhelyRefresh();
                            LSBJarmuvekRefresh();
                            LogKezeles.LogIrasa(Funkcio.Modositas, (Muhely)lsbMuhelyek.SelectedItem, (item as ListBox).SelectedItem as Jarmu);
                        }
                    }
                }

            }
        }

        private void lsbSzemelyAutok_MouseClick(object sender, MouseEventArgs e)
        {
            if (sender is ListBox)
            {
                foreach (Control item in Controls)
                {
                    if (item is ListBox && item != lsbMuhelyek && item != sender as ListBox)
                    {
                        (item as ListBox).SelectedIndex = -1;
                    }
                }
            }
        }
    }
}