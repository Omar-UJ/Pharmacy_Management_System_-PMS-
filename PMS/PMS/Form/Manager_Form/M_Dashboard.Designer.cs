namespace PMS
{
    partial class ManagerDashboard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ManagerDashboard));
            this.panel3 = new System.Windows.Forms.Panel();
            this.welcomeBtn = new System.Windows.Forms.Button();
            this.settingsInDashboarfBtn = new System.Windows.Forms.Button();
            this.employeeInDashboarfBtn = new System.Windows.Forms.Button();
            this.searchInDashboardBtn = new System.Windows.Forms.Button();
            this.itemsInDashboarfBtn = new System.Windows.Forms.Button();
            this.reportInDashboarfBtn = new System.Windows.Forms.Button();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.Controls.Add(this.welcomeBtn);
            this.panel3.Controls.Add(this.settingsInDashboarfBtn);
            this.panel3.Controls.Add(this.employeeInDashboarfBtn);
            this.panel3.Controls.Add(this.searchInDashboardBtn);
            this.panel3.Controls.Add(this.itemsInDashboarfBtn);
            this.panel3.Controls.Add(this.reportInDashboarfBtn);
            this.panel3.Location = new System.Drawing.Point(2, 0);
            this.panel3.Margin = new System.Windows.Forms.Padding(2);
            this.panel3.MinimumSize = new System.Drawing.Size(1106, 683);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1106, 683);
            this.panel3.TabIndex = 8;
            this.panel3.Paint += new System.Windows.Forms.PaintEventHandler(this.Panel3_Paint);
            // 
            // welcomeBtn
            // 
            this.welcomeBtn.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.welcomeBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.welcomeBtn.ForeColor = System.Drawing.Color.MediumSeaGreen;
            this.welcomeBtn.Image = ((System.Drawing.Image)(resources.GetObject("welcomeBtn.Image")));
            this.welcomeBtn.Location = new System.Drawing.Point(125, 90);
            this.welcomeBtn.Name = "welcomeBtn";
            this.welcomeBtn.Size = new System.Drawing.Size(200, 237);
            this.welcomeBtn.TabIndex = 8;
            this.welcomeBtn.Text = "Welcome";
            this.welcomeBtn.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.welcomeBtn.UseVisualStyleBackColor = true;
            this.welcomeBtn.Click += new System.EventHandler(this.WelcomeBtn_Click);
            // 
            // settingsInDashboarfBtn
            // 
            this.settingsInDashboarfBtn.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.settingsInDashboarfBtn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("settingsInDashboarfBtn.BackgroundImage")));
            this.settingsInDashboarfBtn.Font = new System.Drawing.Font("Century Schoolbook", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.settingsInDashboarfBtn.ForeColor = System.Drawing.Color.OrangeRed;
            this.settingsInDashboarfBtn.Image = ((System.Drawing.Image)(resources.GetObject("settingsInDashboarfBtn.Image")));
            this.settingsInDashboarfBtn.Location = new System.Drawing.Point(744, 90);
            this.settingsInDashboarfBtn.Margin = new System.Windows.Forms.Padding(2);
            this.settingsInDashboarfBtn.Name = "settingsInDashboarfBtn";
            this.settingsInDashboarfBtn.Size = new System.Drawing.Size(274, 160);
            this.settingsInDashboarfBtn.TabIndex = 5;
            this.settingsInDashboarfBtn.Text = "Settings";
            this.settingsInDashboarfBtn.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.settingsInDashboarfBtn.UseVisualStyleBackColor = true;
            this.settingsInDashboarfBtn.Click += new System.EventHandler(this.SettingsInDashboarfBtn_Click);
            // 
            // employeeInDashboarfBtn
            // 
            this.employeeInDashboarfBtn.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.employeeInDashboarfBtn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("employeeInDashboarfBtn.BackgroundImage")));
            this.employeeInDashboarfBtn.Font = new System.Drawing.Font("Century Schoolbook", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.employeeInDashboarfBtn.ForeColor = System.Drawing.Color.OrangeRed;
            this.employeeInDashboarfBtn.Image = ((System.Drawing.Image)(resources.GetObject("employeeInDashboarfBtn.Image")));
            this.employeeInDashboarfBtn.ImageAlign = System.Drawing.ContentAlignment.TopRight;
            this.employeeInDashboarfBtn.Location = new System.Drawing.Point(744, 285);
            this.employeeInDashboarfBtn.Margin = new System.Windows.Forms.Padding(2);
            this.employeeInDashboarfBtn.Name = "employeeInDashboarfBtn";
            this.employeeInDashboarfBtn.Size = new System.Drawing.Size(283, 197);
            this.employeeInDashboarfBtn.TabIndex = 6;
            this.employeeInDashboarfBtn.Text = "Manage Employee";
            this.employeeInDashboarfBtn.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.employeeInDashboarfBtn.UseVisualStyleBackColor = true;
            this.employeeInDashboarfBtn.Click += new System.EventHandler(this.EmployeeInDashboarfBtn_Click);
            // 
            // searchInDashboardBtn
            // 
            this.searchInDashboardBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.searchInDashboardBtn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("searchInDashboardBtn.BackgroundImage")));
            this.searchInDashboardBtn.FlatAppearance.BorderColor = System.Drawing.Color.MediumSeaGreen;
            this.searchInDashboardBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.MediumSeaGreen;
            this.searchInDashboardBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumSeaGreen;
            this.searchInDashboardBtn.Font = new System.Drawing.Font("Century Schoolbook", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchInDashboardBtn.ForeColor = System.Drawing.Color.OrangeRed;
            this.searchInDashboardBtn.Image = ((System.Drawing.Image)(resources.GetObject("searchInDashboardBtn.Image")));
            this.searchInDashboardBtn.Location = new System.Drawing.Point(385, 90);
            this.searchInDashboardBtn.Margin = new System.Windows.Forms.Padding(2);
            this.searchInDashboardBtn.Name = "searchInDashboardBtn";
            this.searchInDashboardBtn.Size = new System.Drawing.Size(274, 160);
            this.searchInDashboardBtn.TabIndex = 2;
            this.searchInDashboardBtn.Text = "Search";
            this.searchInDashboardBtn.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.searchInDashboardBtn.UseVisualStyleBackColor = true;
            this.searchInDashboardBtn.Click += new System.EventHandler(this.Button11_Click);
            // 
            // itemsInDashboarfBtn
            // 
            this.itemsInDashboarfBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.itemsInDashboarfBtn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("itemsInDashboarfBtn.BackgroundImage")));
            this.itemsInDashboarfBtn.Font = new System.Drawing.Font("Century Schoolbook", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.itemsInDashboarfBtn.ForeColor = System.Drawing.Color.OrangeRed;
            this.itemsInDashboarfBtn.Image = ((System.Drawing.Image)(resources.GetObject("itemsInDashboarfBtn.Image")));
            this.itemsInDashboarfBtn.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.itemsInDashboarfBtn.Location = new System.Drawing.Point(394, 285);
            this.itemsInDashboarfBtn.Margin = new System.Windows.Forms.Padding(2);
            this.itemsInDashboarfBtn.Name = "itemsInDashboarfBtn";
            this.itemsInDashboarfBtn.Size = new System.Drawing.Size(274, 197);
            this.itemsInDashboarfBtn.TabIndex = 3;
            this.itemsInDashboarfBtn.Text = "Manage Itemes";
            this.itemsInDashboarfBtn.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.itemsInDashboarfBtn.UseVisualStyleBackColor = true;
            this.itemsInDashboarfBtn.Click += new System.EventHandler(this.Button12_Click);
            // 
            // reportInDashboarfBtn
            // 
            this.reportInDashboarfBtn.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.reportInDashboarfBtn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("reportInDashboarfBtn.BackgroundImage")));
            this.reportInDashboarfBtn.Font = new System.Drawing.Font("Century Schoolbook", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.reportInDashboarfBtn.ForeColor = System.Drawing.Color.OrangeRed;
            this.reportInDashboarfBtn.Image = ((System.Drawing.Image)(resources.GetObject("reportInDashboarfBtn.Image")));
            this.reportInDashboarfBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.reportInDashboarfBtn.Location = new System.Drawing.Point(125, 350);
            this.reportInDashboarfBtn.Margin = new System.Windows.Forms.Padding(2);
            this.reportInDashboarfBtn.Name = "reportInDashboarfBtn";
            this.reportInDashboarfBtn.Size = new System.Drawing.Size(203, 132);
            this.reportInDashboarfBtn.TabIndex = 4;
            this.reportInDashboarfBtn.Text = "Report";
            this.reportInDashboarfBtn.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.reportInDashboarfBtn.UseVisualStyleBackColor = true;
            this.reportInDashboarfBtn.Click += new System.EventHandler(this.ReportInDashboarfBtn_Click);
            // 
            // ManagerDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1090, 644);
            this.Controls.Add(this.panel3);
            this.MinimumSize = new System.Drawing.Size(1106, 683);
            this.Name = "ManagerDashboard";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Dashboard";
            this.Load += new System.EventHandler(this.ManagerDashborad_Load);
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button welcomeBtn;
        private System.Windows.Forms.Button settingsInDashboarfBtn;
        private System.Windows.Forms.Button employeeInDashboarfBtn;
        private System.Windows.Forms.Button searchInDashboardBtn;
        private System.Windows.Forms.Button itemsInDashboarfBtn;
        private System.Windows.Forms.Button reportInDashboarfBtn;
    }
}