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
    public partial class JegyForm : Form
    {
        internal Jegy Jegy { get; private set; }
        public JegyForm()
        {
            InitializeComponent();
        }

        private void JegyForm_Load(object sender, EventArgs e)
        {
            try
            {
                cmbTanar.DataSource = ABKezelo.TanarokBeolvasasa();
            }
            catch (ABKivetel ex)
            {

                MessageBox.Show("");
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbTanar.SelectedIndex != -1)
                {
                    Jegy = new Jegy((byte)numJegy.Value, (Tanar)cmbTanar.SelectedItem);

                }
                else
                {
                    MessageBox.Show("Kérem válasszon tanárt!", "Figyelem!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DialogResult = DialogResult.None;
                }
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
                DialogResult = DialogResult.None;
            }
        }
    }
}
