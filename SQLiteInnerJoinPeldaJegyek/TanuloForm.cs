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
    public partial class TanuloForm : Form
    {
        internal Tanulo Tanulo { get; private set; }
        List<Jegy> jegyek;
        public TanuloForm()
        {
            InitializeComponent();
            jegyek = new List<Jegy>();
        }

        void ListBoxFrissites()
        {
            lsbJegyek.DataSource = null;
            lsbJegyek.DataSource = jegyek;
        }

        private void btnUjJegy_Click(object sender, EventArgs e)
        {
            JegyForm jegyForm = new JegyForm();
            if (jegyForm.ShowDialog() == DialogResult.OK)
            {
                jegyek.Add(jegyForm.Jegy);
                ListBoxFrissites();
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                Tanulo = new Tanulo(txbNev.Text);
                foreach (Jegy jegy in jegyek)
                {
                    Tanulo.Jegyek.Add(jegy);
                }
                ABKezelo.TanuloFelvitele(Tanulo);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "HIBA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                DialogResult = DialogResult.None;
            }
        }
    }
}
