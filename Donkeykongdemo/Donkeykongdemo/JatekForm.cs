using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Donkeykongdemo.Osztalyok;
using Donkeykongdemo.Properties;

namespace Donkeykongdemo
{
    public partial class JatekForm : Form
    {
        //SZÜKSÉGES VÁLTOZÓK
        bool balra, jobbra, ugras, fel, le, letrazik, jatekvege = false;
        int ugrasiSebesseg;
        int gravitacio;
        int jatekosSebesseg = 10;
        int kongSebesseg = 8;
        bool serthetetlen = false;
        int vedettIdo = 2000; //sec
        //KONG HATÁROK
        int balszel = 167;
        int jobbszel = 423;

        Point hordoSpawnHely = new Point(500, 200);
        Point jatekosSpawnHely = new Point(68, 578);
        int spawnTick = 50;

        public bool Serthetetlen 
        { 
            get => serthetetlen;
            set
            {
                serthetetlen = value;
                if(value)
                {
                    //IGAZ ESETÉN VÉDETT IDŐT IS BEÁLLÍTJA
                    vedettIdo = 2000;
                    Console.WriteLine("VÉDETT LETT 2SEC-re");
                }
                else
                {
                    Jatekos.VEDELEM_VEGE(jatekos);
                    Console.WriteLine("Védelem lejárt!");
                }
            }
        }

        //FELÜLET FRISSÍTÉS 20ms-enként (50FPS)
        private void idozito_Tick(object sender, EventArgs e)
        {
            //EGY VÁLTOZÓ AMI KEZELI A LÉTRA INTERAKTÍV TERÜLETÉT
            bool letraElottVanAJatekos = false;

            //HALÁL UTÁNI VÉDETT IDŐ (2sec)
            if(vedettIdo > 0)
            {
                vedettIdo -= idozito.Interval; // 20ms
                Console.WriteLine("VÉDETT MS: " + vedettIdo);
            }
            else
            {
                //IGAZÍTÁS
                vedettIdo = 0;
                Serthetetlen = false;
            }

            //HORDÓ SPAWNOLÁS
            if(spawnTick == 100)
            {
                HordoAI hordo = new HordoAI(false);
                hordo.Location = hordoSpawnHely;
                jatekTerulet.Controls.Add(hordo);
                spawnTick = 0;
            }
            else
            {
                spawnTick++;
            }

            //FRISSÍTJÜK A PONTSZÁMOKAT
            pontszam.Text = "Pontszámom: " + Jatekos.Pontszam;

            //JÁTÉKOS MOZGÁS KEZELÉS
            if(balra)
            {
                jatekos.Left -= jatekosSebesseg;
            }
            if(jobbra)
            {
                jatekos.Left += jatekosSebesseg;
            }
            if(ugras && gravitacio < 0)
            {
                ugras = false;
            }
            if(ugras)
            {
                ugrasiSebesseg = -10;
                gravitacio -= 1;
            }
            else
            {
                ugrasiSebesseg = 10; // => TOP TÁVOT ÁLLÍT
            }

            //JÁTÉKOS LEZUHANÁS
            if (jatekos.Top > 1000)
            {
                jatekvege = Jatekos.ELET_VESZTES(jatekos, jatekosSpawnHely, Serthetetlen);
            }

            //KONG MOZGÁS JOBBRA BALRA
            if(kongSebesseg > 0) //=>> JOBBRA MEGY
            {
                kong.Location = new Point(kong.Left + kongSebesseg, kong.Top);
                if (kong.Left >= jobbszel)
                {
                    kongSebesseg = -kongSebesseg / 2;
                    kong.Image = Resources.donkey_kong_promo_Other;
                }
            }
            else //BALRA MEGY
            {
                kong.Location = new Point(kong.Left + kongSebesseg, kong.Top);
                if (kong.Left <= balszel)
                {
                    kongSebesseg = Math.Abs(kongSebesseg * 2);
                    kong.Image = Resources.donkey_kong_promo;
                }
            }

            //FELÜLETEN ELEMEK KEZELÉSE
            foreach (Control elem in jatekTerulet.Controls)
            {
                //ELEMEK KONTAKT
                if (elem is PictureBox)
                {
                    //LÉTRA KONTAKT
                    if ((string)elem.Tag == "letra")
                    {
                        if (jatekos.Bounds.IntersectsWith(elem.Bounds))
                        {
                            letraElottVanAJatekos = true;
                            if (fel)
                            {
                                letrazik = true;
                                jatekos.Top -= jatekosSebesseg;
                            }
                            else if (le && (elem.Top + elem.Height) >= (jatekos.Top + jatekos.Height) + jatekosSebesseg)
                            {
                                letrazik = true;
                                jatekos.Top += jatekosSebesseg;
                            }
                        }
                    }

                    //HORDO KONTAKT
                    if ((string)elem.Tag == "hordo")
                    {
                        if(jatekos.Bounds.IntersectsWith(elem.Bounds) && !Serthetetlen)
                        {
                            jatekvege = Jatekos.ELET_VESZTES(jatekos, jatekosSpawnHely, Serthetetlen);
                        }

                        //HORDÓK EGYÉB KONTAKTJAI
                        if(olajoshordo1.Bounds.IntersectsWith(elem.Bounds) || olajoshordo2.Bounds.IntersectsWith(elem.Bounds))
                        {
                            //KIGYULLAD A HORDÓ ÉS IRÁNYT VÁLT
                            (elem as HordoAI).Tuzese = true;
                        }

                        //SZINTENKÉNTI MŰKÖDÉS
                        //LÉTRÁNÁL LEGURULHAT => ZUHANÁS VAGY HA NINCS TALAJ IS ZUHAN
                        bool zuhan = false;
                        switch ((elem as HordoAI).AktualisSzint)
                        {
                            //KEZDŐ SZINT
                            case 4:
                                //ZUHAN-E
                                if((elem as HordoAI).Eppenzuhan)
                                {
                                    zuhan = true;
                                    //HA TALAJT ÉRT
                                    if(talaj4.Bounds.IntersectsWith(elem.Bounds))
                                    {
                                        //ZUHANÁS MEGÁLLÍTÁSA
                                        (elem as HordoAI).Eppenzuhan = false;
                                        //TALAJ FÖLÉ IGAZÍTÁS
                                        elem.Location = new System.Drawing.Point(elem.Left, talaj4.Top - elem.Height);
                                    }
                                }
                                else
                                {
                                    if((elem as HordoAI).FEDI_E(letra4))
                                    {
                                        (elem as HordoAI).LE_KELL_ESNI();
                                    }
                                }
                                break;
                            case 3:
                                //ZUHAN-E
                                if ((elem as HordoAI).Eppenzuhan)
                                {
                                    zuhan = true;
                                    //HA TALAJT ÉRT
                                    if (talaj3.Bounds.IntersectsWith(elem.Bounds))
                                    {
                                        //ZUHANÁS MEGÁLLÍTÁSA
                                        (elem as HordoAI).Eppenzuhan = false;
                                        //TALAJ FÖLÉ IGAZÍTÁS
                                        elem.Location = new System.Drawing.Point(elem.Left, talaj3.Top - elem.Height);
                                    }
                                }
                                else
                                {
                                    //LÉTRÁK VIZSGÁLATA
                                    if ((elem as HordoAI).FEDI_E(letra3))
                                    {
                                        if((elem as HordoAI).LEGURUL_A_HORDO())
                                        {
                                            Console.WriteLine("LEGURUL EGY HORDÓ");
                                        }
                                    }
                                    else if ((elem as HordoAI).FEDI_E(letra2))
                                    {
                                        if ((elem as HordoAI).LEGURUL_A_HORDO())
                                        {
                                            Console.WriteLine("LEGURUL EGY HORDÓ");
                                        }
                                    }
                                    //SZÉLEK VIZSGÁLATA
                                    if(talaj3.Right < elem.Left)
                                    {
                                        (elem as HordoAI).LE_KELL_ESNI();
                                    }
                                }
                                    break;
                            case 2:
                                //ZUHAN-E
                                if ((elem as HordoAI).Eppenzuhan)
                                {
                                    zuhan = true;
                                    //HA TALAJT ÉRT
                                    if (talaj2.Bounds.IntersectsWith(elem.Bounds))
                                    {
                                        //ZUHANÁS MEGÁLLÍTÁSA
                                        (elem as HordoAI).Eppenzuhan = false;
                                        //TALAJ FÖLÉ IGAZÍTÁS
                                        elem.Location = new System.Drawing.Point(elem.Left, talaj2.Top - elem.Height);
                                    }
                                }
                                else
                                {
                                    if((elem as HordoAI).FEDI_E(letra1))
                                    {
                                        if ((elem as HordoAI).LEGURUL_A_HORDO())
                                        {
                                            Console.WriteLine("LEGURUL EGY HORDÓ");
                                        }
                                    }
                                    //SZÉLEK VIZSGÁLATA
                                    if (talaj2.Left > elem.Right)
                                    {
                                        (elem as HordoAI).LE_KELL_ESNI();
                                    }
                                }
                                break;
                            case 1:
                                //ZUHAN-E
                                if ((elem as HordoAI).Eppenzuhan)
                                {
                                    zuhan = true;
                                    //HA TALAJT ÉRT
                                    if (talaj1.Bounds.IntersectsWith(elem.Bounds))
                                    {
                                        //ZUHANÁS MEGÁLLÍTÁSA
                                        (elem as HordoAI).Eppenzuhan = false;
                                        //TALAJ FÖLÉ IGAZÍTÁS
                                        elem.Location = new System.Drawing.Point(elem.Left, talaj1.Top - elem.Height);
                                    }
                                }
                                else
                                {
                                    //SZÉLEK VIZSGÁLATA
                                    if (talaj1.Left > elem.Right || talaj1.Right < elem.Left)
                                    {
                                        (elem as HordoAI).LE_KELL_ESNI();
                                    }
                                }
                                break;
                                //MEGSEMMISÜLÖ SZINT / TALAJ ALATT
                            case 0:
                                zuhan = true;
                                if(elem.Top > 1000)
                                {
                                    ((HordoAI)elem).MEGSEMMISUL();
                                }
                                break;
                        }
                        //A HORDÓ KISZÁMÍTOTT FELÜLETI ELMOZDULÁSÁT MEGVALÓSÍTJUK
                        if(zuhan)
                        {
                            (elem as HordoAI).ZUHAN(8);
                        }
                        else
                        {
                            (elem as HordoAI).GURUL();
                        }
                    }

                    //TALAJ KONTAKT
                    if ((string)elem.Tag == "talaj")
                    {
                        if (jatekos.Bounds.IntersectsWith(elem.Bounds) && !ugras && elem.Top + (elem.Height / 2) > (jatekos.Top + jatekos.Height) - 8 && !letrazik)
                        {
                            gravitacio = 8;
                            ugrasiSebesseg = 0;
                            //Console.WriteLine("TOP 1: " + jatekos.Top);
                            jatekos.Top = elem.Top - jatekos.Height + 1;
                            //Console.WriteLine("TOP 2: " + jatekos.Top);
                        }
                    }
                    //HERCEGNŐ KONTAKT
                    if ((string)elem.Tag == "hercegno")
                    {
                        if (jatekos.Bounds.IntersectsWith(elem.Bounds))
                        {
                            jatekvege = true;
                            break;
                        }
                    }
                    //KONG KONTAKT
                    if ((string)elem.Tag == "kong")
                    {
                        if (jatekos.Bounds.IntersectsWith(elem.Bounds))
                        {
                            jatekvege = Jatekos.ELET_VESZTES(jatekos, jatekosSpawnHely, Serthetetlen);
                            //BEÜLTETJÜK PARAMÉTERBE MERT TÖBBSZÖR IS ELŐ FORDULHAT! Serthetetlen = true;
                        }
                    }

                }

            }
            //FOREACH UTÁN

            if (jatekvege)
            {
                idozito.Stop();
            }

            if (!letraElottVanAJatekos)
            {
                letrazik = false;
            }

            //FÜGGÖLEGES ELMOZDULÁS
            if (!letrazik)
            {
                jatekos.Top += ugrasiSebesseg;
            }
            //SZIVEK
            ELETKIJELZES();
        }

        //ÉLET KIJELZŐ METÓDUS
        private void ELETKIJELZES()
        {
            //SZÍV MEGJELENÍTÉS
            switch (Jatekos.Elet)
            {
                case 0:
                    elet1.Visible = false;
                    elet2.Visible = false;
                    elet3.Visible = false;
                    break;
                case 1:
                    elet1.Visible = true;
                    elet2.Visible = false;
                    elet3.Visible = false;
                    break;
                case 2:
                    elet1.Visible = true;
                    elet2.Visible = true;
                    elet3.Visible = false;
                    break;
                case 3:
                    elet1.Visible = true;
                    elet2.Visible = true;
                    elet3.Visible = true;
                    break;
            }
            //HA VÉGE A JÁTÉKNAK AKKOR STÁTUSZ ABLAK!!
            //Console.WriteLine("ÉLETEINK: " + Jatekos.Elet);
            if (jatekvege)
            {
                if(Jatekos.Elet > 0)
                {
                    //GYŐZELEM
                    jatekos.Location = new Point(0, 0);
                    jatekos.Size = jatekTerulet.Size;
                    jatekos.BringToFront();
                    MessageBox.Show("Nyertél, a pontszámod: " + Jatekos.Pontszam, "Gratulálunk");
                    NevBekero bekero = new NevBekero();
                    bekero.ShowDialog();
                }
                else
                {
                    //VESZTÉS
                    kong.Location = new Point(0, 0);
                    kong.Size = jatekTerulet.Size;
                    kong.BringToFront();
                    MessageBox.Show("Sajnos vesztettél, a kong elvitte a hercegnőt! :(", "Játék vége");
                }
            }
        }

        //GOMB LENYOMÁS
        private void JatekForm_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Left:
                    balra = true;
                    jatekos.Image = Resources.jatekos_balra;
                    break;
                case Keys.Right:
                    jobbra = true;
                    jatekos.Image = Resources.jatekos_jobbra;
                    break;
                case Keys.Up:
                    fel = true;
                    break;
                case Keys.Down:
                    le = true;
                    break;
                case Keys.Space:
                    if(!ugras)
                    {
                        ugras = true;
                    }
                    break;
                default:
                    //TÖBBIT NEM KEZELJÜK
                    break;
            }
        }

        //GOMB FELENGEDÉS
        private void JatekForm_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Left:
                    balra = false;
                    break;
                case Keys.Right:
                    jobbra = false;
                    break;
                case Keys.Up:
                    fel = false;
                    break;
                case Keys.Down:
                    le = false;
                    break;
                case Keys.Space:
                    if(ugras)
                    {
                        ugras = false;
                    }
                    break;
                default:
                    //TÖBBIT NEM KEZELJÜK
                    break;
            }
        }


        public JatekForm()
        {
            Jatekos.JATEKOS_RESET();
            InitializeComponent();
            rekordpontszam.Text = "Rekord pontszám: " + ToplistaElem.REKORD_PONTSZAM();
        }

        private void exitGomb_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
