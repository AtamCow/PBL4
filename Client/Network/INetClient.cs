﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Network
{
    public interface INetClient
    {
        bool StartClient(string IP, int Port);
        void SendData(string JsonEncoded);
        string ReceiveData();
    }
}
