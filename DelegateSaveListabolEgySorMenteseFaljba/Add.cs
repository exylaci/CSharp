using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DelegateSaveListabolEgySorMenteseFaljba
{
    public partial class FrmAdd : Form
    {
        private Vizsga _vizsga;
        private int _index;
        public FrmAdd(Vizsga vizsga, int index)
        {
            InitializeComponent();
            _vizsga = vizsga;
            _index = index;
            txbCim.Text = _vizsga.Cim;
            txbFeladat.Text = _vizsga.Feladat;
            txbUtvonal.Text = _vizsga.Utvonal;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txbCim.Text.Trim() != string.Empty && txbFeladat.Text.Trim() != string.Empty)
            {
                _vizsga.Cim = txbCim.Text;
                _vizsga.Feladat = txbFeladat.Text;
                _vizsga.Utvonal = txbUtvonal.Text;
                Form1 foAblak = (Form1)this.Owner;
                foAblak.ReceiveVizsga(_vizsga,_index);
                this.Close();
            }
            else
            {
                MessageBox.Show("A címet és a leírást nem lehet üresen hagyni!");
            }
        }
    }
}
