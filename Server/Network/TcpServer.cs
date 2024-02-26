using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using System.Windows.Forms;
using Network;

namespace Network
{
    class TcpServer
    {
        List<INetworkClient> ClientSockets { get; set; }
        Socket TcpListenerSocket { get; set; }

        public event Action<string, INetworkClient> OnMessageReceived;
        public event Action<string> OnServerStatusText;

        private bool ServerActive = true;

        // TODO: reference function that will process input data, and a socket to send out data
        public TcpServer()
        {
            ClientSockets = new List<INetworkClient>();
            CreateSocket();
        }
        private void CreateSocket()
        {
            Socket TCPListener = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            TcpListenerSocket = TCPListener;
        }
        public bool StarServer(string BindIP, int Port)
        {
            try
            {
                IPEndPoint ip = new IPEndPoint(IPAddress.Parse(BindIP), Port);
                TcpListenerSocket.Bind(ip);
                TcpListenerSocket.Listen(0);

                Console.WriteLine("TCP server started at: " + ip.ToString());
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
            Thread.Sleep(2000);
            TcpListenerSocket.Close();
            OnServerStatusText?.Invoke("STOP_SUCCESSFUL");
        }
        private void Kick(INetworkClient s)
        {
            s.GetTCPSocket().Close();
            ClientSockets.Remove(s);
        }
        private void CheckForIncomingConnection()
        {
            if (TcpListenerSocket.Poll(1000, SelectMode.SelectRead))
            {
                Socket socket = TcpListenerSocket.Accept();

                INetworkClient clientSocket = new TcpNetworkClient(socket);

                ClientSockets.Add(clientSocket);

                Console.WriteLine("[TCP] New incomming connection from: " + socket.RemoteEndPoint.ToString());
            }
        }
        private void CheckForNewData()
        {
            foreach (INetworkClient ClSocket in ClientSockets.ToList())
            {
                Socket ClientSock = ClSocket.GetTCPSocket();
                try
                {
                    if (ClientSock.Poll(1000, SelectMode.SelectRead))
                    {
                        byte[] sizeBuf = new byte[4];
                        int receivedDataLength = ClientSock.Receive(sizeBuf);

                        if (receivedDataLength == 0)
                        {
                            Console.WriteLine("Client disconnected: " + ClientSock.RemoteEndPoint.ToString());
                            Kick(ClSocket);
                            continue;
                        }

                        int messageSize = BitConverter.ToInt32(sizeBuf, 0);
                        byte[] messageBuf = new byte[messageSize];
                        int receivedCount = 0;

                        while (receivedCount < messageSize)
                        {
                            byte[] buffer = new byte[1024];
                            int size = ClientSock.Receive(buffer);
                            Array.Copy(buffer, 0, messageBuf, receivedCount, size);
                            receivedCount += size;
                        }

                        string receivedMessage = Encoding.ASCII.GetString(messageBuf);
                        Console.WriteLine($"[TCP] Received data from {ClientSock.RemoteEndPoint.ToString()} : {receivedMessage}");

                        //SendData(ClSocket, receivedMessage.ToUpper());
                        OnMessageReceived?.Invoke(receivedMessage, ClSocket);
                    }
                }
                catch (SocketException)
                {
                    Console.WriteLine("[{0}] A socket exception occurred, possibly due to the client disconnecting unexpectedly.", ClientSock.RemoteEndPoint.ToString());
                    Kick(ClSocket);
                }
            }
        }
        public void Listener()
        {
            while (ServerActive)
            {
                CheckForIncomingConnection();
                CheckForNewData();
            }
        }
    }
}
