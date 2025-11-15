using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PMS
{
    public partial class ManagerDashboard : Form
    {

        DataTable dataTable;
        M_Menu mm;
        public ManagerDashboard(DataTable dt)
        {
            InitializeComponent();
            this.dataTable = dt;


        }

        public void menu(String type){
            mm = new M_Menu(this.dataTable, type);
            mm.Size = new Size(this.Size.Width, this.Size.Height);
            mm.Location = new Point(this.Location.X, this.Location.Y);
            mm.Show();
            this.Hide();
        }
        private void ManagerDashborad_Load(object sender, EventArgs e)
        {
           
        }

        private void Button11_Click(object sender, EventArgs e)
        {
            menu("search");
        }

        private void Button12_Click(object sender, EventArgs e)
        {
          
            menu("items");
           
        }

        private void SettingsInDashboarfBtn_Click(object sender, EventArgs e)
        {
            menu("setting");
        }

        private void EmployeeInDashboarfBtn_Click(object sender, EventArgs e)
        {
              menu("employee");
        }

        private void ReportInDashboarfBtn_Click(object sender, EventArgs e)
        {
                 menu("report");
        }

        private void Panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void WelcomeBtn_Click(object sender, EventArgs e)
        {
            menu("welcome");
        }
    }
}
