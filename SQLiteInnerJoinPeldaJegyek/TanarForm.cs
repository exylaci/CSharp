using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SQLiteInnerJoinPeldaJegyek
{
    public partial class TanarForm : Form
    {
        internal Tanar Tanar { get; private set; }
        public TanarForm()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                Tanar = new Tanar(txbNev.Text, txbTantargy.Text);
                ABKezelo.TanarFelvitele(Tanar);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
                DialogResult = DialogResult.None;
            }
        }
    }
}