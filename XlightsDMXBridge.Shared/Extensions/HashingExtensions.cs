using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace XlightsACNBridge
{
    public static class HashingExtensions
    {
        public static string GenerateGuidFromHash(this FileInfo fileInfo, HashType type = HashType.MD5)
        {
            return new Guid(GenerateHash(fileInfo, type)).ToString();
        }
        public static string GenerateGuidFromHash(this byte[] fileInfo, HashType type = HashType.MD5)
        {
            return new Guid(GenerateHash(fileInfo, type)).ToString();
        }

		public static string GenerateMD5hash(this string input) { 
			byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
			return inputBytes.GenerateHashString(HashType.MD5);
		}

        public static string GenerateHashString(this FileInfo fileInfo, HashType type = HashType.MD5)
        {

            var ba = GenerateHash(fileInfo, type);
            StringBuilder hex = new StringBuilder(ba.Length * 2);
            foreach (byte b in ba)
                hex.AppendFormat("{0:x2}", b);
            return hex.ToString();
        }
        public static string GenerateHashString(this byte[] bytes, HashType type = HashType.MD5)
        {

            var ba = GenerateHash(bytes, type);
            StringBuilder hex = new StringBuilder(ba.Length * 2);
            foreach (byte b in ba)
                hex.AppendFormat("{0:x2}", b);
            return hex.ToString();
        }
        public enum HashType
        {
            MD5,
            SHA1,
            SHA256,
            SHA512,
            HMAC
        }
        public static byte[] GenerateHash(this FileInfo fileInfo, HashType type = HashType.MD5) {
            return GenerateHash(Encoding.Default.GetBytes(fileInfo.FullName), type);
        }

        public static byte[] GenerateHash(this byte[] bytes, HashType type = HashType.MD5)
        {
            HashAlgorithm algorithm = null;
            switch (type)
            {

                case HashType.SHA1:
                    algorithm = SHA1.Create();
                    break;
                case HashType.SHA256:
                    algorithm = SHA256.Create();
                    break;
                case HashType.HMAC:
                    algorithm = HMAC.Create();
                    break;
                case HashType.SHA512:
                    algorithm = SHA512.Create();
                    break;
                case HashType.MD5:

                default:
                    algorithm = MD5.Create();

                    break;
            }

            if (algorithm != null)
            {
                byte[] hash = algorithm.ComputeHash(bytes);
                algorithm.Dispose();
                return hash;
            }
            else return null;
        }

    }
}
