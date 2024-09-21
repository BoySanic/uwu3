using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UwU3_Library
{
    public class Conversation
    {
        public string messageURL;
        public List<AsymmetricKey> CurrentRecipients;
        public SymmetricKey EncryptionKey;
        public Conversation(string messageURL)
        {
            this.messageURL = messageURL;
            EncryptionKey = new SymmetricKey();
        }

        public int addRecipient(AsymmetricKey recipient)
        {
            if (!CurrentRecipients.Any(item => item.nickName == recipient.nickName))
            {
                CurrentRecipients.Add(recipient);
                return 0;
                //OK
            }
            else
            {
                return 1;
                //Error
            }
        }
        public int removeRecipient(string nickName)
        {
            var recipient = CurrentRecipients.FirstOrDefault(r => r.nickName == nickName);
            if (recipient != null)
            {
                CurrentRecipients.Remove(recipient);
                EncryptionKey.Rotate();
                return 0;
                //Removed, Key rotated
            }
            else
            {
                return 1;
                //Does not exist
            }
        }

    }
}
