using System.Security.Cryptography;
using System.Text;

namespace BilgeAdam.NTier.ERP.Common
{
    public static class StringExtensions
    {
        public static string Hash(this string clearText)
        {
            using (var sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(clearText));
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("X2"));
                }
                return builder.ToString();
            }
        }
    }
}