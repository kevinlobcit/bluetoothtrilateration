namespace BeaconApp
{
    partial class BeaconAddFromMap
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
            groupBox2 = new GroupBox();
            button1 = new Button();
            textBoxYLimit = new TextBox();
            textBoxYPos = new TextBox();
            label2 = new Label();
            label4 = new Label();
            textBoxXLimit = new TextBox();
            textBoxXPos = new TextBox();
            label3 = new Label();
            label1 = new Label();
            flowLayoutPanel1 = new FlowLayoutPanel();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(button1);
            groupBox2.Controls.Add(textBoxYLimit);
            groupBox2.Controls.Add(textBoxYPos);
            groupBox2.Controls.Add(label2);
            groupBox2.Controls.Add(label4);
            groupBox2.Controls.Add(textBoxXLimit);
            groupBox2.Controls.Add(textBoxXPos);
            groupBox2.Controls.Add(label3);
            groupBox2.Controls.Add(label1);
            groupBox2.Location = new Point(12, 411);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(427, 117);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            groupBox2.Text = "Position Selecting";
            // 
            // button1
            // 
            button1.Location = new Point(343, 87);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 12;
            button1.Text = "OK";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // textBoxYLimit
            // 
            textBoxYLimit.Location = new Point(273, 58);
            textBoxYLimit.Name = "textBoxYLimit";
            textBoxYLimit.ReadOnly = true;
            textBoxYLimit.Size = new Size(145, 23);
            textBoxYLimit.TabIndex = 11;
            // 
            // textBoxYPos
            // 
            textBoxYPos.Location = new Point(72, 58);
            textBoxYPos.Name = "textBoxYPos";
            textBoxYPos.ReadOnly = true;
            textBoxYPos.Size = new Size(145, 23);
            textBoxYPos.TabIndex = 10;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(223, 61);
            label2.Name = "label2";
            label2.Size = new Size(44, 15);
            label2.TabIndex = 9;
            label2.Text = "Y Limit";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(6, 61);
            label4.Name = "label4";
            label4.Size = new Size(60, 15);
            label4.TabIndex = 8;
            label4.Text = "Y Position";
            // 
            // textBoxXLimit
            // 
            textBoxXLimit.Location = new Point(273, 29);
            textBoxXLimit.Name = "textBoxXLimit";
            textBoxXLimit.ReadOnly = true;
            textBoxXLimit.Size = new Size(145, 23);
            textBoxXLimit.TabIndex = 7;
            // 
            // textBoxXPos
            // 
            textBoxXPos.Location = new Point(72, 29);
            textBoxXPos.Name = "textBoxXPos";
            textBoxXPos.ReadOnly = true;
            textBoxXPos.Size = new Size(145, 23);
            textBoxXPos.TabIndex = 6;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(223, 32);
            label3.Name = "label3";
            label3.Size = new Size(44, 15);
            label3.TabIndex = 4;
            label3.Text = "X Limit";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(6, 32);
            label1.Name = "label1";
            label1.Size = new Size(60, 15);
            label1.TabIndex = 2;
            label1.Text = "X Position";
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Location = new Point(12, 12);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(427, 393);
            flowLayoutPanel1.TabIndex = 4;
            // 
            // BeaconAddFromMap
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(446, 532);
            Controls.Add(flowLayoutPanel1);
            Controls.Add(groupBox2);
            Name = "BeaconAddFromMap";
            Text = "BeaconAddFromMap";
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private GroupBox groupBox2;
        private TextBox textBoxXLimit;
        private TextBox textBoxXPos;
        private Label label3;
        private Label label1;
        private Button button1;
        private TextBox textBoxYLimit;
        private TextBox textBoxYPos;
        private Label label2;
        private Label label4;
        private FlowLayoutPanel flowLayoutPanel1;
    }
}