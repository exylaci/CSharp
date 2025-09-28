using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegatePeldaVizsgakMentese
{
    public class Vizsga
    {
        string cim;
        string feladat;
        string kepUtvonala;

        public string Cim
        {
            get => cim;
            set
            {
                if (cim != string.Empty)
                {
                    cim = value;
                }
                else
                {
                    throw new ArgumentException("A cím nem lehet üres!");
                }
            }
        }
        public string Feladat
        {
            get => feladat;
            set
            {
                if (feladat != string.Empty)
                {
                    feladat = value;
                }
                else
                {
                    throw new ArgumentException("A feladat nem lehet üres!");
                }
            }
        }
        public string KepUtvonala { get => kepUtvonala; set => kepUtvonala = value; }

        public Vizsga(string cim, string feladat, string kepUtvonala)
        {
            Cim = cim;
            Feladat = feladat;
            KepUtvonala = kepUtvonala;
        }

        public override string ToString()
        {
            return Cim;
        }

        public void VizsgaMentese(string utvonal)
        {
            if (Directory.Exists(utvonal) && utvonal.Last() == '\\')
            {
                StreamWriter fajl = new StreamWriter(utvonal + cim + ".html");
                fajl.WriteLine("<!DockType html>");
                fajl.WriteLine("<html>");
                fajl.WriteLine("<head>");
                fajl.WriteLine("<meta charset=\"utf-8\"/>");
                fajl.WriteLine("</head>");
                fajl.WriteLine("<body>");
                fajl.WriteLine(String.Format("\t<h1 style=\"color: red\">{0}</h1>", cim));
                fajl.WriteLine(String.Format("\t<p>{0}</p>", feladat));
                if (kepUtvonala != String.Empty)
                {
                    fajl.WriteLine(String.Format("\t<img src=\"{0}\" alt=\"a vizsgaleíráshoz tartozó kép\"/>", kepUtvonala.Split('\\').Last()));
                }
                fajl.WriteLine("</body>");
                fajl.WriteLine("</html");
                fajl.Close();
            }
            else
            {
                throw new ArgumentException("A megadott útvonal hibás!");
            }
        }
        public void KepMentese(string utvonal)
        {
            if (Directory.Exists(utvonal) && utvonal.Last() == '\\')
            {
                try
                {
                    File.Copy(kepUtvonala, utvonal + kepUtvonala.Split('\\').Last(), true);
                }
                catch (Exception e)
                {
                    throw new IOException("A kép másolása nem sikerült!");
                }
            }
        }
    }

}
