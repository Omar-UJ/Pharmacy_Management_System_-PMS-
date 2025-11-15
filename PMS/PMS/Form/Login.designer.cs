namespace PMS
{
    partial class Login
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            this.forgatPassLink = new System.Windows.Forms.LinkLabel();
            this.JobCB = new System.Windows.Forms.ComboBox();
            this.PasswordTB = new System.Windows.Forms.TextBox();
            this.UserIdTB = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.loginBtn = new PMS.RJButton();
            this.createAccBtn = new PMS.RJButton();
            this.rememberCB = new System.Windows.Forms.CheckBox();
            this.errorLB = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.abtPMSLabel = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.selectJobReset = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cancelResetPassBtn = new System.Windows.Forms.Button();
            this.resetPassBtn = new System.Windows.Forms.Button();
            this.activationkey = new System.Windows.Forms.TextBox();
            this.resetId = new System.Windows.Forms.TextBox();
            this.confirmpass = new System.Windows.Forms.TextBox();
            this.newpass = new System.Windows.Forms.TextBox();
            this.forgetPassPanel = new System.Windows.Forms.Panel();
            this.groupBox2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.forgetPassPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // forgatPassLink
            // 
            this.forgatPassLink.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.forgatPassLink.AutoSize = true;
            this.forgatPassLink.Font = new System.Drawing.Font("Gabriola", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.forgatPassLink.LinkColor = System.Drawing.SystemColors.Highlight;
            this.forgatPassLink.Location = new System.Drawing.Point(265, 375);
            this.forgatPassLink.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.forgatPassLink.Name = "forgatPassLink";
            this.forgatPassLink.Size = new System.Drawing.Size(128, 37);
            this.forgatPassLink.TabIndex = 5;
            this.forgatPassLink.TabStop = true;
            this.forgatPassLink.Text = "Forgat password ?";
            this.forgatPassLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkLabel1_LinkClicked);
            // 
            // JobCB
            // 
            this.JobCB.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.JobCB.BackColor = System.Drawing.Color.FloralWhite;
            this.JobCB.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.JobCB.ForeColor = System.Drawing.Color.MediumSeaGreen;
            this.JobCB.FormattingEnabled = true;
            this.JobCB.Items.AddRange(new object[] {
            "CASHIER",
            "MANAGER",
            "PHARMACIST",
            "OTHERS"});
            this.JobCB.Location = new System.Drawing.Point(79, 324);
            this.JobCB.Margin = new System.Windows.Forms.Padding(4);
            this.JobCB.Name = "JobCB";
            this.JobCB.Size = new System.Drawing.Size(283, 32);
            this.JobCB.TabIndex = 4;
            this.JobCB.SelectedIndexChanged += new System.EventHandler(this.ComboBox1_SelectedIndexChanged);
            // 
            // PasswordTB
            // 
            this.PasswordTB.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.PasswordTB.BackColor = System.Drawing.Color.Ivory;
            this.PasswordTB.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PasswordTB.ForeColor = System.Drawing.Color.MediumSeaGreen;
            this.PasswordTB.Location = new System.Drawing.Point(79, 257);
            this.PasswordTB.Margin = new System.Windows.Forms.Padding(4);
            this.PasswordTB.Name = "PasswordTB";
            this.PasswordTB.PasswordChar = '*';
            this.PasswordTB.Size = new System.Drawing.Size(283, 30);
            this.PasswordTB.TabIndex = 0;
            // 
            // UserIdTB
            // 
            this.UserIdTB.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.UserIdTB.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.UserIdTB.BackColor = System.Drawing.Color.Ivory;
            this.UserIdTB.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UserIdTB.ForeColor = System.Drawing.Color.MediumSeaGreen;
            this.UserIdTB.Location = new System.Drawing.Point(79, 193);
            this.UserIdTB.Margin = new System.Windows.Forms.Padding(4);
            this.UserIdTB.Name = "UserIdTB";
            this.UserIdTB.Size = new System.Drawing.Size(283, 30);
            this.UserIdTB.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox2.Controls.Add(this.loginBtn);
            this.groupBox2.Controls.Add(this.createAccBtn);
            this.groupBox2.Controls.Add(this.rememberCB);
            this.groupBox2.Controls.Add(this.errorLB);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.UserIdTB);
            this.groupBox2.Controls.Add(this.PasswordTB);
            this.groupBox2.Controls.Add(this.forgatPassLink);
            this.groupBox2.Controls.Add(this.JobCB);
            this.groupBox2.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(85, 44);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(456, 694);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "LOGIN";
            this.groupBox2.Enter += new System.EventHandler(this.groupBox2_Enter);
            // 
            // loginBtn
            // 
            this.loginBtn.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.loginBtn.FlatAppearance.BorderSize = 0;
            this.loginBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.loginBtn.ForeColor = System.Drawing.Color.White;
            this.loginBtn.Location = new System.Drawing.Point(79, 474);
            this.loginBtn.Margin = new System.Windows.Forms.Padding(4);
            this.loginBtn.Name = "loginBtn";
            this.loginBtn.Size = new System.Drawing.Size(284, 49);
            this.loginBtn.TabIndex = 11;
            this.loginBtn.Text = "Login";
            this.loginBtn.UseVisualStyleBackColor = false;
            this.loginBtn.Click += new System.EventHandler(this.LoginBtn_Click_1);
            // 
            // createAccBtn
            // 
            this.createAccBtn.BackColor = System.Drawing.Color.Gray;
            this.createAccBtn.FlatAppearance.BorderSize = 0;
            this.createAccBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.createAccBtn.ForeColor = System.Drawing.Color.White;
            this.createAccBtn.Location = new System.Drawing.Point(79, 533);
            this.createAccBtn.Margin = new System.Windows.Forms.Padding(4);
            this.createAccBtn.Name = "createAccBtn";
            this.createAccBtn.Size = new System.Drawing.Size(284, 47);
            this.createAccBtn.TabIndex = 10;
            this.createAccBtn.Text = "Create Manager account?";
            this.createAccBtn.UseVisualStyleBackColor = false;
            this.createAccBtn.Click += new System.EventHandler(this.CreateAccBtn_Click);
            // 
            // rememberCB
            // 
            this.rememberCB.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.rememberCB.AutoSize = true;
            this.rememberCB.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.rememberCB.Location = new System.Drawing.Point(79, 384);
            this.rememberCB.Margin = new System.Windows.Forms.Padding(4);
            this.rememberCB.Name = "rememberCB";
            this.rememberCB.Size = new System.Drawing.Size(121, 21);
            this.rememberCB.TabIndex = 9;
            this.rememberCB.Text = "Remember Me";
            this.rememberCB.UseVisualStyleBackColor = true;
            this.rememberCB.CheckedChanged += new System.EventHandler(this.RememberCB_CheckedChanged);
            // 
            // errorLB
            // 
            this.errorLB.AutoSize = true;
            this.errorLB.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.errorLB.ForeColor = System.Drawing.Color.Red;
            this.errorLB.Location = new System.Drawing.Point(75, 94);
            this.errorLB.Name = "errorLB";
            this.errorLB.Size = new System.Drawing.Size(237, 22);
            this.errorLB.TabIndex = 8;
            this.errorLB.Text = "Please fill the form properly";
            this.errorLB.Visible = false;
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.label4.Location = new System.Drawing.Point(79, 304);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 17);
            this.label4.TabIndex = 7;
            this.label4.Text = "Job Position";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.label3.Location = new System.Drawing.Point(79, 238);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 17);
            this.label3.TabIndex = 7;
            this.label3.Text = "Password";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.label2.Location = new System.Drawing.Point(79, 170);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 17);
            this.label2.TabIndex = 7;
            this.label2.Text = "User ID";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.label1.Location = new System.Drawing.Point(29, 25);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(263, 17);
            this.label1.TabIndex = 6;
            this.label1.Text = "Login to get more access and information";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panel1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Location = new System.Drawing.Point(1, -4);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(603, 794);
            this.panel1.TabIndex = 2;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // panel2
            // 
            this.panel2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.panel2.AutoSize = true;
            this.panel2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel2.BackgroundImage")));
            this.panel2.Location = new System.Drawing.Point(612, -4);
            this.panel2.Margin = new System.Windows.Forms.Padding(4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(779, 537);
            this.panel2.TabIndex = 3;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // abtPMSLabel
            // 
            this.abtPMSLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.abtPMSLabel.AutoSize = true;
            this.abtPMSLabel.BackColor = System.Drawing.Color.Transparent;
            this.abtPMSLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.abtPMSLabel.ForeColor = System.Drawing.Color.MediumSeaGreen;
            this.abtPMSLabel.Location = new System.Drawing.Point(664, 553);
            this.abtPMSLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.abtPMSLabel.Name = "abtPMSLabel";
            this.abtPMSLabel.Size = new System.Drawing.Size(727, 144);
            this.abtPMSLabel.TabIndex = 4;
            this.abtPMSLabel.Text = resources.GetString("abtPMSLabel.Text");
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.groupBox1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.selectJobReset);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.cancelResetPassBtn);
            this.groupBox1.Controls.Add(this.resetPassBtn);
            this.groupBox1.Controls.Add(this.activationkey);
            this.groupBox1.Controls.Add(this.resetId);
            this.groupBox1.Controls.Add(this.confirmpass);
            this.groupBox1.Controls.Add(this.newpass);
            this.groupBox1.Location = new System.Drawing.Point(37, 20);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(480, 570);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Reset Password";
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.label5.Location = new System.Drawing.Point(93, 169);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(85, 17);
            this.label5.TabIndex = 22;
            this.label5.Text = "Job Position";
            // 
            // selectJobReset
            // 
            this.selectJobReset.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.selectJobReset.BackColor = System.Drawing.Color.White;
            this.selectJobReset.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.selectJobReset.ForeColor = System.Drawing.Color.MediumSeaGreen;
            this.selectJobReset.FormattingEnabled = true;
            this.selectJobReset.Items.AddRange(new object[] {
            "CASHIER",
            "MANAGER",
            "PHARMACIST",
            "OTHERS"});
            this.selectJobReset.Location = new System.Drawing.Point(93, 189);
            this.selectJobReset.Margin = new System.Windows.Forms.Padding(4);
            this.selectJobReset.Name = "selectJobReset";
            this.selectJobReset.Size = new System.Drawing.Size(299, 32);
            this.selectJobReset.TabIndex = 21;
            // 
            // label9
            // 
            this.label9.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.label9.Location = new System.Drawing.Point(280, 105);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(21, 17);
            this.label9.TabIndex = 15;
            this.label9.Text = "ID";
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.label8.Location = new System.Drawing.Point(93, 107);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(73, 17);
            this.label8.TabIndex = 16;
            this.label8.Text = "Reset Key";
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.label7.Location = new System.Drawing.Point(93, 295);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(121, 17);
            this.label7.TabIndex = 17;
            this.label7.Text = "Confirm Password";
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.label6.Location = new System.Drawing.Point(91, 234);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(100, 17);
            this.label6.TabIndex = 18;
            this.label6.Text = "New Password";
            // 
            // cancelResetPassBtn
            // 
            this.cancelResetPassBtn.Location = new System.Drawing.Point(139, 398);
            this.cancelResetPassBtn.Margin = new System.Windows.Forms.Padding(4);
            this.cancelResetPassBtn.Name = "cancelResetPassBtn";
            this.cancelResetPassBtn.Size = new System.Drawing.Size(191, 28);
            this.cancelResetPassBtn.TabIndex = 14;
            this.cancelResetPassBtn.Text = "cancel";
            this.cancelResetPassBtn.UseVisualStyleBackColor = true;
            this.cancelResetPassBtn.Click += new System.EventHandler(this.CancelResetPassBtn_Click);
            // 
            // resetPassBtn
            // 
            this.resetPassBtn.Location = new System.Drawing.Point(139, 350);
            this.resetPassBtn.Margin = new System.Windows.Forms.Padding(4);
            this.resetPassBtn.Name = "resetPassBtn";
            this.resetPassBtn.Size = new System.Drawing.Size(191, 28);
            this.resetPassBtn.TabIndex = 13;
            this.resetPassBtn.Text = "Reset";
            this.resetPassBtn.UseVisualStyleBackColor = true;
            this.resetPassBtn.Click += new System.EventHandler(this.resetPassBtn_Click);
            // 
            // activationkey
            // 
            this.activationkey.Location = new System.Drawing.Point(89, 129);
            this.activationkey.Margin = new System.Windows.Forms.Padding(4);
            this.activationkey.Name = "activationkey";
            this.activationkey.Size = new System.Drawing.Size(151, 22);
            this.activationkey.TabIndex = 12;
            // 
            // resetId
            // 
            this.resetId.Location = new System.Drawing.Point(277, 129);
            this.resetId.Margin = new System.Windows.Forms.Padding(4);
            this.resetId.Name = "resetId";
            this.resetId.Size = new System.Drawing.Size(113, 22);
            this.resetId.TabIndex = 11;
            // 
            // confirmpass
            // 
            this.confirmpass.Location = new System.Drawing.Point(89, 316);
            this.confirmpass.Margin = new System.Windows.Forms.Padding(4);
            this.confirmpass.Name = "confirmpass";
            this.confirmpass.Size = new System.Drawing.Size(301, 22);
            this.confirmpass.TabIndex = 10;
            // 
            // newpass
            // 
            this.newpass.Location = new System.Drawing.Point(89, 255);
            this.newpass.Margin = new System.Windows.Forms.Padding(4);
            this.newpass.Name = "newpass";
            this.newpass.Size = new System.Drawing.Size(301, 22);
            this.newpass.TabIndex = 9;
            // 
            // forgetPassPanel
            // 
            this.forgetPassPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.forgetPassPanel.BackColor = System.Drawing.Color.MediumAquamarine;
            this.forgetPassPanel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("forgetPassPanel.BackgroundImage")));
            this.forgetPassPanel.Controls.Add(this.groupBox1);
            this.forgetPassPanel.Location = new System.Drawing.Point(424, 78);
            this.forgetPassPanel.Margin = new System.Windows.Forms.Padding(4);
            this.forgetPassPanel.Name = "forgetPassPanel";
            this.forgetPassPanel.Size = new System.Drawing.Size(555, 603);
            this.forgetPassPanel.TabIndex = 7;
            this.forgetPassPanel.Visible = false;
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1451, 783);
            this.Controls.Add(this.forgetPassPanel);
            this.Controls.Add(this.abtPMSLabel);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1469, 830);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(1469, 830);
            this.Name = "Login";
            this.Opacity = 0.98D;
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "PMS";
            this.Activated += new System.EventHandler(this.Login_Activated);
            this.Load += new System.EventHandler(this.Login_Load);
            this.Resize += new System.EventHandler(this.Login_Resize);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.forgetPassPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox PasswordTB;
        private System.Windows.Forms.TextBox UserIdTB;
        private System.Windows.Forms.ComboBox JobCB;
        private System.Windows.Forms.LinkLabel forgatPassLink;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label errorLB;
        private System.Windows.Forms.Label abtPMSLabel;
        private System.Windows.Forms.CheckBox rememberCB;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button cancelResetPassBtn;
        private System.Windows.Forms.Button resetPassBtn;
        private System.Windows.Forms.TextBox activationkey;
        private System.Windows.Forms.TextBox resetId;
        private System.Windows.Forms.TextBox confirmpass;
        private System.Windows.Forms.TextBox newpass;
        private System.Windows.Forms.Panel forgetPassPanel;
        private RJButton createAccBtn;
        private RJButton loginBtn;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox selectJobReset;
    }
}

