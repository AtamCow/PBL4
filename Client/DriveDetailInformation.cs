using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClientServerUI
{
    public partial class DriveDetailInformation : UserControl
    {
        private double scalingFactor = 1;
        public DriveDetailInformation(double inScalingFactor)
        {
            InitializeComponent();
            InitLogicalDiskList();
            scalingFactor = inScalingFactor;
        }
        private void InitLogicalDiskList()
        {
            LogicalDiskList.RowHeadersVisible = false;
            LogicalDiskList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            LogicalDiskList.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            LogicalDiskList.ReadOnly = true;
            LogicalDiskList.AllowUserToAddRows = false;
            LogicalDiskList.AllowUserToDeleteRows = false;
        }
        public void SetDiskName(string text)
        {
            // Set the text of the label
            DiskNameAndCapacity.Text = text;

            // Disable AutoSize to manually adjust the label size
            DiskNameAndCapacity.AutoSize = false;

            // Start with a reasonable font size
            float fontSize = 20.0f;

            // Calculate the necessary width of the label
            SizeF textSize;
            using (Graphics g = DiskNameAndCapacity.CreateGraphics())
            {
                do
                {
                    DiskNameAndCapacity.Font = new Font(DiskNameAndCapacity.Font.FontFamily, fontSize, DiskNameAndCapacity.Font.Style);
                    textSize = g.MeasureString(DiskNameAndCapacity.Text, DiskNameAndCapacity.Font);
                    fontSize -= 0.5f; // Decrease font size gradually
                }
                while (textSize.Width > this.Width && fontSize > 1); // Ensure the width fits within the form and the font size is reasonable
            }

            // Set the size and location of the label to center the text at (100, 100)
            //DiskNameAndCapacity.Width = (int)textSize.Width;
            //DiskNameAndCapacity.Height = (int)textSize.Height;
            DiskNameAndCapacity.Location = new Point((int)Math.Floor(383 * scalingFactor) - DiskNameAndCapacity.Width / 2, (int)Math.Floor(31 * scalingFactor) - DiskNameAndCapacity.Height / 2);

            // Align the text to the center of the label
            DiskNameAndCapacity.TextAlign = ContentAlignment.MiddleCenter;
        }
        public TextBox GetTxtFirmwareRevision()
        {
            return TxtFirmwareRevision;
        }
        public TextBox GetTxtSerialNumber()
        {
            return TxtSerialNumber;
        }
        public TextBox GetTxtDiskType()
        {
            return TxtDiskType;
        }
        public TextBox GetTxtBytesPerSector()
        {
            return TxtBytesPerSector;
        }
        public TextBox GetTxtSectorsPerTract()
        {
            return TxtSectorsPerTract;
        }
        public TextBox GetTxtDriveLetter()
        {
            return TxtDriveLetter;
        }
        public DataGridView GetLogicalDiskList()
        {
            return LogicalDiskList;
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
    }
}
