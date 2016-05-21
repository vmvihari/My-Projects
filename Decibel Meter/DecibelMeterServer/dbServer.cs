using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Threading;
using System.Collections;

namespace DecibelMeterServer
{
    public class StatusChangedEventArgs : EventArgs
    {
        private string EventMsg;
        public string EventMessage
        {
            get
            {
                return EventMsg;
            }
            set
            {
                EventMsg = value;
            }
        }

        public StatusChangedEventArgs(string strEventMsg)
        {
            EventMsg = strEventMsg;
        }
    }

    public delegate void StatusChangedEventHandler(object sender, StatusChangedEventArgs e);

    class dbServer
    {
        //public static Hashtable htUsers = new Hashtable(30);
        //public static Hashtable htConnections = new Hashtable(30);

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

        //public static event StatusChangedEventHandler StatusChanged;
        //private static StatusChangedEventArgs e;

        public dbServer(IPAddress IpAdd)
        {
            this.ipAddress = IpAdd;
        }

        
        //bool ServRunning = false;

        public static void AddUser(TcpClient tcpUser, string strUsername)
        {
            
        }

        public static void RemoveUser(TcpClient tcpUser)
        {
            
        }

        public static void OnStatusChanged(StatusChangedEventArgs e)
        {
            
        }

        public static void SendAdminMessage(string Message)
        {
            
        }

        public static void SendMessage(string From, string Message)
        {
            
        }

        public void StartListening()
        {
            tcpListen = new TcpListener(ipAddress, 1987);
            tcpListen.Start();
            //ServRunning = true;
            trdListen = new Thread(KeepListening);
            trdListen.Start();
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

        private void KeepListening()
        {
            while (true)
            {
                tcpClient = tcpListen.AcceptTcpClient();
                ServerConnection objServerConnect = new ServerConnection(tcpClient);
            }
        }
    }
}
