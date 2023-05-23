namespace BeaconApp
{
    partial class AlertsModifyFromMap
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
            flowLayoutPanel1 = new FlowLayoutPanel();
            groupBox2 = new GroupBox();
            buttonOk = new Button();
            textBoxYEnd = new TextBox();
            textBoxXEnd = new TextBox();
            label2 = new Label();
            label4 = new Label();
            textBoxYStart = new TextBox();
            textBoxXStart = new TextBox();
            label3 = new Label();
            label1 = new Label();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Location = new Point(12, 12);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(427, 393);
            flowLayoutPanel1.TabIndex = 6;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(buttonOk);
            groupBox2.Controls.Add(textBoxYEnd);
            groupBox2.Controls.Add(textBoxXEnd);
            groupBox2.Controls.Add(label2);
            groupBox2.Controls.Add(label4);
            groupBox2.Controls.Add(textBoxYStart);
            groupBox2.Controls.Add(textBoxXStart);
            groupBox2.Controls.Add(label3);
            groupBox2.Controls.Add(label1);
            groupBox2.Location = new Point(12, 411);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(427, 117);
            groupBox2.TabIndex = 5;
            groupBox2.TabStop = false;
            groupBox2.Text = "Position Selecting";
            // 
            // buttonOk
            // 
            buttonOk.Location = new Point(343, 87);
            buttonOk.Name = "buttonOk";
            buttonOk.Size = new Size(75, 23);
            buttonOk.TabIndex = 12;
            buttonOk.Text = "OK";
            buttonOk.UseVisualStyleBackColor = true;
            buttonOk.Click += buttonOk_Click;
            // 
            // textBoxYEnd
            // 
            textBoxYEnd.Location = new Point(273, 58);
            textBoxYEnd.Name = "textBoxYEnd";
            textBoxYEnd.ReadOnly = true;
            textBoxYEnd.Size = new Size(145, 23);
            textBoxYEnd.TabIndex = 11;
            // 
            // textBoxXEnd
            // 
            textBoxXEnd.Location = new Point(72, 58);
            textBoxXEnd.Name = "textBoxXEnd";
            textBoxXEnd.ReadOnly = true;
            textBoxXEnd.Size = new Size(145, 23);
            textBoxXEnd.TabIndex = 10;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(223, 61);
            label2.Name = "label2";
            label2.Size = new Size(37, 15);
            label2.TabIndex = 9;
            label2.Text = "Y End";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(6, 61);
            label4.Name = "label4";
            label4.Size = new Size(37, 15);
            label4.TabIndex = 8;
            label4.Text = "X End";
            // 
            // textBoxYStart
            // 
            textBoxYStart.Location = new Point(273, 29);
            textBoxYStart.Name = "textBoxYStart";
            textBoxYStart.ReadOnly = true;
            textBoxYStart.Size = new Size(145, 23);
            textBoxYStart.TabIndex = 7;
            // 
            // textBoxXStart
            // 
            textBoxXStart.Location = new Point(72, 29);
            textBoxXStart.Name = "textBoxXStart";
            textBoxXStart.ReadOnly = true;
            textBoxXStart.Size = new Size(145, 23);
            textBoxXStart.TabIndex = 6;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(223, 32);
            label3.Name = "label3";
            label3.Size = new Size(41, 15);
            label3.TabIndex = 4;
            label3.Text = "Y Start";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(6, 32);
            label1.Name = "label1";
            label1.Size = new Size(41, 15);
            label1.TabIndex = 2;
            label1.Text = "X Start";
            // 
            // AlertsModifyFromMap
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(451, 534);
            Controls.Add(flowLayoutPanel1);
            Controls.Add(groupBox2);
            Name = "AlertsModifyFromMap";
            Text = "AlertsModifyFromMap";
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private FlowLayoutPanel flowLayoutPanel1;
        private GroupBox groupBox2;
        private Button buttonOk;
        private TextBox textBoxYEnd;
        private TextBox textBoxXEnd;
        private Label label2;
        private Label label4;
        private TextBox textBoxYStart;
        private TextBox textBoxXStart;
        private Label label3;
        private Label label1;
    }
}