using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegateSaveListabolEgySorMenteseFaljba
{
    public delegate void Exporter(Vizsga vizsga);
    internal class Export
    {
        public static void CreateHtml(Vizsga vizsga,Exporter exporter)
        {
            Program.CreateHtmlMethod(vizsga);
        }

        public static void CopyPicture(Vizsga vizsga)
        {
            Program.CopyPictureMethod(vizsga);
        }

    }
}

