using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DecibelMeterServer
{
    public partial class DecibelMeterServerForm : Form
    {
        private IPAddress ipAddress;
        public IPAddress IpAddress
        {
            get { return ipAddress; }
            set { ipAddress = value; }
        }

        private TcpListener tcpListen;
        public TcpListener TcpListen
        {
            get { return tcpListen; }
            set { tcpListen = value; }
        }

        private Thread trdListen;
        public Thread TrdListen
        {
            get { return trdListen; }
            set { trdListen = value; }
        }

        private TcpClient tcpClient;
        public TcpClient TcpClient
        {
            get { return tcpClient; }
            set { tcpClient = value; }
        }

        private Thread trdSender;
        public Thread TrdSender
        {
            get { return trdSender; }
            set { trdSender = value; }
        }

        private StreamWriter swServerSender;
        public StreamWriter SwServerSender
        {
            get { return swServerSender; }
            set { swServerSender = value; }
        }

        private StreamReader srServerReader;
        public StreamReader SrServerReader
        {
            get { return srServerReader; }
            set { srServerReader = value; }
        }

        private string strClientMsg;
        public string StrClientMsg
        {
            get { return strClientMsg; }
            set { strClientMsg = value; }
        }

        private string strClientName;
        public string StrClientName
        {
            get { return strClientName; }
            set { strClientName = value; }
        }

        public DecibelMeterServerForm()
        {
            InitializeComponent();
        }

        private void btnStartServer_Click(object sender, EventArgs e)
        {
            try
            {
                // Initialize server and start the server to open tcp port and start listenin for connection requests
                tcpListen = new TcpListener(IPAddress.Parse(txtIpAddress.Text), 1986);
                tcpListen.Start();

                // Start a new thread to continuously listen for connection requests and accept the incomming request
                trdListen = new Thread(KeepListening);
                trdListen.Start();

                // Update the windows form log after starting the connection
                txtLog.AppendText("Waiting for connections...\r\n");
            }
            catch { }
        }

        // New thread which continuously listens for connection requests
        private void KeepListening()
        {
            try
            {
                while (true)
                {
                    // Accept an incomming tcp connection request
                    tcpClient = tcpListen.AcceptTcpClient();

                    // Start a new thread to continuously accept the incomming request
                    trdSender = new Thread(AcceptConnection);
                    trdSender.Start();
                }
            }
            catch { }
        }

        // New thread which continuously accepts the incomming request
        private void AcceptConnection()
        {
            try
            {
                // Input server stream to read data from client
                srServerReader = new System.IO.StreamReader(tcpClient.GetStream());

                // Output server stream to send data to cient
                swServerSender = new System.IO.StreamWriter(tcpClient.GetStream());

                strClientName = srServerReader.ReadLine();
                if (strClientName != "")
                {
                    swServerSender.WriteLine("Connected");
                    swServerSender.Flush();
                    UpdateLog(strClientName + " has connected.");
                }

                while ((strClientMsg = srServerReader.ReadLine()) != string.Empty)
                {
                    if (strClientMsg == "Disconnected")
                    {
                        CloseConnection();
                    }
                    // Update the windows form log with client messages
                    UpdateLog(strClientMsg);
                }
            }
            catch { }
        }

        // Update the windows form log with client messages
        public void UpdateLog(string strMessage)
        {
            try
            {
                // New delegate to access the windows form controls in the new thread
                Func<int> delUpdate = delegate ()
                {
                    try
                    {
                        // Update the noise level of the controller indicate the noise at the client
                        dmController.McNoise = Convert.ToInt32(strMessage);
                    }
                    catch
                    {
                        txtLog.AppendText(strClientName + ": " + strMessage + "\n");

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
                tcpClient.Close();
                srServerReader.Close();
                swServerSender.Close();
            }
            catch { }
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtServerMsg.Text != String.Empty)
                {
                    // Send messages to the client
                    swServerSender.WriteLine(txtServerMsg.Text.ToString());
                    swServerSender.Flush();
                    UpdateLog("Me: " + txtServerMsg.Text.ToString());
                }
                txtServerMsg.Text = string.Empty;
            }
            catch { }
        }
    }
}
