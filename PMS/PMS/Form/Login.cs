using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace PMS
{
    public partial class Login : System.Windows.Forms.Form
    {
        Connection connection = new Connection();
        SqlConnection con = Connection.CON();
        public Login()
        {
            InitializeComponent();
        }

        private void LinkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            forgetPassPanel.Visible = true;
        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {

        }

        private void Button3_Click(object sender, EventArgs e)
        {
        }

        private void Button2_Click(object sender, EventArgs e)
        {
           
        }

        private void LoginBtn_Click(object sender, EventArgs e)
        {



        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void Login_Load(object sender, EventArgs e)
        {

        }
        public void _Login()
        {
            PED ped = new PED();
            String query = "";
           // String encPassword = "";

            if (JobCB.Text.ToUpper() == "MANAGER")
                query = "SELECT *FROM MANAGER WHERE m_id='" + UserIdTB.Text
                    + "' AND m_password = '" + ped.Enc(PasswordTB.Text) + "'";
            else if (JobCB.Text.ToUpper() == "PHARMACIST")
                query = "SELECT *FROM PHARMACIST WHERE ph_id='" + UserIdTB.Text
                     + "' AND ph_password = '" + ped.Enc(PasswordTB.Text) + "'";
            else if (JobCB.Text.ToUpper() == "CASHIER")
                query = "SELECT *FROM CASHIER WHERE ca_id='" + UserIdTB.Text
                     + "' AND ca_password = '" + ped.Enc(PasswordTB.Text) + "'";
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            con.Close();
            if (dt.Rows.Count > 0)
            {
                if (rememberCB.Checked)
                {
                    string save_account = null;
                    save_account = "" + UserIdTB.Text + "\n" + PasswordTB.Text + "\n" + JobCB.Text;
                    if (File.Exists("rmbr.pmsac")) File.WriteAllText("rmbr.pmsac", string.Empty);
                    using (StreamWriter writer = new StreamWriter("rmbr.pmsac", true))
                    {
                        writer.Write(save_account);
                    }
                }
                string status = "";
                if (JobCB.Text.ToUpper() == "MANAGER")
                {
                    ManagerDashboard md = new ManagerDashboard(dt);
                    md.Size = new Size(this.Size.Width, this.Size.Height);
                    md.Location = new Point(this.Location.X, this.Location.Y);
                    md.Show();
                    this.Hide();
                }
                else if (JobCB.Text.ToUpper() == "CASHIER")
                {

                    foreach (DataRow row in dt.Rows)
                    {
                        status = row["ca_status"].ToString();
                    }
                    if (status.ToUpper() == "ACTIVE")
                    {
                        CSH_Menu md = new CSH_Menu(dt);
                        md.Size = new Size(this.Size.Width, this.Size.Height);
                        md.Location = new Point(this.Location.X, this.Location.Y);
                        md.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Your Account is no longer activated please contact your manager", "Deactivated Account!", MessageBoxButtons.OK);
                        if (File.Exists("rmbr.pmsac")) File.WriteAllText("rmbr.pmsac", string.Empty);
                    }
                }
                else if (JobCB.Text.ToUpper() == "PHARMACIST")
                {

                    foreach (DataRow row in dt.Rows)
                    {
                        status = row["ph_status"].ToString();
                    }
                    if (status.ToUpper() == "ACTIVE")
                    {
                        PHR_Menu ph = new PHR_Menu(dt);
                        ph.Size = new Size(this.Size.Width, this.Size.Height);
                        ph.Location = new Point(this.Location.X, this.Location.Y);
                        ph.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Your Account is no longer activated please contact your manager", "Deactivated Account!", MessageBoxButtons.OK);
                        if (File.Exists("rmbr.pmsac")) File.WriteAllText("rmbr.pmsac", string.Empty);
                    }
                }


            }
            else
            {
                MessageBox.Show("Please check your id and password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                UserIdTB.Clear();
                PasswordTB.Clear();
                if (File.Exists("rmbr.pmsac")) File.WriteAllText("rmbr.pmsac", string.Empty);
            }

        }
        private void RememberCB_CheckedChanged(object sender, EventArgs e)
        { }

        private void Login_Activated(object sender, EventArgs e)
        {


            String[] acc = null;
            if (File.Exists("rmbr.pmsac")) acc = File.ReadAllLines("rmbr.pmsac");
            if (acc.Length == 3)
                if (acc[0] != "" && acc[1] != "" && acc[2] != "")
                {
                    UserIdTB.Text = acc[0];
                    PasswordTB.Text = acc[1];
                    JobCB.Text = acc[2];
                    _Login();
                }
        }

        private void CancelResetPassBtn_Click(object sender, EventArgs e)
        {
            forgetPassPanel.Visible = false;
        }

        private void Login_Resize(object sender, EventArgs e)
        {
            abtPMSLabel.MaximumSize = new Size();
        }

        private void CreateAccBtn_Click(object sender, EventArgs e)
        {
            Register register = new Register();
            register.Size = new Size(this.Size.Width, this.Size.Height);
            register.Location = new Point(this.Location.X, this.Location.Y);
            register.Show();
            this.Hide();
        }

        private void LoginBtn_Click_1(object sender, EventArgs e)
        {
            if (UserIdTB.Text == "" || PasswordTB.Text == "" || JobCB.Text == "")
            {
                errorLB.Visible = true;

            }
            else _Login();
        }

        private void resetPassBtn_Click(object sender, EventArgs e)
        {
            PED ped = new PED();
            con.Open();
            if (activationkey.Text == "" || resetId.Text == "" || newpass.Text == "" || confirmpass.Text == "" || selectJobReset.Text == "")
            {
                MessageBox.Show("Please fill the form properly", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                String query = "";
                SqlDataAdapter sda;
                DataTable dt;
                if (selectJobReset.Text.ToUpper() == "MANAGER")
                {
                   query = "select p_id from PHARMACY WHERE m_activation_code = '" + activationkey.Text + "'";
                     sda = new SqlDataAdapter(query, con);
                     dt = new DataTable();
                    sda.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        query = "update  MANAGER SET ";
                        if (newpass.Text != "" && confirmpass.Text != "")
                        {

                            if (confirmpass.Text.Length >= 8)
                            {
                                SqlCommand cmd = new SqlCommand(query + " m_password = '" + ped.Enc(confirmpass.Text) + "'", con);

                                cmd.ExecuteNonQuery();
                                MessageBox.Show("Password Successfully Reseted", "Reset Password", MessageBoxButtons.OK);
                                forgetPassPanel.Visible = false;
                            }
                            else
                            {
                                MessageBox.Show("Password must contain at least 8 characters", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }


                        }
                    }
                    else
                    {
                        MessageBox.Show("Please check your reset key", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else if (selectJobReset.Text.ToUpper() == "CASHIER")
                {
                    query = "select p_id from PHARMACY WHERE  e_reset_key  = '" + activationkey.Text + "'";
                    
                    sda = new SqlDataAdapter(query, con);
                    dt = new DataTable();

                    sda.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {

                        string pid = "";
                            foreach (DataRow row in dt.Rows)
                        {
                            pid = row["p_id"].ToString();
                        }
                        query = "update  CASHIER SET ";
                        if (newpass.Text != "" && confirmpass.Text != "")
                        {

                            if (confirmpass.Text.Length >= 8)
                            {
                                SqlCommand cmd = new SqlCommand(query + " ca_password = '" + ped.Enc(confirmpass.Text) + "'", con);

                                cmd.ExecuteNonQuery();
                                MessageBox.Show("Password Successfully Reseted", "Reset Password", MessageBoxButtons.OK);
                                forgetPassPanel.Visible = false;

                                query = "update  PHARMACY SET" +
                                    " e_reset_key = NULL WHERE p_id = "+pid;
                                cmd = new SqlCommand(query, con);
                                cmd.ExecuteNonQuery();
                            }
                            else
                            {
                                MessageBox.Show("Password must contain at least 8 characters", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }


                        }
                    }
                    else
                    {
                        MessageBox.Show("Please check your reset key", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else if (selectJobReset.Text.ToUpper() == "PHARMACIST")
                {
                    query = "select p_id from PHARMACY WHERE e_reset_key = '" + activationkey.Text + "'";
                    sda = new SqlDataAdapter(query, con);
                    dt = new DataTable();
                    sda.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        string pid = "";
                        foreach (DataRow row in dt.Rows)
                        {
                            pid = row["p_id"].ToString();
                        }
                        query = "update  PHARMACIST SET ";
                        if (newpass.Text != "" && confirmpass.Text != "")
                        {

                            if (confirmpass.Text.Length >= 8)
                            {
                                SqlCommand cmd = new SqlCommand(query + " ph_password = '" + ped.Enc(confirmpass.Text) + "'", con);

                                cmd.ExecuteNonQuery();
                                MessageBox.Show("Password Successfully Reseted", "Reset Password", MessageBoxButtons.OK);


                                query = "update  PHARMACY SET" +
                                  " e_reset_key = NULL WHERE p_id = " + pid;
                                cmd = new SqlCommand(query, con);
                                cmd.ExecuteNonQuery();
                                forgetPassPanel.Visible = false;
                            }
                            else
                            {
                                MessageBox.Show("Password must contain at least 8 characters", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }


                        }
                    }
                    else
                    {
                        MessageBox.Show("Please check your reset key", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
                else
                {

                }

                

            }con.Close();
        }
    }
}
