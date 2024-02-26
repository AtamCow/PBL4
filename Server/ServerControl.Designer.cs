namespace Server
{
    partial class ServerControl
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
            label15 = new Label();
            panel4 = new Panel();
            btnUDP = new Button();
            btnTCP = new Button();
            label12 = new Label();
            lbUDPServerStatus = new Label();
            lbTCPServerStatus = new Label();
            panel3 = new Panel();
            label4 = new Label();
            label9 = new Label();
            label6 = new Label();
            label5 = new Label();
            panel2 = new Panel();
            txtUdpPort = new TextBox();
            txtTcpPort = new TextBox();
            panel1 = new Panel();
            lbNumConnectedComputers = new Label();
            label2 = new Label();
            label1 = new Label();
            CbNetworkInterface = new ComboBox();
            panel4.SuspendLayout();
            panel3.SuspendLayout();
            panel2.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label15.Location = new Point(7, 8);
            label15.Margin = new Padding(4, 0, 4, 0);
            label15.Name = "label15";
            label15.Size = new Size(120, 27);
            label15.TabIndex = 0;
            label15.Text = "Trạng thái";
            // 
            // panel4
            // 
            panel4.BackColor = SystemColors.Control;
            panel4.BorderStyle = BorderStyle.FixedSingle;
            panel4.Controls.Add(btnUDP);
            panel4.Controls.Add(btnTCP);
            panel4.Controls.Add(label12);
            panel4.Location = new Point(685, 335);
            panel4.Margin = new Padding(0);
            panel4.Name = "panel4";
            panel4.Size = new Size(150, 162);
            panel4.TabIndex = 11;
            // 
            // btnUDP
            // 
            btnUDP.Location = new Point(17, 108);
            btnUDP.Margin = new Padding(4, 5, 4, 5);
            btnUDP.Name = "btnUDP";
            btnUDP.Size = new Size(107, 38);
            btnUDP.TabIndex = 2;
            btnUDP.Text = "Start";
            btnUDP.UseVisualStyleBackColor = true;
            btnUDP.Click += btnUDP_Click;
            // 
            // btnTCP
            // 
            btnTCP.Location = new Point(17, 50);
            btnTCP.Margin = new Padding(4, 5, 4, 5);
            btnTCP.Name = "btnTCP";
            btnTCP.Size = new Size(107, 38);
            btnTCP.TabIndex = 1;
            btnTCP.Text = "Start";
            btnTCP.UseVisualStyleBackColor = true;
            btnTCP.Click += btnTCP_Click;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label12.Location = new Point(13, 8);
            label12.Margin = new Padding(4, 0, 4, 0);
            label12.Name = "label12";
            label12.Size = new Size(131, 27);
            label12.TabIndex = 0;
            label12.Text = "Hành động";
            // 
            // lbUDPServerStatus
            // 
            lbUDPServerStatus.AutoSize = true;
            lbUDPServerStatus.Font = new Font("Arial", 11F, FontStyle.Regular, GraphicsUnit.Point);
            lbUDPServerStatus.Location = new Point(20, 117);
            lbUDPServerStatus.Margin = new Padding(4, 0, 4, 0);
            lbUDPServerStatus.Name = "lbUDPServerStatus";
            lbUDPServerStatus.Size = new Size(94, 25);
            lbUDPServerStatus.TabIndex = 2;
            lbUDPServerStatus.Text = "Stopped";
            lbUDPServerStatus.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lbTCPServerStatus
            // 
            lbTCPServerStatus.AutoSize = true;
            lbTCPServerStatus.Font = new Font("Arial", 11F, FontStyle.Regular, GraphicsUnit.Point);
            lbTCPServerStatus.Location = new Point(20, 53);
            lbTCPServerStatus.Margin = new Padding(4, 0, 4, 0);
            lbTCPServerStatus.Name = "lbTCPServerStatus";
            lbTCPServerStatus.Size = new Size(94, 25);
            lbTCPServerStatus.TabIndex = 1;
            lbTCPServerStatus.Text = "Stopped";
            lbTCPServerStatus.TextAlign = ContentAlignment.MiddleCenter;
            lbTCPServerStatus.Click += label11_Click;
            // 
            // panel3
            // 
            panel3.BackColor = SystemColors.Control;
            panel3.BorderStyle = BorderStyle.FixedSingle;
            panel3.Controls.Add(lbUDPServerStatus);
            panel3.Controls.Add(lbTCPServerStatus);
            panel3.Controls.Add(label15);
            panel3.Location = new Point(553, 335);
            panel3.Margin = new Padding(0);
            panel3.Name = "panel3";
            panel3.Size = new Size(142, 162);
            panel3.TabIndex = 12;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label4.Location = new Point(7, 10);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(118, 27);
            label4.TabIndex = 0;
            label4.Text = "Giao thức";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label9.Location = new Point(29, 10);
            label9.Margin = new Padding(4, 0, 4, 0);
            label9.Name = "label9";
            label9.Size = new Size(56, 27);
            label9.TabIndex = 0;
            label9.Text = "Port";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Arial", 11F, FontStyle.Regular, GraphicsUnit.Point);
            label6.Location = new Point(31, 113);
            label6.Margin = new Padding(4, 0, 4, 0);
            label6.Name = "label6";
            label6.Size = new Size(59, 25);
            label6.TabIndex = 2;
            label6.Text = "UDP";
            label6.TextAlign = ContentAlignment.MiddleCenter;
            label6.Click += label6_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Arial", 11F, FontStyle.Regular, GraphicsUnit.Point);
            label5.Location = new Point(31, 53);
            label5.Margin = new Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new Size(57, 25);
            label5.TabIndex = 1;
            label5.Text = "TCP";
            label5.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel2
            // 
            panel2.BackColor = SystemColors.Control;
            panel2.BorderStyle = BorderStyle.FixedSingle;
            panel2.Controls.Add(txtUdpPort);
            panel2.Controls.Add(txtTcpPort);
            panel2.Controls.Add(label9);
            panel2.Location = new Point(437, 335);
            panel2.Margin = new Padding(0);
            panel2.Name = "panel2";
            panel2.Size = new Size(120, 162);
            panel2.TabIndex = 13;
            // 
            // txtUdpPort
            // 
            txtUdpPort.Location = new Point(16, 108);
            txtUdpPort.Margin = new Padding(4, 5, 4, 5);
            txtUdpPort.Name = "txtUdpPort";
            txtUdpPort.Size = new Size(80, 31);
            txtUdpPort.TabIndex = 4;
            // 
            // txtTcpPort
            // 
            txtTcpPort.Location = new Point(16, 50);
            txtTcpPort.Margin = new Padding(4, 5, 4, 5);
            txtTcpPort.Name = "txtTcpPort";
            txtTcpPort.Size = new Size(80, 31);
            txtTcpPort.TabIndex = 3;
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.Control;
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(label6);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(label4);
            panel1.Location = new Point(311, 335);
            panel1.Margin = new Padding(0);
            panel1.Name = "panel1";
            panel1.Size = new Size(139, 162);
            panel1.TabIndex = 10;
            // 
            // lbNumConnectedComputers
            // 
            lbNumConnectedComputers.AutoSize = true;
            lbNumConnectedComputers.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lbNumConnectedComputers.Location = new Point(730, 543);
            lbNumConnectedComputers.Margin = new Padding(4, 0, 4, 0);
            lbNumConnectedComputers.Name = "lbNumConnectedComputers";
            lbNumConnectedComputers.Size = new Size(38, 27);
            lbNumConnectedComputers.TabIndex = 9;
            lbNumConnectedComputers.Text = "10";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(401, 543);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(339, 27);
            label2.TabIndex = 8;
            label2.Text = "Số lượng máy tính đã kết nối: ";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(307, 250);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(121, 27);
            label1.TabIndex = 6;
            label1.Text = "Địa chỉ IP:";
            // 
            // CbNetworkInterface
            // 
            CbNetworkInterface.DropDownStyle = ComboBoxStyle.DropDownList;
            CbNetworkInterface.FormattingEnabled = true;
            CbNetworkInterface.Location = new Point(429, 245);
            CbNetworkInterface.Margin = new Padding(4, 5, 4, 5);
            CbNetworkInterface.Name = "CbNetworkInterface";
            CbNetworkInterface.Size = new Size(406, 33);
            CbNetworkInterface.TabIndex = 14;
            // 
            // ServerControl
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlLightLight;
            Controls.Add(CbNetworkInterface);
            Controls.Add(panel4);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(lbNumConnectedComputers);
            Controls.Add(label2);
            Controls.Add(label1);
            Margin = new Padding(4, 5, 4, 5);
            Name = "ServerControl";
            Size = new Size(1156, 845);
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label13;
        private Label label15;
        private Panel panel4;
        private Label label14;
        private Label label12;
        private Label lbUDPServerStatus;
        private Label lbTCPServerStatus;
        private Panel panel3;
        private Label label4;
        private Label label9;
        private Label label6;
        private Label label5;
        private Panel panel2;
        private Panel panel1;
        private Label lbNumConnectedComputers;
        private Label label2;
        private Label label1;
        private ComboBox CbNetworkInterface;
        private Button btnTCP;
        private TextBox txtUdpPort;
        private TextBox txtTcpPort;
        private Button btnUDP;
    }
}
