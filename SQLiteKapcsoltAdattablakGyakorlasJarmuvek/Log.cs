using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLiteKapcsoltAdattablakGyakorlasJarmuvek
{
    enum NaploSzint
    {
        Info,
        Figyelmeztetes,
        Hiba
    }

    static class Log
    {
        public static void Bejegyzes(string szoveg, NaploSzint szint)
        {
            File.AppendAllText("log.txt", $"[{DateTime.Now}] [{szint}] - {szoveg}" + Environment.NewLine);
        }

        public static void Bejegyzes(Exception ex)
        {
            File.AppendAllText("log.txt", $"[{DateTime.Now}] [{NaploSzint.Hiba}] - {ex.Message}{Environment.NewLine}{ex.StackTrace}{Environment.NewLine}");
        }
    }
}
