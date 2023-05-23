namespace BeaconApp
{
    partial class MapDelete
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
            textBoxMapLabel = new TextBox();
            label1 = new Label();
            buttonDelete = new Button();
            SuspendLayout();
            // 
            // textBoxMapLabel
            // 
            textBoxMapLabel.Location = new Point(80, 6);
            textBoxMapLabel.Name = "textBoxMapLabel";
            textBoxMapLabel.Size = new Size(177, 23);
            textBoxMapLabel.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 10);
            label1.Name = "label1";
            label1.Size = new Size(62, 15);
            label1.TabIndex = 1;
            label1.Text = "Map Label";
            // 
            // buttonDelete
            // 
            buttonDelete.Location = new Point(263, 6);
            buttonDelete.Name = "buttonDelete";
            buttonDelete.Size = new Size(75, 23);
            buttonDelete.TabIndex = 2;
            buttonDelete.Text = "Delete";
            buttonDelete.UseVisualStyleBackColor = true;
            buttonDelete.Click += buttonDelete_Click;
            // 
            // MapDelete
            // 
            AcceptButton = buttonDelete;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(350, 39);
            Controls.Add(buttonDelete);
            Controls.Add(label1);
            Controls.Add(textBoxMapLabel);
            Name = "MapDelete";
            Text = "MapDelete";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBoxMapLabel;
        private Label label1;
        private Button buttonDelete;
    }
}