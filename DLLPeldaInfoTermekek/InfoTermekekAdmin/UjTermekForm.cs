using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using InfoTermekekDLL;

namespace InfoTermekekAdmin
{
    public partial class UjTermekForm : Form
    {
        public InfoTermek Termek { get; private set; }

        public UjTermekForm()
        {
            InitializeComponent();
            cmbTermek.DataSource = Enum.GetValues(typeof(TermekTipusok));
            cmbProcesszor.DataSource = Enum.GetValues(typeof(ProcesszorTokozas));
            cmbMemoria.DataSource = Enum.GetValues(typeof(MemoriaTipus));
        }

        public UjTermekForm(InfoTermek modosit) : this()
        {
            Termek = modosit;
            txbGyarto.Text = modosit.Gyarto;
            txbMegnevezes.Text = modosit.Megnevezes;
            txbSzeriaszam.Text = modosit.Szeriaszam;
            numAr.Value = modosit.Ar;
            if (modosit is Alaplap)
            {
                cmbTermek.SelectedIndex = (int)TermekTipusok.Alaplap;
                cmbProcesszor.SelectedIndex = (int)(modosit as Alaplap).Tokozas;
                cmbMemoria.SelectedIndex = (int)(modosit as Alaplap).Tipus;
            }
            else if (modosit is Memoria)
            {
                cmbTermek.SelectedIndex = (int)TermekTipusok.Memoria;
                cmbMemoria.SelectedIndex = (int)(modosit as Memoria).Tipus;
            }
            else if (modosit is Processzor)
            {
                cmbTermek.SelectedIndex = (int)TermekTipusok.Processzor;
                cmbProcesszor.SelectedIndex = (int)(modosit as Processzor).Tokozas;
            }
            cmbTermek.Enabled = false;
            cmbProcesszor.Enabled = false;
            cmbMemoria.Enabled = false;
        }

        private void cmbTermek_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch ((TermekTipusok)cmbTermek.SelectedItem)
            {
                case TermekTipusok.Alaplap:
                    cmbProcesszor.Enabled = true;
                    cmbMemoria.Enabled = true;
                    break;
                case TermekTipusok.Processzor:
                    cmbProcesszor.Enabled = true;
                    cmbMemoria.Enabled = false;
                    break;
                case TermekTipusok.Memoria:
                    cmbProcesszor.Enabled = false;
                    cmbMemoria.Enabled = true;
                    break;
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (Termek == null)
            {
                try
                {
                    switch ((TermekTipusok)cmbTermek.SelectedItem)
                    {
                        case TermekTipusok.Alaplap:
                            Termek = new Alaplap(
                                txbGyarto.Text,
                                txbMegnevezes.Text,
                                txbSzeriaszam.Text,
                                (int)numAr.Value,
                                (ProcesszorTokozas)cmbProcesszor.SelectedIndex,
                                (MemoriaTipus)cmbMemoria.SelectedItem);
                            break;
                        case TermekTipusok.Processzor:
                            Termek = new Processzor(
                                txbGyarto.Text,
                                txbMegnevezes.Text,
                                txbSzeriaszam.Text,
                                (int)numAr.Value,
                                (ProcesszorTokozas)cmbProcesszor.SelectedIndex);
                            break;
                        case TermekTipusok.Memoria:
                            Termek = new Memoria(
                                txbGyarto.Text,
                                txbMegnevezes.Text,
                                txbSzeriaszam.Text,
                                (int)numAr.Value,
                                (MemoriaTipus)cmbMemoria.SelectedItem);
                            break;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        ex.Message,
                        "Hiba",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    DialogResult = DialogResult.None;
                    return;
                }
            }
            else
            {
                try
                {
                    Termek.Gyarto = txbGyarto.Text;
                    Termek.Megnevezes = txbMegnevezes.Text;
                    Termek.Szeriaszam = txbSzeriaszam.Text;
                    Termek.Ar = (int)numAr.Value;

                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        ex.Message,
                        "Hiba",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    DialogResult = DialogResult.None;
                    return;
                }
            }
        }
    }
}
