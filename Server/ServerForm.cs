using Server;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Text.Json;
using static System.Net.Mime.MediaTypeNames;
using Network;

namespace ClientServerUI
{
    public class JsonMessage
    {
        public string Action { get; set; }
        public string ComputerName { get; set; }
    }

    public partial class serverForm : Form
    {
        private List<ComputerDriveInfoUC> ComputersUC;
        private ServerControl serverControlUC;

        private delegate void SafeCallDelegate(string text);

        public serverForm()
        {
            InitializeComponent();
            InitComputerListUI();
            InitServerControlUI();
        }
        private void InitServerControlUI()
        {
            serverControlUC = new ServerControl();
            serverControlUC.ReceiveMessageDelegate += OnReceivedNewDiskInfoMessage;
            serverControlUC.UpdateConnectedClientCount(0);
            SetMainView(serverControlUC);
        }
        public void OnReceivedNewDiskInfoMessage(string JsonMessage, INetworkClient sender)
        {
            // Check if the call is on the UI thread
            if (this.InvokeRequired)
            {
                // If not, use Invoke to marshal the call to the UI thread
                this.Invoke((MethodInvoker)(() => RouteJsonMessage(JsonMessage, sender)));
            }
            else
            {
                // If already on the UI thread, call the method directly
                RouteJsonMessage(JsonMessage, sender);
            }
        }
        public void RouteJsonMessage(string JsonStr, INetworkClient sender)
        {
            try
            {
                // Deserialize the JSON message
                var message = JsonSerializer.Deserialize<JsonMessage>(JsonStr);

                // Check if 'action' field is present
                if (message != null && !string.IsNullOrEmpty(message.Action))
                {
                    // Check for 'computer_name'
                    if (!string.IsNullOrEmpty(message.ComputerName))
                    {
                        OnUserExit(message.ComputerName);
                        return;
                    }
                }
                else
                {
                    List<DiskDriveType> diskDriveTypes;

                    DiskSystemInformation diskSystemInformation = ProcessDiskData(JsonStr, out diskDriveTypes);
                    CreateUserDiskTab(diskSystemInformation);

                    sender.Send(JsonSerializer.Serialize(diskDriveTypes));

                }
            }
            catch (JsonException ex)
            {
            }
        }
        
        private void OnUserExit(string ComputerName)
        {
            foreach (DataGridViewRow row in dataGridView2.Rows)
            {
                if (row.Cells["ComputerColumn"].Value.ToString() == ComputerName)
                {
                    row.Cells["StatusColumn"].Value = "Offline";
                    break;
                }
            }
        }
        public DiskSystemInformation ProcessDiskData(string JSONFX, out List<DiskDriveType> drivesType)
        {
            DiskSystemInformation diskSystemInformation = JsonSerializer.Deserialize<DiskSystemInformation>(JSONFX);

            drivesType = new List<DiskDriveType>();

            foreach (PhysicalDiskInformation phys in diskSystemInformation.PhysicalDisk)
            {
                if (phys.PNPDeviceID.Contains("SSD", StringComparison.OrdinalIgnoreCase) ||
                    phys.SerialNumber.Contains("_"))
                {
                    phys.DiskHardwareType = "SSD";
                }
                else
                {
                    phys.DiskHardwareType = "HDD";
                }
                DiskDriveType newDataField = new DiskDriveType();
                newDataField.Type = phys.DiskHardwareType;
                newDataField.SerialNumber = phys.SerialNumber;

                drivesType.Add(newDataField);
            }
            return diskSystemInformation;
        }
        public void CreateUserDiskTab(DiskSystemInformation diskSystemInformation)
        {
            string systemNameToCheck = diskSystemInformation.SystemName;

            bool systemExists = false;

            foreach (DataGridViewRow row in dataGridView2.Rows)
            {
                if (row.Cells["ComputerColumn"].Value != null && row.Cells["ComputerColumn"].Value.ToString() == systemNameToCheck)
                {
                    // already exist, implement update logic here
                    row.Cells["StatusColumn"].Value = "Online";
                    systemExists = true;
                    break;
                }
            }

            if (!systemExists)
            {
                ComputerDriveInfoUC computerDriveInfoUC = new ComputerDriveInfoUC();
                computerDriveInfoUC.SetDiskInfo(diskSystemInformation);
                computerDriveInfoUC.Load();

                ComputersUC.Add(computerDriveInfoUC);

                dataGridView2.Rows.Add(ComputersUC.Count, systemNameToCheck, "Online");
                serverControlUC.UpdateConnectedClientCount(ComputersUC.Count);
            }
        }
        public void SetMainViewToDesiredComputerUC(string ListIndex)
        {
            int ListIndexInt = int.Parse(ListIndex);
            ComputerDriveInfoUC computerDriveInfoUC = ComputersUC[ListIndexInt - 1];
            SetMainView(computerDriveInfoUC);
        }
        public void SetMainView(UserControl userControl)
        {
            userControl.Dock = DockStyle.Fill;
            MainView.Controls.Add(userControl);
            
            if (MainView.Controls.Count > 1) 
                MainView.Controls.RemoveAt(0);

            userControl.Visible = true;
        }

        public void InitComputerListUI()
        {
            // Assuming you have already created dataGridView2 either via the designer or code
            ComputersUC = new List<ComputerDriveInfoUC>();

            dataGridView2.RowHeadersVisible = false;
            dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dataGridView2.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            // Disable editing
            dataGridView2.ReadOnly = true;

            // Disable adding new rows by the user
            dataGridView2.AllowUserToAddRows = false;

            // Disable deleting rows
            dataGridView2.AllowUserToDeleteRows = false;

            // Add the SelectionChanged event handler
            dataGridView2.SelectionChanged += new EventHandler(dataGridView2_SelectionChanged);

            DataGridViewColumn indexColumn = new DataGridViewTextBoxColumn();
            indexColumn.Name = "IndexColumn";
            indexColumn.HeaderText = "STT";
            indexColumn.ValueType = typeof(int); // Assuming the index is an integer



            // Add a new text column for "Computer"
            DataGridViewColumn computerColumn = new DataGridViewTextBoxColumn();
            computerColumn.Name = "ComputerColumn";
            computerColumn.HeaderText = "Computer";
            computerColumn.ValueType = typeof(string); // Set the type of the data for this column

            // Add a new text column for "Status"
            DataGridViewColumn statusColumn = new DataGridViewTextBoxColumn();
            statusColumn.Name = "StatusColumn";
            statusColumn.HeaderText = "Status";
            statusColumn.ValueType = typeof(string); // Set the type of the data for this column

            // Add the columns to the DataGridView
            dataGridView2.Columns.Add(indexColumn);
            dataGridView2.Columns.Add(computerColumn);
            dataGridView2.Columns.Add(statusColumn);

            dataGridView2.Columns["IndexColumn"].FillWeight = 0.5f; // STT takes 1/4
            dataGridView2.Columns["ComputerColumn"].FillWeight = 2; // Computer takes 2/4 or 1/2
            dataGridView2.Columns["StatusColumn"].FillWeight = 0.75f; // Status takes 1/4        
        }
        private void dataGridView2_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView2.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dataGridView2.SelectedRows[0];
                string computerIndex = row.Cells["IndexColumn"].Value.ToString();

                SetMainViewToDesiredComputerUC(computerIndex);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SetMainView(serverControlUC);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (ComputersUC.Count == 1)
            {
                SetMainViewToDesiredComputerUC("1");
            }
            else
            {
                MainView.Controls.Clear();
            }
        }
    }
}