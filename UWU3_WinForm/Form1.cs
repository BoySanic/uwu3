using UwU3_Library;
using System.Security.Cryptography;
using System.Text;
namespace UWU3_WinForm
{
    public partial class Form1 : Form
    {
        private AsymmetricKey selfKey;
        private List<AsymmetricKey> recipients = new List<AsymmetricKey>();
        private Conversation c;
        public Form1()
        {
            selfKey = new AsymmetricKey();
            c = new Conversation("fakeurl");
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Conversation c1;
            string inputText = richTextBox1.Text;
            var splitLines = inputText.Split('\n');
            var decryptHash = splitLines[0];
            var decryptIV = splitLines[1];
            var decryptIVBytes = Convert.FromBase64String(decryptIV);
            for (int i = 2; i < splitLines.Length - 1; i++)
            {
                var attemptHeader = splitLines[i];
                var rawBytes = Convert.FromBase64String(attemptHeader);
                var decryptBytes = selfKey.rsaKey.Decrypt(rawBytes, RSAEncryptionPadding.OaepSHA256);
                if (Convert.ToBase64String(MD5.HashData(decryptBytes)) == decryptHash)
                {
                    c1 = new Conversation("fakeurl");
                    c1.EncryptionKey.Key.Key = decryptBytes;
                    c1.EncryptionKey.Key.IV = decryptIVBytes;
                    string plaintext = c1.EncryptionKey.DecryptMessage(Convert.FromBase64String(splitLines.Last()));
                    richTextBox2.Text = plaintext;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //reveal pubkey
            MessageBox.Show(selfKey.base64PubKey, "Your Public Key");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //reveal pubkey PEM
            MessageBox.Show(selfKey.rsaKey.ExportRSAPublicKeyPem(), "Your Public Key");

        }

        private void btnAddRecipient_Click(object sender, EventArgs e)
        {
            var nickname = txtNickname.Text;
            var pubkeyText = richTxtBoxPubKey.Text;

            if (pubkeyText.Length > 0 && nickname.Length > 0)
            {
                recipients.Add(new AsymmetricKey(pubkeyText, nickname));
                listboxRecipients.Items.Add(nickname);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //encrypt
            string message = Convert.ToBase64String(c.EncryptionKey.ProduceHash()) + "\n";
            message += Convert.ToBase64String(c.EncryptionKey.Key.IV) + "\n";
            var plaintextMessage = richTextBox2.Text;
            foreach (object checkedBox in listboxRecipients.CheckedItems)
            {

                var recipientNick = checkedBox.ToString();
                var recipientKey = recipients.FirstOrDefault(key => key.nickName == recipientNick);

                if (recipientKey != null) 
                {
                    message += recipientKey.GenerateHeader(c.EncryptionKey.Key) + "\n";
                }

            }
            var encryptedMessage = c.EncryptionKey.EncryptMessage(plaintextMessage);
            message += encryptedMessage;
            richTextBox1.Text = message;
        }
    }
}
