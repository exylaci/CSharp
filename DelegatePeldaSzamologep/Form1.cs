using System;
using System.Windows.Forms;

namespace DelegatePeldaSzamologep
{
    public partial class Form1 : Form
    {
        Muvelet Kivalasztott;

        public Form1()
        {
            InitializeComponent();
            cmbMuveletKivalaszto.DataSource = Enum.GetValues(typeof(MuveletekFunkciok));
        }

        private void cmbMuveletKivalaszto_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch ((MuveletekFunkciok)cmbMuveletKivalaszto.SelectedIndex)
            {
                case MuveletekFunkciok.Osszead:
                    Kivalasztott = Muveletek.Osszead;
                    break;
                case MuveletekFunkciok.Kivon:
                    Kivalasztott = Muveletek.Kivon;
                    break;
                case MuveletekFunkciok.Szoroz:
                    Kivalasztott = Muveletek.Szoroz;
                    break;
                case MuveletekFunkciok.Oszt:
                    Kivalasztott = Muveletek.Oszt;
                    break;
            }
        }
        private void btnVegrehajtas_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"A művelet eredménye: {Kivalasztott((double)numericUpDown1.Value, (double)numericUpDown2.Value)}", "Eredmény:", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
