using Client.Network;
using ClientServerUI;
using System.Text.RegularExpressions;

namespace Client
{
    public partial class MainForm : Form
    {
        private int hotTabIndex = -1;
        private double scalingFactor = 1;

        public MainForm()
        {
            GetHDPISettings();
            InitializeComponent();
            InitDiskTabListUI();


            LoadDiskInfo();
        }
        private void GetHDPISettings()
        {
            float dpiX, dpiY;
            using (Graphics graphics = Graphics.FromHwnd(IntPtr.Zero))
            {
                dpiX = graphics.DpiX;
                dpiY = graphics.DpiY;
            }
            scalingFactor = dpiX / 96.0;
        }
        public void LoadDiskInfo()
        {
            foreach (var disk in DiskInfo.GetDiskInfo().PhysicalDisk)
            {

                // Create a new TabPage
                TabPage newTabPage = new TabPage(disk.Name.ToString());

                // Create your UserControl (assuming you have a UserControl with the following textboxes)
                var myDiskControl = new DriveDetailInformation(scalingFactor); // Replace with your actual UserControl class name

                // Set the UserControl's fields

                string sanitizedDiskName = SanitizeString(disk.Name);
                if (ContainsCapacity(sanitizedDiskName))
                {
                    myDiskControl.SetDiskName($"{sanitizedDiskName}");
                }
                else
                {

                    myDiskControl.SetDiskName($"{sanitizedDiskName} {FormatBytes1000(disk.Size)}");
                }
                myDiskControl.GetTxtFirmwareRevision().Text = disk.FirmwareVersion;
                myDiskControl.GetTxtSerialNumber().Text = disk.SerialNumber;
                myDiskControl.GetTxtDiskType().Text = disk.DiskHardwareType;
                myDiskControl.GetTxtBytesPerSector().Text = disk.BytesPerSector.ToString();
                myDiskControl.GetTxtSectorsPerTract().Text = disk.SectorPerTrack.ToString();

                // Concatenate all drive letters for the TxtDriveLetter textbox
                myDiskControl.GetTxtDriveLetter().Text = string.Join(" ", disk.Logical.Select(l => l.DriveLetter.ToString()));

                // Add the UserControl to the new TabPage
                newTabPage.Controls.Add(myDiskControl);

                // Initialize and populate the DataGridView for logical drives
                DataGridView dgv = myDiskControl.GetLogicalDiskList();

                dgv.Columns.Add("DriveLetter", "Drive Letter");
                dgv.Columns.Add("VolumeName", "Volume name");
                dgv.Columns.Add("Size", "Size");
                dgv.Columns.Add("FreeSize", "Free space");
                dgv.Columns.Add("SerialNumber", "Serial number");
                dgv.Columns.Add("Format", "Format");

                foreach (var logicalDrive in disk.Logical)
                {
                    string serialNumberHex = logicalDrive.SerialNumber.ToString("X");

                    string VolumeName = "Local Disk";

                    if (logicalDrive.VolumeName != null && logicalDrive.VolumeName.Length > 0)
                        VolumeName = logicalDrive.VolumeName;

                    dgv.Rows.Add(logicalDrive.DriveLetter,
                                 VolumeName,
                                 FormatBytes(logicalDrive.Size),
                                 FormatBytes(logicalDrive.FreeSize),
                                 serialNumberHex,
                                 logicalDrive.Format);
                }

                // Add the new TabPage to your TabControl
                tabControl1.TabPages.Add(newTabPage);
            }
        }
        public void InitDiskTabListUI()
        {
            tabControl1.DrawMode = TabDrawMode.OwnerDrawFixed;

            // Set the SizeMode to Fixed, so all tabs have the same width
            tabControl1.SizeMode = TabSizeMode.Fixed;

            tabControl1.ItemSize = new Size((int)Math.Round(100 * scalingFactor), (int)Math.Round(67 * scalingFactor)); // Increase the height to 60 pixels

            tabControl1.DrawItem += new DrawItemEventHandler(tabControl1_DrawItem);
            tabControl1.MouseMove += new MouseEventHandler(tabControl1_MouseMove);
        }
        private void tabControl1_DrawItem(object sender, DrawItemEventArgs e)
        {
            TabPage page = tabControl1.TabPages[e.Index];
            PhysicalDiskInformation disk = DiskInfo.GetDiskInfo().PhysicalDisk[e.Index];

            Color textColor = page.ForeColor;
            Rectangle tabBounds = tabControl1.GetTabRect(e.Index);
            Color statusColor = Color.Red;
            if (disk.Status == "OK" && disk.Logical.Count > 0)
            {
                statusColor = Color.Blue;
            }
            // Set the background color
            using (SolidBrush brush = new SolidBrush(page.BackColor))
            {
                e.Graphics.FillRectangle(brush, e.Bounds);
            }

            // Text format
            StringFormat sf = new StringFormat
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            };

            // Your tab text here
            string statusText = $"Disk {e.Index}";




            string DiskSizeText = FormatBytes1000(disk.Size);
            string label = string.Join(" ", disk.Logical.Select(l => l.DriveLetter.ToString())); ;

            // Calculate the height for each line of text
            int lineHeight = (int)e.Graphics.MeasureString("Text", page.Font).Height;
            PointF statusTextLocation = new PointF(tabBounds.X + tabBounds.Width / 2, tabBounds.Y + lineHeight * 1);
            PointF temperatureTextLocation = new PointF(tabBounds.X + tabBounds.Width / 2, tabBounds.Y + lineHeight * 2);
            PointF labelTextLocation = new PointF(tabBounds.X + tabBounds.Width / 2, tabBounds.Y + lineHeight * 3);


            // Draw the status text
            using (SolidBrush brush = new SolidBrush(textColor))
            {
                e.Graphics.DrawString(statusText, page.Font, brush, statusTextLocation, sf);
                e.Graphics.DrawString(DiskSizeText, page.Font, brush, temperatureTextLocation, sf);
                e.Graphics.DrawString(label, page.Font, brush, labelTextLocation, sf);
            }

            // Optionally draw icons or other graphics

            // Draw the status dot
            int dotRadius = (int)Math.Round(4 * scalingFactor); // Radius of the status dot
            PointF dotLocation = new PointF(tabBounds.X + 3, tabBounds.Y + 3); // Adjust for exact positioning
            using (SolidBrush brush = new SolidBrush(statusColor))
            {
                e.Graphics.FillEllipse(brush, dotLocation.X, dotLocation.Y, dotRadius * 2, dotRadius * 2);
            }


            // Draw border around tab if it is selected
            if (e.State.HasFlag(DrawItemState.Selected))
            {
                using (Pen selectedPen = new Pen(Color.Black))
                {
                    Rectangle box = tabBounds;
                    box.X += 1;
                    box.Y += 1;
                    box.Width -= 1;
                    box.Height -= 1;
                    e.Graphics.DrawRectangle(selectedPen, box);
                }
            }
            // Draw the line at the bottom of the tab
            Color lineColor = e.State.HasFlag(DrawItemState.Selected) ? Color.Blue :
                              e.Index == hotTabIndex ? Color.Black :
                              page.BackColor; // Default to background color

            using (Pen pen = new Pen(lineColor, 2)) // Use a thickness of 2 for the line
            {
                e.Graphics.DrawLine(pen, tabBounds.Left, tabBounds.Bottom - 1, tabBounds.Right, tabBounds.Bottom - 1);
            }
        }
        private void tabPage1_Click(object sender, EventArgs e)
        {

        }


        private void tabControl1_MouseMove(object sender, MouseEventArgs e)
        {
            TabControl tabControl = (TabControl)sender;
            for (int index = 0; index < tabControl.TabCount; index++)
            {
                if (tabControl.GetTabRect(index).Contains(e.Location))
                {
                    if (hotTabIndex != index)
                    {
                        hotTabIndex = index;
                        tabControl.Invalidate(); // Causes the tab to be redrawn
                    }
                    return;
                }
            }

            if (hotTabIndex != -1)
            {
                hotTabIndex = -1;
                tabControl.Invalidate(); // Causes the tab to be redrawn
            }
        }

        private void tabControl1_MouseLeave(object sender, EventArgs e)
        {
            hotTabIndex = -1;
            tabControl1.Invalidate(); // Causes the tab to be redrawn
        }

        private void serverForm_Load(object sender, EventArgs e)
        {

        }

        // Helper method to format bytes into a readable format
        private string FormatBytes(decimal bytes)
        {
            string[] sizes = { "B", "KB", "MB", "GB", "TB", "PB", "EB" };
            double formattedSize = (double)bytes;
            int order = 0;
            while (formattedSize >= 1024 && order < sizes.Length - 1)
            {
                order++;
                formattedSize /= 1024;
            }
            return $"{formattedSize:0.##} {sizes[order]}";
        }
        private string FormatBytes1000(decimal bytes)
        {
            string[] sizes = { "B", "KB", "MB", "GB", "TB", "PB", "EB" };
            double formattedSize = (double)bytes;
            int order = 0;
            while (formattedSize >= 1000 && order < sizes.Length - 1)
            {
                order++;
                formattedSize /= 1000;
            }
            return $"{formattedSize:0.##} {sizes[order]}";
        }

        private bool ContainsCapacity(string diskName)
        {
            string pattern = @"\d+(?:\.\d+)?(GB|TB)";
            return Regex.IsMatch(diskName, pattern, RegexOptions.IgnoreCase);
        }
        public string SanitizeString(string input)
        {
            string pattern = "[^a-zA-Z0-9 ]";
            return Regex.Replace(input, pattern, "");
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            NetClient netClient = NetClient.GetInstance();

            string systemName = DiskInfo.GetDiskInfo().SystemName;
            string jsonData = "{\"Action\":\"CLIENT_EXIT\", \"ComputerName\":\"" + systemName + "\"}";
            netClient.GetNetClient().SendData(jsonData);
        }
    }


}