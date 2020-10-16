using System;
using System.Security.Cryptography;
using System.Text;

namespace Zero_Web.Content.csharp.Zero
{
    public class HashPassword
    {

        /// <summary>
        /// Create the hash Value from the given Password/String
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>

        public string CreateHash(string text)
        {
            // SHA512 is disposable by inheritance.
            using (var sha256 = SHA256.Create())
            {
                // Send a sample text to hash.
                var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(text));
                // Get the hashed string.
                return BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
            }
        }

    }
}