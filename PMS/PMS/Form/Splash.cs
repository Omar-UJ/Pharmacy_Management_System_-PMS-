using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PMS
{
    public partial class SplashForm : Form
    {
        public SplashForm()
        {
            InitializeComponent();
        }
        private void ProgressTimer_Tick(object sender, EventArgs e)
        {
            loadProgresssPanel.Width += 2;

            if (loadProgresssPanel.Width >= 800)
            {
                ProgressTimer.Stop();
                Login lg = new Login();
                lg.Location = new Point(this.Location.Y);
                lg.Show();
                this.Hide();
           }
        }
    }
}
