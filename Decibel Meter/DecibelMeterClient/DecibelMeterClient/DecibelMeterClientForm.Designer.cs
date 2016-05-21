namespace DecibelMeterClient
{
    partial class DecibelMeterClientForm
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
            this.components = new System.ComponentModel.Container();
            this.txtClientMsg = new System.Windows.Forms.TextBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.txtLog = new System.Windows.Forms.TextBox();
            this.lblIpAddress = new System.Windows.Forms.Label();
            this.txtIpAddress = new System.Windows.Forms.TextBox();
            this.btnConnect = new System.Windows.Forms.Button();
            this.txtClientName = new System.Windows.Forms.TextBox();
            this.lblClientName = new System.Windows.Forms.Label();
            this.lblLog = new System.Windows.Forms.Label();
            this.lblMsg = new System.Windows.Forms.Label();
            this.btnDisconnect = new System.Windows.Forms.Button();
            this.dmTimer = new System.Windows.Forms.Timer(this.components);
            this.lblAudioSource = new System.Windows.Forms.Label();
            this.cbxAudioSource = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // txtClientMsg
            // 
            this.txtClientMsg.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtClientMsg.Location = new System.Drawing.Point(152, 487);
            this.txtClientMsg.Margin = new System.Windows.Forms.Padding(4);
            this.txtClientMsg.Name = "txtClientMsg";
            this.txtClientMsg.Size = new System.Drawing.Size(301, 27);
            this.txtClientMsg.TabIndex = 22;
            this.txtClientMsg.Visible = false;
            // 
            // btnSend
            // 
            this.btnSend.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnSend.FlatAppearance.BorderSize = 0;
            this.btnSend.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSend.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSend.ForeColor = System.Drawing.Color.White;
            this.btnSend.Location = new System.Drawing.Point(461, 487);
            this.btnSend.Margin = new System.Windows.Forms.Padding(4);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(141, 28);
            this.btnSend.TabIndex = 21;
            this.btnSend.Text = "Send";
            this.btnSend.UseVisualStyleBackColor = false;
            this.btnSend.Visible = false;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // txtLog
            // 
            this.txtLog.Location = new System.Drawing.Point(152, 238);
            this.txtLog.Margin = new System.Windows.Forms.Padding(4);
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtLog.Size = new System.Drawing.Size(450, 221);
            this.txtLog.TabIndex = 20;
            // 
            // lblIpAddress
            // 
            this.lblIpAddress.AutoSize = true;
            this.lblIpAddress.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIpAddress.Location = new System.Drawing.Point(26, 25);
            this.lblIpAddress.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblIpAddress.Name = "lblIpAddress";
            this.lblIpAddress.Size = new System.Drawing.Size(93, 19);
            this.lblIpAddress.TabIndex = 19;
            this.lblIpAddress.Text = "IP Address:";
            // 
            // txtIpAddress
            // 
            this.txtIpAddress.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIpAddress.Location = new System.Drawing.Point(152, 22);
            this.txtIpAddress.Margin = new System.Windows.Forms.Padding(4);
            this.txtIpAddress.Name = "txtIpAddress";
            this.txtIpAddress.Size = new System.Drawing.Size(228, 27);
            this.txtIpAddress.TabIndex = 18;
            // 
            // btnConnect
            // 
            this.btnConnect.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnConnect.FlatAppearance.BorderSize = 0;
            this.btnConnect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConnect.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConnect.ForeColor = System.Drawing.Color.White;
            this.btnConnect.Location = new System.Drawing.Point(152, 135);
            this.btnConnect.Margin = new System.Windows.Forms.Padding(4);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(141, 28);
            this.btnConnect.TabIndex = 17;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = false;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // txtClientName
            // 
            this.txtClientName.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtClientName.Location = new System.Drawing.Point(152, 79);
            this.txtClientName.Margin = new System.Windows.Forms.Padding(4);
            this.txtClientName.Name = "txtClientName";
            this.txtClientName.Size = new System.Drawing.Size(228, 27);
            this.txtClientName.TabIndex = 24;
            // 
            // lblClientName
            // 
            this.lblClientName.AutoSize = true;
            this.lblClientName.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblClientName.Location = new System.Drawing.Point(26, 82);
            this.lblClientName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblClientName.Name = "lblClientName";
            this.lblClientName.Size = new System.Drawing.Size(108, 19);
            this.lblClientName.TabIndex = 25;
            this.lblClientName.Text = "Client Name:";
            // 
            // lblLog
            // 
            this.lblLog.AutoSize = true;
            this.lblLog.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLog.Location = new System.Drawing.Point(26, 239);
            this.lblLog.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblLog.Name = "lblLog";
            this.lblLog.Size = new System.Drawing.Size(44, 19);
            this.lblLog.TabIndex = 26;
            this.lblLog.Text = "Log:";
            // 
            // lblMsg
            // 
            this.lblMsg.AutoSize = true;
            this.lblMsg.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMsg.Location = new System.Drawing.Point(26, 488);
            this.lblMsg.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMsg.Name = "lblMsg";
            this.lblMsg.Size = new System.Drawing.Size(78, 19);
            this.lblMsg.TabIndex = 27;
            this.lblMsg.Text = "Message:";
            this.lblMsg.Visible = false;
            // 
            // btnDisconnect
            // 
            this.btnDisconnect.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnDisconnect.FlatAppearance.BorderSize = 0;
            this.btnDisconnect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDisconnect.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDisconnect.ForeColor = System.Drawing.Color.White;
            this.btnDisconnect.Location = new System.Drawing.Point(152, 186);
            this.btnDisconnect.Margin = new System.Windows.Forms.Padding(4);
            this.btnDisconnect.Name = "btnDisconnect";
            this.btnDisconnect.Size = new System.Drawing.Size(141, 28);
            this.btnDisconnect.TabIndex = 28;
            this.btnDisconnect.Text = "Disconnect";
            this.btnDisconnect.UseVisualStyleBackColor = false;
            this.btnDisconnect.Click += new System.EventHandler(this.btnDisconnect_Click);
            // 
            // dmTimer
            // 
            this.dmTimer.Enabled = true;
            this.dmTimer.Interval = 10;
            this.dmTimer.Tick += new System.EventHandler(this.dmTimer_Tick);
            // 
            // lblAudioSource
            // 
            this.lblAudioSource.AutoSize = true;
            this.lblAudioSource.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAudioSource.ForeColor = System.Drawing.Color.Black;
            this.lblAudioSource.Location = new System.Drawing.Point(26, 555);
            this.lblAudioSource.Name = "lblAudioSource";
            this.lblAudioSource.Size = new System.Drawing.Size(69, 19);
            this.lblAudioSource.TabIndex = 30;
            this.lblAudioSource.Text = "Sensor :";
            // 
            // cbxAudioSource
            // 
            this.cbxAudioSource.FormattingEnabled = true;
            this.cbxAudioSource.Location = new System.Drawing.Point(152, 550);
            this.cbxAudioSource.Name = "cbxAudioSource";
            this.cbxAudioSource.Size = new System.Drawing.Size(301, 24);
            this.cbxAudioSource.TabIndex = 29;
            // 
            // DecibelMeterClientForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(649, 678);
            this.Controls.Add(this.lblAudioSource);
            this.Controls.Add(this.cbxAudioSource);
            this.Controls.Add(this.btnDisconnect);
            this.Controls.Add(this.lblMsg);
            this.Controls.Add(this.lblLog);
            this.Controls.Add(this.lblClientName);
            this.Controls.Add(this.txtClientName);
            this.Controls.Add(this.txtClientMsg);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.txtLog);
            this.Controls.Add(this.lblIpAddress);
            this.Controls.Add(this.txtIpAddress);
            this.Controls.Add(this.btnConnect);
            this.Name = "DecibelMeterClientForm";
            this.Text = "DecibelMeterClientForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtClientMsg;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.TextBox txtLog;
        private System.Windows.Forms.Label lblIpAddress;
        private System.Windows.Forms.TextBox txtIpAddress;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.TextBox txtClientName;
        private System.Windows.Forms.Label lblClientName;
        private System.Windows.Forms.Label lblLog;
        private System.Windows.Forms.Label lblMsg;
        private System.Windows.Forms.Button btnDisconnect;
        private System.Windows.Forms.Timer dmTimer;
        private System.Windows.Forms.Label lblAudioSource;
        private System.Windows.Forms.ComboBox cbxAudioSource;
    }
}