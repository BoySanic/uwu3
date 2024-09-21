using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.ComponentModel.Design.Serialization;
namespace UwU3_Library
{
    public class AsymmetricKey
    {
        public string nickName;
        public string base64PubKey;
        public RSA rsaKey;

        public AsymmetricKey()
        {
            rsaKey = RSA.Create(2048);
            base64PubKey = Convert.ToBase64String(rsaKey.ExportRSAPublicKey());
        }
        public AsymmetricKey(string base64PubKey, string nickName)
        {
            rsaKey = RSA.Create(2048);
            this.base64PubKey = base64PubKey;
            this.nickName = nickName;
            var pubKeyBytes = Convert.FromBase64String(base64PubKey);
            int bytesRead = 0;
            rsaKey.ImportRSAPublicKey(pubKeyBytes, out _);
        }
        public string GenerateHeader(Aes Key)
        {
            //byte[] aesKey = new byte[Key.Key.Length];
            //Buffer.BlockCopy(Key.Key, 0, aesKey, 0, Key.Key.Length);

            byte[] encryptedAesKey = rsaKey.Encrypt(Key.Key, RSAEncryptionPadding.OaepSHA256);
            return Convert.ToBase64String(encryptedAesKey);

        }
    }
}
