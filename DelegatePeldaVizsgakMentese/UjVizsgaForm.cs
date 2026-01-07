using System;
using System.Windows.Forms;

namespace DelegatePeldaVizsgakMentese
{
    public partial class UjVizsgaForm : Form
    {
        public Vizsga Vizsga { get; set; }

        public UjVizsgaForm()
        {
            InitializeComponent();
        }

        private void btnTallozas_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                txbKep.Text = openFileDialog1.FileName;
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                Vizsga = new Vizsga(txbCim.Text, txbFeladat.Text, txbKep.Text);
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Hiba!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                DialogResult = DialogResult.None;
            }
        }
    }
}
