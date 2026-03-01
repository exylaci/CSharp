using Donkeykongdemo.Osztalyok;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Donkeykongdemo
{
    public partial class Form1 : Form
    {
        //MOZGATÁHOZ SEGÉD VÁLTOZÓ
        Point egerkattPozicio;

        public Form1()
        {
            InitializeComponent();
            //MOZGATHATÓVÁ TÉVŐ FELIRATKOZÁSOK
            this.MouseDown += (s, e) => egerkattPozicio = e.Button == MouseButtons.Left ? e.Location : egerkattPozicio;
            this.MouseMove += (s, e) => this.Location = e.Button == MouseButtons.Left ? new Point(e.X + this.Left - egerkattPozicio.X, e.Y + this.Top - egerkattPozicio.Y) : this.Location;
        }

        //WEBOLDAL MEGNYITÁS
        private void label1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.prooktatas.hu/");
        }

        //KISMÉRETRE ÁLLÍT
        private void kismeretLBL_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
        }

        //TELJES KÉPERNYŐRE ÁLLÍT
        private void maxmeretLBL_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }

        //JÁTÉK INDÍTÁSA
        private void button1_Click(object sender, EventArgs e)
        {
            JatekForm ablak = new JatekForm();
            this.Hide();
            ablak.ShowDialog();
            this.Show();
        }

        //TOPLISTA MEGNYITÁS
        private void button2_Click(object sender, EventArgs e)
        {
            TopAblak top = new TopAblak();
            top.ShowDialog();   
        }

        //KILÉPÉS
        private void button3_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Biztos ki szeretne lépni a játékból?", "Kérdés", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        //GOMBRA ÉRKEZÉS
        private void button1_MouseEnter(object sender, EventArgs e)
        {
            KomponensEffektek.GOMBRA_ERKEZES(sender as Button);
        }

        //GOMRÓL TÁVOLODÁS
        private void button1_MouseLeave(object sender, EventArgs e)
        {
            KomponensEffektek.GOMBROL_ELMEGYUNK((Button)sender);
        }

        //FELIRATRA ÉRKEZÉS
        private void kismeretLBL_MouseEnter(object sender, EventArgs e)
        {
            KomponensEffektek.FELIRATRA_ERKEZES(sender as Label);
        }

        //FELIRATRÓL TÁVOLODÁS
        private void kismeretLBL_MouseLeave(object sender, EventArgs e)
        {
            KomponensEffektek.FELIRATROL_TAVOLODAS(sender as Label);
        }
    }
}
