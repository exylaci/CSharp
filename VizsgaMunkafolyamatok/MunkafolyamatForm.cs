using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

namespace VizsgaMunkafolyamatok
{
    public partial class MunkafolyamatForm : Form
    {
        internal Munkafolyamat munkafolyamat;
        public MunkafolyamatForm()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                munkafolyamat = new Munkafolyamat(txbMegnevezes.Text, (double)numAr.Value);
            }
            catch (Exception ex)
            {
                {
                    MessageBox.Show(ex.Message, "Hiba!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    DialogResult = DialogResult.None;
                }
            }
        }
    }
}
