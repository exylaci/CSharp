using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormsDinamikusElemekTiliToli
{
    public partial class Form1 : Form
    {
        //Azért, hogy gyakoroljam a gombok elérését a Form osztály példányán
        //keresztül, nem gyültöm külön kollekcióba a szám gomnokat.
        //List<Button> buttons = new List<Button>();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            for (int i = 1; i <= 15; i++)
            {
                Button btn = new Button()
                {
                    Parent = this,
                    Text = "'",
                    Top = 10,
                    Left = 10,
                    Width = 40,
                    Height = 40,
                    ForeColor = Color.Blue,
                    BackColor = Color.LightGray,
                    Font = new Font("Arial", 12, FontStyle.Bold),
                    Name = "btn" + i
                };
                btn.Click += Btn_Click;
            }
            shuffleButtons();
        }

        private void shuffleButtons()
        {
            Random rnd = new Random();
            int[] buttonTexts = Enumerable.Range(1, 15).OrderBy(a => rnd.Next()).ToArray();
            int index = 0;
            int pointed = rnd.Next(0, 16);
            foreach (Control component in this.Controls)
            {
                if (component is Button button && button.Name.StartsWith("btn"))
                {
                    button.Text = buttonTexts[index].ToString();
                    if (index == pointed)
                    {
                        button.Left = 130;
                        button.Top = 130;
                    }
                    else
                    {
                        button.Left = 10 + (index % 4) * 40;
                        button.Top = 10 + (index / 4) * 40;
                    }
                    index++;
                }
            }
        }

        private void isOrdered()
        {
            foreach (Control component in this.Controls)
            {
                if (component is Button button && button.Name.StartsWith("btn"))
                {
                    if (Convert.ToInt32(button.Text) != ((button.Top - 10) / 10 + (button.Left - 10) / 40 + 1))
                    {
                        return;
                    }
                }
            }
            MessageBox.Show("Gratulálok, nyertél!");
        }

        private void Btn_Click(object sender, EventArgs e)
        {
            if (((Button)sender).Top > 10)
            {
                bool canMove = true;
                foreach (Control component in this.Controls)
                {
                    if (component is Button button && button.Name.StartsWith("btn"))
                    {
                        if (button.Top + 40 == ((Button)sender).Top && button.Left == ((Button)sender).Left)
                        {
                            canMove = false;
                        }
                    }
                }
                if (canMove)
                {
                    ((Button)sender).Top -= 40;
                    isOrdered();
                    return;
                }
            }
            if (((Button)sender).Top < 130)
            {
                bool canMove = true;
                foreach (Control component in this.Controls)
                {
                    if (component is Button button && button.Name.StartsWith("btn"))
                    {
                        if (button.Top - 40 == ((Button)sender).Top && button.Left == ((Button)sender).Left)
                        {
                            canMove = false;
                        }
                    }
                }
                if (canMove)
                {
                    ((Button)sender).Top += 40;
                    isOrdered();
                    return;
                }
            }
            if (((Button)sender).Left > 10)
            {
                bool canMove = true;
                foreach (Control component in this.Controls)
                {
                    if (component is Button button && button.Name.StartsWith("btn"))
                    {
                        if (button.Left + 40 == ((Button)sender).Left && button.Top == ((Button)sender).Top)
                        {
                            canMove = false;
                        }
                    }
                }
                if (canMove)
                {
                    ((Button)sender).Left -= 40;
                    isOrdered();
                    return;
                }
            }
            if (((Button)sender).Left < 130)
            {
                bool canMove = true;
                foreach (Control component in this.Controls)
                {
                    if (component is Button button && button.Name.StartsWith("btn"))
                    {
                        if (button.Left - 40 == ((Button)sender).Left && button.Top == ((Button)sender).Top)
                        {
                            canMove = false;
                        }
                    }
                }
                if (canMove)
                {
                    ((Button)sender).Left += 40;
                    isOrdered();
                    return;
                }
            }
        }

        private void btnShuffle_Click(object sender, EventArgs e)
        {
            shuffleButtons();
        }
    }
}