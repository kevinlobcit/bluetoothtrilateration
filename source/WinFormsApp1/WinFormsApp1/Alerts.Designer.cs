namespace BeaconApp
{
    partial class Alerts
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
            groupBox1 = new GroupBox();
            dataGridViewRules = new DataGridView();
            groupBox2 = new GroupBox();
            dataGridViewAlerts = new DataGridView();
            buttonRefresh = new Button();
            buttonModify = new Button();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewRules).BeginInit();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewAlerts).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(dataGridViewRules);
            groupBox1.Location = new Point(12, 232);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(776, 214);
            groupBox1.TabIndex = 2;
            groupBox1.TabStop = false;
            groupBox1.Text = "Rules";
            // 
            // dataGridViewRules
            // 
            dataGridViewRules.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewRules.Location = new Point(6, 22);
            dataGridViewRules.Name = "dataGridViewRules";
            dataGridViewRules.ReadOnly = true;
            dataGridViewRules.RowTemplate.Height = 25;
            dataGridViewRules.Size = new Size(764, 186);
            dataGridViewRules.TabIndex = 0;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(dataGridViewAlerts);
            groupBox2.Location = new Point(12, 12);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(584, 214);
            groupBox2.TabIndex = 3;
            groupBox2.TabStop = false;
            groupBox2.Text = "Alerts";
            // 
            // dataGridViewAlerts
            // 
            dataGridViewAlerts.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewAlerts.Location = new Point(6, 22);
            dataGridViewAlerts.Name = "dataGridViewAlerts";
            dataGridViewAlerts.ReadOnly = true;
            dataGridViewAlerts.RowTemplate.Height = 25;
            dataGridViewAlerts.Size = new Size(572, 186);
            dataGridViewAlerts.TabIndex = 0;
            // 
            // buttonRefresh
            // 
            buttonRefresh.Location = new Point(677, 34);
            buttonRefresh.Name = "buttonRefresh";
            buttonRefresh.Size = new Size(76, 23);
            buttonRefresh.TabIndex = 4;
            buttonRefresh.Text = "Refresh";
            buttonRefresh.UseVisualStyleBackColor = true;
            buttonRefresh.Click += buttonRefresh_Click;
            // 
            // buttonModify
            // 
            buttonModify.Location = new Point(677, 63);
            buttonModify.Name = "buttonModify";
            buttonModify.Size = new Size(76, 23);
            buttonModify.TabIndex = 5;
            buttonModify.Text = "Modify";
            buttonModify.UseVisualStyleBackColor = true;
            buttonModify.Click += buttonModify_Click;
            // 
            // Alerts
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 462);
            Controls.Add(buttonModify);
            Controls.Add(buttonRefresh);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Name = "Alerts";
            Text = "Alerts";
            groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridViewRules).EndInit();
            groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridViewAlerts).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private Button buttonRefresh;
        private Button buttonModify;
        private DataGridView dataGridViewRules;
        private DataGridView dataGridViewAlerts;
    }
}