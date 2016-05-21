using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DecibelMeterClient
{
    class ClientConnection
    {
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

        public ClientConnection(TcpClient TcpServ)
        {
            this.tcpServer = TcpServ;
        }

        public void AcceptMessages(String strClientName)
        {
            swClientSender = new StreamWriter(tcpServer.GetStream());
            swClientSender.WriteLine(strClientName);
            swClientSender.Flush();

            trdReceiveMessaging = new Thread(new ThreadStart(ReceiveMessage));
            trdReceiveMessaging.Start();
        }

        public void ReceiveMessage()
        {
            srClientReader = new StreamReader(tcpServer.GetStream());
            string strMsg = srClientReader.ReadLine();
            if (strMsg == "Connected")
            {
                UpdateLog("Connected Successfully!");
            }

            while (true)
            {
                UpdateLog(srClientReader.ReadLine());
            }
        }

        private void UpdateLog(string strMessage)
        {
            DecibelMeterClientForm objdmClientForm = new DecibelMeterClientForm();
            objdmClientForm.UpdateLog(strMessage);
        }
    }
}
