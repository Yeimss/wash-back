using System.Security.Cryptography;
using System.Text;

namespace core.Entities.Utils
{
    internal class StringHelper
    {
        public static string ComputeSha256(string input)
        {
            using var sha256 = SHA256.Create();
            var bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(input));
            return BitConverter.ToString(bytes).Replace("-", "").ToLowerInvariant();
        }
    }
}
