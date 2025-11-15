using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace PMS
{
    public partial class PHR_Menu : Form
    {
        Connection connection = new Connection();
        SqlConnection con = Connection.CON();
        String id = "", name = "", lName = "", phone = "", pharmacy_id = "";
        String city = "", address = "", dob = "", gender = "", password = "";

        private void C_MenuListPanel_MouseHover(object sender, EventArgs e)
        {
            C_MenuListPanel.BringToFront();
        }

        private void PHR_MenuSettingsBtn_MouseLeave(object sender, EventArgs e)
        {
            C_MenuBGPanel.BringToFront();
        }

        private void searchBtn_MouseLeave(object sender, EventArgs e)
        {
            C_MenuBGPanel.BringToFront();
        }

        private void C_MenuListPanel_MouseLeave(object sender, EventArgs e)
        {
            C_MenuBGPanel.BringToFront();
        }

        private void M_searchBtn_Click(object sender, EventArgs e)
        {
            M_hide();
            C_searchItemsPanel.Visible = true;
            M_searchItemTB.Visible = true;
            M_searchBtn.Visible = false;
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT *from VIEW_ITEMS  WHERE p_id = '" + this.pharmacy_id + "'", con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                emptyIconPB.Visible = false;
                searchDGV.DataSource = dt;
                searchDGV.Columns[0].HeaderText = "ID";
                searchDGV.Columns[1].HeaderText = "Name";
                searchDGV.Columns[2].HeaderText = "Descripition";
                searchDGV.Columns[3].HeaderText = "Pur Price";
                searchDGV.Columns[4].HeaderText = "Sell Price";
                searchDGV.Columns[5].HeaderText = "Quantity";
                searchDGV.Columns[6].HeaderText = "Mfg Date";
                searchDGV.Columns[7].HeaderText = "Import Date";
                searchDGV.Columns[8].HeaderText = "Exp-Date";
                searchDGV.Columns[9].HeaderText = "Pharmacy ID";
            }
            else
            {
                emptyIconPB.Visible = true;
            }
            con.Close();
        }

        private void M_searchItemTB_TextChanged(object sender, EventArgs e)
        {
            C_searchItemsPanel.Visible = true;
            string search;
            search = M_searchItemTB.Text.Trim();

            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT *from VIEW_ITEMS WHERE i_name like '%" + search + "%' AND  p_id = '" + pharmacy_id + "'" + "OR i_id like '%" + search + "%' AND  p_id = '" + pharmacy_id + "'", con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                emptyIconPB.Visible = false;
                searchDGV.DataSource = dt;
                searchDGV.Columns[0].HeaderText = "ID";
                searchDGV.Columns[1].HeaderText = "Name";
                searchDGV.Columns[2].HeaderText = "Descripition";
                searchDGV.Columns[3].HeaderText = "Pur Price";
                searchDGV.Columns[4].HeaderText = "Sell Price";
                searchDGV.Columns[5].HeaderText = "Quantity";
                searchDGV.Columns[6].HeaderText = "Mfg Date";
                searchDGV.Columns[7].HeaderText = "Import Date";
                searchDGV.Columns[8].HeaderText = "Exp-Date";
                searchDGV.Columns[9].HeaderText = "Pharmacy ID";
            }
            else
            {
                searchDGV.DataSource = null;
                emptyIconPB.Visible = true;
            }
            con.Close();
        }

        private void searchBtn_Click(object sender, EventArgs e)
        {
            M_hide();
            C_searchItemsPanel.Visible = true;
            M_searchItemTB.Visible = true;
            M_searchBtn.Visible = false;
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT *from VIEW_ITEMS  WHERE p_id = '" + this.pharmacy_id + "'", con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                emptyIconPB.Visible = false;
                searchDGV.DataSource = dt;
                searchDGV.Columns[0].HeaderText = "ID";
                searchDGV.Columns[1].HeaderText = "Name";
                searchDGV.Columns[2].HeaderText = "Descripition";
                searchDGV.Columns[3].HeaderText = "Pur Price";
                searchDGV.Columns[4].HeaderText = "Sell Price";
                searchDGV.Columns[5].HeaderText = "Quantity";
                searchDGV.Columns[6].HeaderText = "Mfg Date";
                searchDGV.Columns[7].HeaderText = "Import Date";
                searchDGV.Columns[8].HeaderText = "Exp-Date";
                searchDGV.Columns[9].HeaderText = "Pharmacy ID";
            }
            else
            {
                emptyIconPB.Visible = true;
            }
            con.Close();
        }

        private void M_LogoutBtn_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            DialogResult dialogResult = MessageBox.Show("Are you sure, you want to logout?", "Logout", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                File.WriteAllText("rmbr.pmsac", string.Empty); this.Hide();
                login.Size = new Size(this.Size.Width, this.Size.Height);
                login.Location = new Point(this.Location.X, this.Location.Y);
                login.Show();
            }
        }
        public void SelectProfilePicture()
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "JPG Files(*.jpg)|*.jpg|PNG Files(*.png)|*.png|All Files(*.*)|*.*";
            DialogResult dr = ofd.ShowDialog();
            if (dr == DialogResult.OK)
            {
                Image i = Image.FromFile(ofd.FileName);
                Bitmap b = (Bitmap)i;
                profilepicture.Image = b;
            }

        }

        private void ChangePPictureBtn_Click(object sender, EventArgs e)
        {
            SelectProfilePicture();


            string query = "update  PHARMACIST SET " +
                "ph_profile_pic = @PP" +
                 " WHERE ph_id = '" + id + "'";
            con.Open();
            SqlCommand cmd = new SqlCommand(query, con);

            MemoryStream stream = new MemoryStream();
            profilepicture.Image.Save(stream, ImageFormat.Jpeg);
            byte[] pPicture = stream.ToArray();
            cmd.Parameters.Add(new SqlParameter("@PP", pPicture));

            cmd.ExecuteNonQuery();
            con.Close();
        }

        private void getManualBtn_Click(object sender, EventArgs e)
        {
            string pdf = "Pharmacist Manual.pdf";
            System.Diagnostics.Process.Start(pdf);
        }

        private void getManualBtn_MouseHover(object sender, EventArgs e)
        {
            UserManualplaceholder.Visible = true;
            UserManualplaceholder.BringToFront();
        }

        private void getManualBtn_MouseLeave(object sender, EventArgs e)
        {
            UserManualplaceholder.Visible = false;
        }

        private void searchBtn_MouseHover(object sender, EventArgs e)
        {
            C_MenuListPanel.BringToFront();
        }

        private void PHR_MenuSettingsBtn_MouseHover(object sender, EventArgs e)
        {
            C_MenuListPanel.BringToFront();
        }

        DataTable dataTable;
        public PHR_Menu(DataTable dt)
        {
            InitializeComponent();

            this.dataTable = dt;
            MemoryStream ms = null;
            foreach (DataRow row in dt.Rows)
            {
                id = row["ph_id"].ToString();
                name = row["ph_name"].ToString();
                lName = row["ph_lname"].ToString();
                phone = row["ph_phone"].ToString();
                city = row["ph_city"].ToString();
                address = row["ph_address"].ToString();
                dob = row["ph_dob"].ToString();
                gender = row["ph_gender"].ToString();
                pharmacy_id = row["p_id"].ToString();
                password = row["ph_password"].ToString();
                ms = new MemoryStream((byte[])row["ph_profile_pic"]);

            }
            profilepicture.Image = Image.FromStream(ms);
            pID_LB.Text = id;
            pName_LB.Text = name + " " + lName;
            MS_FNameTB.Text = name;
            MS_LNameTB.Text = lName;
            MS_CityCB.Text = city;
            MS_AddressTB.Text = address;
            MS_PNumberTB.Text = phone;
            MS_bDateLB.Text = dob;

            if (gender.ToUpper() == "M") MS_maleRB.Select();
            else MS_femaleRB.Select();

            M_hide();
            M_welcomePb.Visible = true;
            welcomeLB.Visible = true;
            welcomeLB.BringToFront();
        }
        public void M_hide()
        {
            C_settingPanel.Visible = false;
            //reportPanel.Visible = false;
            welcomeLB.Visible = false;
            M_welcomePb.Visible = false;
            C_searchItemsPanel.Visible = false;
            // purchasePanel.Visible = false;
            M_searchItemTB.Visible = false;
            M_searchBtn.Anchor = new AnchorStyles();

        }
        private void SettingSaveBtn_Click(object sender, EventArgs e)
        {
            if (MS_AddressTB.Text == "" || MS_bDateLB.Text == "" || MS_CityCB.Text == "" || MS_PNumberTB.Text == "" || MS_FNameTB.Text == "" || MS_LNameTB.Text == "" || !MS_maleRB.Checked && !MS_femaleRB.Checked || MS_nPasswordTB.Text != "" && MS_cPasswordTB.Text == "")
            {
                MessageBox.Show("Please Fill The Form Properly!", "Settings", MessageBoxButtons.OK);
            }
            else
            {
                String query = "update  PHARMACIST SET " +
                "ph_name = '" + MS_FNameTB.Text + "'," +
                "ph_lname = '" + MS_LNameTB.Text + "'," +
                "ph_phone = '" + MS_PNumberTB.Text + "'," +
                "ph_dob = '" + MS_bDateLB.Value.ToString() + "'," +
                "ph_city = '" + MS_CityCB.Text + "'," +
                "ph_address = '" + MS_AddressTB.Text;
                if (MS_cPasswordTB.Text != "" && MS_nPasswordTB.Text != "")
                {

                    if (password == MS_cPasswordTB.Text)
                    {

                        query = query + "', ph_password = '" + MS_nPasswordTB.Text;

                    }
                }
                SqlCommand cmd = new SqlCommand(query + "' WHERE ph_id = '" + this.id + "'", con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

       

        private void PHR_MenuSettingsBtn_Click(object sender, EventArgs e)
        {
            M_hide();
            C_settingPanel.Visible = true;
        }

        private void PHR_Menu_Load(object sender, EventArgs e)
        {

        }
    }
}
