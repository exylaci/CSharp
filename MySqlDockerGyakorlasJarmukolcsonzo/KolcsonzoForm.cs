using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace MySqlDockerGyakorlasJarmukolcsonzo
{
    public partial class KolcsonzoForm : Form
    {
        internal Kolcsonzo Kolcsonzo { get; private set; }

        public KolcsonzoForm()
        {
            InitializeComponent();
        }
        internal KolcsonzoForm(Kolcsonzo kolcsonzo) : this()
        {
            if (kolcsonzo != null)
            {
                Kolcsonzo = kolcsonzo;
                txbId.Text = Kolcsonzo.Id.ToString();
                txbNev.Text = Kolcsonzo.Nev;
                txbCim.Text = Kolcsonzo.Cim;
                txbTulaj.Text = Kolcsonzo.Tulajdonos;
                ListViewFrissitese();
            }
        }


        private void ListViewFrissitese()
        {
            listview.View = View.Details;
            listview.Items.Clear();
            if (listview.Columns.Count == 0)
            {
                foreach (PropertyInfo item in typeof(Jarmu).GetProperties())
                {
                    listview.Columns.Add(item.Name);
                }
            }
            foreach (Jarmu jarmu in Kolcsonzo.Jarmuvek)
            {
                string[] sor = new string[typeof(Jarmu).GetProperties().Length];
                int i = 0;
                foreach (PropertyInfo property in typeof(Jarmu).GetProperties())
                {
                    sor[i++] = property.GetValue(jarmu).ToString();
                }
                listview.Items.Add(new ListViewItem(sor));
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                if (Kolcsonzo == null)
                {
                    Kolcsonzo = new Kolcsonzo(txbNev.Text, txbCim.Text, txbTulaj.Text);
                    ABKezelo.KolcsonzoMentese(Kolcsonzo);
                }
                else
                {
                    Kolcsonzo.Nev = txbNev.Text;
                    Kolcsonzo.Cim = txbCim.Text;
                    Kolcsonzo.Tulajdonos = txbTulaj.Text;
                    ABKezelo.KolcsonzoModositasa(Kolcsonzo);
                }
            }
            catch (ABKivetel ex)
            {
                MessageBox.Show(ex.Message, "Hiba!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                DialogResult = DialogResult.None;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Figyelem!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                DialogResult = DialogResult.None;
                Log.Bejegyzes(ex);
            }
        }
    }
}
