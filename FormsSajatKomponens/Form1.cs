using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormsSajatKomponens
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void myButton1_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"A {myButton1.Name} meg lett nyomva", "Esemény", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }
    }
}
