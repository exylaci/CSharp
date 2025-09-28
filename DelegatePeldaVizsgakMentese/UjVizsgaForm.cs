using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
               Vizsga = new Vizsga(txbCim.Text, txbFeladat.Text, txbKep.Text);
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Hiba!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
