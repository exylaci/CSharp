using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Vizsgaremek_Szallashelyek
{
    static internal class Log
    {
        public static void Append(string message)
        {
            try
            {
                File.AppendAllText("log.txt", $"[{DateTime.Now}] - {message}" + Environment.NewLine);

            }
            catch (Exception)
            {

                MessageBox.Show("Nem lehet a log fájlba írni!", "Logolási hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static void Append(Exception ex)
        {
            try
            {
                File.AppendAllText("log.txt", $"[{DateTime.Now}] - {ex.Message}{Environment.NewLine}{ex.StackTrace}{Environment.NewLine}");
            }
            catch (Exception)
            {

                MessageBox.Show("Nem lehet a log fájlba írni!", "Logolási hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
