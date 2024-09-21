using UwU3_Library;
using System.Security.Cryptography;
namespace uwu3_console
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Conversation> conversationList = new List<Conversation>();
            AsymmetricKey selfKey = new AsymmetricKey();
            for (int i = 0; i < args.Length; i++)
            {
                if (args[i].ToLower() == "conversation")
                {
                    if (args[i + 1].ToLower() == "start")
                    {
                        conversationList.Add(new Conversation(args[i + 2]));
                    }
                    if (args[i + 1].ToLower() == "add")
                    {
                        var conversation = new Conversation(args[i + 2]);
                        var decryptedAesKeyAndIV = selfKey.rsaKey.Decrypt(Convert.FromBase64String(args[i + 3]), RSAEncryptionPadding.OaepSHA256);
                        Buffer.BlockCopy(decryptedAesKeyAndIV, 0, conversation.EncryptionKey.Key.Key, 0, 32);
                        Buffer.BlockCopy(decryptedAesKeyAndIV, 32, conversation.EncryptionKey.Key.IV, 0, 16);
                        conversationList.Add(conversation);
                    }
                }

            }
        }
    }
}
