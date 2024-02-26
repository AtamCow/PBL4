namespace Client
{
    partial class ConnectForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            TxtServerIP = new TextBox();
            TxtPort = new TextBox();
            BtnConnect = new Button();
            CbProtocol = new ComboBox();
            LbStatus = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Arial", 18F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(177, 29);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(294, 43);
            label1.TabIndex = 0;
            label1.Text = "Cấu hình kết nối";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Arial", 16F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(82, 133);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(45, 36);
            label2.TabIndex = 1;
            label2.Text = "IP";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Arial", 16F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(54, 201);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(73, 36);
            label3.TabIndex = 2;
            label3.Text = "Port";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Arial", 16F, FontStyle.Regular, GraphicsUnit.Point);
            label4.Location = new Point(30, 274);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(154, 36);
            label4.TabIndex = 3;
            label4.Text = "Giao thức";
            // 
            // TxtServerIP
            // 
            TxtServerIP.Font = new Font("Arial", 15F, FontStyle.Regular, GraphicsUnit.Point);
            TxtServerIP.Location = new Point(206, 126);
            TxtServerIP.Margin = new Padding(4, 5, 4, 5);
            TxtServerIP.Name = "TxtServerIP";
            TxtServerIP.Size = new Size(353, 42);
            TxtServerIP.TabIndex = 4;
            // 
            // TxtPort
            // 
            TxtPort.Font = new Font("Arial", 15F, FontStyle.Regular, GraphicsUnit.Point);
            TxtPort.Location = new Point(205, 201);
            TxtPort.Margin = new Padding(4, 5, 4, 5);
            TxtPort.Name = "TxtPort";
            TxtPort.Size = new Size(353, 42);
            TxtPort.TabIndex = 5;
            // 
            // BtnConnect
            // 
            BtnConnect.BackColor = Color.White;
            BtnConnect.Font = new Font("Arial", 15F, FontStyle.Regular, GraphicsUnit.Point);
            BtnConnect.Location = new Point(206, 353);
            BtnConnect.Margin = new Padding(4, 5, 4, 5);
            BtnConnect.Name = "BtnConnect";
            BtnConnect.Size = new Size(220, 55);
            BtnConnect.TabIndex = 8;
            BtnConnect.Text = "Kết nối";
            BtnConnect.UseVisualStyleBackColor = false;
            BtnConnect.Click += button3_Click;
            // 
            // CbProtocol
            // 
            CbProtocol.Font = new Font("Arial", 15F, FontStyle.Regular, GraphicsUnit.Point);
            CbProtocol.FormattingEnabled = true;
            CbProtocol.Items.AddRange(new object[] { "TCP", "UDP" });
            CbProtocol.Location = new Point(204, 274);
            CbProtocol.Margin = new Padding(4, 5, 4, 5);
            CbProtocol.Name = "CbProtocol";
            CbProtocol.Size = new Size(354, 43);
            CbProtocol.Sorted = true;
            CbProtocol.TabIndex = 9;
            // 
            // LbStatus
            // 
            LbStatus.AutoSize = true;
            LbStatus.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point);
            LbStatus.Location = new Point(177, 444);
            LbStatus.Name = "LbStatus";
            LbStatus.Size = new Size(315, 27);
            LbStatus.TabIndex = 10;
            LbStatus.Text = "Đang kết nối đến máy chủ...";
            // 
            // ConnectForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(646, 519);
            Controls.Add(LbStatus);
            Controls.Add(CbProtocol);
            Controls.Add(BtnConnect);
            Controls.Add(TxtPort);
            Controls.Add(TxtServerIP);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Margin = new Padding(4, 5, 4, 5);
            Name = "ConnectForm";
            Text = "Kết nối đến máy chủ";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private TextBox TxtServerIP;
        private TextBox TxtPort;
        private Button BtnConnect;
        private ComboBox CbProtocol;
        private Label LbStatus;
    }
}