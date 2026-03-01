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
    public partial class TopAblak : Form
    {
        public TopAblak()
        {
            InitializeComponent();
            //A REKORDOK SORRENDBE JELENJENEK MEG!!
            listBox1.DataSource = ToplistaElem.TOPLISTA_OLVASAS();
        }

        //KILÉPÉS
        private void exitGomb_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void exitGomb_MouseEnter(object sender, EventArgs e)
        {
            KomponensEffektek.KEPRE(sender as PictureBox);
        }

        private void exitGomb_MouseLeave(object sender, EventArgs e)
        {
            KomponensEffektek.KEPROL(sender as PictureBox);
        }
    }
}
