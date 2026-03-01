using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Donkeykongdemo.Osztalyok
{
    public static class KomponensEffektek
    {
        static Color sargaszin = Color.FromArgb(254, 216, 56);
        static Color pirosszin = Color.FromArgb(222, 4, 10);
        //HANG LEJÁTSZÓ OBJEKTUM
        public static SoundPlayer lejatszo = new SoundPlayer();

        public static void TUZ_HANG()
        {
            try
            {
                lejatszo.SoundLocation = Application.StartupPath + "/Hangok/fire.wav";
                lejatszo.Play();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        #region KÉP EFFEKT
        public static void KEPRE(PictureBox kep)
        {
            kep.Size = new Size(kep.Width + 4, kep.Height + 4);
            kep.Location = new Point(kep.Location.X - 2, kep.Location.Y - 2);
            try
            {
                lejatszo.SoundLocation = Application.StartupPath + "/Hangok/gombhang.wav";
                lejatszo.Play();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static void KEPROL(PictureBox kep)
        {
            kep.Size = new Size(kep.Width - 4, kep.Height - 4);
            kep.Location = new Point(kep.Location.X + 2, kep.Location.Y + 2);
        }
        #endregion

        #region GOMB EFFEKT
        public static void GOMBRA_ERKEZES(Button gomb)
        {
            gomb.BackColor = sargaszin;
            gomb.ForeColor = pirosszin;
            try
            {
                lejatszo.SoundLocation = Application.StartupPath + "/Hangok/gombhang.wav";
                lejatszo.Play();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static void GOMBROL_ELMEGYUNK(Button gomb)
        {
            gomb.BackColor = pirosszin;
            gomb.ForeColor = sargaszin;
        }
        #endregion

        #region FELIRAT EFFEKT
        public static void FELIRATRA_ERKEZES(Label felirat)
        {
            felirat.ForeColor = sargaszin;
            felirat.Font = new Font("Verdana", 14, FontStyle.Bold);
        }

        public static void FELIRATROL_TAVOLODAS(Label felirat)
        {
            felirat.ForeColor = Color.FloralWhite;
            felirat.Font = new Font("Verdana", 12, FontStyle.Bold);
        }
        #endregion
    }
}
