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

namespace ServiceBasedLocalDBGyakorlasJarmukolcsonző
{
    public partial class Form1 : Form
    {
        List<Kolcsonzo> kolcsonzok;
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            ABKezeles abKezeles = new ABKezeles();
            kolcsonzok = ABKezeles.TeljesBeolvasas();
            ListViewFrissites();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                ABKezeles.KapcsolatBontas();
            }
            catch (ABKivetel ex)
            {
                MessageBox.Show(ex.Message, "Hiba!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Bejegyzes(ex);
            }
        }
        private void lsvTeljes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lsvTeljes.SelectedItems.Count != 0)
            {
                string rendszam = lsvTeljes.SelectedItems[0].SubItems[3].Text;
                if (string.IsNullOrEmpty(rendszam))
                {
                    KolcsonzesGroupBoxFrissites();
                }
                else
                {
                    KolcsonzesGroupBoxFrissites(JarmuKereses(rendszam));
                }
            }
            else
            {
                KolcsonzesGroupBoxFrissites();
            }
        }
        private void btnUjKolcsonzo_Click(object sender, EventArgs e)
        {
            KolcsonzoForm kolcsonzoForm = new KolcsonzoForm();
            if (kolcsonzoForm.ShowDialog() == DialogResult.OK)
            {
                kolcsonzok.Add(kolcsonzoForm.Kolcsonzo);
                ListViewFrissites();
            }
        }
        private void btnKolcsonzoTorles_Click(object sender, EventArgs e)
        {
            if (lsvTeljes.SelectedItems.Count == 0)
            {
                MessageBox.Show("Elöszőr jelöljön ki egy kölcsönzőt a törléshez!", "Kölcsönző törlése", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            DialogResult result = MessageBox.Show("Biztosan törölni szeretné a kiválasztott kölcsönzőt?", "Kölcsönző törlése", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (result == DialogResult.OK)
            {
                try
                {
                    Kolcsonzo kolcsonzo = kolcsonzok.First(k => k.Nev == lsvTeljes.SelectedItems[0].SubItems[0].Text && k.Cim == lsvTeljes.SelectedItems[0].SubItems[1].Text);
                    ABKezeles.KolcsonzoTorlese(kolcsonzo);
                    kolcsonzok.Remove(kolcsonzo);
                    ListViewFrissites();
                }
                catch (ABKivetel ex)
                {
                    MessageBox.Show(ex.Message, "Hiba!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Log.Bejegyzes(ex);
                }
            }
        }
        private void btnKolcsonzoModositas_Click(object sender, EventArgs e)
        {
            if (lsvTeljes.SelectedItems.Count == 0)
            {
                MessageBox.Show("Elöszőr jelölje ki a módosítandó kölcsönzőt!", "Kölcsönző módosítása", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Kolcsonzo kolcsonzo = kolcsonzok.First(k => k.Nev == lsvTeljes.SelectedItems[0].SubItems[0].Text && k.Cim == lsvTeljes.SelectedItems[0].SubItems[1].Text);
            int index = kolcsonzok.IndexOf(kolcsonzo);

            KolcsonzoForm kolcsonzoForm = new KolcsonzoForm(kolcsonzo);
            if (kolcsonzoForm.ShowDialog() == DialogResult.OK)
            {
                kolcsonzok[index] = kolcsonzoForm.Kolcsonzo;
                ListViewFrissites();
            }
        }
        private void btnJarmuModositas_Click(object sender, EventArgs e)
        {
            if (lsvTeljes.SelectedItems.Count == 0)
            {
                MessageBox.Show("Elöszőr jelölje ki a módosítandó járművet!", "Kölcsönző módosítása", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Kolcsonzo kivalasztottKolcsonzo = kolcsonzok.First(k => k.Nev == lsvTeljes.SelectedItems[0].SubItems[0].Text && k.Cim == lsvTeljes.SelectedItems[0].SubItems[1].Text);
            Kolcsonzo kolcsonzo = new Kolcsonzo(kivalasztottKolcsonzo.Nev, kivalasztottKolcsonzo.Cim, 1);

            Jarmu jarmu = kivalasztottKolcsonzo.Jarmuvek.FirstOrDefault(j => j.Rendszam == lsvTeljes.SelectedItems[0].SubItems[3].Text);
            if (jarmu == null)
            {
                MessageBox.Show("Ebben a kölcsönzőben nincsen jármű!", "Kölcsönző módosítása", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            int jarmuIndex = kivalasztottKolcsonzo.Jarmuvek.IndexOf(jarmu);

            JarmuForm jarmuForm = new JarmuForm(jarmu, kolcsonzo, kolcsonzok);
            if (jarmuForm.ShowDialog() == DialogResult.OK)
            {
                if (!kivalasztottKolcsonzo.Nev.Equals(jarmuForm.kolcsonzo.Nev) || !kivalasztottKolcsonzo.Cim.Equals(jarmuForm.kolcsonzo.Cim))
                {
                    foreach (Kolcsonzo k in kolcsonzok)
                    {
                        if (k.Nev.Equals(jarmuForm.kolcsonzo.Nev) && k.Cim.Equals(jarmuForm.kolcsonzo.Cim))
                        {
                            kivalasztottKolcsonzo.Jarmuvek.RemoveAt(jarmuIndex);
                            k.Jarmuvek.Add(jarmuForm.jarmu);
                            break;
                        }
                    }
                }
                else
                {
                    kivalasztottKolcsonzo.Jarmuvek[jarmuIndex] = jarmuForm.jarmu;
                }
                ListViewFrissites();
            }
        }
        private void btnKikolcsonzik_Click(object sender, EventArgs e)
        {
            Jarmu jarmu = JarmuKereses(txbRendszam.Text);
            jarmu.Foglalt = true;
            ABKezeles.JarmuModositas(jarmu);
            ListViewFrissites();
        }
        private void btnVisszahoztak_Click(object sender, EventArgs e)
        {
            Jarmu jarmu = JarmuKereses(txbRendszam.Text);
            jarmu.Foglalt = false;
            ABKezeles.JarmuModositas(jarmu);
            ListViewFrissites();
        }
        private void BtnUjJarmu_Click(object sender, EventArgs e)
        {
            if (lsvTeljes.Items.Count == 0)
            {
                MessageBox.Show("Elöszőr egy kölcsönzőt kell hozzáadni!", "Új jármű hozzáadása", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Kolcsonzo kolcsonzo = null;
            if (lsvTeljes.SelectedItems.Count != 0)
            {
                kolcsonzo = kolcsonzok.First(k => k.Nev == lsvTeljes.SelectedItems[0].SubItems[0].Text && k.Cim == lsvTeljes.SelectedItems[0].SubItems[1].Text);
            }

            JarmuForm jarmuForm = new JarmuForm(null, kolcsonzo, kolcsonzok);
            if (jarmuForm.ShowDialog() == DialogResult.OK)
            {
                foreach (Kolcsonzo k in kolcsonzok)
                {
                    if (k.Nev.Equals(jarmuForm.kolcsonzo.Nev) && k.Cim.Equals(jarmuForm.kolcsonzo.Cim))
                    {
                        k.Jarmuvek.Add(jarmuForm.jarmu);
                        break;
                    }
                }
                ListViewFrissites();
            }
        }
        private void btnJarmuTorles_Click(object sender, EventArgs e)
        {
            if (lsvTeljes.SelectedItems.Count == 0)
            {
                MessageBox.Show("Elöszőr jelöljön ki egy járművet a törléshez!", "Jármű törlése", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (MessageBox.Show("Biztosan törölni szeretné a kiválasztott járművet?", "Jármű törlése", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    Kolcsonzo kolcsonzo = kolcsonzok.First(k => k.Nev == lsvTeljes.SelectedItems[0].SubItems[0].Text && k.Cim == lsvTeljes.SelectedItems[0].SubItems[1].Text);
                    Jarmu jarmu = kolcsonzo.Jarmuvek.FirstOrDefault(j => j.Rendszam == lsvTeljes.SelectedItems[0].SubItems[3].Text);
                    if (jarmu == null)
                    {
                        MessageBox.Show("Ebben a kölcsönzőben nincsen jármű!", "Jármű törlése", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    ABKezeles.JarmuTorlese(jarmu);
                    kolcsonzo.Jarmuvek.Remove(jarmu);
                    ListViewFrissites();
                }
                catch (ABKivetel ex)
                {
                    MessageBox.Show(ex.Message, "Hiba!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Log.Bejegyzes(ex);
                }
            }
        }
        private void txbRendszam_Leave(object sender, EventArgs e)
        {
            txbRendszam.Text = txbRendszam.Text.ToUpper().Trim();
            KolcsonzesGroupBoxFrissites(JarmuKereses(txbRendszam.Text));

            lsvTeljes.SelectedItems.Clear();
            foreach (ListViewItem item in lsvTeljes.Items)
            {
                if (item.SubItems[3].Text == txbRendszam.Text)
                {
                    item.Selected = true;
                    item.Focused = true;
                    item.EnsureVisible();
                    break;
                }
            }
        }

        private void ListViewFrissites()
        {
            int index = -1;
            if (lsvTeljes.SelectedItems.Count > 0)
            {
                index = lsvTeljes.SelectedItems[0].Index;

            }

            lsvTeljes.View = View.Details;
            lsvTeljes.Items.Clear();
            if (lsvTeljes.Columns.Count == 0)
            {
                for (int i = 0; i < typeof(Kolcsonzo).GetProperties().Count() - 1; ++i)
                {
                    lsvTeljes.Columns.Add(typeof(Kolcsonzo).GetProperties().ElementAt(i).Name);
                }
                foreach (PropertyInfo item in typeof(Jarmu).GetProperties())
                {
                    lsvTeljes.Columns.Add(item.Name);
                }
                lsvTeljes.Columns.Add(" ");
            }
            foreach (Kolcsonzo kolcsonzo in kolcsonzok)
            {
                if (kolcsonzo.Jarmuvek.Count == 0)
                {
                    lsvTeljes.Items.Add(new ListViewItem(new string[]
                    {
                        kolcsonzo.Nev,
                        kolcsonzo.Cim,
                        kolcsonzo.MaxJarmu.ToString(),
                        ""
                    }));
                }
                else
                {
                    foreach (Jarmu jarmu in kolcsonzo.Jarmuvek)
                    {
                        lsvTeljes.Items.Add(new ListViewItem(new string[]
                        {
                            kolcsonzo.Nev,
                            kolcsonzo.Cim,
                            kolcsonzo.MaxJarmu.ToString(),
                            jarmu.Rendszam,
                            jarmu.Marka,
                            (jarmu.Foglalt ? "Foglalt":"Szabad"),
                            jarmu is Auto ? $"Auto   {((Auto)jarmu).Kialakitas}" : $"Motor {((Motor)jarmu).Kobcenti} köbcentis"
                        }));

                    }
                }
            }
            lsvTeljes.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            if (index >= 0 && lsvTeljes.Items.Count > index)
            {
                lsvTeljes.Items[index].Selected = true;
                KolcsonzesGroupBoxFrissites(JarmuKereses(lsvTeljes.Items[index].SubItems[3].Text.Trim()));
            }
            else
            {
                KolcsonzesGroupBoxFrissites();
            }
        }
        private Jarmu JarmuKereses(string rendszam)
        {
            foreach (Kolcsonzo kolcsonzo in kolcsonzok)
            {
                foreach (Jarmu jarmu in kolcsonzo.Jarmuvek)
                {
                    if (jarmu.Rendszam.Equals(rendszam))
                    {
                        return (jarmu);
                    }
                }
            }
            return null;
        }
        private void KolcsonzesGroupBoxFrissites(Jarmu jarmu = null)
        {
            if (jarmu == null)
            {
                grbKolcsonzes.Text = string.Empty;
                txbRendszam.Text = string.Empty;
                chbKikolcsonozheto.Checked = false;
                chbKikolcsonozheto.Enabled = false;
                btnKikolcsonzik.Enabled = false;
                btnVisszahoztak.Enabled = false;
            }
            else
            {
                txbRendszam.Text = jarmu.Rendszam;
                grbKolcsonzes.Text = (jarmu is Auto) ? "Autó" : "Motor";
                chbKikolcsonozheto.Checked = !jarmu.Foglalt;
                chbKikolcsonozheto.Enabled = true;
                btnKikolcsonzik.Enabled = !jarmu.Foglalt;
                btnVisszahoztak.Enabled = jarmu.Foglalt;
            }
        }
    }
}