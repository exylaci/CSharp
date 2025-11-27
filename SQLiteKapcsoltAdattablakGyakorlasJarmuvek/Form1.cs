using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SQLiteKapcsoltAdattablakGyakorlasJarmuvek
{
    public partial class Form1 : Form
    {
        List<Jarmu> jarmuvek = new List<Jarmu>();
        public Form1()
        {
            InitializeComponent();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                ABKezelo.Beolvasas().ForEach(j => jarmuvek.Add(j));
                ListBoxFrissites();
            }
            catch (ABKivetel ex)
            {
                MessageBox.Show(ex.Message, "Hiba!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                DialogResult = DialogResult.None;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Hiba!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                DialogResult = DialogResult.None;
                Log.Bejegyzes(ex);
            }
        }

        private void ListBoxFrissites()
        {
            lsbJarmuvek.DataSource = null;
            lsbJarmuvek.DataSource = jarmuvek;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                ABKezelo.KapcsolatBontasa();
            }
            catch (ABKivetel ex)
            {
                MessageBox.Show(ex.Message, "Hiba!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Hiba!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Bejegyzes(ex);
            }
        }

        private void btnUj_Click(object sender, EventArgs e)
        {
            JarmuForm form = new JarmuForm();
            if (form.ShowDialog() == DialogResult.OK)
            {
                jarmuvek.Add(form.Jarmu);
                ListBoxFrissites();
            }
        }

        private void btnModosit_Click(object sender, EventArgs e)
        {
            int index = lsbJarmuvek.SelectedIndex;
            if (index > -1)
            {
                JarmuForm form = new JarmuForm(jarmuvek[index]);
                if (form.ShowDialog() == DialogResult.OK)
                {
                    jarmuvek[index] = form.Jarmu;
                    //Jarmu tmp = (Jarmu)lsbJarmuvek.SelectedItem;
                    //lsbJarmuvek.Items.RemoveAt(index);
                    //lsbJarmuvek.Items.Insert(index, tmp);
                    //lsbJarmuvek.SelectedIndex = index;
                    ListBoxFrissites();
                }
            }
            else
            {
                MessageBox.Show("Nincs kiválasztva jármű!", "Figyelem!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnTorol_Click(object sender, EventArgs e)
        {
            if (lsbJarmuvek.SelectedIndex > -1 && MessageBox.Show("Valóban töröljük ezt a járművet?", "Törlés", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    ABKezelo.Torles((Jarmu)lsbJarmuvek.SelectedItem);
                    jarmuvek.RemoveAt(lsbJarmuvek.SelectedIndex);
                    ListBoxFrissites();
                }
                catch (ABKivetel ex)
                {
                    MessageBox.Show(ex.Message, "Hiba!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Hiba!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Log.Bejegyzes(ex);
                }
            }
            else
            {
                MessageBox.Show("Nincs kiválasztva jármű!", "Figyelem!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            try
            {
                openFileDialog1.Title = "Beolvasás CSV fájlból";
                openFileDialog1.Filter = "CSV fájl (*.csv)|*.csv|Minden fájl (*.*)|*.*";
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    foreach (string line in File.ReadAllLines(openFileDialog1.FileName, Encoding.UTF8))
                    {
                        if (line.StartsWith("Auto;"))
                        {
                            Jarmu jarmu = new Auto(line);
                            EgyJarmuBetoltese(jarmu);
                        }
                        else if (line.StartsWith("Motor;"))
                        {
                            Jarmu jarmu = new Motor(line);
                            EgyJarmuBetoltese(jarmu);
                        }
                    }
                }
                ListBoxFrissites();

                MessageBox.Show("Importálás sikeresen megtörtént! ", "Importálás...", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (ABKivetel ex)
            {
                MessageBox.Show(ex.Message, "Hiba!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(" Az importálás sikertelen! " + ex.Message, "Hiba...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Bejegyzes(ex);
            }
        }

        private void EgyJarmuBetoltese(Jarmu jarmu)
        {
            if (!jarmuvek.Contains(jarmu))
            {
                ABKezelo.UjJarmu(jarmu);
                jarmuvek.Add(jarmu);
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            try
            {
                saveFileDialog1.Title = "Mentés CSV fájlba";
                saveFileDialog1.Filter = "CSV fájl (*.csv)|*.csv|Minden fájl (*.*)|*.*";
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    Jarmu.Exportalas(saveFileDialog1.FileName);

                    MessageBox.Show("Mentés sikeresen megtörtént! ", "Mentés...", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(" A mentés sikertelen! " + ex.Message, "Hiba...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Bejegyzes(ex);
            }
        }
    }
}
