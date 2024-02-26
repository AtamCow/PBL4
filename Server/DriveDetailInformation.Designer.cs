namespace ClientServerUI
{
    partial class DriveDetailInformation
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            TxtSerialNumber = new TextBox();
            TxtDriveLetter = new TextBox();
            TxtFirmwareRevision = new TextBox();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            DiskNameAndCapacity = new Label();
            LogicalDiskList = new DataGridView();
            label5 = new Label();
            TxtSectorsPerTract = new TextBox();
            TxtBytesPerSector = new TextBox();
            label6 = new Label();
            label7 = new Label();
            TxtDiskType = new TextBox();
            label8 = new Label();
            ((System.ComponentModel.ISupportInitialize)LogicalDiskList).BeginInit();
            SuspendLayout();
            // 
            // TxtSerialNumber
            // 
            TxtSerialNumber.BorderStyle = BorderStyle.FixedSingle;
            TxtSerialNumber.Font = new Font("Arial", 11F, FontStyle.Regular, GraphicsUnit.Point);
            TxtSerialNumber.Location = new Point(197, 147);
            TxtSerialNumber.Name = "TxtSerialNumber";
            TxtSerialNumber.ReadOnly = true;
            TxtSerialNumber.Size = new Size(235, 29);
            TxtSerialNumber.TabIndex = 14;
            TxtSerialNumber.Text = " S5SVNF0NB12079T";
            // 
            // TxtDriveLetter
            // 
            TxtDriveLetter.BorderStyle = BorderStyle.FixedSingle;
            TxtDriveLetter.Font = new Font("Arial", 11F, FontStyle.Regular, GraphicsUnit.Point);
            TxtDriveLetter.Location = new Point(197, 201);
            TxtDriveLetter.Name = "TxtDriveLetter";
            TxtDriveLetter.ReadOnly = true;
            TxtDriveLetter.Size = new Size(235, 29);
            TxtDriveLetter.TabIndex = 13;
            TxtDriveLetter.Text = " C: D: E: F:";
            // 
            // TxtFirmwareRevision
            // 
            TxtFirmwareRevision.BorderStyle = BorderStyle.FixedSingle;
            TxtFirmwareRevision.Font = new Font("Arial", 11F, FontStyle.Regular, GraphicsUnit.Point);
            TxtFirmwareRevision.Location = new Point(197, 91);
            TxtFirmwareRevision.Name = "TxtFirmwareRevision";
            TxtFirmwareRevision.ReadOnly = true;
            TxtFirmwareRevision.Size = new Size(235, 29);
            TxtFirmwareRevision.TabIndex = 12;
            TxtFirmwareRevision.Text = " SVQ02B6Q";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label4.Location = new Point(96, 203);
            label4.Name = "label4";
            label4.Size = new Size(97, 23);
            label4.TabIndex = 11;
            label4.Text = "Ổ đĩa con";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(102, 149);
            label3.Name = "label3";
            label3.Size = new Size(90, 23);
            label3.TabIndex = 10;
            label3.Text = "Số Serial";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(102, 92);
            label2.Name = "label2";
            label2.Size = new Size(93, 23);
            label2.TabIndex = 9;
            label2.Text = "Firmware";
            // 
            // DiskNameAndCapacity
            // 
            DiskNameAndCapacity.AutoSize = true;
            DiskNameAndCapacity.Font = new Font("Arial", 20F, FontStyle.Regular, GraphicsUnit.Point);
            DiskNameAndCapacity.Location = new Point(181, 19);
            DiskNameAndCapacity.Name = "DiskNameAndCapacity";
            DiskNameAndCapacity.Size = new Size(631, 39);
            DiskNameAndCapacity.TabIndex = 8;
            DiskNameAndCapacity.Text = "Samsung SSD 870 QVO 1TB 1000.2 GB";
            DiskNameAndCapacity.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // LogicalDiskList
            // 
            LogicalDiskList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            LogicalDiskList.Location = new Point(18, 284);
            LogicalDiskList.Margin = new Padding(2, 3, 2, 3);
            LogicalDiskList.Name = "LogicalDiskList";
            LogicalDiskList.RowHeadersWidth = 62;
            LogicalDiskList.RowTemplate.Height = 33;
            LogicalDiskList.Size = new Size(878, 300);
            LogicalDiskList.TabIndex = 15;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Arial", 11F, FontStyle.Regular, GraphicsUnit.Point);
            label5.Location = new Point(18, 256);
            label5.Margin = new Padding(2, 0, 2, 0);
            label5.Name = "label5";
            label5.Size = new Size(188, 22);
            label5.TabIndex = 16;
            label5.Text = "Danh sách ổ đĩa con:";
            // 
            // TxtSectorsPerTract
            // 
            TxtSectorsPerTract.BorderStyle = BorderStyle.FixedSingle;
            TxtSectorsPerTract.Font = new Font("Arial", 11F, FontStyle.Regular, GraphicsUnit.Point);
            TxtSectorsPerTract.Location = new Point(603, 205);
            TxtSectorsPerTract.Name = "TxtSectorsPerTract";
            TxtSectorsPerTract.ReadOnly = true;
            TxtSectorsPerTract.Size = new Size(235, 29);
            TxtSectorsPerTract.TabIndex = 20;
            TxtSectorsPerTract.Text = "1024";
            TxtSectorsPerTract.TextAlign = HorizontalAlignment.Center;
            // 
            // TxtBytesPerSector
            // 
            TxtBytesPerSector.BorderStyle = BorderStyle.FixedSingle;
            TxtBytesPerSector.Font = new Font("Arial", 11F, FontStyle.Regular, GraphicsUnit.Point);
            TxtBytesPerSector.Location = new Point(603, 148);
            TxtBytesPerSector.Name = "TxtBytesPerSector";
            TxtBytesPerSector.ReadOnly = true;
            TxtBytesPerSector.Size = new Size(235, 29);
            TxtBytesPerSector.TabIndex = 19;
            TxtBytesPerSector.Text = "12";
            TxtBytesPerSector.TextAlign = HorizontalAlignment.Center;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label6.Location = new Point(480, 207);
            label6.Name = "label6";
            label6.Size = new Size(123, 23);
            label6.TabIndex = 18;
            label6.Text = "Sector/Track";
            label6.TextAlign = ContentAlignment.TopCenter;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label7.Location = new Point(478, 149);
            label7.Name = "label7";
            label7.Size = new Size(124, 23);
            label7.TabIndex = 17;
            label7.Text = "Bytes/Sector";
            label7.Click += label7_Click;
            // 
            // TxtDiskType
            // 
            TxtDiskType.BorderStyle = BorderStyle.FixedSingle;
            TxtDiskType.Font = new Font("Arial", 11F, FontStyle.Regular, GraphicsUnit.Point);
            TxtDiskType.Location = new Point(603, 93);
            TxtDiskType.Name = "TxtDiskType";
            TxtDiskType.ReadOnly = true;
            TxtDiskType.Size = new Size(235, 29);
            TxtDiskType.TabIndex = 22;
            TxtDiskType.Text = "SSD";
            TxtDiskType.TextAlign = HorizontalAlignment.Center;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label8.Location = new Point(536, 94);
            label8.Name = "label8";
            label8.Size = new Size(64, 23);
            label8.TabIndex = 21;
            label8.Text = "Loại ổ";
            // 
            // DriveDetailInformation
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlLightLight;
            Controls.Add(TxtDiskType);
            Controls.Add(label8);
            Controls.Add(TxtSectorsPerTract);
            Controls.Add(TxtBytesPerSector);
            Controls.Add(label6);
            Controls.Add(label7);
            Controls.Add(label5);
            Controls.Add(LogicalDiskList);
            Controls.Add(TxtSerialNumber);
            Controls.Add(TxtDriveLetter);
            Controls.Add(TxtFirmwareRevision);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(DiskNameAndCapacity);
            Margin = new Padding(2, 3, 2, 3);
            Name = "DriveDetailInformation";
            Size = new Size(919, 595);
            ((System.ComponentModel.ISupportInitialize)LogicalDiskList).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TextBox TxtSerialNumber;
        private TextBox TxtDriveLetter;
        private TextBox TxtFirmwareRevision;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label DiskNameAndCapacity;
        private DataGridView LogicalDiskList;
        private Label label5;
        private TextBox TxtSectorsPerTract;
        private TextBox TxtBytesPerSector;
        private Label label6;
        private Label label7;
        private TextBox TxtDiskType;
        private Label label8;
    }
}
