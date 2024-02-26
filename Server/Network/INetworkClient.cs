using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Network
{
    public interface INetworkClient
    {
        void Send(string message);
        Socket GetTCPSocket();
    }

    public class TcpNetworkClient : INetworkClient
    {
        private Socket _clientSocket;

        public TcpNetworkClient(Socket clientSocket)
        {
            _clientSocket = clientSocket;
        }
        public Socket GetTCPSocket()
        {
            return _clientSocket;
        }

        public void Send(string message)
        {
            if (!_clientSocket.Connected)
                return;

            byte[] data = Encoding.ASCII.GetBytes(message);
            byte[] size = BitConverter.GetBytes(data.Length);

            _clientSocket.Send(size);
            _clientSocket.Send(data);
        }
    }

    public class UdpNetworkClient : INetworkClient
    {
        private Socket _udpSocket;
        private EndPoint _clientEndPoint;

        public Socket GetTCPSocket()
        {
            return null;
        }

        public UdpNetworkClient(Socket udpSocket, EndPoint clientEndPoint)
        {
            _udpSocket = udpSocket;
            _clientEndPoint = clientEndPoint;
        }

        public void Send(string message)
        {
            var sendBuffer = Encoding.ASCII.GetBytes(message);
            _udpSocket.SendTo(sendBuffer, _clientEndPoint);
        }
    }
}
