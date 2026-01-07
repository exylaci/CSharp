using System;
using System.Windows.Forms;

namespace DelegatePeldaVizsgakMentese
{
    public partial class Form1 : Form
    {
        delegate void MentesMetodusok(string utvonal);
        MentesMetodusok Mentes;

        public Form1()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            UjVizsgaForm dialogus = new UjVizsgaForm();
            if (dialogus.ShowDialog() == DialogResult.OK)
            {
                listBox1.Items.Add(dialogus.Vizsga);
                if (Mentes != null)
                {
                    Mentes += dialogus.Vizsga.VizsgaMentese;
                }
                else
                {
                    Mentes = new MentesMetodusok(dialogus.Vizsga.VizsgaMentese);
                }
                if (dialogus.Vizsga.KepUtvonala != string.Empty)
                {
                    Mentes += dialogus.Vizsga.KepMentese;
                }
            }
        }

        private void butDelete_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex != -1 && MessageBox.Show("Valóban törli a kiválasztott vizsgát?", "Vizsga törlése", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Mentes -= (listBox1.SelectedItem as Vizsga).VizsgaMentese;
                if ((listBox1.SelectedItem as Vizsga).KepUtvonala != string.Empty)
                {
                    Mentes -= (listBox1.SelectedItem as Vizsga).KepMentese;
                }
                listBox1.Items.RemoveAt(listBox1.SelectedIndex);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    Mentes(folderBrowserDialog1.SelectedPath + '\\');
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Hiba!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
