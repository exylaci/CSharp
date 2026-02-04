using System;
using System.ComponentModel.Design.Serialization;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace convert2ascii
{
    internal class Program
    {
        const string SOURCE = "őŐűŰ€→—\"“”„'‘’`*?|";
        const string TARGET = "ôÔûÛE--------------";
        static int succesful = 0, failed = 0;

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
            StartingMessage();

            if (args.Length < 1)
            {
                Console.WriteLine("Nem adtál meg útvonalat, vagy fájlnevet!");
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
                Console.WriteLine("Nem létezik a megadott útvonal, vagy fájlnév!");
            }
            Console.ReadKey();
        }

        private static string ConvertToASCII(string name)
        {
            name = name.Replace("EXTERNAL_", "");
            name = name.Replace("ΑΠ", "Re");
            bool previous = false;
            StringBuilder sb = new StringBuilder();
            int index;
            char oc;
            foreach (char c in name)
            {
                if (previous && c == ' ') continue;
                previous = c == ' ';
                index = SOURCE.IndexOf(c);
                oc = index >= 0 ? TARGET[index] : c;
                sb.Append(oc > 254 ? '_' : oc);
            }
            return sb.ToString();
        }

        private static string IncreaseNumberingIfAlreadyExists(string currentName)
        {
            string filename = Path.GetFileNameWithoutExtension(currentName);
            if (filename.Length < 3 || filename.Substring(filename.Length - 3, 1) != "_")
            {
                return Path.Combine(Path.GetDirectoryName(currentName), filename + "_01" + Path.GetExtension(currentName));

            }
            string result = "";
            do
            {
                int numero;
                numero = int.TryParse(filename.Substring(filename.Length - 2, 2), out numero) ? numero : 0;
                filename = filename.Substring(0, filename.Length - 2) + string.Format("{0:00}", ++numero);
                result = Path.Combine(Path.GetDirectoryName(currentName), filename + Path.GetExtension(currentName));
            } while (File.Exists(result));
            return result;
        }

        private static void RenameOneFile(string oldFullPath)
        {
            string oldFileName = Path.GetFileName(oldFullPath);
            string newFileName = ConvertToASCII(oldFileName);
            if (newFileName.Equals(oldFileName)) return;

            string newFullPath = Path.Combine(Path.GetDirectoryName(oldFullPath), newFileName);
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
                Console.Write(new string(' ', Console.WindowWidth-1));
                Console.SetCursorPosition(0, y);
                Console.Write($"{index--} {entry}");
                Console.SetCursorPosition(0, y);
                RenameOneFile(entry);
            }

            for (index = dirs.Count() - 1; index >= 0; --index)
            {
                y = Console.CursorTop;
                Console.Write(new string(' ', Console.WindowWidth-1));
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

            Console.WriteLine($"Átnevezés:  {oldPath}");
            try
            {
                Directory.Move(oldPath, newPath);
                Console.WriteLine($"            {newPath}");
                ++succesful;
            }
            catch (Exception)
            {
                Console.WriteLine($"Sikertelen: {newPath}");
                ++failed;
            }
        }
    }
}
