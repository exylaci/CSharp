using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DelegateGyakorlasAutokolcsonzo
{
    public partial class UjUgyfelForm : Form
    {
        internal string Nev { get ; private set; }
        public UjUgyfelForm()
        {
            InitializeComponent();
        }

        private void btnHozzaad_Click(object sender, EventArgs e)
        {
            Nev=txbNev.Text.Trim();
        }
    }
}
