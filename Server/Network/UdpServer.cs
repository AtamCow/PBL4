using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Network;

namespace Network
{
    class UdpServer
    {
        Socket UdpListenerSocket { get; set; }
        private bool ServerActive = true;

        public event Action<string, INetworkClient> OnMessageReceived;
        public event Action<string> OnServerStatusText;


        public UdpServer()
        {
            CreateSocket();
        }
        private void CreateSocket()
        {
            Socket UDPListener = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            UdpListenerSocket = UDPListener;
        }
        public bool StarServer(string BindIP, int Port)
        {
            try
            {
                IPEndPoint ip = new IPEndPoint(IPAddress.Parse(BindIP), Port);
                UdpListenerSocket.Bind(ip);
                Console.WriteLine("UDP server started at: " + ip.ToString());
            }
            catch (Exception ex)
            {
                OnServerStatusText?.Invoke("START_ERROR");
                Console.WriteLine(ex.Message);
                return false;
            }
            OnServerStatusText?.Invoke("START_SUCCESSFUL");
            return true;
        }
        public void StopServer()
        {
            ServerActive = false; // terminate listener thread
            UdpListenerSocket.Shutdown(SocketShutdown.Both);
            UdpListenerSocket.Close();
            OnServerStatusText?.Invoke("STOP_SUCCESSFUL");
        }
        public void Listener()
        {
            var size = 65535 - 28;
            var receiveBuffer = new byte[size];
            while (ServerActive)
            {
                try
                {
                    EndPoint remoteEndpoint = new IPEndPoint(IPAddress.Any, 0);
                    var length = UdpListenerSocket.ReceiveFrom(receiveBuffer, ref remoteEndpoint);

                    var text = Encoding.ASCII.GetString(receiveBuffer, 0, length);
                    Console.WriteLine($"[UDP] Received data from {remoteEndpoint} : {text}");

                    INetworkClient udpClient = new UdpNetworkClient(UdpListenerSocket, remoteEndpoint);
                    OnMessageReceived?.Invoke(text, udpClient);
                    //var result = text.ToUpper();
                    //var sendBuffer = Encoding.ASCII.GetBytes(result);
                    //UdpListenerSocket.SendTo(sendBuffer, remoteEndpoint);


                    Array.Clear(receiveBuffer, 0, size);
                }
                catch (SocketException ex) when (ex.NativeErrorCode == 10004)  // WSACancelBlockingCall
                {
                    // Handle the specific case of interrupting a blocking call
                    // This can be normal during shutdown
                }
            }
        }
    }

}
