using System.Drawing;
using System.Windows.Forms;

namespace GrafikusObjektumAlap
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics canavas = e.Graphics;
            canavas.DrawRectangle(new Pen(Color.Blue), 50, 50, 100, 50);
            canavas.FillEllipse(new Pen(Color.Orange).Brush, 100, 100, 60, 60);
            canavas.FillRectangle(new Pen(Color.Chartreuse).Brush, 150, 150, 100, 50);
        }
    }
}
