using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Linq;

namespace XMLprocessing
{
    public partial class Form1 : Form
    {
        List<Ember> emberek;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (File.Exists("adatok.xml"))
            {
                XDocument xml = XDocument.Load("adatok.xml");
                emberek = (from ember in xml.Root.Elements("Ember")
                           select new Ember(ember)).ToList();
                LBFrissit();
            }
            else
            {
                MessageBox.Show("Az adatok XML fájl nem létezik.", "Baj van!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
            }
        }

        private void LBFrissit()
        {
            listBox1.DataSource = null;
            listBox1.DataSource = emberek;
        }
        private void btnFilter_Click(object sender, EventArgs e)
        {
            var szures = from ember in emberek
                         where ember.Nev.ToLower().Contains(txbName.Text.Trim().ToLower())
                            && ember.SzulDatum <= dateTimePicker.Value
                            && ember.Lakcimek.Count(item => item.Varos.ToLower().Contains(txbAddress.Text.Trim().ToLower())) > 0
                         select ember;

            listBox1.DataSource = null;
            listBox1.DataSource = szures.ToList();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            LBFrissit();
        }
    }
}
