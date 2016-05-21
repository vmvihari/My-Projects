namespace SecureChatClient
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnDisconnect = new System.Windows.Forms.Button();
            this.lblLog = new System.Windows.Forms.Label();
            this.lblClientName = new System.Windows.Forms.Label();
            this.txtClientName = new System.Windows.Forms.TextBox();
            this.txtLog = new System.Windows.Forms.TextBox();
            this.lblIpAddress = new System.Windows.Forms.Label();
            this.txtIpAddress = new System.Windows.Forms.TextBox();
            this.btnConnect = new System.Windows.Forms.Button();
            this.lblMode = new System.Windows.Forms.Label();
            this.cmbMode = new System.Windows.Forms.ComboBox();
            this.btnMode = new System.Windows.Forms.Button();
            this.lblFactors = new System.Windows.Forms.Label();
            this.txtFactor1 = new System.Windows.Forms.TextBox();
            this.txtFactor2 = new System.Windows.Forms.TextBox();
            this.btnGenerateKey = new System.Windows.Forms.Button();
            this.lblEncryptKey = new System.Windows.Forms.Label();
            this.txtEncryptKey = new System.Windows.Forms.TextBox();
            this.lblDecryptKey = new System.Windows.Forms.Label();
            this.txtDecryptKey = new System.Windows.Forms.TextBox();
            this.lblMessage = new System.Windows.Forms.Label();
            this.txtMessage = new System.Windows.Forms.TextBox();
            this.btnEncrypt = new System.Windows.Forms.Button();
            this.btnSend = new System.Windows.Forms.Button();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnDisconnect
            // 
            this.btnDisconnect.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnDisconnect.FlatAppearance.BorderSize = 0;
            this.btnDisconnect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDisconnect.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDisconnect.ForeColor = System.Drawing.Color.White;
            this.btnDisconnect.Location = new System.Drawing.Point(318, 143);
            this.btnDisconnect.Margin = new System.Windows.Forms.Padding(4);
            this.btnDisconnect.Name = "btnDisconnect";
            this.btnDisconnect.Size = new System.Drawing.Size(141, 28);
            this.btnDisconnect.TabIndex = 36;
            this.btnDisconnect.Text = "Disconnect";
            this.btnDisconnect.UseVisualStyleBackColor = false;
            this.btnDisconnect.Click += new System.EventHandler(this.btnDisconnect_Click_1);
            // 
            // lblLog
            // 
            this.lblLog.AutoSize = true;
            this.lblLog.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLog.Location = new System.Drawing.Point(23, 214);
            this.lblLog.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblLog.Name = "lblLog";
            this.lblLog.Size = new System.Drawing.Size(44, 19);
            this.lblLog.TabIndex = 35;
            this.lblLog.Text = "Log:";
            // 
            // lblClientName
            // 
            this.lblClientName.AutoSize = true;
            this.lblClientName.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblClientName.Location = new System.Drawing.Point(23, 90);
            this.lblClientName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblClientName.Name = "lblClientName";
            this.lblClientName.Size = new System.Drawing.Size(108, 19);
            this.lblClientName.TabIndex = 34;
            this.lblClientName.Text = "Client Name:";
            // 
            // txtClientName
            // 
            this.txtClientName.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtClientName.Location = new System.Drawing.Point(149, 87);
            this.txtClientName.Margin = new System.Windows.Forms.Padding(4);
            this.txtClientName.Name = "txtClientName";
            this.txtClientName.Size = new System.Drawing.Size(310, 27);
            this.txtClientName.TabIndex = 33;
            // 
            // txtLog
            // 
            this.txtLog.Location = new System.Drawing.Point(149, 213);
            this.txtLog.Margin = new System.Windows.Forms.Padding(4);
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtLog.Size = new System.Drawing.Size(310, 143);
            this.txtLog.TabIndex = 32;
            // 
            // lblIpAddress
            // 
            this.lblIpAddress.AutoSize = true;
            this.lblIpAddress.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIpAddress.Location = new System.Drawing.Point(23, 33);
            this.lblIpAddress.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblIpAddress.Name = "lblIpAddress";
            this.lblIpAddress.Size = new System.Drawing.Size(93, 19);
            this.lblIpAddress.TabIndex = 31;
            this.lblIpAddress.Text = "IP Address:";
            // 
            // txtIpAddress
            // 
            this.txtIpAddress.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIpAddress.Location = new System.Drawing.Point(149, 30);
            this.txtIpAddress.Margin = new System.Windows.Forms.Padding(4);
            this.txtIpAddress.Name = "txtIpAddress";
            this.txtIpAddress.Size = new System.Drawing.Size(310, 27);
            this.txtIpAddress.TabIndex = 30;
            // 
            // btnConnect
            // 
            this.btnConnect.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnConnect.FlatAppearance.BorderSize = 0;
            this.btnConnect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConnect.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConnect.ForeColor = System.Drawing.Color.White;
            this.btnConnect.Location = new System.Drawing.Point(149, 143);
            this.btnConnect.Margin = new System.Windows.Forms.Padding(4);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(141, 28);
            this.btnConnect.TabIndex = 29;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = false;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click_1);
            // 
            // lblMode
            // 
            this.lblMode.AutoSize = true;
            this.lblMode.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMode.Location = new System.Drawing.Point(23, 398);
            this.lblMode.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMode.Name = "lblMode";
            this.lblMode.Size = new System.Drawing.Size(71, 19);
            this.lblMode.TabIndex = 37;
            this.lblMode.Text = "Scheme:";
            // 
            // cmbMode
            // 
            this.cmbMode.FormattingEnabled = true;
            this.cmbMode.Location = new System.Drawing.Point(149, 391);
            this.cmbMode.Name = "cmbMode";
            this.cmbMode.Size = new System.Drawing.Size(310, 24);
            this.cmbMode.TabIndex = 38;
            // 
            // btnMode
            // 
            this.btnMode.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnMode.FlatAppearance.BorderSize = 0;
            this.btnMode.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMode.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMode.ForeColor = System.Drawing.Color.White;
            this.btnMode.Location = new System.Drawing.Point(149, 447);
            this.btnMode.Margin = new System.Windows.Forms.Padding(4);
            this.btnMode.Name = "btnMode";
            this.btnMode.Size = new System.Drawing.Size(141, 28);
            this.btnMode.TabIndex = 39;
            this.btnMode.Text = "Set Scheme";
            this.btnMode.UseVisualStyleBackColor = false;
            this.btnMode.Click += new System.EventHandler(this.btnMode_Click);
            // 
            // lblFactors
            // 
            this.lblFactors.AutoSize = true;
            this.lblFactors.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFactors.Location = new System.Drawing.Point(568, 33);
            this.lblFactors.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFactors.Name = "lblFactors";
            this.lblFactors.Size = new System.Drawing.Size(72, 19);
            this.lblFactors.TabIndex = 41;
            this.lblFactors.Text = "Factors:";
            // 
            // txtFactor1
            // 
            this.txtFactor1.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFactor1.Location = new System.Drawing.Point(696, 30);
            this.txtFactor1.Margin = new System.Windows.Forms.Padding(4);
            this.txtFactor1.Name = "txtFactor1";
            this.txtFactor1.Size = new System.Drawing.Size(100, 27);
            this.txtFactor1.TabIndex = 40;
            // 
            // txtFactor2
            // 
            this.txtFactor2.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFactor2.Location = new System.Drawing.Point(813, 30);
            this.txtFactor2.Margin = new System.Windows.Forms.Padding(4);
            this.txtFactor2.Name = "txtFactor2";
            this.txtFactor2.Size = new System.Drawing.Size(100, 27);
            this.txtFactor2.TabIndex = 42;
            // 
            // btnGenerateKey
            // 
            this.btnGenerateKey.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnGenerateKey.FlatAppearance.BorderSize = 0;
            this.btnGenerateKey.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGenerateKey.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGenerateKey.ForeColor = System.Drawing.Color.White;
            this.btnGenerateKey.Location = new System.Drawing.Point(930, 30);
            this.btnGenerateKey.Margin = new System.Windows.Forms.Padding(4);
            this.btnGenerateKey.Name = "btnGenerateKey";
            this.btnGenerateKey.Size = new System.Drawing.Size(141, 28);
            this.btnGenerateKey.TabIndex = 43;
            this.btnGenerateKey.Text = "Generate Key";
            this.btnGenerateKey.UseVisualStyleBackColor = false;
            this.btnGenerateKey.Click += new System.EventHandler(this.btnGenerateKey_Click);
            // 
            // lblEncryptKey
            // 
            this.lblEncryptKey.AutoSize = true;
            this.lblEncryptKey.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEncryptKey.Location = new System.Drawing.Point(570, 146);
            this.lblEncryptKey.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblEncryptKey.Name = "lblEncryptKey";
            this.lblEncryptKey.Size = new System.Drawing.Size(106, 19);
            this.lblEncryptKey.TabIndex = 45;
            this.lblEncryptKey.Text = "Encrypt Key:";
            // 
            // txtEncryptKey
            // 
            this.txtEncryptKey.Enabled = false;
            this.txtEncryptKey.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEncryptKey.Location = new System.Drawing.Point(696, 143);
            this.txtEncryptKey.Margin = new System.Windows.Forms.Padding(4);
            this.txtEncryptKey.Name = "txtEncryptKey";
            this.txtEncryptKey.PasswordChar = '*';
            this.txtEncryptKey.Size = new System.Drawing.Size(375, 27);
            this.txtEncryptKey.TabIndex = 44;
            // 
            // lblDecryptKey
            // 
            this.lblDecryptKey.AutoSize = true;
            this.lblDecryptKey.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDecryptKey.Location = new System.Drawing.Point(570, 202);
            this.lblDecryptKey.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDecryptKey.Name = "lblDecryptKey";
            this.lblDecryptKey.Size = new System.Drawing.Size(106, 19);
            this.lblDecryptKey.TabIndex = 47;
            this.lblDecryptKey.Text = "Decrypt Key:";
            // 
            // txtDecryptKey
            // 
            this.txtDecryptKey.Enabled = false;
            this.txtDecryptKey.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDecryptKey.Location = new System.Drawing.Point(696, 199);
            this.txtDecryptKey.Margin = new System.Windows.Forms.Padding(4);
            this.txtDecryptKey.Name = "txtDecryptKey";
            this.txtDecryptKey.PasswordChar = '*';
            this.txtDecryptKey.Size = new System.Drawing.Size(375, 27);
            this.txtDecryptKey.TabIndex = 46;
            // 
            // lblMessage
            // 
            this.lblMessage.AutoSize = true;
            this.lblMessage.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMessage.Location = new System.Drawing.Point(570, 261);
            this.lblMessage.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(78, 19);
            this.lblMessage.TabIndex = 49;
            this.lblMessage.Text = "Message:";
            // 
            // txtMessage
            // 
            this.txtMessage.Location = new System.Drawing.Point(696, 260);
            this.txtMessage.Margin = new System.Windows.Forms.Padding(4);
            this.txtMessage.Multiline = true;
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtMessage.Size = new System.Drawing.Size(375, 152);
            this.txtMessage.TabIndex = 48;
            // 
            // btnEncrypt
            // 
            this.btnEncrypt.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnEncrypt.FlatAppearance.BorderSize = 0;
            this.btnEncrypt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEncrypt.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEncrypt.ForeColor = System.Drawing.Color.White;
            this.btnEncrypt.Location = new System.Drawing.Point(696, 443);
            this.btnEncrypt.Margin = new System.Windows.Forms.Padding(4);
            this.btnEncrypt.Name = "btnEncrypt";
            this.btnEncrypt.Size = new System.Drawing.Size(170, 28);
            this.btnEncrypt.TabIndex = 51;
            this.btnEncrypt.Text = "Encrypt";
            this.btnEncrypt.UseVisualStyleBackColor = false;
            this.btnEncrypt.Click += new System.EventHandler(this.btnEncrypt_Click);
            // 
            // btnSend
            // 
            this.btnSend.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnSend.FlatAppearance.BorderSize = 0;
            this.btnSend.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSend.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSend.ForeColor = System.Drawing.Color.White;
            this.btnSend.Location = new System.Drawing.Point(901, 443);
            this.btnSend.Margin = new System.Windows.Forms.Padding(4);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(170, 28);
            this.btnSend.TabIndex = 52;
            this.btnSend.Text = "Send";
            this.btnSend.UseVisualStyleBackColor = false;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // btnGenerate
            // 
            this.btnGenerate.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnGenerate.FlatAppearance.BorderSize = 0;
            this.btnGenerate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGenerate.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGenerate.ForeColor = System.Drawing.Color.White;
            this.btnGenerate.Location = new System.Drawing.Point(696, 87);
            this.btnGenerate.Margin = new System.Windows.Forms.Padding(4);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(141, 28);
            this.btnGenerate.TabIndex = 53;
            this.btnGenerate.Text = "Generate Key";
            this.btnGenerate.UseVisualStyleBackColor = false;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1112, 553);
            this.Controls.Add(this.btnGenerate);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.btnEncrypt);
            this.Controls.Add(this.lblMessage);
            this.Controls.Add(this.txtMessage);
            this.Controls.Add(this.lblDecryptKey);
            this.Controls.Add(this.txtDecryptKey);
            this.Controls.Add(this.lblEncryptKey);
            this.Controls.Add(this.txtEncryptKey);
            this.Controls.Add(this.btnGenerateKey);
            this.Controls.Add(this.txtFactor2);
            this.Controls.Add(this.lblFactors);
            this.Controls.Add(this.txtFactor1);
            this.Controls.Add(this.btnMode);
            this.Controls.Add(this.cmbMode);
            this.Controls.Add(this.lblMode);
            this.Controls.Add(this.btnDisconnect);
            this.Controls.Add(this.lblLog);
            this.Controls.Add(this.lblClientName);
            this.Controls.Add(this.txtClientName);
            this.Controls.Add(this.txtLog);
            this.Controls.Add(this.lblIpAddress);
            this.Controls.Add(this.txtIpAddress);
            this.Controls.Add(this.btnConnect);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnDisconnect;
        private System.Windows.Forms.Label lblLog;
        private System.Windows.Forms.Label lblClientName;
        private System.Windows.Forms.TextBox txtClientName;
        private System.Windows.Forms.TextBox txtLog;
        private System.Windows.Forms.Label lblIpAddress;
        private System.Windows.Forms.TextBox txtIpAddress;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Label lblMode;
        private System.Windows.Forms.ComboBox cmbMode;
        private System.Windows.Forms.Button btnMode;
        private System.Windows.Forms.Label lblFactors;
        private System.Windows.Forms.TextBox txtFactor1;
        private System.Windows.Forms.TextBox txtFactor2;
        private System.Windows.Forms.Button btnGenerateKey;
        private System.Windows.Forms.Label lblEncryptKey;
        private System.Windows.Forms.TextBox txtEncryptKey;
        private System.Windows.Forms.Label lblDecryptKey;
        private System.Windows.Forms.TextBox txtDecryptKey;
        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.TextBox txtMessage;
        private System.Windows.Forms.Button btnEncrypt;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.Button btnGenerate;
    }
}

