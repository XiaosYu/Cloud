using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Cloud.Utility.Cryptography
{
	public class ShiftCryptography : ICryptography
	{
        public Encoding DefaultEncoding { get; set; } = Encoding.UTF8;

        public static ShiftCryptography Share { get; } = new ShiftCryptography();
        public static ShiftCryptography Create() => new ShiftCryptography();

        public byte[] Encrypt(byte[] source, byte[] key)
		{
			List<byte> result = new List<byte>();
			int offset = -1;
			while(true) 
			{
				foreach(var k in key) 
				{
					if (offset == source.Length - 1)
						result.Add(source[++offset] == k ? (byte)0x1 : (byte)0x0);
					else return result.ToArray();
				}
			}
		}
        public byte[] Decrypt(byte[] source, byte[] key)
        {
            List<byte> result = new List<byte>();
            int offset = -1;
            while (true)
            {
                foreach (var k in key)
                {
                    if (offset == source.Length - 1)
                        result.Add(source[++offset] != k ? (byte)0x1 : (byte)0x0);
                    else return result.ToArray();
                }
            }
        }
    }
    
    
}
