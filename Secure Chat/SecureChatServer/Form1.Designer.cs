namespace SecureChatServer
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
            this.lblLog = new System.Windows.Forms.Label();
            this.txtLog = new System.Windows.Forms.TextBox();
            this.lblIpAddress = new System.Windows.Forms.Label();
            this.btnStartServer = new System.Windows.Forms.Button();
            this.txtIpAddress = new System.Windows.Forms.TextBox();
            this.txtScheme = new System.Windows.Forms.TextBox();
            this.lblScheme = new System.Windows.Forms.Label();
            this.btnSend = new System.Windows.Forms.Button();
            this.btnEncrypt = new System.Windows.Forms.Button();
            this.lblMessage = new System.Windows.Forms.Label();
            this.txtMessage = new System.Windows.Forms.TextBox();
            this.lblDecryptKey = new System.Windows.Forms.Label();
            this.txtDecryptKey = new System.Windows.Forms.TextBox();
            this.lblEncryptKey = new System.Windows.Forms.Label();
            this.txtEncryptKey = new System.Windows.Forms.TextBox();
            this.btnGenerateKey = new System.Windows.Forms.Button();
            this.txtFactor2 = new System.Windows.Forms.TextBox();
            this.lblFactors = new System.Windows.Forms.Label();
            this.txtFactor1 = new System.Windows.Forms.TextBox();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblLog
            // 
            this.lblLog.AutoSize = true;
            this.lblLog.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLog.Location = new System.Drawing.Point(26, 85);
            this.lblLog.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblLog.Name = "lblLog";
            this.lblLog.Size = new System.Drawing.Size(44, 19);
            this.lblLog.TabIndex = 32;
            this.lblLog.Text = "Log:";
            // 
            // txtLog
            // 
            this.txtLog.Location = new System.Drawing.Point(137, 84);
            this.txtLog.Margin = new System.Windows.Forms.Padding(4);
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtLog.Size = new System.Drawing.Size(381, 221);
            this.txtLog.TabIndex = 31;
            // 
            // lblIpAddress
            // 
            this.lblIpAddress.AutoSize = true;
            this.lblIpAddress.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIpAddress.Location = new System.Drawing.Point(26, 35);
            this.lblIpAddress.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblIpAddress.Name = "lblIpAddress";
            this.lblIpAddress.Size = new System.Drawing.Size(93, 19);
            this.lblIpAddress.TabIndex = 30;
            this.lblIpAddress.Text = "IP Address:";
            // 
            // btnStartServer
            // 
            this.btnStartServer.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnStartServer.FlatAppearance.BorderSize = 0;
            this.btnStartServer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStartServer.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStartServer.ForeColor = System.Drawing.Color.White;
            this.btnStartServer.Location = new System.Drawing.Point(377, 30);
            this.btnStartServer.Margin = new System.Windows.Forms.Padding(4);
            this.btnStartServer.Name = "btnStartServer";
            this.btnStartServer.Size = new System.Drawing.Size(141, 28);
            this.btnStartServer.TabIndex = 28;
            this.btnStartServer.Text = "Start Server";
            this.btnStartServer.UseVisualStyleBackColor = false;
            this.btnStartServer.Click += new System.EventHandler(this.btnStartServer_Click_1);
            // 
            // txtIpAddress
            // 
            this.txtIpAddress.Enabled = false;
            this.txtIpAddress.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold);
            this.txtIpAddress.Location = new System.Drawing.Point(137, 30);
            this.txtIpAddress.Name = "txtIpAddress";
            this.txtIpAddress.Size = new System.Drawing.Size(233, 27);
            this.txtIpAddress.TabIndex = 33;
            // 
            // txtScheme
            // 
            this.txtScheme.Enabled = false;
            this.txtScheme.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold);
            this.txtScheme.Location = new System.Drawing.Point(137, 335);
            this.txtScheme.Name = "txtScheme";
            this.txtScheme.Size = new System.Drawing.Size(233, 27);
            this.txtScheme.TabIndex = 35;
            // 
            // lblScheme
            // 
            this.lblScheme.AutoSize = true;
            this.lblScheme.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblScheme.Location = new System.Drawing.Point(26, 340);
            this.lblScheme.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblScheme.Name = "lblScheme";
            this.lblScheme.Size = new System.Drawing.Size(71, 19);
            this.lblScheme.TabIndex = 34;
            this.lblScheme.Text = "Scheme:";
            // 
            // btnSend
            // 
            this.btnSend.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnSend.FlatAppearance.BorderSize = 0;
            this.btnSend.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSend.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSend.ForeColor = System.Drawing.Color.White;
            this.btnSend.Location = new System.Drawing.Point(906, 368);
            this.btnSend.Margin = new System.Windows.Forms.Padding(4);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(170, 28);
            this.btnSend.TabIndex = 64;
            this.btnSend.Text = "Send";
            this.btnSend.UseVisualStyleBackColor = false;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // btnEncrypt
            // 
            this.btnEncrypt.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnEncrypt.FlatAppearance.BorderSize = 0;
            this.btnEncrypt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEncrypt.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEncrypt.ForeColor = System.Drawing.Color.White;
            this.btnEncrypt.Location = new System.Drawing.Point(701, 368);
            this.btnEncrypt.Margin = new System.Windows.Forms.Padding(4);
            this.btnEncrypt.Name = "btnEncrypt";
            this.btnEncrypt.Size = new System.Drawing.Size(170, 28);
            this.btnEncrypt.TabIndex = 63;
            this.btnEncrypt.Text = "Encrypt";
            this.btnEncrypt.UseVisualStyleBackColor = false;
            this.btnEncrypt.Click += new System.EventHandler(this.btnEncrypt_Click);
            // 
            // lblMessage
            // 
            this.lblMessage.AutoSize = true;
            this.lblMessage.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMessage.Location = new System.Drawing.Point(575, 243);
            this.lblMessage.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(78, 19);
            this.lblMessage.TabIndex = 62;
            this.lblMessage.Text = "Message:";
            // 
            // txtMessage
            // 
            this.txtMessage.Location = new System.Drawing.Point(701, 242);
            this.txtMessage.Margin = new System.Windows.Forms.Padding(4);
            this.txtMessage.Multiline = true;
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtMessage.Size = new System.Drawing.Size(375, 100);
            this.txtMessage.TabIndex = 61;
            // 
            // lblDecryptKey
            // 
            this.lblDecryptKey.AutoSize = true;
            this.lblDecryptKey.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDecryptKey.Location = new System.Drawing.Point(575, 184);
            this.lblDecryptKey.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDecryptKey.Name = "lblDecryptKey";
            this.lblDecryptKey.Size = new System.Drawing.Size(106, 19);
            this.lblDecryptKey.TabIndex = 60;
            this.lblDecryptKey.Text = "Decrypt Key:";
            // 
            // txtDecryptKey
            // 
            this.txtDecryptKey.Enabled = false;
            this.txtDecryptKey.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDecryptKey.Location = new System.Drawing.Point(701, 181);
            this.txtDecryptKey.Margin = new System.Windows.Forms.Padding(4);
            this.txtDecryptKey.Name = "txtDecryptKey";
            this.txtDecryptKey.PasswordChar = '*';
            this.txtDecryptKey.Size = new System.Drawing.Size(375, 27);
            this.txtDecryptKey.TabIndex = 59;
            // 
            // lblEncryptKey
            // 
            this.lblEncryptKey.AutoSize = true;
            this.lblEncryptKey.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEncryptKey.Location = new System.Drawing.Point(575, 128);
            this.lblEncryptKey.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblEncryptKey.Name = "lblEncryptKey";
            this.lblEncryptKey.Size = new System.Drawing.Size(106, 19);
            this.lblEncryptKey.TabIndex = 58;
            this.lblEncryptKey.Text = "Encrypt Key:";
            // 
            // txtEncryptKey
            // 
            this.txtEncryptKey.Enabled = false;
            this.txtEncryptKey.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEncryptKey.Location = new System.Drawing.Point(701, 125);
            this.txtEncryptKey.Margin = new System.Windows.Forms.Padding(4);
            this.txtEncryptKey.Name = "txtEncryptKey";
            this.txtEncryptKey.PasswordChar = '*';
            this.txtEncryptKey.Size = new System.Drawing.Size(375, 27);
            this.txtEncryptKey.TabIndex = 57;
            // 
            // btnGenerateKey
            // 
            this.btnGenerateKey.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnGenerateKey.FlatAppearance.BorderSize = 0;
            this.btnGenerateKey.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGenerateKey.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGenerateKey.ForeColor = System.Drawing.Color.White;
            this.btnGenerateKey.Location = new System.Drawing.Point(935, 31);
            this.btnGenerateKey.Margin = new System.Windows.Forms.Padding(4);
            this.btnGenerateKey.Name = "btnGenerateKey";
            this.btnGenerateKey.Size = new System.Drawing.Size(141, 28);
            this.btnGenerateKey.TabIndex = 56;
            this.btnGenerateKey.Text = "Generate Key";
            this.btnGenerateKey.UseVisualStyleBackColor = false;
            this.btnGenerateKey.Click += new System.EventHandler(this.btnGenerateKey_Click);
            // 
            // txtFactor2
            // 
            this.txtFactor2.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFactor2.Location = new System.Drawing.Point(818, 31);
            this.txtFactor2.Margin = new System.Windows.Forms.Padding(4);
            this.txtFactor2.Name = "txtFactor2";
            this.txtFactor2.Size = new System.Drawing.Size(100, 27);
            this.txtFactor2.TabIndex = 55;
            // 
            // lblFactors
            // 
            this.lblFactors.AutoSize = true;
            this.lblFactors.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFactors.Location = new System.Drawing.Point(573, 34);
            this.lblFactors.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFactors.Name = "lblFactors";
            this.lblFactors.Size = new System.Drawing.Size(72, 19);
            this.lblFactors.TabIndex = 54;
            this.lblFactors.Text = "Factors:";
            // 
            // txtFactor1
            // 
            this.txtFactor1.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFactor1.Location = new System.Drawing.Point(701, 31);
            this.txtFactor1.Margin = new System.Windows.Forms.Padding(4);
            this.txtFactor1.Name = "txtFactor1";
            this.txtFactor1.Size = new System.Drawing.Size(100, 27);
            this.txtFactor1.TabIndex = 53;
            // 
            // btnGenerate
            // 
            this.btnGenerate.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnGenerate.FlatAppearance.BorderSize = 0;
            this.btnGenerate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGenerate.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGenerate.ForeColor = System.Drawing.Color.White;
            this.btnGenerate.Location = new System.Drawing.Point(701, 80);
            this.btnGenerate.Margin = new System.Windows.Forms.Padding(4);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(141, 28);
            this.btnGenerate.TabIndex = 65;
            this.btnGenerate.Text = "Generate Key";
            this.btnGenerate.UseVisualStyleBackColor = false;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1112, 439);
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
            this.Controls.Add(this.txtScheme);
            this.Controls.Add(this.lblScheme);
            this.Controls.Add(this.txtIpAddress);
            this.Controls.Add(this.lblLog);
            this.Controls.Add(this.txtLog);
            this.Controls.Add(this.lblIpAddress);
            this.Controls.Add(this.btnStartServer);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblLog;
        private System.Windows.Forms.TextBox txtLog;
        private System.Windows.Forms.Label lblIpAddress;
        private System.Windows.Forms.Button btnStartServer;
        private System.Windows.Forms.TextBox txtIpAddress;
        private System.Windows.Forms.TextBox txtScheme;
        private System.Windows.Forms.Label lblScheme;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.Button btnEncrypt;
        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.TextBox txtMessage;
        private System.Windows.Forms.Label lblDecryptKey;
        private System.Windows.Forms.TextBox txtDecryptKey;
        private System.Windows.Forms.Label lblEncryptKey;
        private System.Windows.Forms.TextBox txtEncryptKey;
        private System.Windows.Forms.Button btnGenerateKey;
        private System.Windows.Forms.TextBox txtFactor2;
        private System.Windows.Forms.Label lblFactors;
        private System.Windows.Forms.TextBox txtFactor1;
        private System.Windows.Forms.Button btnGenerate;
    }
}

