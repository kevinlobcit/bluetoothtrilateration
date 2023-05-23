namespace WinFormsApp1
{
    partial class MainProgram
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            imageList1 = new ImageList(components);
            buttonAddMaps = new Button();
            buttonBeacons = new Button();
            buttonDevices = new Button();
            buttonTracking = new Button();
            buttonLogs = new Button();
            buttonAlerts = new Button();
            SuspendLayout();
            // 
            // imageList1
            // 
            imageList1.ColorDepth = ColorDepth.Depth8Bit;
            imageList1.ImageSize = new Size(16, 16);
            imageList1.TransparentColor = Color.Transparent;
            // 
            // buttonAddMaps
            // 
            buttonAddMaps.Location = new Point(12, 41);
            buttonAddMaps.Name = "buttonAddMaps";
            buttonAddMaps.Size = new Size(75, 23);
            buttonAddMaps.TabIndex = 6;
            buttonAddMaps.Text = "Maps";
            buttonAddMaps.UseVisualStyleBackColor = true;
            buttonAddMaps.Click += buttonAddMaps_Click;
            // 
            // buttonBeacons
            // 
            buttonBeacons.Location = new Point(12, 12);
            buttonBeacons.Name = "buttonBeacons";
            buttonBeacons.Size = new Size(75, 23);
            buttonBeacons.TabIndex = 7;
            buttonBeacons.Text = "Beacons";
            buttonBeacons.UseVisualStyleBackColor = true;
            buttonBeacons.Click += buttonBeacons_Click;
            // 
            // buttonDevices
            // 
            buttonDevices.Location = new Point(93, 12);
            buttonDevices.Name = "buttonDevices";
            buttonDevices.Size = new Size(75, 23);
            buttonDevices.TabIndex = 8;
            buttonDevices.Text = "Devices";
            buttonDevices.UseVisualStyleBackColor = true;
            buttonDevices.Click += buttonDevices_Click;
            // 
            // buttonTracking
            // 
            buttonTracking.Location = new Point(93, 41);
            buttonTracking.Name = "buttonTracking";
            buttonTracking.Size = new Size(75, 23);
            buttonTracking.TabIndex = 9;
            buttonTracking.Text = "Tracking";
            buttonTracking.UseVisualStyleBackColor = true;
            buttonTracking.Click += buttonTracking_Click;
            // 
            // buttonLogs
            // 
            buttonLogs.Location = new Point(93, 70);
            buttonLogs.Name = "buttonLogs";
            buttonLogs.Size = new Size(75, 23);
            buttonLogs.TabIndex = 10;
            buttonLogs.Text = "Logs";
            buttonLogs.UseVisualStyleBackColor = true;
            buttonLogs.Click += buttonLogs_Click;
            // 
            // buttonAlerts
            // 
            buttonAlerts.Location = new Point(12, 70);
            buttonAlerts.Name = "buttonAlerts";
            buttonAlerts.Size = new Size(75, 23);
            buttonAlerts.TabIndex = 11;
            buttonAlerts.Text = "Alerts";
            buttonAlerts.UseVisualStyleBackColor = true;
            buttonAlerts.Click += buttonAlerts_Click;
            // 
            // MainProgram
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(181, 102);
            Controls.Add(buttonAlerts);
            Controls.Add(buttonLogs);
            Controls.Add(buttonTracking);
            Controls.Add(buttonDevices);
            Controls.Add(buttonBeacons);
            Controls.Add(buttonAddMaps);
            Name = "MainProgram";
            Text = "Form2";
            FormClosed += Form2_FormClosed;
            ResumeLayout(false);
        }

        #endregion
        private ImageList imageList1;
        private Button buttonAddMaps;
        private Button buttonBeacons;
        private Button buttonDevices;
        private Button buttonTracking;
        private Button buttonLogs;
        private Button buttonAlerts;
    }
}