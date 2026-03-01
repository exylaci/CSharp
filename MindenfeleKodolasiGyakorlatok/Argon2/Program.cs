using MindenfeleKodolasiGyakorlatok;
using Org.BouncyCastle.Bcpg.Sig;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;

//NuGet packages:
//  Konscious.Security.Cryptography.Argon2
//  Portable.BouncyCastle

namespace Argon2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            UserService userService = new UserService();
            while (true)
            {
                Console.WriteLine("\n========= Hashelés demó ==========");
                Console.WriteLine("1 - Regisztráció");
                Console.WriteLine("2 - Bejelentkezés");
                Console.WriteLine("3 - Userek listázása");
                Console.WriteLine("4 - Kilépés");
                Console.WriteLine("5 - Benchmark Argon2id");
                Console.WriteLine("6 - Mini demo brute force attack");
                Console.WriteLine("7 - Argon2 vs PBKDF2 osszehasomlítás");
                Console.WriteLine("8 - Paraméterezés");

                switch (Console.ReadKey().KeyChar)
                {
                    case '1':
                        Console.Write("Őj felhasználó neve: ");
                        string newUser = Console.ReadLine();
                        Console.Write("Új jelszó:");
                        string password = Console.ReadLine();
                        userService.Register(newUser, password);
                        break;
                    case '2':
                        Console.Write("Felhasználónév: ");
                        string username = Console.ReadLine();
                        Console.Write("Új jelszó:");
                        string pass = Console.ReadLine();
                        userService.Authentication(username, pass);
                        break;
                    case '3':
                        userService.ListUsers();
                        break;
                    case '5':
                        RunBenchmark();
                        break;
                    case '6':
                        RunDemoAttack();
                        break;
                    case '7':
                        RunCompareArgon2VsPbkdf2();
                        break;
                    case '8':
                        RunParametering();
                        break;
                    default:
                        Console.WriteLine("Ilyen opció nincs!");
                        break;
                }
            }
        }

        private static void RunBenchmark()
        {
            Console.WriteLine("\n== Argon2id Benchmark ==");
            var tests = new (int memMB, int iter, int paral)[]
             {
                (16,1,1),
                (64,4,2),
                (256,6,4)
             };

            foreach (var item in tests)
            {
                SecurityServices.MemorySiz = item.memMB * 1024;
                SecurityServices.Iteration = item.iter;
                SecurityServices.Parallelism = item.paral;

                byte[] salt = SecurityServices.GenerateSalt();
                Stopwatch clock = Stopwatch.StartNew();
                SecurityServices.HashPassword("benchmark", salt);
                clock.Stop();
                Console.WriteLine($"{item.memMB} MB, {item.iter}, {item.paral} => {clock.Elapsed}");
            }
        }

        private static void RunDemoAttack()
        {
            Console.WriteLine("\n== Demo Brute force ==");
            const int tries = 10;
            Stopwatch clock = Stopwatch.StartNew();
            for (int i = 0; i < tries; ++i)
            {
                byte[] salt = SecurityServices.GenerateSalt();
                SecurityServices.HashPassword("demo", salt);
            }
            clock.Stop();
            double one = clock.Elapsed.Milliseconds / tries; ;
            Console.WriteLine($"{tries} hash elkészítése: {clock.Elapsed} 1db elkészítése {one} millisec");
        }

        private static void RunCompareArgon2VsPbkdf2()
        {
            Console.WriteLine("\n== Argon2 vs PKBDF2 ==");
            byte[] salt = SecurityServices.GenerateSalt();

            Stopwatch clock1 = Stopwatch.StartNew();
            SecurityServices.HashPassword("compare", salt);
            clock1.Stop();

            Stopwatch clock2 = Stopwatch.StartNew();
            SecurityServices.HashWidthPbkdf2("compare", salt);
            clock2.Stop();

            Console.WriteLine($"Argon2id => {clock1.Elapsed}");
            Console.WriteLine($"PKBDF2   => {clock2.Elapsed}");
        }

        private static void RunParametering()
        {
            Console.WriteLine("\n== Parameterezes ==");
            Console.WriteLine("Memori (MB): ");
            int memMB = int.Parse(Console.ReadLine());
            Console.WriteLine("Iterációk száma: ");
            int iter = int.Parse(Console.ReadLine());
            Console.WriteLine("Szálak száma: ");
            int p = int.Parse(Console.ReadLine());

            SecurityServices.MemorySiz = memMB * 1024;
            SecurityServices.Iteration = iter;
            SecurityServices.Parallelism = p;

            byte[] salt = SecurityServices.GenerateSalt();
            Stopwatch clock1 = Stopwatch.StartNew();
            SecurityServices.HashPassword("compare", salt);
            clock1.Stop();
            Console.WriteLine($"Argon2id => {clock1.Elapsed}");
        }
    }
}
