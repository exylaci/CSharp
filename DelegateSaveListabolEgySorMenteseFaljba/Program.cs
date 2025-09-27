using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DelegateSaveListabolEgySorMenteseFaljba
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }

        public static void CreateHtmlMethod(Vizsga vizsga)
        {
            string htmlFileNeve = Path.Combine(Directory.GetCurrentDirectory(), vizsga.Cim + ".html");
            string kepFileNeve = Path.GetFileName(vizsga.Utvonal);
            try
            {
                using (StreamWriter writer = new(htmlFileNeve))
                {
                    writer.WriteLine("<!DOCTYPE html>");
                    writer.WriteLine("<html>");
                    writer.WriteLine("<body>");
                    writer.WriteLine($"\t<h1>{vizsga.Cim}</h1>");
                    writer.WriteLine($"\t<p>{vizsga.Feladat}</p>");
                    writer.WriteLine($"\t<img src=\"{kepFileNeve}\" alt=\"a vizsgaleíráshoz tartozó kép\"/>");
                    writer.WriteLine("</body>");
                    writer.WriteLine("</html");
                }
                MessageBox.Show($"A vizsga tételt kiírva ebbe a fájlba:\n  {htmlFileNeve}");
            }
            catch (Exception e)
            {
                MessageBox.Show("Nem sikerült a fájlba mentés: " + e.Message);
            }
        }

        public static void CopyPictureMethod(Vizsga vizsga)
        {
            string kepFileNeve = Path.Combine(Directory.GetCurrentDirectory(), Path.GetFileName(vizsga.Utvonal));
            try
            {
                File.Copy(vizsga.Utvonal, kepFileNeve, true);
                MessageBox.Show($"A vizsga tételhez tartozó kép {vizsga.Utvonal} \n sikeresen átmásolva ide: {kepFileNeve}");
            }
            catch (IOException e)
            {
                MessageBox.Show("Nem sikerült a kép másolása: " + e.Message);
            }
        }


    }
}
