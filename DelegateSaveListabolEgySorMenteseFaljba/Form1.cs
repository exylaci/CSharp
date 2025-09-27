using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DelegateSaveListabolEgySorMenteseFaljba
{
    public partial class Form1 : Form
    {
        List<Vizsga> vizsgak = new List<Vizsga>();
        public Form1()
        {
            vizsgak.Add(new Vizsga("Feladat1", "1. feladat szövege", "C:\\Temp\\elle.jpg"));
            vizsgak.Add(new Vizsga("Feladat2", "2. feladat szövege", "C:\\Temp\\u2.jpg"));
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            foreach (Vizsga vizsga in vizsgak)
            {
                lbxVizsgak.Items.Add(vizsga.Cim);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (lbxVizsgak.SelectedItem != null)
            {
                FrmAdd formAdd = new FrmAdd(vizsgak[lbxVizsgak.SelectedIndex], lbxVizsgak.SelectedIndex)
                {
                    Owner = this
                };
                DialogResult result = formAdd.ShowDialog();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Vizsga vizsga = new Vizsga("", "", "");
            FrmAdd formAdd = new FrmAdd(vizsga, -1)
            {
                Owner = this
            };
            DialogResult result = formAdd.ShowDialog();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Environment.Exit(1);
        }
        public void ReceiveVizsga(Vizsga vizsga, int index)
        {
            if (index == -1)
            {
                vizsgak.Add(vizsga);
            }
            else
            {
                vizsgak[index] = vizsga;
            }
            lbxVizsgak.Items.Clear();
            foreach (Vizsga v in vizsgak)
            {
                lbxVizsgak.Items.Add(v.Cim);
            }
            lbxVizsgak.Invalidate();
            lbxVizsgak.Update();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Vizsga vizsga = vizsgak[lbxVizsgak.SelectedIndex];
            Exporter exportalas = null;
            exportalas += Program.CreateHtmlMethod;
            exportalas += Program.CopyPictureMethod;
            exportalas(vizsga);
        }
    }
}
