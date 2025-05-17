using System.Linq;
using System.Security.Cryptography;

namespace AgendaApp.Services
{
    public static class AuthService
    {
        public static void CriarSenha(string senha, out byte[] hash, out byte[] salt)
        {
            salt = new byte[16];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }
            using (var pbkdf2 = new Rfc2898DeriveBytes(senha, salt, 10000))
            {
                hash = pbkdf2.GetBytes(32);
            }
        }

        public static bool VerificarSenha(string senha, byte[] hash, byte[] salt)
        {
            using (var pbkdf2 = new Rfc2898DeriveBytes(senha, salt, 10000))
            {
                return pbkdf2.GetBytes(32).SequenceEqual(hash);
            }
        }
    }
}
