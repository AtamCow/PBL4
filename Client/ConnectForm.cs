using Client.Network;
using System.Net;
using System.Security.Cryptography;

namespace Client
{
    public partial class ConnectForm : Form
    {
        public bool IsConnected { get; private set; }

        public ConnectForm()
        {
            InitializeComponent();

            LbStatus.Text = "";
            CbProtocol.SelectedIndex = 0;
            TxtPort.Text = "1407";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            NetClient netClient = NetClient.GetInstance();

            string svIP = TxtServerIP.Text;
            string svPortS = TxtPort.Text;
            int svPort = 0;

            bool isValid = true;

            // Validate IP Address
            if (!IPAddress.TryParse(svIP, out IPAddress ip))
            {
                LbStatus.Text = "Invalid IP address.";
                isValid = false;
            }

            // Validate Port Number
            if (isValid && (!int.TryParse(svPortS, out svPort) || svPort < 0 || svPort > 65535))
            {
                LbStatus.Text = "Invalid port number.";
                isValid = false;
            }

            if (isValid)
            {
                if (CbProtocol.SelectedIndex == 0)
                {
                    netClient.CreateTCPClient();
                }
                else
                {
                    netClient.CreateUDPClient();
                }
                bool connectionSuccessful = netClient.GetNetClient().StartClient(svIP, svPort);

                if (connectionSuccessful)
                {
                    netClient.GetNetClient().SendData(DiskInfo.GetDiskInfoJSON());

                    string DiskTypeResult = netClient.GetNetClient().ReceiveData();
                    DiskInfo.ParseDiskTypeResult(DiskTypeResult);

                    IsConnected = true;
                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    // Handle failed connection
                    LbStatus.Text = "Có lỗi khi kết nối.";
                    IsConnected = false;
                }
            }
        }
    }
}