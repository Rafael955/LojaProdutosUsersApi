using System;
using System.Security.Cryptography;
using System.Text;

namespace UsersApi.Infra.Data.Helpers
{
    public static class SHA256Encrypt
    {
        public static string Encrypt(string input)
        {
            if(string.IsNullOrEmpty(input))
                throw new ArgumentNullException(nameof(input), "O valor não pode ser nulo ou vazio.");

            using (var sha256 = SHA256.Create())
            {
                var bytes = Encoding.UTF8.GetBytes(input);
                var hash = sha256.ComputeHash(bytes);

                // Converte o hash em string hexadecimal
                var sb = new StringBuilder();
                foreach (var b in hash)
                {
                    sb.Append(b.ToString("x2"));
                }

                return sb.ToString();
            }
        }
    }
}
