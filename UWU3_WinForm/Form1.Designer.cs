using UwU3_Library;
namespace UWU3_WinForm
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            richTextBox1 = new RichTextBox();
            button1 = new Button();
            label2 = new Label();
            button2 = new Button();
            button3 = new Button();
            richTextBox2 = new RichTextBox();
            button4 = new Button();
            listboxRecipients = new CheckedListBox();
            label3 = new Label();
            label4 = new Label();
            txtNickname = new TextBox();
            label5 = new Label();
            richTxtBoxPubKey = new RichTextBox();
            label6 = new Label();
            btnAddRecipient = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(36, 27);
            label1.Name = "label1";
            label1.Size = new Size(222, 25);
            label1.TabIndex = 0;
            label1.Text = "Message Including Header";
            // 
            // richTextBox1
            // 
            richTextBox1.Location = new Point(36, 55);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new Size(598, 305);
            richTextBox1.TabIndex = 1;
            richTextBox1.Text = "";
            // 
            // button1
            // 
            button1.Location = new Point(486, 366);
            button1.Name = "button1";
            button1.Size = new Size(148, 34);
            button1.TabIndex = 2;
            button1.Text = "Decrypt";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(911, 9);
            label2.Name = "label2";
            label2.Size = new Size(144, 25);
            label2.TabIndex = 3;
            label2.Text = "Asymmetric  Key";
            // 
            // button2
            // 
            button2.Location = new Point(911, 37);
            button2.Name = "button2";
            button2.Size = new Size(178, 34);
            button2.TabIndex = 4;
            button2.Text = "Reveal Public";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Location = new Point(911, 78);
            button3.Name = "button3";
            button3.Size = new Size(178, 34);
            button3.TabIndex = 5;
            button3.Text = "Reveal Public PEM";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // richTextBox2
            // 
            richTextBox2.Location = new Point(36, 472);
            richTextBox2.Name = "richTextBox2";
            richTextBox2.Size = new Size(598, 326);
            richTextBox2.TabIndex = 6;
            richTextBox2.Text = "";
            // 
            // button4
            // 
            button4.Location = new Point(486, 816);
            button4.Name = "button4";
            button4.Size = new Size(148, 34);
            button4.TabIndex = 7;
            button4.Text = "Encrypt";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // listboxRecipients
            // 
            listboxRecipients.FormattingEnabled = true;
            listboxRecipients.Location = new Point(639, 478);
            listboxRecipients.Name = "listboxRecipients";
            listboxRecipients.Size = new Size(180, 312);
            listboxRecipients.TabIndex = 8;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(639, 441);
            label3.Name = "label3";
            label3.Size = new Size(91, 25);
            label3.TabIndex = 9;
            label3.Text = "Recipients";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(36, 441);
            label4.Name = "label4";
            label4.Size = new Size(153, 25);
            label4.TabIndex = 10;
            label4.Text = "Plaintext Message";
            // 
            // txtNickname
            // 
            txtNickname.Location = new Point(849, 478);
            txtNickname.Name = "txtNickname";
            txtNickname.Size = new Size(252, 31);
            txtNickname.TabIndex = 11;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(849, 450);
            label5.Name = "label5";
            label5.Size = new Size(166, 25);
            label5.TabIndex = 12;
            label5.Text = "Recipient Nickname";
            // 
            // richTxtBoxPubKey
            // 
            richTxtBoxPubKey.Location = new Point(850, 543);
            richTxtBoxPubKey.Name = "richTxtBoxPubKey";
            richTxtBoxPubKey.Size = new Size(251, 247);
            richTxtBoxPubKey.TabIndex = 13;
            richTxtBoxPubKey.Text = "";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(850, 515);
            label6.Name = "label6";
            label6.Size = new Size(168, 25);
            label6.TabIndex = 14;
            label6.Text = "Recipient Public Key";
            // 
            // btnAddRecipient
            // 
            btnAddRecipient.Location = new Point(989, 796);
            btnAddRecipient.Name = "btnAddRecipient";
            btnAddRecipient.Size = new Size(112, 34);
            btnAddRecipient.TabIndex = 15;
            btnAddRecipient.Text = "Add";
            btnAddRecipient.UseVisualStyleBackColor = true;
            btnAddRecipient.Click += btnAddRecipient_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1196, 952);
            Controls.Add(btnAddRecipient);
            Controls.Add(label6);
            Controls.Add(richTxtBoxPubKey);
            Controls.Add(label5);
            Controls.Add(txtNickname);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(listboxRecipients);
            Controls.Add(button4);
            Controls.Add(richTextBox2);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(label2);
            Controls.Add(button1);
            Controls.Add(richTextBox1);
            Controls.Add(label1);
            Name = "Form1";
            Text = "UwU3 Utility";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private RichTextBox richTextBox1;
        private Button button1;
        private Label label2;
        private Button button2;
        private Button button3;
        private RichTextBox richTextBox2;
        private Button button4;
        private CheckedListBox listboxRecipients;
        private Label label3;
        private Label label4;
        private TextBox txtNickname;
        private Label label5;
        private RichTextBox richTxtBoxPubKey;
        private Label label6;
        private Button btnAddRecipient;
    }
}
