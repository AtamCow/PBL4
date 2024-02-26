namespace ClientServerUI
{
    partial class serverForm
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
            dataGridView2 = new DataGridView();
            button1 = new Button();
            button2 = new Button();
            MainView = new Panel();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).BeginInit();
            SuspendLayout();
            // 
            // dataGridView2
            // 
            dataGridView2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView2.Location = new Point(6, 108);
            dataGridView2.Name = "dataGridView2";
            dataGridView2.RowHeadersWidth = 62;
            dataGridView2.RowTemplate.Height = 33;
            dataGridView2.Size = new Size(331, 738);
            dataGridView2.TabIndex = 5;
            // 
            // button1
            // 
            button1.Location = new Point(6, 10);
            button1.Name = "button1";
            button1.Size = new Size(160, 92);
            button1.TabIndex = 7;
            button1.Text = "Máy chủ";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(177, 10);
            button2.Name = "button2";
            button2.Size = new Size(160, 92);
            button2.TabIndex = 8;
            button2.Text = "Thông tin";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // MainView
            // 
            MainView.Location = new Point(343, 2);
            MainView.Name = "MainView";
            MainView.Size = new Size(1156, 845);
            MainView.TabIndex = 9;
            // 
            // serverForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlLightLight;
            ClientSize = new Size(1500, 852);
            Controls.Add(MainView);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(dataGridView2);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(4, 3, 4, 3);
            Name = "serverForm";
            Text = "ServerForm";
            ((System.ComponentModel.ISupportInitialize)dataGridView2).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private DataGridView dataGridView2;
        private Button button1;
        private Button button2;
        private Panel MainView;
    }
}