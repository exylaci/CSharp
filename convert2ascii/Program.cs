using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace convert2ascii
{
    internal class Program
    {
        const string SOURCE = "őŐűŰ€→—\"“”„'‘’`*?|";
        const string TARGET = "ôÔûÛE--------------";
        static int succesful = 0, failed = 0;

        private static readonly Regex MyCountingPattern = new Regex(@"_\d{2}$");
        private static readonly Regex OtherCountingPattern = new Regex(@" *\(\d+\) *$");
        private static readonly Regex BothCountingPattern = new Regex(@" *(?:\(\d+\)|_\d{2}) *$");

        private static void StartingMessage()
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.WriteLine("Ez a program a paraméterként megadott útvonaltól a fájl nevéből, ");
            Console.WriteLine("vagy az alkönyvtárakban minden fájl és könyvtár bejegyzés nevéből");
            Console.WriteLine("   kiszedi: ");
            Console.WriteLine("     • a többlet szóközöket,");
            Console.WriteLine("     • az EXTERNAL_ szöveget.");
            Console.WriteLine("   kicseréli: ");
            Console.WriteLine("     • az őŐ és űŰ betűket, ôÔ és ûÛ betűkre");
            Console.WriteLine("     • az € karaktert, E betüre,");
            Console.WriteLine("     • az → — \" “ ” „ ' ‘ ’ ` * ? karaktereket, - karakterre,");
            Console.WriteLine("     • a görög ΑΠ(Re) szöveget latin betűs Re szövegre,");
            Console.WriteLine("     • minden más nem ASCII karaktert, _ jelre.");
            Console.WriteLine("Ha így azonossá válna fájlok neve, akkor a további átnevezéseknél egy _ jel");
            Console.WriteLine("után növekvő sorszámot tesz a fájlnév végére a kiterjesztés elé." + Environment.NewLine);
            Console.WriteLine("Használata egy könyvtár és alkönyvtárai minden bejegyzésére:");
            Console.WriteLine("   • convert2ascii c:\\temp\\e-mailek");
            Console.WriteLine("   • convert2ascii \"c:\\temp\\inbox 2023\"");
            Console.WriteLine("Használata csak egy fájl nevének módosítása esetén:");
            Console.WriteLine("   • convert2ascii c:\\temp\\minta.msg");
            Console.WriteLine("   • convert2ascii \"c:\\temp\\minta levél.msg\"" + Environment.NewLine + Environment.NewLine);
        }

        static void Main(string[] args)
        {
            Console.WriteLine();
            if (args.Length != 1)
            {
                StartingMessage();
                Console.WriteLine("Nem, vagy nem jól adtál meg útvonalat, vagy fájlnevet!");
                Console.ReadKey();
                Environment.Exit(-1);
            }

            if (File.Exists(args[0]))
            {
                Console.WriteLine($"[{DateTime.Now}] Egyetlen fájl átnevezése.");
                RenameOneFile(args[0]);
                Console.WriteLine($"[{DateTime.Now}] Kész.");

            }
            else if (Directory.Exists(args[0]))
            {
                Console.WriteLine($"[{DateTime.Now}] Könyvtár minden bejegyzésének összegyűjtése.");
                RenameAllFile(args[0]);
                Console.WriteLine($"[{DateTime.Now}] Kész.");
            }
            else
            {
                StartingMessage();
                Console.WriteLine("Nem létezik a megadott útvonal, vagy fájlnév!");
                Console.ReadKey();
            }
        }

        private static string ConvertToASCII(string name)
        {
            name = name.Replace("EXTERNAL_", "");
            name = name.Replace("ΑΠ", "Re");
            bool previousSpace = false;
            bool previousHyphen = false;
            bool previousUnderline = false;
            StringBuilder sb = new StringBuilder();
            int index;
            char oc;
            foreach (char c in name)
            {
                index = SOURCE.IndexOf(c);
                oc = index >= 0 ? TARGET[index] : (c > 254 ? '_' : c);

                if ((previousSpace && oc == ' ') || (previousHyphen && oc == '-') || (previousUnderline && oc == '_')) continue;
                previousSpace = oc == ' ';
                previousHyphen = oc == '-';
                previousUnderline = oc == '_';

                sb.Append(oc);
            }
            return sb.ToString();
        }

        private static string IncreaseNumberingIfAlreadyExists(string originalFullPathAndNAme)
        {
            string namePart = Path.GetFileNameWithoutExtension(originalFullPathAndNAme);
            namePart = MyCountingPattern.IsMatch(namePart) ? namePart : namePart + "_00";
            int numero;
            string result;
            do
            {
                numero = int.Parse(namePart.Substring(namePart.Length - 2, 2));
                if (numero == 99)
                {
                    namePart += "_00";
                    numero = 0;
                }
                namePart = namePart.Substring(0, namePart.Length - 2) + string.Format("{0:00}", ++numero);
                result = Path.Combine(Path.GetDirectoryName(originalFullPathAndNAme), namePart + Path.GetExtension(originalFullPathAndNAme));
            } while (File.Exists(result));
            return result;
        }

        private static string RemoveBothCounting(string oldFileName)
        {
            return BothCountingPattern.Replace(Path.GetFileNameWithoutExtension(oldFileName).Trim(), "") + Path.GetExtension(oldFileName);
        }

        private static string RemoveOtherCounting(string oldFileName)
        {
            return OtherCountingPattern.Replace(Path.GetFileNameWithoutExtension(oldFileName).Trim(), "") + Path.GetExtension(oldFileName);
        }

        private static void RenameOneFile(string oldFullPath)
        {
            string oldFileName = Path.GetFileName(oldFullPath);
            string newFileName = ConvertToASCII(RemoveOtherCounting(oldFileName));
            if (newFileName.Equals(oldFileName)) return;

            string newFullPath = Path.Combine(Path.GetDirectoryName(oldFullPath), RemoveBothCounting(newFileName));
            if (File.Exists(newFullPath))
            {
                newFullPath = IncreaseNumberingIfAlreadyExists(newFullPath);
            }
            Console.WriteLine($"Átnevezés:  {oldFullPath}");
            try
            {
                File.Move(oldFullPath, newFullPath);
                Console.WriteLine($"            {newFullPath}");
                ++succesful;
            }
            catch (Exception)
            {
                Console.SetCursorPosition(0, Console.CursorTop - 1);
                Console.WriteLine($"Sikertelen: {newFullPath}");
                ++failed;
            }
        }

        private static void RenameAllFile(string rootPath)
        {
            var dirs = Directory.EnumerateDirectories(rootPath, "*", SearchOption.AllDirectories);
            Console.Write($"A {dirs.Count()} darab alkönyvtárral együtt összesen ");
            var files = Directory.EnumerateFiles(rootPath, "*", SearchOption.AllDirectories);
            Console.WriteLine($"{files.Count()} fájlbejegyzés van.");

            Console.WriteLine($"[{DateTime.Now}] Átnevezések:");
            int index = dirs.Count() + files.Count();
            int y;
            foreach (var entry in files)
            {
                y = Console.CursorTop;
                Console.Write(new string(' ', Console.WindowWidth - 1));
                Console.SetCursorPosition(0, y);
                Console.Write($"{index--} {entry}");
                Console.SetCursorPosition(0, y);
                RenameOneFile(entry);
            }

            for (index = dirs.Count() - 1; index >= 0; --index)
            {
                y = Console.CursorTop;
                Console.Write(new string(' ', Console.WindowWidth - 1));
                Console.SetCursorPosition(0, y);
                Console.Write($"{index} {dirs.ElementAt(index)}");
                Console.SetCursorPosition(0, y);
                RenameOneDirectory(dirs.ElementAt(index));
            }
            y = Console.CursorTop;
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(0, y);
            Console.WriteLine($"A {dirs.Count() + files.Count()} bejegyzésből {succesful} darab sikeresen átnevezve, nem sikerűlt átnevezni {failed} darabot.");
        }

        private static void RenameOneDirectory(string oldPath)
        {
            string oldDir = new DirectoryInfo(oldPath).Name;
            string newDir = ConvertToASCII(oldDir);
            if (newDir.Equals(oldDir)) return;

            string parentDir = Directory.GetParent(oldPath)?.FullName;
            string newPath = parentDir == null ? newDir : Path.Combine(parentDir, newDir);

            Console.WriteLine($"Átnevezendő könyvtár: {oldPath}");
            try
            {
                Directory.Move(oldPath, newPath);
                Console.WriteLine($"                      {newPath}");
                ++succesful;
            }
            catch (Exception)
            {
                Console.WriteLine($"Nem sikerült erre:    {newPath}");
                ++failed;
            }
        }
    }
}
