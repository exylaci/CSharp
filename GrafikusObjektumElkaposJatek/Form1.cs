using GrafikusObjektumElkaposJatek.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GrafikusObjektumElkaposJatek
{
    public partial class Form1 : Form
    {
        List<Macska> macskak;
        ElkapoSzerkezet elkapoSzerkezet;
        uint elkapott, elejtett;
        static Random rnd = new Random();
        static Font betuMeret = new Font(FontFamily.GenericSansSerif, 12, FontStyle.Bold);

        private void timer1_Tick(object sender, EventArgs e)
        {
            elkapoSzerkezet.Mozog(MousePosition);
            foreach (Macska macska in macskak)
            {
                macska.Mozog();
                if (macska.UtkozesTeszt(elkapoSzerkezet) || macska.Pozicio.Y > Height)
                {
                    if (macska.Pozicio.Y < Height)
                    {
                        ++elkapott;
                    }
                    else
                    {
                        ++elejtett;
                    }
                    int meret = rnd.Next(50, 100);
                    macska.Meret = new Size(meret, meret);
                    macska.Pozicio = new Point(rnd.Next(0, Width - macska.Meret.Width), 0 - macska.Meret.Height);
                }
            }
            Invalidate();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            elkapott = 0;
            elejtett = 0;
            macskak = new List<Macska>();
            elkapoSzerkezet = new ElkapoSzerkezet(new Point(10, Height - 80), new Size(60, 20), 0, Resources.elkapo);
            for (int i = 0; i < 10; ++i)
            {
                Size macskaMeret = new Size(50, 50);
                macskaMeret.Width = rnd.Next(50, 151);
                macskaMeret.Height = macskaMeret.Width;
                Point macskaPozicio = new Point(0, 0);
                macskaPozicio.X = rnd.Next(0, Width - macskaMeret.Width);
                macskaPozicio.Y = 0 - macskaMeret.Height;
                byte sebesseg = (byte)rnd.Next(1, 5);
                int kepIndex = rnd.Next(0, 5);
                macskak.Add(new Macska(macskaPozicio, macskaMeret, sebesseg, kepIndex, Resources.macska1, Resources.macska2, Resources.macska3, Resources.macska4, Resources.macska5));

            }
            timer1.Start();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            string elkapottSzoveg = "Az elkapott macskák száma: " + elkapott;
            string elejtettSzoveg = "Az elejtett macskák száma: " + elejtett;
            SizeF elkapottSzovegMerete = e.Graphics.MeasureString(elkapottSzoveg, betuMeret);
            SizeF elejtettSzovegMerete = e.Graphics.MeasureString(elejtettSzoveg, betuMeret);
            e.Graphics.DrawString(elkapottSzoveg, betuMeret, Brushes.Green, new PointF(Width - elkapottSzovegMerete.Width -20, 10));
            e.Graphics.DrawString(elejtettSzoveg, betuMeret, Brushes.Green, new PointF(Width - elejtettSzovegMerete.Width - 20, 15 + elkapottSzovegMerete.Height));
            foreach (Macska macska in macskak)
            {
                macska.Kirajzol(e.Graphics);
            }
            elkapoSzerkezet.Kirajzol(e.Graphics);
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 27)
            {
                Close();
            }
        }

        public Form1()
        {
            InitializeComponent();
        }
    }
}
