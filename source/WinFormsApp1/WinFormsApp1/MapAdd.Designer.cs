namespace BeaconApp
{
    partial class MapAdd
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
            textBoxFilename = new TextBox();
            buttonBrowse = new Button();
            label1 = new Label();
            label2 = new Label();
            textBoxMapLabel = new TextBox();
            buttonAdd = new Button();
            pictureBox1 = new PictureBox();
            label3 = new Label();
            numericUpDown1 = new NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            SuspendLayout();
            // 
            // textBoxFilename
            // 
            textBoxFilename.Location = new Point(78, 327);
            textBoxFilename.Name = "textBoxFilename";
            textBoxFilename.ReadOnly = true;
            textBoxFilename.Size = new Size(294, 23);
            textBoxFilename.TabIndex = 1;
            // 
            // buttonBrowse
            // 
            buttonBrowse.Location = new Point(378, 326);
            buttonBrowse.Name = "buttonBrowse";
            buttonBrowse.Size = new Size(75, 23);
            buttonBrowse.TabIndex = 2;
            buttonBrowse.Text = "Browse Image";
            buttonBrowse.UseVisualStyleBackColor = true;
            buttonBrowse.Click += buttonBrowse_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 330);
            label1.Name = "label1";
            label1.Size = new Size(60, 15);
            label1.TabIndex = 3;
            label1.Text = "File Name";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(10, 359);
            label2.Name = "label2";
            label2.Size = new Size(62, 15);
            label2.TabIndex = 4;
            label2.Text = "Map Label";
            // 
            // textBoxMapLabel
            // 
            textBoxMapLabel.Location = new Point(78, 356);
            textBoxMapLabel.Name = "textBoxMapLabel";
            textBoxMapLabel.Size = new Size(294, 23);
            textBoxMapLabel.TabIndex = 5;
            // 
            // buttonAdd
            // 
            buttonAdd.Location = new Point(378, 384);
            buttonAdd.Name = "buttonAdd";
            buttonAdd.Size = new Size(75, 23);
            buttonAdd.TabIndex = 6;
            buttonAdd.Text = "Add";
            buttonAdd.UseVisualStyleBackColor = true;
            buttonAdd.Click += buttonAdd_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(12, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(440, 309);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(10, 389);
            label3.Name = "label3";
            label3.Size = new Size(45, 15);
            label3.TabIndex = 8;
            label3.Text = "Scaling";
            // 
            // numericUpDown1
            // 
            numericUpDown1.Location = new Point(78, 387);
            numericUpDown1.Maximum = new decimal(new int[] { 9999999, 0, 0, 0 });
            numericUpDown1.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(294, 23);
            numericUpDown1.TabIndex = 9;
            numericUpDown1.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // MapAdd
            // 
            AcceptButton = buttonAdd;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(464, 413);
            Controls.Add(numericUpDown1);
            Controls.Add(label3);
            Controls.Add(buttonAdd);
            Controls.Add(textBoxMapLabel);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(pictureBox1);
            Controls.Add(buttonBrowse);
            Controls.Add(textBoxFilename);
            Name = "MapAdd";
            Text = "MapAdd";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TextBox textBoxFilename;
        private Button buttonBrowse;
        private Label label1;
        private Label label2;
        private TextBox textBoxMapLabel;
        private Button buttonAdd;
        private PictureBox pictureBox1;
        private Label label3;
        private NumericUpDown numericUpDown1;
    }
}