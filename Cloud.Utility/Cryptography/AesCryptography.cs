using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Cloud.Utility.Cryptography
{
    public class AesCryptography : ICryptography
    {
        public AesCryptography() { }

        private const string IV = "worldcloudisbest";

        public Encoding DefaultEncoding { get; set; } = Encoding.UTF8;
        public static AesCryptography Share { get; } = new AesCryptography();
        public static AesCryptography Create() => new AesCryptography();
        public byte[] Decrypt(byte[] source, byte[] key)
        {
            if(key.Length != 32) throw new KeyLengthException();
            var aes = Aes.Create();
            aes.Key = key;
            aes.Mode = CipherMode.ECB;
            aes.Padding = PaddingMode.PKCS7;
            aes.IV = DefaultEncoding.GetBytes(IV);
            var transform = aes.CreateDecryptor();
            var result = transform.TransformFinalBlock(source, 0, source.Length);
            return result;
        }
        public byte[] Encrypt(byte[] source, byte[] key)
        {
            if (key.Length != 32) throw new KeyLengthException();
            var aes = Aes.Create();
            aes.Key = key;
            aes.Mode = CipherMode.ECB;
            aes.Padding = PaddingMode.PKCS7;
            aes.IV = DefaultEncoding.GetBytes(IV);
            var transform = aes.CreateEncryptor();
            var result = transform.TransformFinalBlock(source, 0, source.Length);
            return result;
        }
    }
}
