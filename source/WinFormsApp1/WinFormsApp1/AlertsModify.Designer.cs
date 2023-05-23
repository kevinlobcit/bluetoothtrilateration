namespace BeaconApp
{
    partial class AlertsModify
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
            label1 = new Label();
            textBoxRuleName = new TextBox();
            textBoxDeviceMac = new TextBox();
            label2 = new Label();
            label3 = new Label();
            numericUpDownXStart = new NumericUpDown();
            numericUpDownYStart = new NumericUpDown();
            label4 = new Label();
            textBoxFloorLabel = new TextBox();
            label5 = new Label();
            mySqlCommand1 = new MySql.Data.MySqlClient.MySqlCommand();
            numericUpDownYEnd = new NumericUpDown();
            label6 = new Label();
            numericUpDownXEnd = new NumericUpDown();
            label7 = new Label();
            groupBox1 = new GroupBox();
            buttonSelectArea = new Button();
            buttonAdd = new Button();
            groupBox2 = new GroupBox();
            label8 = new Label();
            textBoxRuleDelete = new TextBox();
            buttonDelete = new Button();
            buttonRefresh = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownXStart).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownYStart).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownYEnd).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownXEnd).BeginInit();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.AllowUserToResizeRows = false;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(12, 12);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowTemplate.Height = 25;
            dataGridView1.Size = new Size(536, 426);
            dataGridView1.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(6, 19);
            label1.Name = "label1";
            label1.Size = new Size(65, 15);
            label1.TabIndex = 1;
            label1.Text = "Rule Name";
            // 
            // textBoxRuleName
            // 
            textBoxRuleName.Location = new Point(77, 16);
            textBoxRuleName.Name = "textBoxRuleName";
            textBoxRuleName.Size = new Size(114, 23);
            textBoxRuleName.TabIndex = 2;
            // 
            // textBoxDeviceMac
            // 
            textBoxDeviceMac.Location = new Point(77, 45);
            textBoxDeviceMac.Name = "textBoxDeviceMac";
            textBoxDeviceMac.Size = new Size(114, 23);
            textBoxDeviceMac.TabIndex = 4;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(6, 48);
            label2.Name = "label2";
            label2.Size = new Size(68, 15);
            label2.TabIndex = 3;
            label2.Text = "Device Mac";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(6, 105);
            label3.Name = "label3";
            label3.Size = new Size(40, 15);
            label3.TabIndex = 5;
            label3.Text = "x Start";
            // 
            // numericUpDownXStart
            // 
            numericUpDownXStart.Location = new Point(52, 103);
            numericUpDownXStart.Maximum = new decimal(new int[] { 99999999, 0, 0, 0 });
            numericUpDownXStart.Name = "numericUpDownXStart";
            numericUpDownXStart.ReadOnly = true;
            numericUpDownXStart.Size = new Size(139, 23);
            numericUpDownXStart.TabIndex = 6;
            // 
            // numericUpDownYStart
            // 
            numericUpDownYStart.Location = new Point(52, 132);
            numericUpDownYStart.Maximum = new decimal(new int[] { 99999999, 0, 0, 0 });
            numericUpDownYStart.Name = "numericUpDownYStart";
            numericUpDownYStart.ReadOnly = true;
            numericUpDownYStart.Size = new Size(139, 23);
            numericUpDownYStart.TabIndex = 8;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(6, 134);
            label4.Name = "label4";
            label4.Size = new Size(40, 15);
            label4.TabIndex = 7;
            label4.Text = "y Start";
            // 
            // textBoxFloorLabel
            // 
            textBoxFloorLabel.Location = new Point(77, 74);
            textBoxFloorLabel.Name = "textBoxFloorLabel";
            textBoxFloorLabel.Size = new Size(114, 23);
            textBoxFloorLabel.TabIndex = 10;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(6, 77);
            label5.Name = "label5";
            label5.Size = new Size(62, 15);
            label5.TabIndex = 9;
            label5.Text = "Map Label";
            // 
            // mySqlCommand1
            // 
            mySqlCommand1.CacheAge = 0;
            mySqlCommand1.Connection = null;
            mySqlCommand1.EnableCaching = false;
            mySqlCommand1.Transaction = null;
            // 
            // numericUpDownYEnd
            // 
            numericUpDownYEnd.Location = new Point(52, 190);
            numericUpDownYEnd.Maximum = new decimal(new int[] { 99999999, 0, 0, 0 });
            numericUpDownYEnd.Name = "numericUpDownYEnd";
            numericUpDownYEnd.ReadOnly = true;
            numericUpDownYEnd.Size = new Size(139, 23);
            numericUpDownYEnd.TabIndex = 14;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(6, 192);
            label6.Name = "label6";
            label6.Size = new Size(36, 15);
            label6.TabIndex = 13;
            label6.Text = "y End";
            // 
            // numericUpDownXEnd
            // 
            numericUpDownXEnd.Location = new Point(52, 161);
            numericUpDownXEnd.Maximum = new decimal(new int[] { 99999999, 0, 0, 0 });
            numericUpDownXEnd.Name = "numericUpDownXEnd";
            numericUpDownXEnd.ReadOnly = true;
            numericUpDownXEnd.Size = new Size(139, 23);
            numericUpDownXEnd.TabIndex = 12;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(6, 163);
            label7.Name = "label7";
            label7.Size = new Size(36, 15);
            label7.TabIndex = 11;
            label7.Text = "x End";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(buttonSelectArea);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(numericUpDownYEnd);
            groupBox1.Controls.Add(textBoxRuleName);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(numericUpDownXEnd);
            groupBox1.Controls.Add(textBoxDeviceMac);
            groupBox1.Controls.Add(label7);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(numericUpDownYStart);
            groupBox1.Controls.Add(textBoxFloorLabel);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(numericUpDownXStart);
            groupBox1.Location = new Point(555, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(204, 250);
            groupBox1.TabIndex = 15;
            groupBox1.TabStop = false;
            groupBox1.Text = "Add Rule";
            // 
            // buttonSelectArea
            // 
            buttonSelectArea.Location = new Point(116, 219);
            buttonSelectArea.Name = "buttonSelectArea";
            buttonSelectArea.Size = new Size(75, 23);
            buttonSelectArea.TabIndex = 16;
            buttonSelectArea.Text = "Select Area";
            buttonSelectArea.UseVisualStyleBackColor = true;
            buttonSelectArea.Click += buttonSelectArea_Click;
            // 
            // buttonAdd
            // 
            buttonAdd.Location = new Point(671, 268);
            buttonAdd.Name = "buttonAdd";
            buttonAdd.Size = new Size(75, 23);
            buttonAdd.TabIndex = 16;
            buttonAdd.Text = "Add";
            buttonAdd.UseVisualStyleBackColor = true;
            buttonAdd.Click += buttonAdd_Click;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(label8);
            groupBox2.Controls.Add(textBoxRuleDelete);
            groupBox2.Location = new Point(555, 297);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(204, 52);
            groupBox2.TabIndex = 17;
            groupBox2.TabStop = false;
            groupBox2.Text = "Delete Rule";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(6, 25);
            label8.Name = "label8";
            label8.Size = new Size(65, 15);
            label8.TabIndex = 17;
            label8.Text = "Rule Name";
            // 
            // textBoxRuleDelete
            // 
            textBoxRuleDelete.Location = new Point(77, 22);
            textBoxRuleDelete.Name = "textBoxRuleDelete";
            textBoxRuleDelete.Size = new Size(114, 23);
            textBoxRuleDelete.TabIndex = 18;
            // 
            // buttonDelete
            // 
            buttonDelete.Location = new Point(671, 355);
            buttonDelete.Name = "buttonDelete";
            buttonDelete.Size = new Size(75, 23);
            buttonDelete.TabIndex = 18;
            buttonDelete.Text = "Delete";
            buttonDelete.UseVisualStyleBackColor = true;
            buttonDelete.Click += buttonDelete_Click;
            // 
            // buttonRefresh
            // 
            buttonRefresh.Location = new Point(554, 355);
            buttonRefresh.Name = "buttonRefresh";
            buttonRefresh.Size = new Size(75, 23);
            buttonRefresh.TabIndex = 19;
            buttonRefresh.Text = "Refresh";
            buttonRefresh.UseVisualStyleBackColor = true;
            buttonRefresh.Click += buttonRefresh_Click;
            // 
            // AlertsModify
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(771, 450);
            Controls.Add(buttonRefresh);
            Controls.Add(buttonDelete);
            Controls.Add(groupBox2);
            Controls.Add(buttonAdd);
            Controls.Add(groupBox1);
            Controls.Add(dataGridView1);
            Name = "AlertsModify";
            Text = "AlertsModify";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownXStart).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownYStart).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownYEnd).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownXEnd).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dataGridView1;
        private Label label1;
        private TextBox textBoxRuleName;
        private TextBox textBoxDeviceMac;
        private Label label2;
        private Label label3;
        private NumericUpDown numericUpDownXStart;
        private NumericUpDown numericUpDownYStart;
        private Label label4;
        private TextBox textBoxFloorLabel;
        private Label label5;
        private MySql.Data.MySqlClient.MySqlCommand mySqlCommand1;
        private NumericUpDown numericUpDownYEnd;
        private Label label6;
        private NumericUpDown numericUpDownXEnd;
        private Label label7;
        private GroupBox groupBox1;
        private Button buttonSelectArea;
        private Button buttonAdd;
        private GroupBox groupBox2;
        private Label label8;
        private TextBox textBoxRuleDelete;
        private Button buttonDelete;
        private Button buttonRefresh;
    }
}