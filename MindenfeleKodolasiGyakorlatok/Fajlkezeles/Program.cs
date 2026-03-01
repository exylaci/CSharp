using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fajlkezeles
{
    internal class Program
    {
        private int myVar;

        public int MyProperty
        {
            get { return myVar; }
            set { myVar = value; }
        }


        public const string filenameInput = ".\\szovegfile.txt";
        //public const string[] convertionTable = {  "áéíóöőúüű ", "aeiooouuu_"};      //hibás:   const -> static readonly
        public static readonly string[] convertionTable = { "áéíóöőúüű ", "aeiooouuu_" };

        public struct Person
        {
            public string Name { get; set; }
            public int Id { get; set; }
            public string username { get; set; }
            public string password { get; set; }
        }

        static void Main(string[] args)
        {
            if (!Directory.Exists(Path.GetDirectoryName(filenameInput)))
            {
                ConsoleColor original = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Nincs ilyen könyvtár, útvonal!");
                Console.ForegroundColor = original;
                return;
            }
            if (!File.Exists(filenameInput))
            {
                Console.WriteLine("Nincs ilyen fájl!");
                return;
            }

            string[] data = ReadFromFile(filenameInput);
            string[] data2 = File.ReadAllLines(filenameInput, Encoding.UTF8);
            string data3 = File.ReadAllText(filenameInput);

            Person[] people = new Person[data.Length / 2];
            for (int i = 0, j = 0; (i + 1) < data.Length && j < people.Length; i += 2, ++j)
            {
                people[j].Name = data[i];
                people[j].Id = Convert.ToInt32(data[i + 1]);
            }

            TextConverter(people);                      //tömb primitív típus, amit változtat a függvény, az itt is változik



            string filenameOutput = filenameInput;
            WriteToFile(filenameOutput, people);
        }



        private static void TextConverter(Person[] people)
        {
            for (int index = 0; index < people.Length; ++index)
            {
                people[index].Name = people[index].Name.Trim().ToLower();
                for (int i = 0; i < convertionTable[0].Length; ++i)
                {
                    people[index].Name = people[index].Name.Replace(convertionTable[0][i], convertionTable[1][i]);
                }
            }
        }

        static string[] ReadFromFile(string filename)
        {
            StreamReader streamReader = new StreamReader(filename, Encoding.UTF8);
            int counter = 0;
            while (!streamReader.EndOfStream)
            {
                streamReader.ReadLine();
                ++counter;

            }
            streamReader.Close();

            string[] result = new string[counter];
            streamReader = new StreamReader(filename, Encoding.UTF8);
            for (int i = 0; i < counter && !streamReader.EndOfStream; ++i)
            {
                result[i] = streamReader.ReadLine();
            }
            streamReader.Close();
            return result;
        }

        private static void WriteToFile(string filename, Person[] people)
        {
            StreamWriter streamWriter = new StreamWriter(filename, false, Encoding.UTF8);
            foreach (Person person in people)
            {
                streamWriter.WriteLine(person.Id + ";" + person.Name);
            }
            streamWriter.Close();
        }

    }
}
