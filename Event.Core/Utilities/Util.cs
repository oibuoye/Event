using Hangfire.Common;
using Hangfire.States;
using Hangfire.Storage;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Event.Core.Utilities
{
    public class Util
    {
        /// <summary>
        /// Generates a Random Password
        /// respecting the given strength requirements.
        /// </summary>
        /// <param name="opts">A valid PasswordOptions object
        /// containing the password strength requirements.</param>
        /// <returns>A random password</returns>
        public static string GenerateRandomPassword(PasswordOptions opts = null)
        {
            if (opts == null) opts = new PasswordOptions()
            {
                RequiredLength = 12,
                RequiredUniqueChars = 4,
                RequireDigit = true,
                RequireLowercase = true,
                RequireNonAlphanumeric = true,
                RequireUppercase = true
            };

            string[] randomChars = new[] {
            "ABCDEFGHJKLMNOPQRSTUVWXYZ",    // uppercase 
            "abcdefghijkmnopqrstuvwxyz",    // lowercase
            "0123456789",                   // digits
            "!@$?_-"                        // non-alphanumeric
        };

            Random rand = new Random(Environment.TickCount);
            List<char> chars = new List<char>();

            if (opts.RequireUppercase)
                chars.Insert(rand.Next(0, chars.Count),
                    randomChars[0][rand.Next(0, randomChars[0].Length)]);

            if (opts.RequireLowercase)
                chars.Insert(rand.Next(0, chars.Count),
                    randomChars[1][rand.Next(0, randomChars[1].Length)]);

            if (opts.RequireDigit)
                chars.Insert(rand.Next(0, chars.Count),
                    randomChars[2][rand.Next(0, randomChars[2].Length)]);

            if (opts.RequireNonAlphanumeric)
                chars.Insert(rand.Next(0, chars.Count),
                    randomChars[3][rand.Next(0, randomChars[3].Length)]);

            for (int i = chars.Count; i < opts.RequiredLength
                || chars.Distinct().Count() < opts.RequiredUniqueChars; i++)
            {
                string rcs = randomChars[rand.Next(0, randomChars.Length)];
                chars.Insert(rand.Next(0, chars.Count),
                    rcs[rand.Next(0, rcs.Length)]);
            }

            return new string(chars.ToArray());
        }

        public static string ZeroPadUp(string value, int maxPadding, string prefix = null)
        {
            string result = value.PadLeft(maxPadding, '0');
            if (!string.IsNullOrEmpty(prefix)) { return prefix + result; }
            return result;
        }

        public static string LetsEncrypt(string input, string maggi = null)
        {
            byte[] inputArray = UTF8Encoding.UTF8.GetBytes(input);
            byte[] resultArray = null;
            using (TripleDESCryptoServiceProvider dezzProv = new TripleDESCryptoServiceProvider())
            {
                using (MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider())
                {
                    byte[] keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(maggi));

                    dezzProv.Key = keyArray;
                    dezzProv.Mode = CipherMode.ECB;
                    dezzProv.Padding = PaddingMode.PKCS7;
                    ICryptoTransform cryptor = dezzProv.CreateEncryptor();
                    resultArray = cryptor.TransformFinalBlock(inputArray, 0, inputArray.Length);
                }
            }
            return Convert.ToBase64String(resultArray, 0, resultArray.Length);
        }

        public static string LetsDecrypt(string input, string key = null)
        {
            byte[] inputArray = Convert.FromBase64String(input);
            byte[] resultArray = null;
            using (TripleDESCryptoServiceProvider tripleDES = new TripleDESCryptoServiceProvider())
            {
                using (MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider())
                {
                    byte[] keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));

                    tripleDES.Key = keyArray;
                    tripleDES.Mode = CipherMode.ECB;
                    tripleDES.Padding = PaddingMode.PKCS7;
                    ICryptoTransform decryptor = tripleDES.CreateDecryptor();
                    resultArray = decryptor.TransformFinalBlock(inputArray, 0, inputArray.Length);
                }
            }
            return UTF8Encoding.UTF8.GetString(resultArray);
        }

        public static string GenerateCode()
        {
            using (var rng = new RNGCryptoServiceProvider())
            {
                var data = new byte[16];
                rng.GetBytes(data);

                int generatedValue = Math.Abs(BitConverter.ToInt32(data, startIndex: 0));
                string str = Convert.ToBase64String(data);
                return generatedValue.ToString().Substring(0, 4);
            }
        }

    }

    public class ProlongExpirationTimeAttribute : JobFilterAttribute, IApplyStateFilter
    {

        public void OnStateUnapplied(ApplyStateContext context, IWriteOnlyTransaction transaction)
        {
            double getHangfireExpirationDay = 20d;

            context.JobExpirationTimeout = TimeSpan.FromDays(getHangfireExpirationDay);
        }

        public void OnStateApplied(ApplyStateContext context, IWriteOnlyTransaction transaction)
        {
            double getHangfireExpirationDay = 20d;

            context.JobExpirationTimeout = TimeSpan.FromDays(getHangfireExpirationDay);
        }
    }

}
