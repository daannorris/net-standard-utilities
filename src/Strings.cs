using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Utils
{
    /// <summary>
    /// String utilities
    /// </summary>
    public class Strings
    {
        internal static readonly char[] Uppercase = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
        internal static readonly char[] Lowercase = "abcdefghijklmnopqrstuvwxyz".ToCharArray();
        internal static readonly char[] Numbers = "1234567890".ToCharArray();
        internal static readonly char[] Symbols = "@#$%&/()!?¡¿.,:;*-_{}[]+|°".ToCharArray();

        /// <summary>
        /// Generates a random string.
        /// </summary>
        /// <param name="length">The length to create the string</param>
        /// <param name="uppercase">If set to <c>true</c> use [uppercase].</param>
        /// <param name="lowercase">If set to <c>true</c> use [lowercase].</param>
        /// <param name="numbers">If set to <c>true</c> use [numbers].</param>
        /// <param name="symbols">If set to <c>true</c> use[symbols].</param>
        /// <returns>A random string</returns>
        public static string GenerateRandom(int length, bool uppercase = true, bool lowercase = true, bool numbers = true, bool symbols = true)
        {
            if (length > 0)
            {
                var data = new byte[length];
                var chars = new List<char>();

                if (uppercase)
                {
                    chars.AddRange(Uppercase);
                }

                if (lowercase)
                {
                    chars.AddRange(Lowercase);
                }

                if (numbers)
                {
                    chars.AddRange(Numbers);
                }

                if (symbols)
                {
                    chars.AddRange(Symbols);
                }

                using (var crypto = new RNGCryptoServiceProvider())
                {
                    crypto.GetBytes(data);

                    var builder = new StringBuilder(length);

                    foreach (byte b in data)
                    {
                        builder.Append(chars[b % chars.Count]);
                    }

                    return builder.ToString();
                }
            }

            return string.Empty;
        }
    }
}
