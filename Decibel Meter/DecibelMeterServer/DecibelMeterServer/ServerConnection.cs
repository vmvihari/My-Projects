using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DecibelMeterServer
{
    class ServerConnection
    {
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

        //private string currUser;
        //private string strResponse;

        public ServerConnection(TcpClient TcpClt)
        {
            this.tcpClient = TcpClt;
            trdSender = new Thread(AcceptConnection);
            trdSender.Start();
        }

        private void AcceptConnection()
        {
            srServerReader = new System.IO.StreamReader(tcpClient.GetStream());
            swServerSender = new System.IO.StreamWriter(tcpClient.GetStream());

            string strClientName = srServerReader.ReadLine();
            if (strClientName != "")
            {
                swServerSender.WriteLine("Connected");
                swServerSender.Flush();
            }
            else
            {
                CloseConnection();
                return;
            }

            while ((strClientMsg = srServerReader.ReadLine()) != string.Empty)
            {
                dbServer.SendMessage(currUser, strResponse);
            }
        }

        private void CloseConnection()
        {
            tcpClient.Close();
            srServerReader.Close();
            swServerSender.Close();
        }
    }
}
