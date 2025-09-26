using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegateSaveListabolEgySorMenteseFaljba
{
    internal class Save
    {
        static void CreateHtml(Vizsga vizsga)
        {
            string fileName = vizsga.Cim + ".html";
            try
            {
                using (StreamWriter writer = new(fileName))
                {
                    writer.Write("<!DOCTYPE html>");
                }
                Console.WriteLine($"A vizsga tételt kiírva ebbe a fájlba:\n  {fileName}");
            }
            catch (Exception e)
            {
                Console.WriteLine("Nem sikerült a fájlba mentés: " + e.Message);
            }
        }
    }
}
