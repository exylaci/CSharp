using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace MindenfeleKodolasiGyakorlatok
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string passwd = TypePasswd();
            string encodedPasswd = Encoder(passwd);
            Console.WriteLine($"{passwd} -> {encodedPasswd}");

        }

        private static string TypePasswd()
        {
            Console.WriteLine("Kérem a jelszót! "); 
            string passwd = string.Empty;
            char oneCharacter;
            do
            {
                oneCharacter = Console.ReadKey(true).KeyChar;       //true, ha ne írja ki a képernyőre
                if (oneCharacter >= 32)
                {
                    passwd += oneCharacter;
                }
                else if (oneCharacter == 8 && passwd.Length > 0)
                {
                    passwd = passwd.Remove(passwd.Length - 1);
                }
            }
            while (oneCharacter != 13);
            return passwd;
        }

        private static string Encoder(String password)
        {
            SHA1CryptoServiceProvider sha256 = new SHA1CryptoServiceProvider();
            byte[] passwdBytes = Encoding.UTF8.GetBytes(password ?? "");            //?? "" -> ha a paraméter=null kivédésére
            byte[] shaBytes = sha256.ComputeHash(passwdBytes);
            string shaPasswd = BitConverter.ToString(shaBytes).Replace("-", "").ToLower();
            return shaPasswd;
            // egybeírva:
            // return BitConverter.ToString(new SHA1CryptoServiceProvider().ComputeHash(Encoding.UTF8.GetBytes(password ?? ""))).Replace("-", "").ToLower(); ;
        }

    }
}
