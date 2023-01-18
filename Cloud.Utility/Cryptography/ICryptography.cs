using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cloud.Utility.Cryptography
{
    public interface ICryptography
    {
        public Encoding DefaultEncoding { get; set; }
        public byte[] Encrypt(byte[] source, byte[] key);
        public byte[] Decrypt(byte[] source, byte[] key);
    }
}
