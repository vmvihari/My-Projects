using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace DecibelMeterClient
{
    class dbClient
    {
        private IPAddress ipAddress;
        public IPAddress IpAddress
        {
            get { return ipAddress; }
            set { ipAddress = value; }
        }

        private TcpClient tcpServer;
        public TcpClient TcpServer
        {
            get { return tcpServer; }
            set { tcpServer = value; }
        }


        public dbClient(IPAddress IpAddress)
        {
            this.ipAddress = IpAddress;
        }

        public void StartConnecting(String strClientName)
        {
            tcpServer = new TcpClient();
            tcpServer.Connect(ipAddress, 1987);
            ClientConnection objCC = new ClientConnection(tcpServer);
            objCC.AcceptMessages(strClientName);
        }
    }
}
