using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySqlDockerGyakorlasJarmukolcsonzo
{
    static class Log
    {
        public static void Bejegyzes(string szoveg)
        {
            File.AppendAllText("log.txt", $"[{DateTime.Now}] - {szoveg}" + Environment.NewLine);
        }

        public static void Bejegyzes(Exception ex)
        {
            File.AppendAllText("log.txt", $"[{DateTime.Now}] - {ex.Message}{Environment.NewLine}{ex.StackTrace}{Environment.NewLine}");
        }
    }
}
