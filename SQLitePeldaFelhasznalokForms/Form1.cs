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

namespace SQLitePeldaFelhasznalokForms
{
    public partial class Form1 : Form
    {
        List<Felhasznalo> felhasznalok;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                felhasznalok = ABKezelo.Beolvasas();
                LBFrissit();
                LVFrissit();
                DGVFrissit();
            }
            catch (ABKivetel ex)
            {
                MessageBox.Show(ex.Message, "Hiba!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DGVFrissit()
        {
            dataGridView.DataSource = null;
            dataGridView.AllowUserToAddRows = false;
            dataGridView.AllowUserToDeleteRows = false;
            dataGridView.Rows.Clear();
            if (dataGridView.Columns.Count == 0)
            {
                foreach (var item in typeof(Felhasznalo).GetProperties())
                {
                    dataGridView.Columns.Add(item.Name, item.Name);

                }
            }
            foreach (Felhasznalo item in felhasznalok)
            {
                dataGridView.Rows.Add();
                for (int i = 0; i < typeof(Felhasznalo).GetProperties().Length; ++i)
                {
                    dataGridView.Rows[dataGridView.Rows.Count - 1].Cells[i].Value = typeof(Felhasznalo).GetProperties()[i].GetValue(item);
                }
            }
        }

        private void LVFrissit()
        {
            listView.View = View.Details;
            listView.FullRowSelect = true;
            listView.MultiSelect = false;
            listView.Items.Clear();
            if (listView.Columns.Count == 0)
            {
                foreach (PropertyInfo item in typeof(Felhasznalo).GetProperties())
                {
                    listView.Columns.Add(item.Name);
                }
            }
            foreach (Felhasznalo item in felhasznalok)
            {
                string[] adatok = new string[typeof(Felhasznalo).GetProperties().Length];
                for (int i = 0; i < adatok.Length; ++i)
                {
                    adatok[i] = typeof(Felhasznalo).GetProperties()[i].GetValue(item).ToString();
                }
                listView.Items.Add(new ListViewItem(adatok));
            }
        }

        private void LBFrissit()
        {
            listBox.DataSource = null;
            listBox.DataSource = felhasznalok;
        }

        private void btnUj_Click(object sender, EventArgs e)
        {
            FelhasznaloForm dialogus = new FelhasznaloForm();
            if (dialogus.ShowDialog() == DialogResult.OK)
            {
                felhasznalok.Add(dialogus.Felhasznalo);
                LBFrissit();
                LVFrissit();
                DGVFrissit();
            }
        }

        private void btnModosit_Click(object sender, EventArgs e)
        {
            if (listBox.SelectedIndex != -1)
            {
                FelhasznaloForm dialogus = new FelhasznaloForm(felhasznalok[listBox.SelectedIndex]);
                if (dialogus.ShowDialog() == DialogResult.OK)
                {
                    felhasznalok.Add(dialogus.Felhasznalo);
                    LBFrissit();
                    LVFrissit();
                    DGVFrissit();
                }
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                ABKezelo.KapcsolatBontas();
            }
            catch (ABKivetel ex)
            {
                MessageBox.Show(ex.Message, "HIBA!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnTorol_Click(object sender, EventArgs e)
        {
            if (listBox.SelectedIndex != -1 && MessageBox.Show("Valóban töröljük ezt a felhasználót?", "Törlés", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    ABKezelo.Torles(felhasznalok[listBox.SelectedIndex]);
                    felhasznalok.RemoveAt(listBox.SelectedIndex);
                    LBFrissit();
                    LVFrissit();
                    DGVFrissit();
                }
                catch (ABKivetel ex)
                {
                    MessageBox.Show(ex.Message, "HIBA!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
