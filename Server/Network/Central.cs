using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection.Emit;
using System.Collections.Concurrent;
using System.Drawing;
using System.Xml.Linq;
using System.Collections.Specialized;
using System.Runtime.InteropServices;
using System.Net;
using System.Net.Sockets;
using System.Net.WebSockets;
using System.Text.Json;
using Network;

namespace Network
{
    public class Router
    {
        public event Action<string, INetworkClient> OnMessageReceiveFunc;
        public event Action<string> OnTcpServerStatusTextFunc;
        public event Action<string> OnUdpServerStatusTextFunc;

        private bool TcpServerActive = false;
        private bool UdpServerActive = false;

        private TcpServer TcpServerPtr;
        private UdpServer UdpServerPtr;

        public bool StartTCPServer(string BindIP, int Port)
        {

            Thread TCPListenerThread = new Thread(() => {
                TcpServer TcpSv = new TcpServer();
                TcpSv.OnMessageReceived += OnMessageReceiveFunc;
                TcpSv.OnServerStatusText += OnTcpServerStatusTextFunc;
                bool success = TcpSv.StarServer(BindIP, Port);
                if (success)
                {
                    TcpServerPtr = TcpSv;
                    TcpServerActive = true;
                    TcpSv.Listener();
                }
            });
            TCPListenerThread.IsBackground = false;
            TCPListenerThread.Start();

            return true;
        }
        public bool StopTCPServer()
        {
            if (!TcpServerActive)
                return false;

            TcpServerPtr.StopServer();

            return true;
        }
        public void StartUDPServer(string BindIP, int Port)
        {

            Thread UDPListenerThread = new Thread(() => {
                UdpServer UdpSv = new UdpServer();

                UdpSv.OnMessageReceived += OnMessageReceiveFunc;
                UdpSv.OnServerStatusText += OnUdpServerStatusTextFunc;
                bool success = UdpSv.StarServer(BindIP, Port);
                if (success)
                {
                    UdpServerPtr = UdpSv;
                    UdpServerActive = true;
                    UdpSv.Listener();
                }
            });
            UDPListenerThread.IsBackground = false;
            UDPListenerThread.Start();
            
        }
        public bool StopUDPServer()
        {
            if (!UdpServerActive)
                return false;

            UdpServerPtr.StopServer();

            return true;
        }
    }
}
