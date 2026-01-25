using System;

namespace _1_Singleton
{
    public sealed class AppConfig
    {
        private static readonly AppConfig instance = new AppConfig();
        public string ApiBaseUrl { get; private set; }

        public AppConfig() { ApiBaseUrl = "https://api.test.hu"; }

        public static AppConfig Instance { get { return instance; } }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            AppConfig a = AppConfig.Instance;
            AppConfig b = AppConfig.Instance;

            Console.WriteLine("Ugyanaz az egy példány: " + Object.ReferenceEquals(a, b));
            Console.WriteLine(a.ApiBaseUrl);
            Console.WriteLine(a.ApiBaseUrl);

            AppConfig c = new AppConfig();                                                      //Így ne hozzunk létre mégegyet belőle!
            Console.WriteLine("\nUgyanaz az egy példány? " + Object.ReferenceEquals(a, c));
            Console.WriteLine(c.ApiBaseUrl);
        }
    }
}
