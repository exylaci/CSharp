using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Donkeykongdemo.Osztalyok
{
    public static class Jatekos
    {
        public static int Elet = 3;
        public static int Pontszam = 50000;
        public static string Nev = string.Empty;

        public static void JATEKOS_RESET()
        {
            Elet = 3;
            Pontszam = 50000;
            Nev = string.Empty;
        }

        public static bool ELET_VESZTES(PictureBox ajatekos, Point spawnhely, bool serthetetlensegTulajdonsag)
        {
            Elet--;
            if (Elet > 0)
            {
                Console.WriteLine("Vesztettél egy életet, de újra spawnolsz!");
                serthetetlensegTulajdonsag = true;
                //ELHALVÁNYÍTÁS EFFEKT
                Panel takaro = new Panel();
                takaro.BackColor = Color.FromArgb(100, Color.Black);
                takaro.Size = ajatekos.Size;
                takaro.Location = new Point(0, 0);
                takaro.Parent = ajatekos;
                takaro.BringToFront();
                //SPAWN
                ajatekos.Location = spawnhely;
                return false;
            }
            return true;
        }

        public static void VEDELEM_VEGE(PictureBox ajatekos)
        {
            //LESZEDI A HALVÁNYÍTÓ PANELT!
            ajatekos.Controls.Clear();
        }

        //PONTSZÁM MENTÉS
        public static void PONTSZAM_MENTES()
        {
            string eleres = "toplista.ini";
            if(File.Exists(eleres))
            {
                //VAN MÁR FÁJL BELE ÍRUNK
                File.AppendAllText(eleres, Environment.NewLine + Nev + "|" + Pontszam); //név|pontszám => laci|24500
            }
            else
            {
                //MÉG NINCS FÁJL
                File.AppendAllText(eleres, Nev + "|" + Pontszam);
            }
            Console.WriteLine("PONTSZÁM MENTVE!");
        }
    }
}
