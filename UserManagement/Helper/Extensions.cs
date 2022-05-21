using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace UserManagement.Helper
{
    public static class Extensions
    {
        public static string ToMD5(this string value)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] hashData = md5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(value));
            StringBuilder build = new StringBuilder();
            for (int i = 0; i < hashData.Length; i++)
            {
                build.Append(hashData[i].ToString("x2"));
            }
            return build.ToString();
        }
    }
}