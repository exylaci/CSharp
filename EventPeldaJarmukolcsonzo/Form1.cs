using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EventPeldaJarmukolcsonzo
{
    public partial class Form1 : Form
    {
        public delegate void UjKolcsonzesEsemenyKezelo(string rendszam, bool kolcsonoz);
        public event UjKolcsonzesEsemenyKezelo UjKolcsonzes;
        public Form1()
        {
            InitializeComponent();
        }

        private void btnUj_Click(object sender, EventArgs e)
        {
            UjJarmuForm form = new UjJarmuForm();
            if (form.ShowDialog() == DialogResult.OK)
            {
                lsbJarmuvek.Items.Add(form.Jarmu);
                UjKolcsonzes += form.Jarmu.UjKolcsonozes;
            }
        }

        private void btnKolcsonzes_Click(object sender, EventArgs e)
        {
            try
            {
                UjKolcsonzes(txbRendszam.Text, chbKolcsonzes.Checked);
                for (int i = 0; i < lsbJarmuvek.Items.Count; ++i)
                {
                    lsbJarmuvek.Items[i] = lsbJarmuvek.Items[i];
                }
            }
            catch (MarKolcsonozveKivetel ex)
            {
                MessageBox.Show(ex.Message, "Baj van!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (NullReferenceException ex)
            {
                MessageBox.Show("Még nincs kölcsönözhető autó felvéve!", "Baj van!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
