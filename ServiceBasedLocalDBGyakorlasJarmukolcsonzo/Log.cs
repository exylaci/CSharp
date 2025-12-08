using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceBasedLocalDBGyakorlasJarmukolcsonző
{
    static class Log
    {
        public static void Bejegyzes(Exception ex)
        {
            File.AppendAllText("log.txt", $"{DateTime.Now} - {ex.Message}{Environment.NewLine}{ex.StackTrace}{Environment.NewLine}");
        }
    }
}
