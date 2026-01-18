using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormsSajatKomponens
{
    public partial class MyButton : Button
    {
        bool checkedState;
        Color ledColor;
        Color borderColor;

        public bool CheckedState
        {
            get => checkedState;
            set
            {
                checkedState = value;
                Invalidate();
            }
        }
        public Color LedColor
        {
            get => ledColor;
            set
            {
                ledColor = value;
                Invalidate();
            }
        }
        public Color BorderColor
        {
            get => borderColor;
            set
            {
                borderColor = value;
                Invalidate();
            }
        }


        public MyButton()
        {
            //InitializeComponent();        //Nem kell, mert a szülő Button meghívja
            CheckedState = false;
            ledColor = Color.Green;
            MinimumSize = new Size(80, 45);
            BorderColor = Color.Black;
        }
        //public MyButton(IContainer container)
        //{   container.Add(this);
        //    InitializeComponent();
        //}

        protected override void OnClick(EventArgs e)
        {
            CheckedState = !CheckedState;
            base.OnClick(e);
        }

        protected override void OnPaint(PaintEventArgs pevent)
        {
            //base.OnPaint(pevent);         //Saját gombnyomás "effektet" készítünk,
            //                                 és nem a Button-ét akarjuk használni.
            pevent.Graphics.Clear(BackColor);
            pevent.Graphics.DrawRectangle(new Pen(BorderColor), 0, 0, Width - 1, Height - 1);
            pevent.Graphics.DrawRectangle(new Pen(BorderColor), Width * 3 / 8, Height / 3 + Height / 8, Width / 4, Height / 4);
            if (checkedState)
            {
                pevent.Graphics.FillRectangle(new Pen(LedColor).Brush, Width * 3 / 8, Height / 3 + Height / 8, Width / 4, Height / 4);
            }
            SizeF textSize = pevent.Graphics.MeasureString(Text, Font);     //Default Font és Text propertyk
            pevent.Graphics.DrawString(Text, Font, new Pen(BorderColor).Brush, (Width - textSize.Width) / 2, Height / 3 - textSize.Height / 2);
        }
    }
}
