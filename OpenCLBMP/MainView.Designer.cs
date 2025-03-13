namespace OpenCLBMP
{
    partial class MainView
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
			comboBox_devices = new ComboBox();
			label_ram = new Label();
			progressBar_ram = new ProgressBar();
			pictureBox_view = new PictureBox();
			listBox_log = new ListBox();
			label_platform = new Label();
			((System.ComponentModel.ISupportInitialize) pictureBox_view).BeginInit();
			SuspendLayout();
			// 
			// comboBox_devices
			// 
			comboBox_devices.FormattingEnabled = true;
			comboBox_devices.Location = new Point(12, 12);
			comboBox_devices.Name = "comboBox_devices";
			comboBox_devices.Size = new Size(300, 23);
			comboBox_devices.TabIndex = 0;
			// 
			// label_ram
			// 
			label_ram.AutoSize = true;
			label_ram.Location = new Point(12, 69);
			label_ram.Name = "label_ram";
			label_ram.Size = new Size(83, 15);
			label_ram.TabIndex = 1;
			label_ram.Text = "RAM: 0 / 0 MB";
			// 
			// progressBar_ram
			// 
			progressBar_ram.Location = new Point(12, 56);
			progressBar_ram.Name = "progressBar_ram";
			progressBar_ram.Size = new Size(300, 10);
			progressBar_ram.TabIndex = 2;
			// 
			// pictureBox_view
			// 
			pictureBox_view.BackColor = Color.Black;
			pictureBox_view.Location = new Point(12, 134);
			pictureBox_view.Name = "pictureBox_view";
			pictureBox_view.Size = new Size(720, 480);
			pictureBox_view.TabIndex = 3;
			pictureBox_view.TabStop = false;
			// 
			// listBox_log
			// 
			listBox_log.FormattingEnabled = true;
			listBox_log.ItemHeight = 15;
			listBox_log.Location = new Point(12, 855);
			listBox_log.Name = "listBox_log";
			listBox_log.Size = new Size(810, 94);
			listBox_log.TabIndex = 4;
			// 
			// label_platform
			// 
			label_platform.AutoSize = true;
			label_platform.Location = new Point(12, 38);
			label_platform.Name = "label_platform";
			label_platform.Size = new Size(64, 15);
			label_platform.TabIndex = 5;
			label_platform.Text = "Platform: -";
			// 
			// MainView
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(834, 961);
			Controls.Add(label_platform);
			Controls.Add(listBox_log);
			Controls.Add(pictureBox_view);
			Controls.Add(progressBar_ram);
			Controls.Add(label_ram);
			Controls.Add(comboBox_devices);
			MaximizeBox = false;
			MaximumSize = new Size(850, 1000);
			MinimumSize = new Size(850, 1000);
			Name = "MainView";
			Text = "OpenCL BMP";
			((System.ComponentModel.ISupportInitialize) pictureBox_view).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private ComboBox comboBox_devices;
		private Label label_ram;
		private ProgressBar progressBar_ram;
		private PictureBox pictureBox_view;
		private ListBox listBox_log;
		private Label label_platform;
	}
}
