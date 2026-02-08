using System;
using System.IO;
using System.Windows.Forms;

namespace Vizsgaremek_Szallashelyek
{
    static internal class Log
    {
        private const string LOG_FILE_NAME = "log.txt";

        public static void Append(string message)
        {
            try
            {
                File.AppendAllText(LOG_FILE_NAME, $"[{DateTime.Now}] - {message}" + Environment.NewLine);
            }
            catch (Exception)
            {
                MessageBox.Show("Nem lehet a log fájlba írni!", "Logolás hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static void Append(Exception exception)
        {
            try
            {
                File.AppendAllText(LOG_FILE_NAME, $"[{DateTime.Now}] - {exception.Message}{Environment.NewLine}{exception.StackTrace}{Environment.NewLine}");
            }
            catch (Exception)
            {
                MessageBox.Show("Nem lehet a log fájlba írni!", "Logolás hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
