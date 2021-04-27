using ABAPAI.Domain.Enums;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
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

        public static string GetJWTStaff(string id, Roles role)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("tokensecreto");
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[] {
                    new Claim(ClaimTypes.NameIdentifier, id),
                    new Claim(ClaimTypes.Role, role.ToString())
                }),
                Expires = DateTime.UtcNow.AddHours(12),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}
