using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AblakFileOsztalyListaGyakorlasJarmuJavitoMuhely
{
    public partial class frmJarmuKezeles : Form
    {
        Muhely muhely;
        int index;
        public enum Valasztas
        {
            Választás, Szeméylautó, Teherautó
        }
        //Szenélyautó
        Label s_kialakitas_lb;
        ComboBox s_kialakitas_cb;
        CheckBox muszakivizsga_cb;
        //Teherautó
        Label t_kialakitas_lb;
        ComboBox t_kialakitas_cb;
        CheckBox utanfutos_cb;

        internal frmJarmuKezeles(Muhely muhely)
        {
            InitializeComponent();
            GroupBoxKomponensek();
            this.muhely = muhely;
            cmbValasztas.DataSource = Enum.GetValues(typeof(Valasztas));
            numGyartasiEv.Value = DateTime.Now.Year;
            numGyartasiEv.Maximum = DateTime.Now.Year;
            cmbJarmuMarka.DataSource = Enum.GetValues(typeof(JarmuMarka));
            cmbSzarmazasiHely.DataSource = Enum.GetValues(typeof(SzarmazasiHely));
            index = -1;
            ActiveControl = cmbValasztas;
        }

        internal frmJarmuKezeles(Muhely muhely, Jarmu jarmu, int index, bool megtekintes = false)
        {
            InitializeComponent();
            GroupBoxKomponensek();
            this.muhely = muhely;
            this.index = index;
            txbAzonositoszam.Text = jarmu.AzonositoSzam;
            txbRendszam.Text = jarmu.JarmuRendszam;
            numGyartasiEv.Value = jarmu.GyartasiEv;
            numGyartasiEv.Maximum = DateTime.Now.Year;
            cmbJarmuMarka.DataSource = Enum.GetValues(typeof(JarmuMarka));
            cmbSzarmazasiHely.DataSource = Enum.GetValues(typeof(SzarmazasiHely));
            cmbJarmuMarka.SelectedIndex = (int)jarmu.Jarmumarkaja;
            cmbSzarmazasiHely.SelectedIndex = (int)jarmu.SzarmazasiHelye;
            chbHasznalt.Checked = jarmu.HasznaltJarmu;
            numJavitasAra.Value = jarmu.JavitasAra;
            cmbValasztas.DataSource = Enum.GetValues(typeof(Valasztas));
            if (jarmu is SzemelyAuto)
            {
                cmbValasztas.SelectedIndex = (int)Valasztas.Szeméylautó;
                s_kialakitas_cb.SelectedIndex = (int)(jarmu as SzemelyAuto).SzemelyAutoKialakitas;
                muszakivizsga_cb.Checked = (jarmu as SzemelyAuto).JavitasMuszakiVizsga;
            }
            else
            {
                cmbValasztas.SelectedIndex = (int)Valasztas.Teherautó;
                t_kialakitas_cb.SelectedIndex = (int)(jarmu as Teherauto).TeherautoKialakitas;
                utanfutos_cb.Checked = (jarmu as Teherauto).Utanfutos;
            }
            cmbValasztas.Enabled = false;
            this.ActiveControl = txbRendszam;
            if (megtekintes)
            {
                foreach (Control item in groupBox1.Controls)
                {
                    if (!(item is Label))
                    {
                        item.Enabled = false;
                    }
                }
                foreach (Control item in grbSpecialis.Controls)
                {
                    if (!(item is Label))
                    {
                        item.Enabled = false;
                    }
                }
                btnOK.Enabled = false;
                ActiveControl = btnCancel;

            }
        }

        private void GroupBoxKomponensek()
        {
            s_kialakitas_lb = new Label()
            {
                Parent = grbSpecialis,
                Top = 20,
                Left = label6.Left,
                Width = label6.Width,
                Text = "Kialakítás"
            };
            s_kialakitas_cb = new ComboBox()
            {
                Parent = grbSpecialis,
                Top = 20,
                Left = cmbJarmuMarka.Left,
                Width = cmbJarmuMarka.Width,
                DataSource = Enum.GetValues(typeof(SzemelyAutoKialakitas)),
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            muszakivizsga_cb = new CheckBox()
            {
                Parent = grbSpecialis,
                Top = s_kialakitas_cb.Bottom+5,
                Left = chbHasznalt.Left,
                Width = chbHasznalt.Width,
                Text = "Műszaki vizsga?"
            };
            //Tegerautó
            t_kialakitas_lb = new Label()
            {
                Parent = grbSpecialis,
                Top = 20,
                Left = label6.Left,
                Width = label6.Width,
                Text = "Kialakítás"
            };
            t_kialakitas_cb = new ComboBox()
            {
                Parent = grbSpecialis,
                Top = 20,
                Left = numJavitasAra.Left,
                Width = numJavitasAra.Width,
                DataSource = Enum.GetValues(typeof(TeherautoKialakitas)),
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            utanfutos_cb = new CheckBox()
            {
                Parent = grbSpecialis,
                Top = t_kialakitas_cb.Bottom + 5,
                Left = t_kialakitas_cb.Left,
                Width = t_kialakitas_cb.Width,
                Text = "Utánfutós?"
            };
        }

        private void cmbValasztas_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch ((Valasztas)cmbValasztas.SelectedIndex)
            {
                case Valasztas.Választás:
                    grbSpecialis.Visible = false;
                    btnOK.Enabled = false;
                    break;
                case Valasztas.Szeméylautó:
                    grbSpecialis.Visible = true;
                    s_kialakitas_lb.Visible = true;
                    s_kialakitas_cb.Visible = true;
                    muszakivizsga_cb.Visible = true;
                    t_kialakitas_lb.Visible = false;
                    t_kialakitas_cb.Visible = false;
                    utanfutos_cb.Visible = false;
                    if (index == -1)
                    {
                        txbAzonositoszam.Text = muhely.AzonositoSzamMeghatarozas(true);
                    }
                    btnOK.Enabled = true;
                    break;
                case Valasztas.Teherautó:
                    grbSpecialis.Visible = true;
                    s_kialakitas_lb.Visible = false;
                    s_kialakitas_cb.Visible = false;
                    muszakivizsga_cb.Visible = false;
                    t_kialakitas_lb.Visible = true;
                    t_kialakitas_cb.Visible = true;
                    utanfutos_cb.Visible = true;
                    if (index == -1)
                    {
                        txbAzonositoszam.Text = muhely.AzonositoSzamMeghatarozas(false);
                    }
                    btnOK.Enabled = true;
                    break;
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (txbRendszam.Text.Trim() != string.Empty && txbRendszam.Text.Trim().Length > 6)
            {
                switch ((Valasztas)cmbValasztas.SelectedIndex)
                {
                    case Valasztas.Szeméylautó:
                        Jarmu kezelendoSzemelyauto = new SzemelyAuto((SzemelyAutoKialakitas)s_kialakitas_cb.SelectedIndex, muszakivizsga_cb.Checked, txbAzonositoszam.Text, txbRendszam.Text.Trim(), (short)numGyartasiEv.Value, (JarmuMarka)cmbJarmuMarka.SelectedIndex, (SzarmazasiHely)cmbSzarmazasiHely.SelectedIndex, chbHasznalt.Checked, (int)numJavitasAra.Value);
                        JarmuvetKezel(kezelendoSzemelyauto);
                        break;
                    case Valasztas.Teherautó:
                        Jarmu kezelendoTeherauto = new Teherauto((TeherautoKialakitas)t_kialakitas_cb.SelectedIndex, utanfutos_cb.Checked, txbAzonositoszam.Text, txbRendszam.Text.Trim(), (short)numGyartasiEv.Value, (JarmuMarka)cmbJarmuMarka.SelectedIndex, (SzarmazasiHely)cmbSzarmazasiHely.SelectedIndex, chbHasznalt.Checked, (int)numJavitasAra.Value);
                        JarmuvetKezel(kezelendoTeherauto);
                        break;
                }
            }
            else
            {
                MessageBox.Show("A mező helyes kitöltése kötelező!", "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                DialogResult = DialogResult.None;
            }
        }

        private void JarmuvetKezel(Jarmu kezelendoJarmu)
        {
            if (index == -1)
            {
                muhely.UjJarmu(kezelendoJarmu);
            }
            else
            {
                muhely.JarmuModositas(index, kezelendoJarmu);
            }
        }
    }
}
