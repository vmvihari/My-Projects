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
using NAudio.CoreAudioApi;

namespace DecibelMeterClient
{
    public partial class DecibelMeterClientForm : Form
    {
        public DecibelMeterClientForm()
        {
            InitializeComponent();
            blConnected = false;
            btnConnect.Visible = true;
            btnDisconnect.Visible = false;
        }

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

        private void btnConnect_Click(object sender, EventArgs e)
        {
            try
            {
                // Initialize client with server ip and port and connect
                tcpServer = new TcpClient();
                tcpServer.Connect(IPAddress.Parse(txtIpAddress.Text), 1986);
                blConnected = true;
                btnDisconnect.Visible = true;
                btnConnect.Visible = false;

                strClientName = txtClientName.Text.ToString();
                // Output server stream to send data to cient
                swClientSender = new StreamWriter(tcpServer.GetStream());
                swClientSender.WriteLine(strClientName);
                swClientSender.Flush();

                // Start a new thread to continuously receive messages from server
                trdReceiveMessaging = new Thread(new ThreadStart(ReceiveMessage));
                trdReceiveMessaging.Start();

                // Retreive all the available microphone and audio sensors
                var dmEnumerator = new MMDeviceEnumerator();
                var dmDevice = dmEnumerator.EnumerateAudioEndPoints(DataFlow.All, DeviceState.Active);
                cbxAudioSource.Items.AddRange(dmDevice.ToArray());

                // Update the windows form log after starting the connection
                txtLog.AppendText("Waiting to connect...\r\n");
            }
            catch { }
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
                    UpdateLog("Admin: " + strServerMsg);
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
                    txtLog.AppendText(strMessage + "\n");
                    return 0;
                };
                Invoke(delUpdate);
            }
            catch { }
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtClientMsg.Text != String.Empty)
                {
                    // Send messages to the server
                    swClientSender.WriteLine(txtClientMsg.Text.ToString());
                    swClientSender.Flush();
                    UpdateLog("Me: " + txtClientMsg.Text.ToString());
                }
                txtClientMsg.Text = string.Empty;
            }
            catch { }
        }

        private void btnDisconnect_Click(object sender, EventArgs e)
        {
            if (blConnected == true)
            {
                CloseConnection();
            }
        }

        // Close the tcs connection
        private void CloseConnection()
        {
            try
            {
                blConnected = false;
                btnDisconnect.Visible = false;
                btnConnect.Visible = true;
                swClientSender.WriteLine("Disconnected");
                swClientSender.Flush();
                srClientReader.Close();
                swClientSender.Close();
                tcpServer.Close();
                trdReceiveMessaging.Abort();
                cbxAudioSource.Items.Clear();
            }
            catch { }
        }

        // Timer object to iterate the microphone activity
        private void dmTimer_Tick(object sender, EventArgs e)
        {
            if (cbxAudioSource.SelectedItem != null && blConnected == true)
            {
                // Capture the microphone activity and send the peal value of the noise level to the server
                var dmDevice = (MMDevice)cbxAudioSource.SelectedItem;
                swClientSender.WriteLine(Math.Round(dmDevice.AudioMeterInformation.MasterPeakValue * 100));
                swClientSender.Flush();
            }
        }
    }
}
