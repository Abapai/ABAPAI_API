using System;
using System.Collections.Generic;
using System.Globalization;
using System.Security.Cryptography;
using System.Text;

namespace ABAPAI.Domain.Utils
{
    public static class Utils
    {
        public static bool IsValid(this object obj)
        {
            if (obj is null || obj is 0 || obj is "imagepadrao.jpg")
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public static string GetHash(this string password)
        {
            UnicodeEncoding unicodeEncoding = new UnicodeEncoding();
            byte[] hashBytes;
            using(HashAlgorithm hash = SHA1.Create())
            {
                hashBytes = hash.ComputeHash(unicodeEncoding.GetBytes(password));
            }
            var hashValue = new StringBuilder(hashBytes.Length * 2);
            foreach(byte b in hashBytes)
            {
                hashValue.AppendFormat(CultureInfo.InvariantCulture, "{0:X2}", b);
            }

            return hashValue.ToString();
        }
    }
}
