using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Network
{
    public class NetClient
    {
        public INetClient netClient = null;

        private static NetClient _instance;
        public static NetClient GetInstance()
        {
            if (_instance == null)
            {
                _instance = new NetClient();
            }
            return _instance;
        }
        public void CreateTCPClient()
        {
            netClient = new NetTcpClient();
        }
        public void CreateUDPClient()
        {
            netClient = new NetUdpClient();
        }
        public INetClient GetNetClient()
        {
            return netClient;
        }
    }
}
