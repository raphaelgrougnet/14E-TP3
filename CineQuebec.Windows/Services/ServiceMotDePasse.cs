using CineQuebec.Windows.Domain;
using Konscious.Security.Cryptography;
using System.Security.Cryptography;
using System.Text;

namespace CineQuebec.Windows.Services
{
    public static class ServiceMotDePasse
    {
        private static Random rnd = new Random();


        public static byte[] CreerSALT()
        {
            var buffer = new byte[16];
            var rng = new RNGCryptoServiceProvider();
            rng.GetBytes(buffer);
            return buffer;
        }


        public static byte[] HacherMotDePasse(string password, byte[] salt)
        {
            var argon2 = new Argon2id(Encoding.UTF8.GetBytes(password))
            {
                Salt = salt,
                DegreeOfParallelism = 8,
                Iterations = 4,
                MemorySize = 1024 * 1024
            };

            return argon2.GetBytes(16);
        }

        public static bool EstMotDePasseCorrespond(this Abonne abonne, string password)
        {

            return abonne.MotDePasse.SequenceEqual(HacherMotDePasse(password, abonne.Salt));
        }
    }
}
