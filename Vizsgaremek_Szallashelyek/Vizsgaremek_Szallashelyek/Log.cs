using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vizsgaremek_Szallashelyek
{
    static internal class Log
    {
        public static void Append(string message)
        {
            File.AppendAllText("log.txt", $"[{DateTime.Now}] - {message}" + Environment.NewLine);
        }

        public static void Append(Exception ex)
        {
            File.AppendAllText("log.txt", $"[{DateTime.Now}] - {ex.Message}{Environment.NewLine}{ex.StackTrace}{Environment.NewLine}");
        }
    }
}
