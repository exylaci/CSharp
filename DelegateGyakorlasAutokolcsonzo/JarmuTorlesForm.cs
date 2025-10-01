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
    public partial class JarmuTorlesForm : Form
    {
        internal string Rendszam { get; private set; }
       
        public JarmuTorlesForm()
        {
            InitializeComponent();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            Rendszam = txbRendszam.Text.Trim();
        }
    }
}
