using KonyvesboltKomponens;
using System;
using System.Windows.Forms;

namespace KonyvesboltWinForms
{
    public partial class MolyForm : Form
    {
        public Konyvmoly Moly { get; private set; }
        public MolyForm()
        {
            InitializeComponent();
            comboBox1.DataSource = Enum.GetValues(typeof(KonyvTipusok));
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                Moly = new Konyvmoly((KonyvTipusok)comboBox1.SelectedIndex, (int)numericUpDown1.Value, textBox1.Text);
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Hiba!", MessageBoxButtons.OK);
                DialogResult = DialogResult.None;
            }
        }
    }
}
