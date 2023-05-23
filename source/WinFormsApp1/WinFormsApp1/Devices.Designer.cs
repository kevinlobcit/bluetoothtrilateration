namespace BeaconApp
{
    partial class Devices
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
            textBoxDeviceMac = new TextBox();
            label1 = new Label();
            label2 = new Label();
            buttonSubmit = new Button();
            numericUpDownRSSI = new NumericUpDown();
            groupBox1 = new GroupBox();
            groupBox2 = new GroupBox();
            label3 = new Label();
            textBoxDelete = new TextBox();
            buttonDelete = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownRSSI).BeginInit();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(12, 12);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowTemplate.Height = 25;
            dataGridView1.Size = new Size(333, 251);
            dataGridView1.TabIndex = 0;
            // 
            // textBoxDeviceMac
            // 
            textBoxDeviceMac.Location = new Point(141, 16);
            textBoxDeviceMac.Name = "textBoxDeviceMac";
            textBoxDeviceMac.Size = new Size(120, 23);
            textBoxDeviceMac.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(61, 19);
            label1.Name = "label1";
            label1.Size = new Size(74, 15);
            label1.TabIndex = 3;
            label1.Text = "Device_MAC";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(8, 48);
            label2.Name = "label2";
            label2.Size = new Size(127, 15);
            label2.TabIndex = 4;
            label2.Text = "Reference RSSI 1 Meter";
            // 
            // buttonSubmit
            // 
            buttonSubmit.Location = new Point(186, 74);
            buttonSubmit.Name = "buttonSubmit";
            buttonSubmit.Size = new Size(75, 23);
            buttonSubmit.TabIndex = 5;
            buttonSubmit.Text = "Add";
            buttonSubmit.UseVisualStyleBackColor = true;
            buttonSubmit.Click += buttonSubmit_Click;
            // 
            // numericUpDownRSSI
            // 
            numericUpDownRSSI.Location = new Point(141, 45);
            numericUpDownRSSI.Minimum = new decimal(new int[] { 100, 0, 0, int.MinValue });
            numericUpDownRSSI.Name = "numericUpDownRSSI";
            numericUpDownRSSI.Size = new Size(120, 23);
            numericUpDownRSSI.TabIndex = 6;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(numericUpDownRSSI);
            groupBox1.Controls.Add(textBoxDeviceMac);
            groupBox1.Controls.Add(buttonSubmit);
            groupBox1.Controls.Add(label2);
            groupBox1.Location = new Point(362, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(272, 108);
            groupBox1.TabIndex = 7;
            groupBox1.TabStop = false;
            groupBox1.Text = "Add";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(label3);
            groupBox2.Controls.Add(textBoxDelete);
            groupBox2.Controls.Add(buttonDelete);
            groupBox2.Location = new Point(362, 126);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(272, 78);
            groupBox2.TabIndex = 8;
            groupBox2.TabStop = false;
            groupBox2.Text = "Delete";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(61, 19);
            label3.Name = "label3";
            label3.Size = new Size(74, 15);
            label3.TabIndex = 3;
            label3.Text = "Device_MAC";
            // 
            // textBoxDelete
            // 
            textBoxDelete.Location = new Point(141, 16);
            textBoxDelete.Name = "textBoxDelete";
            textBoxDelete.Size = new Size(120, 23);
            textBoxDelete.TabIndex = 1;
            // 
            // buttonDelete
            // 
            buttonDelete.Location = new Point(186, 45);
            buttonDelete.Name = "buttonDelete";
            buttonDelete.Size = new Size(75, 23);
            buttonDelete.TabIndex = 5;
            buttonDelete.Text = "Delete";
            buttonDelete.UseVisualStyleBackColor = true;
            buttonDelete.Click += buttonDelete_Click;
            // 
            // Devices
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(645, 271);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(dataGridView1);
            Name = "Devices";
            Text = "Devices";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownRSSI).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dataGridView1;
        private TextBox textBoxDeviceMac;
        private Label label1;
        private Label label2;
        private Button buttonSubmit;
        private NumericUpDown numericUpDownRSSI;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private Label label3;
        private TextBox textBoxDelete;
        private Button buttonDelete;
    }
}