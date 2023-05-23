namespace BeaconApp
{
    partial class Beacon
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
            dataGridView1 = new DataGridView();
            groupBox1 = new GroupBox();
            buttonAdd = new Button();
            groupBox2 = new GroupBox();
            buttonChooseFromMap = new Button();
            buttonChooseBeacon = new Button();
            label4 = new Label();
            textBoxYPos = new TextBox();
            label3 = new Label();
            textBoxXPos = new TextBox();
            label2 = new Label();
            textBoxFloorLabel = new TextBox();
            label1 = new Label();
            textBoxBeaconMac = new TextBox();
            groupBox3 = new GroupBox();
            buttonDelete = new Button();
            label8 = new Label();
            textBoxDelete = new TextBox();
            buttonRefresh = new Button();
            buttonDisplayBeaconMap = new Button();
            buttonMaps = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(6, 22);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowTemplate.Height = 25;
            dataGridView1.Size = new Size(367, 451);
            dataGridView1.TabIndex = 0;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(dataGridView1);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(379, 479);
            groupBox1.TabIndex = 2;
            groupBox1.TabStop = false;
            groupBox1.Text = "Assigned Beacons";
            // 
            // buttonAdd
            // 
            buttonAdd.Location = new Point(284, 167);
            buttonAdd.Name = "buttonAdd";
            buttonAdd.Size = new Size(75, 23);
            buttonAdd.TabIndex = 3;
            buttonAdd.Text = "Add";
            buttonAdd.UseVisualStyleBackColor = true;
            buttonAdd.Click += buttonAdd_Click;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(buttonMaps);
            groupBox2.Controls.Add(buttonChooseFromMap);
            groupBox2.Controls.Add(buttonAdd);
            groupBox2.Controls.Add(buttonChooseBeacon);
            groupBox2.Controls.Add(label4);
            groupBox2.Controls.Add(textBoxYPos);
            groupBox2.Controls.Add(label3);
            groupBox2.Controls.Add(textBoxXPos);
            groupBox2.Controls.Add(label2);
            groupBox2.Controls.Add(textBoxFloorLabel);
            groupBox2.Controls.Add(label1);
            groupBox2.Controls.Add(textBoxBeaconMac);
            groupBox2.Location = new Point(397, 12);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(368, 216);
            groupBox2.TabIndex = 4;
            groupBox2.TabStop = false;
            groupBox2.Text = "Beacon Add";
            // 
            // buttonChooseFromMap
            // 
            buttonChooseFromMap.Location = new Point(191, 138);
            buttonChooseFromMap.Name = "buttonChooseFromMap";
            buttonChooseFromMap.Size = new Size(168, 23);
            buttonChooseFromMap.TabIndex = 9;
            buttonChooseFromMap.Text = "Choose Position From Map";
            buttonChooseFromMap.UseVisualStyleBackColor = true;
            buttonChooseFromMap.Click += buttonChooseFromMap_Click;
            // 
            // buttonChooseBeacon
            // 
            buttonChooseBeacon.ForeColor = SystemColors.ControlText;
            buttonChooseBeacon.Location = new Point(9, 138);
            buttonChooseBeacon.Name = "buttonChooseBeacon";
            buttonChooseBeacon.Size = new Size(95, 23);
            buttonChooseBeacon.TabIndex = 8;
            buttonChooseBeacon.Text = "Beacon Ideas";
            buttonChooseBeacon.UseVisualStyleBackColor = true;
            buttonChooseBeacon.Click += buttonChooseBeacon_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(6, 112);
            label4.Name = "label4";
            label4.Size = new Size(60, 15);
            label4.TabIndex = 7;
            label4.Text = "Y Position";
            // 
            // textBoxYPos
            // 
            textBoxYPos.Location = new Point(90, 109);
            textBoxYPos.Name = "textBoxYPos";
            textBoxYPos.ReadOnly = true;
            textBoxYPos.Size = new Size(269, 23);
            textBoxYPos.TabIndex = 6;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(6, 83);
            label3.Name = "label3";
            label3.Size = new Size(60, 15);
            label3.TabIndex = 5;
            label3.Text = "X Position";
            // 
            // textBoxXPos
            // 
            textBoxXPos.Location = new Point(90, 80);
            textBoxXPos.Name = "textBoxXPos";
            textBoxXPos.ReadOnly = true;
            textBoxXPos.Size = new Size(269, 23);
            textBoxXPos.TabIndex = 4;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(6, 54);
            label2.Name = "label2";
            label2.Size = new Size(65, 15);
            label2.TabIndex = 3;
            label2.Text = "Floor Label";
            // 
            // textBoxFloorLabel
            // 
            textBoxFloorLabel.Location = new Point(90, 51);
            textBoxFloorLabel.Name = "textBoxFloorLabel";
            textBoxFloorLabel.Size = new Size(269, 23);
            textBoxFloorLabel.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(6, 25);
            label1.Name = "label1";
            label1.Size = new Size(78, 15);
            label1.TabIndex = 1;
            label1.Text = "Beacon_MAC";
            // 
            // textBoxBeaconMac
            // 
            textBoxBeaconMac.Location = new Point(90, 22);
            textBoxBeaconMac.Name = "textBoxBeaconMac";
            textBoxBeaconMac.Size = new Size(269, 23);
            textBoxBeaconMac.TabIndex = 0;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(buttonDelete);
            groupBox3.Controls.Add(label8);
            groupBox3.Controls.Add(textBoxDelete);
            groupBox3.Location = new Point(397, 234);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(368, 79);
            groupBox3.TabIndex = 10;
            groupBox3.TabStop = false;
            groupBox3.Text = "Beacon Delete";
            // 
            // buttonDelete
            // 
            buttonDelete.Location = new Point(284, 50);
            buttonDelete.Name = "buttonDelete";
            buttonDelete.Size = new Size(75, 23);
            buttonDelete.TabIndex = 3;
            buttonDelete.Text = "Delete";
            buttonDelete.UseVisualStyleBackColor = true;
            buttonDelete.Click += buttonDelete_Click;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(6, 24);
            label8.Name = "label8";
            label8.Size = new Size(78, 15);
            label8.TabIndex = 1;
            label8.Text = "Beacon_MAC";
            // 
            // textBoxDelete
            // 
            textBoxDelete.Location = new Point(90, 21);
            textBoxDelete.Name = "textBoxDelete";
            textBoxDelete.Size = new Size(269, 23);
            textBoxDelete.TabIndex = 0;
            // 
            // buttonRefresh
            // 
            buttonRefresh.Location = new Point(681, 319);
            buttonRefresh.Name = "buttonRefresh";
            buttonRefresh.Size = new Size(75, 23);
            buttonRefresh.TabIndex = 11;
            buttonRefresh.Text = "Refresh";
            buttonRefresh.UseVisualStyleBackColor = true;
            buttonRefresh.Click += buttonRefresh_Click;
            // 
            // buttonDisplayBeaconMap
            // 
            buttonDisplayBeaconMap.Location = new Point(550, 319);
            buttonDisplayBeaconMap.Name = "buttonDisplayBeaconMap";
            buttonDisplayBeaconMap.Size = new Size(125, 23);
            buttonDisplayBeaconMap.TabIndex = 12;
            buttonDisplayBeaconMap.Text = "Display Beacon Map";
            buttonDisplayBeaconMap.UseVisualStyleBackColor = true;
            buttonDisplayBeaconMap.Click += buttonDisplayBeaconMap_Click;
            // 
            // buttonMaps
            // 
            buttonMaps.Location = new Point(110, 138);
            buttonMaps.Name = "buttonMaps";
            buttonMaps.Size = new Size(75, 23);
            buttonMaps.TabIndex = 10;
            buttonMaps.Text = "Maps";
            buttonMaps.UseVisualStyleBackColor = true;
            buttonMaps.Click += buttonMaps_Click;
            // 
            // Beacon
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(776, 494);
            Controls.Add(buttonDisplayBeaconMap);
            Controls.Add(buttonRefresh);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Name = "Beacon";
            Text = "Beacon";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dataGridView1;
        private GroupBox groupBox1;
        private Button buttonAdd;
        private GroupBox groupBox2;
        private Button buttonChooseFromMap;
        private Button buttonChooseBeacon;
        private Label label4;
        private TextBox textBoxYPos;
        private Label label3;
        private TextBox textBoxXPos;
        private Label label2;
        private TextBox textBoxFloorLabel;
        private Label label1;
        private TextBox textBoxBeaconMac;
        private GroupBox groupBox3;
        private Button buttonDelete;
        private Label label8;
        private TextBox textBoxDelete;
        private Button buttonRefresh;
        private Button buttonDisplayBeaconMap;
        private Button buttonMaps;
    }
}