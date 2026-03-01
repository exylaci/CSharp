using Microsoft.VisualBasic;
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

namespace FormsKiserletezgetes
{
    public partial class MainForm : Form
    {
        int szam;
        string fajlnev;
        int modositas;
        public MainForm()
        {
            InitializeComponent();
            modositas = 0;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            int osszeg = 0;
            int szorzat = 1;
            while (osszeg < 100)
            {
                string valasz = Interaction.InputBox($"Jelenlegi összeg: {osszeg}\nAdd meg a következő számot:", "Számok összeadása és szorzása", "100");
                if (!string.IsNullOrEmpty(valasz) && int.TryParse(valasz, out int szam))
                {
                    osszeg += szam;
                    szorzat *= szam;
                }
                else
                {
                    MessageBox.Show("Nem értelmezhető az adat szám, próbáld újra!", "User hiba", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }
            }
            MessageBox.Show($"Az összeadás eredménye: {osszeg}\nA szorzás eredménye: {szorzat}", "Eredmény", MessageBoxButtons.OK, MessageBoxIcon.Information);

            btnNewGame_Click(null, null);
        }



        private void btnCopy_Click(object sender, EventArgs e)
        {
            lblTarget.Text = txbSource.Text;
            txbSource.Clear();
        }

        private void lblTarget_MouseEnter(object sender, EventArgs e)
        {
            lblTarget.Left = MousePosition.X + lblTarget.Width;
        }

        private void btnNewGame_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();
            szam = rnd.Next(-1000, 1001);
            lsbTippek.Items.Clear();
            lblTippel.Text = "Gondoltam egy számra -1000 és 1000 között. Találd ki!";
            txbTipp.Focus();
            btnTipp.Enabled = true;

        }

        private void txbTipp_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 && e.KeyChar != 45)
            {
                e.Handled = true;
            }
        }

        private void btnTipp_Click(object sender, EventArgs e)
        {
            if (txbTipp.Text == "")
            {
                MessageBox.Show("Adj meg egy tippet!");
                return;
            }
            else
            {
                int tipp = Convert.ToInt32(txbTipp.Text);
                lsbTippek.Items.Add(tipp);
                if (tipp < szam)
                {
                    lblTippel.Text = "Nagyobbra gondoltam!";
                }
                else if (tipp > szam)
                {
                    lblTippel.Text = "Kisebbre gondoltam!";
                }
                else
                {
                    lblTippel.Text = "Eltaláltad!";
                    btnTipp.Enabled = false;
                }
                lsbTippek.Items.Add($"{tipp} - {txbTipp.Text}");
                txbTipp.Clear();
                lsbTippek.SelectedIndex = lsbTippek.Items.Count - 1;
                txbTipp.Focus();
            }
        }

        private void txbTipp_TextChanged(object sender, EventArgs e)
        {
            if (txbTipp.Text.Length > 0 && txbTipp.Text != "-")
            {
                btnTipp.Enabled = true;
            }
            else
            {
                btnTipp.Enabled = false;
            }
        }

        private void megnyitasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dlgOpenFile.ShowDialog() == DialogResult.OK)
            {
                fajlnev = dlgOpenFile.FileName;
                txbNotepad.Text = File.ReadAllText(dlgOpenFile.FileName);
            }
        }

        private void mentesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(fajlnev)) { File.WriteAllText(fajlnev, txbNotepad.Text); }
            else
            {
                mentesMaskentToolStripMenuItem_Click(sender, e);
            }
        }

        private void mentesMaskentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dlgSave.ShowDialog() == DialogResult.OK)
            {
                fajlnev = dlgSave.FileName;
                File.WriteAllText(fajlnev, txbNotepad.Text);
            }
        }

        private void kilepesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void betutipusToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dlgFont.ShowDialog() == DialogResult.OK)
            {
                txbNotepad.Font = dlgFont.Font;
            }
        }

        private void hatterszinToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dlgColor.ShowDialog() == DialogResult.OK)
            {
                txbNotepad.BackColor = dlgColor.Color;
            }
        }

        private void betuszinToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dlgColor.ShowDialog() == DialogResult.OK)
            {
                txbNotepad.ForeColor = dlgColor.Color;
            }
        }

        private void masolasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (txbNotepad.SelectedText.Length > 0)
            {
                Clipboard.SetText(txbNotepad.SelectedText);
            }
            else
            {
                MessageBox.Show("Nincs kijelölt szöveg a másoláshoz!", "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void kivagasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (txbNotepad.SelectedText.Length > 0)
            {
                Clipboard.SetText(txbNotepad.SelectedText);
                txbNotepad.SelectedText = "";
            }
            else
            {
                MessageBox.Show("Nincs kijelölt szöveg a kivágáshoz!", "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void beillesztesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Clipboard.ContainsText())
            {
                int pozicio = txbNotepad.SelectionStart;
                txbNotepad.SelectedText = "";
                txbNotepad.Text = txbNotepad.Text.Insert(pozicio, Clipboard.GetText());
                txbNotepad.SelectionStart = pozicio + Clipboard.GetText().Length;
            }
            else
            {
                MessageBox.Show("Nincs szöveg a vágólapon a beillesztéshez!", "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void nevjegyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("FormsKiserletezgetes\nVerzió: 1.0.0\nKészítette: én :)", "Névjegy", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Biztosan bezárja a programot?", "Bezárás", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
            {
                e.Cancel = true;
            }

            if (File.Exists(Path.Combine(folderBrowserDialog.SelectedPath, "log.log")))
            {
                File.WriteAllText(Path.Combine(folderBrowserDialog.SelectedPath, "main.log"),
                    $"[{DateTime.Now}] - {File.ReadAllText(Path.Combine(folderBrowserDialog.SelectedPath, "log.log"))}{Environment.NewLine}");
                File.Delete(Path.Combine(folderBrowserDialog.SelectedPath, "log.log"));
            }

        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog.ShowDialog() != DialogResult.OK)
            {
                txbLogolt.Enabled = false;
                FormClosing -= MainForm_FormClosing;
                return;
            }
            txbLogolt.Enabled = true;

        }

        private void txbLogolt_TextChanged(object sender, EventArgs e)
        {
            ++modositas;
            if (modositas > 5)
            {
                File.WriteAllText(Path.Combine(folderBrowserDialog.SelectedPath, "log.log"), txbLogolt.Text);
                modositas = 0;
            }
        }
    }
}
