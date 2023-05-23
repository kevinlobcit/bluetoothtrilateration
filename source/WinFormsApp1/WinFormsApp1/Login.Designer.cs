namespace WinFormsApp1
{
    partial class Login
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
            buttonLogin = new Button();
            textBoxLogin = new TextBox();
            label2 = new Label();
            groupBox1 = new GroupBox();
            textBoxPassword = new TextBox();
            label3 = new Label();
            label1 = new Label();
            textBoxIP = new TextBox();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // buttonLogin
            // 
            buttonLogin.Location = new Point(151, 110);
            buttonLogin.Name = "buttonLogin";
            buttonLogin.Size = new Size(75, 23);
            buttonLogin.TabIndex = 3;
            buttonLogin.Text = "Login";
            buttonLogin.UseVisualStyleBackColor = true;
            buttonLogin.Click += buttonLogin_Click;
            // 
            // textBoxLogin
            // 
            textBoxLogin.Location = new Point(71, 52);
            textBoxLogin.Name = "textBoxLogin";
            textBoxLogin.Size = new Size(155, 23);
            textBoxLogin.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(8, 55);
            label2.Name = "label2";
            label2.Size = new Size(37, 15);
            label2.TabIndex = 5;
            label2.Text = "Login";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(textBoxPassword);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(textBoxIP);
            groupBox1.Controls.Add(buttonLogin);
            groupBox1.Controls.Add(textBoxLogin);
            groupBox1.Controls.Add(label2);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(242, 145);
            groupBox1.TabIndex = 6;
            groupBox1.TabStop = false;
            groupBox1.Text = "SQL Server Login";
            // 
            // textBoxPassword
            // 
            textBoxPassword.Location = new Point(71, 81);
            textBoxPassword.Name = "textBoxPassword";
            textBoxPassword.Size = new Size(155, 23);
            textBoxPassword.TabIndex = 2;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(8, 84);
            label3.Name = "label3";
            label3.Size = new Size(57, 15);
            label3.TabIndex = 10;
            label3.Text = "Password";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(8, 26);
            label1.Name = "label1";
            label1.Size = new Size(62, 15);
            label1.TabIndex = 8;
            label1.Text = "Ip Address";
            // 
            // textBoxIP
            // 
            textBoxIP.Location = new Point(71, 23);
            textBoxIP.Name = "textBoxIP";
            textBoxIP.Size = new Size(155, 23);
            textBoxIP.TabIndex = 0;
            // 
            // Form1
            // 
            AcceptButton = buttonLogin;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(265, 167);
            Controls.Add(groupBox1);
            Name = "Form1";
            Text = "Form1";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private GroupBox groupBox1;
        private Label label1;
        private Label label2;
        private Label label3;
        private Button buttonLogin;
        private TextBox textBoxIP;
        private TextBox textBoxLogin;
        private TextBox textBoxPassword;
    }
}