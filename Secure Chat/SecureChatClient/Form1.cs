using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SecureChatClient
{
    public partial class Form1 : Form
    {
        PublicKey objPublicKey = new PublicKey();
        AESBuiltIn objAESBuiltIn = new AESBuiltIn();
        RSABuiltIn objRSABuiltIn = new RSABuiltIn();

        private TcpClient tcpServer;
        public TcpClient TcpServer
        {
            get { return tcpServer; }
            set { tcpServer = value; }
        }

        private StreamWriter swClientSender;
        public StreamWriter SwClientSender
        {
            get { return swClientSender; }
            set { swClientSender = value; }
        }

        private StreamReader srClientReader;
        public StreamReader SrClientReader
        {
            get { return srClientReader; }
            set { srClientReader = value; }
        }

        private Thread trdReceiveMessaging;
        public Thread TrdReceiveMessaging
        {
            get { return trdReceiveMessaging; }
            set { trdReceiveMessaging = value; }
        }

        private string strServerMsg;
        public string StrServerMsg
        {
            get { return strServerMsg; }
            set { strServerMsg = value; }
        }

        private string strOrigMsg;
        public string StrOrigMsg
        {
            get { return strOrigMsg; }
            set { strOrigMsg = value; }
        }

        private string strClientName;
        public string StrClientName
        {
            get { return strClientName; }
            set { strClientName = value; }
        }

        private bool blConnected;
        public bool BlConnected
        {
            get { return blConnected; }
            set { blConnected = value; }
        }

        public string strScheme = string.Empty;

        public Form1()
        {
            InitializeComponent();
            lblFactors.Visible = false;
            txtFactor1.Visible = false;
            txtFactor2.Visible = false;
            btnGenerateKey.Visible = false;
            btnGenerate.Visible = false;
            lblEncryptKey.Visible = false;
            txtEncryptKey.Visible = false;
            lblDecryptKey.Visible = false;
            txtDecryptKey.Visible = false;
            lblMessage.Visible = false;
            txtMessage.Visible = false;
            btnEncrypt.Visible = false;
            btnSend.Visible = false;
        }

        public static DialogResult InputBox(string title, string promptText, ref string strKey)
        {
            Form form = new Form();
            Label label = new Label();
            TextBox textBox = new TextBox();
            Button buttonOk = new Button();
            Button buttonCancel = new Button();

            form.Text = title;
            label.Text = promptText;
            textBox.Text = strKey;

            buttonOk.Text = "OK";
            buttonCancel.Text = "Cancel";
            buttonOk.DialogResult = DialogResult.OK;
            buttonCancel.DialogResult = DialogResult.Cancel;

            label.SetBounds(9, 20, 372, 13);
            textBox.SetBounds(12, 36, 372, 20);
            buttonOk.SetBounds(228, 72, 75, 23);
            buttonCancel.SetBounds(309, 72, 75, 23);

            label.AutoSize = true;
            textBox.Anchor = textBox.Anchor | AnchorStyles.Right;
            textBox.PasswordChar = '*';
            buttonOk.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;

            form.ClientSize = new Size(396, 107);
            form.Controls.AddRange(new Control[] { label, textBox, buttonOk, buttonCancel });
            form.ClientSize = new Size(Math.Max(300, label.Right + 10), form.ClientSize.Height);
            form.FormBorderStyle = FormBorderStyle.FixedDialog;
            form.StartPosition = FormStartPosition.CenterScreen;
            form.MinimizeBox = false;
            form.MaximizeBox = false;
            form.AcceptButton = buttonOk;
            form.CancelButton = buttonCancel;

            DialogResult dialogResult = form.ShowDialog();
            strKey = textBox.Text;
            return dialogResult;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            blConnected = false;
            btnConnect.Enabled = true;
            btnDisconnect.Enabled = false;
        }

        // New thread which continuously receives messages from server
        public void ReceiveMessage()
        {
            try
            {
                // Input server stream to read data from client
                srClientReader = new StreamReader(tcpServer.GetStream());

                // Output server stream to send data to cient
                swClientSender = new System.IO.StreamWriter(tcpServer.GetStream());

                // Update the windows form log with server messages
                string strMsg = srClientReader.ReadLine();
                if (strMsg == "Connected")
                {
                    UpdateLog("Connected Successfully!");
                }

                while ((strServerMsg = srClientReader.ReadLine()) != string.Empty)
                {
                    if (strScheme == "Mode-1")
                    {
                        if ((strServerMsg.Length > 4 && strServerMsg.Substring(0, 4) != "KEY:") || (strServerMsg.Length <= 4))
                        {
                            DialogResult dialogResult = MessageBox.Show("Do you want to decrypt the message", "Decryption", MessageBoxButtons.YesNo);
                            if (dialogResult == DialogResult.Yes)
                            {
                                strServerMsg = objRSABuiltIn.Decrypt(strServerMsg);
                                //break;
                            }
                        }
                    }
                    else if (strScheme == "Mode-2")
                    {
                        DialogResult dialogResult = MessageBox.Show("Do you want to decrypt the message", "Decryption", MessageBoxButtons.YesNo);
                        if (dialogResult == DialogResult.Yes)
                        {
                            string strKey = "";
                            while (true)
                            {
                                if (InputBox("Decryption", "Please enter secret key for decryption:", ref strKey) == DialogResult.OK)
                                {
                                    if (strKey != "")
                                    {
                                        break;
                                    }
                                }
                            }
                            strServerMsg = objAESBuiltIn.Decrypt(strServerMsg, strKey);
                            //break;
                        }
                        else if (strScheme == "Mode-3")
                        {

                        }
                        else if (strScheme == "Mode-4")
                        {

                        }
                    }
                    UpdateLog(strServerMsg);
                }
            }
            catch { }
        }

        // Update the windows form log with server messages
        public void UpdateLog(string strMessage)
        {
            try
            {
                // New delegate to access the windows form controls in the new thread
                Func<int> delUpdate = delegate ()
                {
                    if (strMessage != null && strMessage.Length > 4 && strMessage.Substring(0, 4) == "KEY:")
                    {
                        if (cmbMode.SelectedValue.ToString() == "Mode-1")
                            objRSABuiltIn.StrEncryptKey = strMessage.Substring(4);
                        else if (cmbMode.SelectedValue.ToString() == "Mode-3")
                            objPublicKey.DecryptClient = Int64.Parse(strMessage.Substring(4));
                        txtEncryptKey.Text = strMessage.Substring(4);
                    }
                    else if (strMessage != null && strMessage.Length > 4 && strMessage.Substring(0, 4) == "MOD:")
                    {
                        objPublicKey.ModuloClient = Int64.Parse(strMessage.Substring(4));
                    }
                    else if (strMessage != null)
                    {
                        txtLog.AppendText("Admin: " + strMessage + "\n");
                    }
                    return 0;
                };
                Invoke(delUpdate);
            }
            catch { }
        }

        // Close the tcs connection
        private void CloseConnection()
        {
            try
            {
                blConnected = false;
                btnDisconnect.Enabled = false;
                btnConnect.Enabled = true;
                swClientSender.WriteLine("Disconnected");
                swClientSender.Flush();
                srClientReader.Close();
                swClientSender.Close();
                tcpServer.Close();
                trdReceiveMessaging.Abort();
            }
            catch { }
        }

        private void btnConnect_Click_1(object sender, EventArgs e)
        {
            try
            {
                // Initialize client with server ip and port and connect
                tcpServer = new TcpClient();
                tcpServer.Connect(IPAddress.Parse(txtIpAddress.Text), 1986);
                blConnected = true;
                btnDisconnect.Enabled = true;
                btnConnect.Enabled = false;

                strClientName = txtClientName.Text.ToString();
                // Output server stream to send data to cient
                swClientSender = new StreamWriter(tcpServer.GetStream());
                swClientSender.WriteLine(strClientName);
                swClientSender.Flush();

                // Start a new thread to continuously receive messages from server
                trdReceiveMessaging = new Thread(new ThreadStart(ReceiveMessage));
                trdReceiveMessaging.Start();

                // Update the windows form log after starting the connection
                txtLog.AppendText("Waiting to connect...\r\n");
                LoadEncryptionMode();
            }
            catch { }
        }

        private void LoadEncryptionMode()
        {
            DataTable dtMode = new DataTable();
            dtMode.Columns.Add("ModeName", typeof(string));
            dtMode.Columns.Add("ModeValue", typeof(string));
            dtMode.Rows.Add("--Select--", "-0-");
            dtMode.Rows.Add("Public Key Built-in", "Mode-1");
            dtMode.Rows.Add("Symmetric Key Built-in", "Mode-2");
            //dtMode.Rows.Add("Public Key", "Mode-3");
            //dtMode.Rows.Add("Symmetric Key", "Mode-4");

            cmbMode.DataSource = dtMode;
            cmbMode.DisplayMember = "ModeName";
            cmbMode.ValueMember = "ModeValue";

        }

        private void btnDisconnect_Click_1(object sender, EventArgs e)
        {
            if (blConnected == true)
            {
                txtLog.AppendText("Disconnected from server.\r\n");
                CloseConnection();
            }
        }

        private void btnMode_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbMode.SelectedValue != null && cmbMode.SelectedValue.ToString() != "-0-")
                {
                    strScheme = cmbMode.SelectedValue.ToString();
                    // Send messages to the server
                    swClientSender.WriteLine(cmbMode.SelectedValue.ToString());
                    swClientSender.Flush();
                    //UpdateLog("Me: " + txtClientMsg.Text.ToString());
                    if (cmbMode.SelectedValue.ToString() == "Mode-1")
                    {
                        txtFactor1.Text = string.Empty;
                        txtFactor2.Text = string.Empty;
                        txtEncryptKey.Text = string.Empty;
                        txtDecryptKey.Text = string.Empty;
                        txtMessage.Text = string.Empty;
                        lblFactors.Visible = false;
                        txtFactor1.Visible = false;
                        txtFactor2.Visible = false;
                        btnGenerateKey.Visible = false;
                        btnGenerate.Visible = true;
                        lblEncryptKey.Visible = true;
                        txtEncryptKey.Enabled = false;
                        txtEncryptKey.Visible = true;
                        lblDecryptKey.Visible = true;
                        txtDecryptKey.Visible = true;
                        lblMessage.Visible = true;
                        txtMessage.Visible = true;
                        btnEncrypt.Visible = true;
                        btnSend.Visible = true;
                    }
                    else if (cmbMode.SelectedValue.ToString() == "Mode-2")
                    {
                        txtFactor1.Text = string.Empty;
                        txtFactor2.Text = string.Empty;
                        txtEncryptKey.Text = string.Empty;
                        txtDecryptKey.Text = string.Empty;
                        txtMessage.Text = string.Empty;
                        lblFactors.Visible = false;
                        txtFactor1.Visible = false;
                        txtFactor2.Visible = false;
                        btnGenerateKey.Visible = false;
                        btnGenerate.Visible = false;
                        lblEncryptKey.Visible = true;
                        txtEncryptKey.Enabled = true;
                        txtEncryptKey.Visible = true;
                        lblDecryptKey.Visible = false;
                        txtDecryptKey.Visible = false;
                        lblMessage.Visible = true;
                        txtMessage.Visible = true;
                        btnEncrypt.Visible = true;
                        btnSend.Visible = true;
                    }
                    else if (cmbMode.SelectedValue.ToString() == "Mode-3")
                    {
                        txtFactor1.Text = string.Empty;
                        txtFactor2.Text = string.Empty;
                        txtEncryptKey.Text = string.Empty;
                        txtDecryptKey.Text = string.Empty;
                        txtMessage.Text = string.Empty;
                        lblFactors.Visible = true;
                        txtFactor1.Visible = true;
                        txtFactor2.Visible = true;
                        btnGenerateKey.Visible = true;
                        btnGenerate.Visible = false;
                        lblEncryptKey.Visible = true;
                        txtEncryptKey.Enabled = false;
                        txtEncryptKey.Visible = true;
                        lblDecryptKey.Visible = true;
                        txtDecryptKey.Visible = true;
                        lblMessage.Visible = true;
                        txtMessage.Visible = true;
                        btnEncrypt.Visible = true;
                        btnSend.Visible = true;
                    }
                }
                else
                {
                    MessageBox.Show("Please select encryption scheme.");
                }
                //txtClientMsg.Text = string.Empty;
            }
            catch { }
        }

        private void btnGenerateKey_Click(object sender, EventArgs e)
        {
            if (txtFactor1.Text != null && txtFactor2.Text != null)
            {
                objPublicKey.PrimeOne = Convert.ToInt32(txtFactor1.Text);
                objPublicKey.PrimeTwo = Convert.ToInt32(txtFactor2.Text);
                objPublicKey.GenerateKey();
                txtDecryptKey.Text = objPublicKey.e[0].ToString();

                swClientSender.WriteLine("KEY:" + objPublicKey.d[0].ToString());
                swClientSender.Flush();

                swClientSender.WriteLine("MOD:" + objPublicKey.ModuloFactor.ToString());
                swClientSender.Flush();
            }
            else
            {
                MessageBox.Show("Please enter both the factors.");
            }
        }

        private void btnEncrypt_Click(object sender, EventArgs e)
        {
            if (txtMessage.Text != null)
            {
                strOrigMsg = txtMessage.Text.ToString();
                if (strScheme == "Mode-1")
                {
                    txtMessage.Text = objRSABuiltIn.Encrypt(txtMessage.Text.ToString());
                }
                else if (cmbMode.SelectedValue.ToString() == "Mode-2")
                {
                    if (txtEncryptKey.Text != null)
                    {
                        txtMessage.Text = objAESBuiltIn.Encrypt(txtMessage.Text.ToString(), txtEncryptKey.Text.ToString());
                        //strPlainText = objAESBuiltIn.Decrypt(strCipherText, strKey);
                    }
                    else
                    {
                        MessageBox.Show("Please enter the secret key for encryption.");
                    }
                }
                else if (cmbMode.SelectedValue.ToString() == "Mode-3")
                {
                    //    long[] strEncryptMsg = objPublicKey.Encrypt(txtMessage.Text.ToString());
                    //    txtMessage.Text = string.Empty;
                    //    for (int i = 0; strEncryptMsg[i] != '\0'; i++)
                    //    {
                    //        txtMessage.Text += (char)strEncryptMsg[i];
                    //    }

                    //    long[] strDecryptMsg = objPublicKey.Decrypt(strEncryptMsg);
                }
            }
            else
            {
                MessageBox.Show("Please enter the text to encrypt.");
            }
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtMessage.Text != String.Empty)
                {
                    // Send messages to the server
                    swClientSender.WriteLine(txtMessage.Text.ToString());
                    swClientSender.Flush();
                }
                UpdateLog("Me: " + strOrigMsg);
                txtMessage.Text = string.Empty;
            }
            catch { }
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            objRSABuiltIn.GenerateKeys();
            txtDecryptKey.Text = objRSABuiltIn.StrPrivateKey;

            swClientSender.WriteLine("KEY:" + objRSABuiltIn.StrPublicKey);
            swClientSender.Flush();
        }
    }

    class RSABuiltIn
    {
        private int keySize = 1024;

        private string strPublicKey;
        public string StrPublicKey
        {
            get { return strPublicKey; }
            set { this.strPublicKey = value; }
        }

        private string strPrivateKey;
        public string StrPrivateKey
        {
            get { return strPrivateKey; }
            set { this.strPrivateKey = value; }
        }

        private string strEncryptKey;
        public string StrEncryptKey
        {
            get { return strEncryptKey; }
            set { this.strEncryptKey = value; }
        }

        public void GenerateKeys()
        {
            using (var provider = new RSACryptoServiceProvider(keySize))
            {
                strPublicKey = provider.ToXmlString(false);
                strPrivateKey = provider.ToXmlString(true);
            }
        }

        public string Encrypt(string strPlainText)
        {
            try
            {
                byte[] bytesPlainText = Encoding.UTF8.GetBytes(strPlainText);
                byte[] bytesCipherText = null;

                bytesCipherText = RSA_Encrypt(bytesPlainText, keySize, strEncryptKey);
                return Convert.ToBase64String(bytesCipherText);
            }
            catch { return null; }
        }

        public string Decrypt(string strCipherText)
        {
            try
            {
                byte[] bytesCipherText = Convert.FromBase64String(strCipherText);
                byte[] bytesPlainText = null;

                bytesPlainText = RSA_Decrypt(bytesCipherText, keySize, strPrivateKey);
                return Encoding.UTF8.GetString(bytesPlainText);
            }
            catch { return null; }
        }

        private byte[] RSA_Encrypt(byte[] bytesPlainText, int KeySize, string strKey)
        {
            try
            {
                using (var provider = new RSACryptoServiceProvider(KeySize))
                {
                    provider.FromXmlString(strKey);
                    return provider.Encrypt(bytesPlainText, false);
                }
            }
            catch (CryptographicException e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        private byte[] RSA_Decrypt(byte[] bytesCipherText, int KeySize, string strKey)
        {
            try
            {
                using (var provider = new RSACryptoServiceProvider(KeySize))
                {
                    provider.FromXmlString(strKey);
                    return provider.Decrypt(bytesCipherText, false);
                }
            }
            catch (CryptographicException e)
            {
                Console.WriteLine(e.ToString());
                return null;
            }
        }
    }

    class AESBuiltIn
    {
        public string Encrypt(string strPlainText, string strKey)
        {
            try
            {
                byte[] bytesPlainText = Encoding.UTF8.GetBytes(strPlainText);
                byte[] bytesCipherText = null;
                byte[] bytesKey = Encoding.UTF8.GetBytes(strKey);

                // Hash the password with SHA256
                bytesKey = SHA256.Create().ComputeHash(bytesKey);

                // Generating salt bytes
                byte[] byesSaltBits = GetRandomBytes();

                // Appending salt bytes to original bytes
                byte[] bytesToBeEncrypted = new byte[byesSaltBits.Length + bytesPlainText.Length];
                for (int i = 0; i < byesSaltBits.Length; i++)
                    bytesToBeEncrypted[i] = byesSaltBits[i];
                for (int i = 0; i < bytesPlainText.Length; i++)
                    bytesToBeEncrypted[i + byesSaltBits.Length] = bytesPlainText[i];

                bytesCipherText = AES_Encrypt(bytesToBeEncrypted, bytesKey);
                return Convert.ToBase64String(bytesCipherText);
            }
            catch { return null; }
        }

        public string Decrypt(string strCipherText, string strKey)
        {
            try
            {
                byte[] bytesToBeDecrypted = Convert.FromBase64String(strCipherText);
                byte[] bytesKey = Encoding.UTF8.GetBytes(strKey);

                // Hash the password with SHA256
                bytesKey = SHA256.Create().ComputeHash(bytesKey);

                byte[] decryptedBytes = AES_Decrypt(bytesToBeDecrypted, bytesKey);

                // Removing salt bytes, retrieving original bytes
                int _saltSize = 4;
                byte[] bytesPlainText = new byte[decryptedBytes.Length - _saltSize];
                for (int i = _saltSize; i < decryptedBytes.Length; i++)
                    bytesPlainText[i - _saltSize] = decryptedBytes[i];

                return Encoding.UTF8.GetString(bytesPlainText);
            }
            catch { return null; }
        }

        private byte[] GetRandomBytes()
        {
            try
            {
                int _saltSize = 4;
                byte[] bytesSaltBits = new byte[_saltSize];
                RNGCryptoServiceProvider.Create().GetBytes(bytesSaltBits);
                return bytesSaltBits;
            }
            catch { return null; }
        }

        private byte[] AES_Encrypt(byte[] bytesToBeEncrypted, byte[] bytesKey)
        {
            try
            {
                byte[] bytesCipherText = null;

                // Set your salt here, change it to meet your flavor:
                // The salt bytes must be at least 8 bytes.
                byte[] byesSaltBits = new byte[] { 1, 2, 3, 4, 5, 6, 7, 8 };

                using (MemoryStream ms = new MemoryStream())
                {
                    using (RijndaelManaged AES = new RijndaelManaged())
                    {
                        AES.KeySize = 256;
                        AES.BlockSize = 128;

                        var key = new Rfc2898DeriveBytes(bytesKey, byesSaltBits, 1000);
                        AES.Key = key.GetBytes(AES.KeySize / 8);
                        AES.IV = key.GetBytes(AES.BlockSize / 8);

                        AES.Mode = CipherMode.CBC;

                        using (var cs = new CryptoStream(ms, AES.CreateEncryptor(), CryptoStreamMode.Write))
                        {
                            cs.Write(bytesToBeEncrypted, 0, bytesToBeEncrypted.Length);
                            cs.Close();
                        }
                        bytesCipherText = ms.ToArray();
                    }
                }
                return bytesCipherText;
            }
            catch { return null; }
        }

        public byte[] AES_Decrypt(byte[] bytesToBeDecrypted, byte[] bytesKey)
        {
            try
            {
                byte[] decryptedBytes = null;

                // Set your salt here, change it to meet your flavor:
                // The salt bytes must be at least 8 bytes.
                byte[] byesSaltBits = new byte[] { 1, 2, 3, 4, 5, 6, 7, 8 };

                using (MemoryStream ms = new MemoryStream())
                {
                    using (RijndaelManaged AES = new RijndaelManaged())
                    {
                        AES.KeySize = 256;
                        AES.BlockSize = 128;

                        var key = new Rfc2898DeriveBytes(bytesKey, byesSaltBits, 1000);
                        AES.Key = key.GetBytes(AES.KeySize / 8);
                        AES.IV = key.GetBytes(AES.BlockSize / 8);

                        AES.Mode = CipherMode.CBC;

                        using (var cs = new CryptoStream(ms, AES.CreateDecryptor(), CryptoStreamMode.Write))
                        {
                            cs.Write(bytesToBeDecrypted, 0, bytesToBeDecrypted.Length);
                            cs.Close();
                        }
                        decryptedBytes = ms.ToArray();
                    }
                }
                return decryptedBytes;
            }
            catch { return null; }
        }
    }

    class PublicKey
    {
        private long primeOne;
        public long PrimeOne
        {
            get { return primeOne; }
            set { primeOne = value; }
        }

        private long primeTwo;
        public long PrimeTwo
        {
            get { return primeTwo; }
            set { primeTwo = value; }
        }

        private long moduloFactor;
        public long ModuloFactor
        {
            get { return moduloFactor; }
            set { moduloFactor = value; }
        }

        private long moduloClient;
        public long ModuloClient
        {
            get { return moduloClient; }
            set { moduloClient = value; }
        }

        private long decryptClient;
        public long DecryptClient
        {
            get { return decryptClient; }
            set { decryptClient = value; }
        }

        private long range_of_e;
        public long Range_of_e
        {
            get { return range_of_e; }
            set { range_of_e = value; }
        }

        private long flag;
        public long Flag
        {
            get { return flag; }
            set { flag = value; }
        }

        public long[] e = new long[100];
        public long[] d = new long[100];

        public void GenerateKey()
        {
            try
            {
                // moduloFactor is used as the modulus for both the public and private keys
                moduloFactor = primeOne * primeTwo;

                //range_of_e: Euler's totient function. This value is kept private.
                range_of_e = (primeOne - 1) * (primeTwo - 1);

                int count = 0;
                for (int i = 2; i < range_of_e; i++)
                {
                    if (range_of_e % i == 0)
                        continue;
                    flag = isPrime(i);
                    if (flag == 1 && i != primeOne && i != primeTwo)
                    {
                        e[count] = i;
                        flag = GenerateKey(e[count]);
                        if (flag > 0)
                        {
                            d[count] = flag;
                            count++;
                        }
                        if (count == 99)
                            break;
                    }
                }
            }
            catch { }
        }

        private long GenerateKey(long v)
        {
            long count = 1;
            while (true)
            {
                count = count + range_of_e;
                if (count % v == 0)
                {
                    return count / v;
                }
            }
        }

        private int isPrime(long primeCheck)
        {
            int i;
            long sqrt_prime = (long)Math.Sqrt(primeCheck);
            for (i = 2; i <= sqrt_prime; i++)
            {
                if (primeCheck % i == 0)
                    return 0;
            }
            return 1;
        }

        public long[] Encrypt(string strPlainText)
        {
            ////pt is to store ascii value of char before encrytyping
            ////ct is to store ascii value of char after encrytyping
            ////k is used to find "pow(inputchar,key)" followed by "mod n"using for loop
            //long pt, ct, key = e[0], k, q;
            //long[] temp = new long[100];
            long[] strEncryptMsg = new long[100];
            //int i = 0;
            //while (i != strPlainText.Length)
            //{
            //    pt = strPlainText[i];
            //    pt = pt - 96;
            //    k = 1;
            //    for (q = 0; q < key; q++)
            //    {
            //        k = k * pt;
            //        k = k % moduloFactor;
            //    }
            //    temp[i] = k;
            //    ct = k + 96;
            //    strEncryptMsg[i] = ct;
            //    i++;
            //}
            //strEncryptMsg[i] = '\0';
            return strEncryptMsg;
        }

        public long[] Decrypt(long[] strCipherText)
        {
            //long pt, ct, key = d[0], k, q;
            long[] messag = new long[100];
            //long[] temp = new long[100];
            //int i = 0;
            //while (strCipherText[i] != '\0')
            //{
            //    ct = temp[i];
            //    k = 1;
            //    for (q = 0; q < key; q++)
            //    {
            //        k = k * ct;
            //        k = k % moduloFactor;
            //    }
            //    pt = k + 96;
            //    messag[i] = pt;
            //    i++;
            //}
            //messag[i] = '\0';
            return messag;
        }
    }
}
