using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace UwU3_Library
{
    public class SymmetricKey
    {
        public Aes Key;
        public string KeyBase64;
        public string IVBase64;
        private bool _rotated = true;
        public SymmetricKey()
        {
            //New conversation
            Key = Aes.Create();
            Key.KeySize = 256;
            Key.GenerateKey();
            Key.GenerateIV();

            KeyBase64 = Convert.ToBase64String(Key.Key);
            IVBase64 = Convert.ToBase64String(Key.IV);

        }
        public SymmetricKey(string KeyBase64, string IVBase64)
        {
            //Existing Conversation, or one that originated from someone else
            Key = Aes.Create();
            Key.Key = Convert.FromBase64String(KeyBase64);
            Key.IV = Convert.FromBase64String(IVBase64);
            this.KeyBase64 = KeyBase64;
            this.IVBase64 = IVBase64;
        }
        public void Rotate()
        {
            Key = Aes.Create();
            Key.KeySize = 256;
            Key.GenerateKey();
            Key.GenerateIV();
            KeyBase64 = Convert.ToBase64String(Key.Key);
            IVBase64 = Convert.ToBase64String(Key.IV);
            _rotated = true;
        }
        public string EncryptMessage(string Message)
        {
            ICryptoTransform encryptor = Key.CreateEncryptor(Key.Key, Key.IV);
            using (MemoryStream msEncrypt = new MemoryStream())
            {
                using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                {
                    using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                    {
                        swEncrypt.Write(Message);
                    }

                }
                byte[] encrypted = msEncrypt.ToArray();
                return Convert.ToBase64String(encrypted);
            }
                
        }
        public string DecryptMessage(byte[] Message)
        {
            ICryptoTransform decryptor = Key.CreateDecryptor(Key.Key, Key.IV);
            using (MemoryStream msDecrypt = new MemoryStream(Message))
            {
                using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                {
                    using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                    {
                        return srDecrypt.ReadToEnd();
                    }

                }
                //byte[] decrypted = msDecrypt.ToArray();
               
            }

        }
        public byte[] ProduceHash()
        {
            return MD5.HashData(Key.Key);
        }
        public byte[] ProduceCombinedIVAndKey()
        {
            byte[] aesKeyAndIv = new byte[Key.Key.Length + Key.IV.Length];
            Buffer.BlockCopy(Key.Key, 0, aesKeyAndIv, 0, Key.Key.Length);
            Buffer.BlockCopy(Key.IV, 0, aesKeyAndIv, Key.Key.Length, Key.IV.Length);
            return aesKeyAndIv;
        }

    }
}
