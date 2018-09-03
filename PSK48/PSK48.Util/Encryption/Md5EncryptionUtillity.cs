using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace PSK48.Util.Encryption
{
    public static class Md5EncryptionUtillity
    {
        public static string GenerateMd5Payload(params string[] payload)
        {
            var payloadConcat = string.Concat(payload);

            using (var md5 = MD5.Create())
            {
                byte[] inputBytes = Encoding.ASCII.GetBytes(payloadConcat);
                byte[] hash = md5.ComputeHash(inputBytes);
                var sb = new StringBuilder();
                for (int i = 0; i < hash.Length; i++)
                    sb.Append(hash[i].ToString("X2"));
                return sb.ToString();
            }
        }
    }
}
