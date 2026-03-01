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
    public partial class Form1 : Form
    {
        List<Tanulo> tanulok;
        public Form1()
        {
            InitializeComponent();
            ListBoxFrissites();
        }

        private void ListBoxFrissites()
        {
            try
            {
                tanulok = ABKezelo.TanulokBeolvasasa();
                lsb.DataSource = null;
                lsb.DataSource = tanulok;
            }
            catch (ABKivetel ex)
            {
                MessageBox.Show(ex.Message, "HIBA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnUjTanulo_Click(object sender, EventArgs e)
        {
            TanuloForm tanuloForm = new TanuloForm();
            if (tanuloForm.ShowDialog() == DialogResult.OK)
            {
                ListBoxFrissites();
            }
        }

        private void btnUjTanar_Click(object sender, EventArgs e)
        {
            TanarForm tanarForm = new TanarForm();
            if (tanarForm.ShowDialog() == DialogResult.OK)
            {
                MessageBox.Show("Új tanár felvétele sikeres volt.", "Információ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}