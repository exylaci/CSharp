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
    public partial class UgyfelTorlesForm : Form
    {
        internal string Nev { get; private set; }
        public UgyfelTorlesForm()
        {
            InitializeComponent();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            Nev = txbNev.Text.Trim();
        }
    }
}
