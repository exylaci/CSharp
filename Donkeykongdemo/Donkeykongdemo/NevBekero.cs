using Donkeykongdemo.Osztalyok;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Donkeykongdemo
{
    public partial class NevBekero : Form
    {
        public NevBekero()
        {
            InitializeComponent();
        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            KomponensEffektek.GOMBRA_ERKEZES(sender as Button);
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            KomponensEffektek.GOMBROL_ELMEGYUNK(sender as Button);
        }

        //MENTÉS
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length < 3)
            {
                MessageBox.Show("A név nem lehet 3 karakternél rövidebb!", "Figyelem");
            }
            else
            {
                Jatekos.Nev = textBox1.Text;
                Jatekos.PONTSZAM_MENTES();
                this.Close();
            }
        }
    }
}
