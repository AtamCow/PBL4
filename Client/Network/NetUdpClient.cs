using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;

namespace Client.Network
{
    internal class NetUdpClient : INetClient
    {
        private UdpClient netStream;
        private IPEndPoint ipEndPoint;

        public bool StartClient(string IP, int Port)
        {
            try
            {
                netStream = new UdpClient();
                ipEndPoint = new IPEndPoint(IPAddress.Parse(IP), Port);
            }
            catch (Exception ex) 
            {
                return false;
            }
            return true;
        }

        public void SendData(string JsonEncoded)
        {
            byte[] data = Encoding.ASCII.GetBytes(JsonEncoded);
            netStream.Send(data, data.Length, ipEndPoint);
        }
        public string ReceiveData()
        {
            byte[] receivedBytes = netStream.Receive(ref ipEndPoint);
            string receivedData = Encoding.ASCII.GetString(receivedBytes);

            return receivedData;
        }
    }
}
