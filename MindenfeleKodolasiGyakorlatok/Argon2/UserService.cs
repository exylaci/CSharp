using MindenfeleKodolasiGyakorlatok;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Argon2
{
    internal class UserService
    {
        private const int MaxUser = 100;
        private User[] users = new User[MaxUser];
        private int userCount = 0;

        public bool Register(string name, string password)
        {
            if (userCount >= MaxUser)
            {
                Console.WriteLine("A felhasználó tároló megtelt");
                return false;
            }
            if (FindUser(name) != null)
            {
                Console.WriteLine("Ez a felhasználó már létezik!");
                return false;
            }
            byte[] salt = SecurityServices.GenerateSalt();
            byte[] hash = SecurityServices.HashPassword(password, salt);

            users[userCount++] = new User()
            {
                Username = name,
                Salt = salt,
                PasswordHash = hash
            };
            Console.WriteLine("Sikeres regisztráció");
            return true;
        }

        public bool Authentication(string username, string password)
        {
            User u = FindUser(username);
            if (u != null)
            {
                Console.WriteLine("Nincs ilyen felhasználó!");
                return false;
            }
            bool ok = SecurityServices.VerifyPassword(password, u.Salt, u.PasswordHash);
            Console.WriteLine(ok ? "Sikeres bejelentkezés" : "Hibás jelszó!");
            return ok;
        }

        public void ListUsers()
        {
            Console.WriteLine("Regisztrált felhasználók:");
            for (int i = 0; i < users.Length; ++i)
            {
                Console.WriteLine($"{users[i].Username}");
            }
            Console.WriteLine("=============================\n");
        }

        private User FindUser(string name)
        {
            return users.FirstOrDefault(x => x.Username == name);
        }
    }
}
