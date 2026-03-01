using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Konscious.Security.Cryptography;
using System.Security.Cryptography;
using Org.BouncyCastle.Utilities;

//NuGet packages:
//  Konscious.Security.Cryptography.Argon2
//  Portable.BouncyCastle

namespace MindenfeleKodolasiGyakorlatok
{
    internal class SecurityServices
    {
        public static int MemorySiz = 64 * 1024;
        public static int Iteration = 4;
        public static int Parallelism = 2;

        private const int SaltSize = 16;
        private const int HasLength = 32;

        public static byte[] GenerateSalt(int size = SaltSize)
        {
            byte[] salt = new byte[size];
            using (RandomNumberGenerator rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }
            return salt;
        }

        public static byte[] HashPassword(string password, byte[] salt)
        {
            Argon2id argon = new Argon2id(Encoding.UTF8.GetBytes(password))
            {
                Salt = salt,
                DegreeOfParallelism = Parallelism,
                Iterations = Iteration,
                MemorySize = MemorySiz
            };
            return argon.GetBytes(HasLength);
        }

        public static bool VerifyPassword(string password, byte[] salt, byte[] expected)
        {
            byte[] ah = HashPassword(password, salt);
            return Arrays.ConstantTimeAreEqual(ah, expected);
        }

        public static byte[] HashWidthPbkdf2(string password, byte[] salt, int iterCount = 10, int hashLen = 32)
        {
            using (Rfc2898DeriveBytes pbkdf2 = new Rfc2898DeriveBytes(password, salt, iterCount, HashAlgorithmName.SHA256))
            {
                return pbkdf2.GetBytes(hashLen);
            }

        }
    }
}
