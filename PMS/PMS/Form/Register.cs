using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
//using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PMS
{
    public partial class Register : System.Windows.Forms.Form
    {
        Connection connection = new Connection();
        SqlConnection con = Connection.CON();
        public Register()
        {
            InitializeComponent();
        }
       

        private void Button3_Click(object sender, EventArgs e)
        {
          
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.Size = new Size(this.Size.Width, this.Size.Height);
            login.Location = new Point(this.Location.X, this.Location.Y);
            login.Show();
            this.Hide();
        }

        private void RegisterBtn_Click(object sender, EventArgs e)
        {
            
        }

        private void RichTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Pass_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Register_Load(object sender, EventArgs e)
        {

        }

        private void BirthDC_ValueChanged(object sender, EventArgs e)
        {

        }

        private void Button2_Click(object sender, EventArgs e)
        {

        }

        private void PNumberTB_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }
        }
    string p_id = "", genderInRegister = "";
        private void RegisterBtn_Click_1(object sender, EventArgs e)
        {
               
                if (maleRB.Checked) genderInRegister = "M";
                else if (femaleRB.Checked) genderInRegister = "F";
                else genderInRegister = "";
            if (FNameTB.Text == "" || LNameTB.Text == "" || PNumberTB.Text == "+251" || CityCB.Text == "" || AddressTB.Text == "" || genderInRegister == "")
            {
                     errorLB.Visible = true;
            }
            else
            {

                String query = "select p_id from PHARMACY WHERE m_activation_code = '" + activeTB.Text + "'";
                SqlDataAdapter sda = new SqlDataAdapter(query, con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                con.Close();

                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        p_id = row["p_id"].ToString();

                        DialogResult dialogResult = MessageBox.Show("Are you sure, you want to register?", "Register", MessageBoxButtons.YesNo);
                        if (dialogResult == DialogResult.Yes)
                        {
                            setPasswordPanel.Visible = true;
                        }

                        
                    }
                }
                else
                {
                    MessageBox.Show("Please check your activation code", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }public void createAcc()
        {
            PED ped = new PED();

            SqlCommand cmd = new SqlCommand("insert into MANAGER ( m_name,m_lname,m_phone,m_dob,m_city,m_address,m_password,m_gender,p_id)" +
                            " values ('" + FNameTB.Text + "','" + LNameTB.Text + "','" + PNumberTB.Text + "','" + birthDC.Value.ToString() + "','" + CityCB.Text + "','" + AddressTB.Text + "','"+ped.Enc(confirmPassTb.Text) +"','" + genderInRegister + "','" + p_id + "');", con);
            con.Open();
            cmd.ExecuteNonQuery();
           
           

            String query = "select m_id,m_name,m_password FROM MANAGER WHERE m_name = '" + FNameTB.Text + "' AND m_phone = '"+PNumberTB.Text+"'";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                string mid = "",mname="",mpassword="";
                foreach (DataRow row in dt.Rows)
                {
                    mid = row["m_id"].ToString();
                    mname = row["m_name"].ToString();
                    mpassword = row["m_password"].ToString();

                }
                MessageBox.Show("Manager Successfully Registered", "Account", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                MessageBox.Show("ID : " + mid+"\n"+ "Name : " + mname + "\n" + "Password : " + mpassword , "Account Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Login login = new Login();
                login.Size = new Size(this.Size.Width, this.Size.Height);
                login.Location = new Point(this.Location.X, this.Location.Y);
                login.Show();
                this.Hide();
            }
            con.Close();
        }

        private void CancelBtn_Click(object sender, EventArgs e)
        {
            setPasswordPanel.Visible = false;
        }

        private void ContinueBtn_Click(object sender, EventArgs e)
        {
            if(newPassTB.Text == "" || confirmPassTb.Text == "")
            {
                passLengthErorr.Visible = false;
                notMatchErorr.Visible = false;
                fillPassErorr.Visible = true;
            }else if(newPassTB.Text != confirmPassTb.Text)
            {
                passLengthErorr.Visible = false;
                fillPassErorr.Visible = false;
                notMatchErorr.Visible = true;
            }
            else if (confirmPassTb.Text.Length<9)
            {
                fillPassErorr.Visible = false;
                notMatchErorr.Visible = false;
                passLengthErorr.Visible = true;
            }
            else
            {
                createAcc();
            }
        }
    }
}
