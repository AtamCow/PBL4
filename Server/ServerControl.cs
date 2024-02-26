using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Network;

namespace Server
{
    public partial class ServerControl : UserControl
    {
        private bool TcpServerActive = false;
        private bool UdpServerActive = false;

        public event Action<string, INetworkClient> ReceiveMessageDelegate;


        private Network.Router Fx;

        public ServerControl()
        {
            InitializeComponent();
            GetAllAvailableNetInterfaceAndShow();
            SetDefaultIpAndPortInput();
        }
        private void GetAllAvailableNetInterfaceAndShow()
        {
            CbNetworkInterface.Items.Add("0.0.0.0"); // IpAddress.Any

            NetworkInterface[] networkInterfaces = NetworkInterface.GetAllNetworkInterfaces();

            foreach (NetworkInterface nic in networkInterfaces)
            {
                IPInterfaceProperties ipProps = nic.GetIPProperties();

                foreach (UnicastIPAddressInformation ip in ipProps.UnicastAddresses)
                {
                    if (ip.Address.AddressFamily == AddressFamily.InterNetwork)
                    {
                        if (!ip.Address.ToString().StartsWith("169.254") &&
                            !ip.Address.IsIPv6Multicast)
                        {
                            CbNetworkInterface.Items.Add(ip.Address.ToString());
                        }
                    }
                }
            }
            CbNetworkInterface.SelectedIndex = 0;
        }
        private void SetDefaultIpAndPortInput()
        {
            Fx = new Network.Router(); // muon cho

            txtTcpPort.Text = "1407";
            txtUdpPort.Text = "1407";
        }
        private void label11_Click(object sender, EventArgs e)
        {

        }
        public void ProcessMessage(string message, INetworkClient sender)
        {
            Console.WriteLine("Received message: " + message);
            // @TODO: check for valid JSON message, route by data type if needed
            ReceiveMessageDelegate?.Invoke(message, sender);
        }
        public void OnTcpServerStatusMessage(string message)
        {
            if (message == "START_SUCCESSFUL")
            {
                btnTCP.Invoke((Action)(() => btnTCP.Text = "Stop"));
                lbTCPServerStatus.Invoke((Action)(() => lbTCPServerStatus.Text = "Started"));
                TcpServerActive = true;
            }
            else if (message == "STOP_SUCCESSFUL")
            {
                btnTCP.Invoke((Action)(() => btnTCP.Text = "Start"));
                lbTCPServerStatus.Invoke((Action)(() => lbTCPServerStatus.Text = "Stopped"));
                TcpServerActive = false;
            }
            else
            {
                lbTCPServerStatus.Invoke((Action)(() => lbTCPServerStatus.Text = "Error"));
                TcpServerActive = false;
            }
        }
        public void OnUdpServerStatusMessage(string message)
        {
            if (message == "START_SUCCESSFUL")
            {
                btnUDP.Invoke((Action)(() => btnUDP.Text = "Stop"));
                lbUDPServerStatus.Invoke((Action)(() => lbUDPServerStatus.Text = "Started"));
                UdpServerActive = true;
            }
            else if (message == "STOP_SUCCESSFUL")
            {
                btnUDP.Invoke((Action)(() => btnUDP.Text = "Start"));
                lbUDPServerStatus.Invoke((Action)(() => lbUDPServerStatus.Text = "Stopped"));
                UdpServerActive = false;
            }
            else
            {
                lbUDPServerStatus.Invoke((Action)(() => lbUDPServerStatus.Text = "Error"));
                UdpServerActive = false;
            }
        }
        private void btnTCP_Click(object sender, EventArgs e)
        {
            if (!TcpServerActive)
            {
                lbTCPServerStatus.Text = "Starting";


                Fx.OnMessageReceiveFunc += ProcessMessage;
                Fx.OnTcpServerStatusTextFunc += OnTcpServerStatusMessage;

                string BindIP = CbNetworkInterface.SelectedItem.ToString();
                string BindPortStr = txtTcpPort.Text;

                int BindPort = int.Parse(BindPortStr);

                Fx.StartTCPServer(BindIP, BindPort);

            }
            else
            {
                Fx.StopTCPServer();
            }
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void btnUDP_Click(object sender, EventArgs e)
        {
            if (!UdpServerActive)
            {
                lbUDPServerStatus.Text = "Starting";


                Fx.OnMessageReceiveFunc += ProcessMessage;
                Fx.OnUdpServerStatusTextFunc += OnUdpServerStatusMessage;

                string BindIP = CbNetworkInterface.SelectedItem.ToString();
                string BindPortStr = txtUdpPort.Text;

                int BindPort = int.Parse(BindPortStr);

                Fx.StartUDPServer(BindIP, BindPort);

            }
            else
            {
                Fx.StopUDPServer();
            }
        }
        public void UpdateConnectedClientCount(int count)
        {
            lbNumConnectedComputers.Text = count.ToString();
        }
    }
}
