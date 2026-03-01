using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Donkeykongdemo.Properties;

namespace Donkeykongdemo.Osztalyok
{
    public class HordoAI : PictureBox
    {
        bool tuzese;
        int pontszama;
        int gurulasiSebesseg = 7; //+jobbra -balra
        bool eppenzuhan = true;
        int aktualisSzint = 4;
        Random veletlen = new Random();

        public bool Tuzese 
        { 
            get => tuzese;
            set
            {
                tuzese = value;
                TUZES_BEALLITAS(value);
            }
        }
        public int Pontszama { get => pontszama; }
        public int GurulasiSebesseg { get => gurulasiSebesseg; }
        public bool Eppenzuhan 
        { 
            get => eppenzuhan;
            set
            {
                eppenzuhan = value;
                //HA FALSE-RA ÁLLÍTJUK AKKOR LEHET IRÁNY VÁLTOZÁST SORSOLNI!!!
                //(A 4-ES SZINTEN CSAK JOBBRA MEHET)
                if(!value)
                {
                    if (AktualisSzint < 4 && veletlen.Next(1, 101) % 2 == 0)
                    {
                        IRANY_VALTAS();
                    }
                    else
                    {
                        this.Image = GurulasiSebesseg > 0 ? this.Tuzese ? Resources.hordo_tuzes_jobbra : Resources.hordo_jobbra : this.Tuzese ? Resources.hordo_tuzes_balra : Resources.hordo_balra;
                    }
                }
                else// if(value)
                {
                    this.Image = Tuzese ? Resources.hordo_zuhan_tuzes : Resources.hordo_zuhan;
                }
            }
        }
        public int AktualisSzint { get => aktualisSzint; }

        public HordoAI(bool tuzese)
        {
            Tuzese = tuzese;
            this.DoubleBuffered = true;
            SizeMode = PictureBoxSizeMode.Zoom;
            Size = new System.Drawing.Size(35, 35);
            Tag = "hordo";
        }

        //TÜZES ÁLLAPOT VÁLTOZÁS
        void TUZES_BEALLITAS(bool tuzese)
        {
            this.pontszama = tuzese ? 1000 : 500;
            if(tuzese)
            {
                IRANY_VALTAS();
            }
            else
            {
                this.Image = Resources.hordo_zuhan;
            }
        }

        //ERŐLTETT VAGY KÖTELEZŐ ESÉS METÓDUS
        public void LE_KELL_ESNI()
        {
            this.BringToFront();
            eppenzuhan = true;
            this.Image = Tuzese ? Resources.hordo_zuhan_tuzes : Resources.hordo_zuhan;
            aktualisSzint--;
        }

        //VÉLETLEN FUNKCIÓ LEGURUL VAGY NEM
        public bool LEGURUL_A_HORDO()
        {
            if(veletlen.Next(1, 101) % 2 == 0)
            {
                LE_KELL_ESNI();
                return true;
            }
            return false;
        }

        //MEGSEMMISÜL A HORDÓ
        public void MEGSEMMISUL()
        {
            //VONJA LE A PONTSZÁMOT
            Jatekos.Pontszam = Jatekos.Pontszam - this.Pontszama < 0 ? 0 : Jatekos.Pontszam - this.Pontszama;
            //MEMÓRIÁBÓL IS KISZEDJÜK A HORDOAI OBJEKTUMOT
            this.Dispose();
        }

        //SEGÉD FUNKCIÓ HOGY A HORDÓ FEDI-E A LÉTRÁT AMIN LEGURULNA
        public bool FEDI_E(PictureBox aLetra)
        {
            return (this.Left >= aLetra.Left && this.Right <= aLetra.Right);
        }

        //IRÁNY VÁLTOZTATÁS
        public void IRANY_VALTAS()
        {
            this.BringToFront();
            if (GurulasiSebesseg > 0)
            {
                //JOBBRA MENT EDDIG => BALRA FOG MENNI
                //gurulasiSebesseg = -GurulasiSebesseg;
                //KÉPET IS CSERÉLÜNK
                this.Image = this.Tuzese ? Resources.hordo_tuzes_balra : Resources.hordo_balra;
            }
            else
            {
                //BALRA MENT EDDIG => JOBBRA FOG MENNI
                //gurulasiSebesseg = Math.Abs(GurulasiSebesseg);
                //gurulasiSebesseg *= -1;
                //KÉPET IS CSERÉLÜNK
                this.Image = this.Tuzese ? Resources.hordo_tuzes_jobbra : Resources.hordo_jobbra;
            }
            //IRÁNY ÁLLÍTÁS KÓDJA
            gurulasiSebesseg *= -1;
        }

        //VALÓS ELMOZDÍTÓ METÓDUSOK
        //GURULÁS
        public void GURUL()
        {
            this.Location = new System.Drawing.Point(Location.X + GurulasiSebesseg, Location.Y);
        }

        //ZUHANÁS
        public void ZUHAN(int gravitaciosErtek)
        {
            this.Location = new System.Drawing.Point(Location.X, Location.Y + gravitaciosErtek);
        }

    }
}
