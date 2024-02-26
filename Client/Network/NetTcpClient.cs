using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Client.Network
{
    public class NetTcpClient : INetClient
    {
        public NetworkStream netStream { get; set; }
        public TcpClient client;

        public bool StartClient(string IP, int Port)
        {
            try
            {
                client = new TcpClient();
                client.Connect(IP, Port);
                netStream = client.GetStream();
            }
            catch (Exception ex) 
            {
                return false;
            }
            return true;
        }

        public void SendData(string JsonEncoded)
        {
            if (!netStream.CanWrite)
                return;

            byte[] data = Encoding.ASCII.GetBytes(JsonEncoded);
            byte[] size = BitConverter.GetBytes(data.Length);

            netStream.Write(size, 0, size.Length);
            netStream.Write(data, 0, data.Length);
        }
        public string ReceiveData()
        {
            byte[] sizeBuf = new byte[4];
            netStream.Read(sizeBuf, 0, 4);

            int messageSize = BitConverter.ToInt32(sizeBuf, 0);
            byte[] messageBuf = new byte[messageSize];
            int receivedCount = 0;

            while (receivedCount < messageSize)
            {
                byte[] buffer = new byte[1024];
                int size = netStream.Read(buffer, 0, Math.Min(1024, messageSize - receivedCount));
                Array.Copy(buffer, 0, messageBuf, receivedCount, size);
                receivedCount += size;
            }

            string receivedMessage = Encoding.ASCII.GetString(messageBuf);
            return receivedMessage;
        }
    }
}
