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
            if (MessageBox.Show("Szeretne kezdőállományt importálni?", "Importálás...", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
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
    }
}
