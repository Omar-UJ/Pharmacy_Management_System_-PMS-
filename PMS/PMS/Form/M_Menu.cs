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
    public partial class M_Menu : Form
    {
        SqlConnection con = new SqlConnection("data source =DESKTOP-VV29LOD;database = PMS;integrated security = true");
        DataTable dataTable;
        String id = "", name = "",lName = "",phone = "";
        String city = "",address = "",dob = "",gender= "",password="";
        String pharmacy_id = "";
        

        public M_Menu(DataTable dt,String selected)
        {
            
            InitializeComponent();
            this.dataTable = dt;
            foreach (DataRow row in dt.Rows)
            {
                 id = row["m_id"].ToString();
                 name = row["m_name"].ToString();
                 lName = row["m_lname"].ToString();
                 phone = row["m_phone"].ToString();
                 city = row["m_city"].ToString();
                 address = row["m_address"].ToString();
                 dob = row["m_dob"].ToString();
                 gender = row["m_gender"].ToString();
                 pharmacy_id =  row["p_id"].ToString();
                 password =  row["m_password"].ToString();
                
            }
            pID_LB.Text = id;
            pName_LB.Text = name+" "+lName;
            MS_FNameTB.Text = name;
            MS_LNameTB.Text = lName;
            MS_CityCB.Text = city;
            MS_AddressTB.Text = address;
            MS_PNumberTB.Text = phone;
            MS_bDateLB.Text = dob;
            if (gender.ToUpper() == "M") MS_maleRB.Select();
            else MS_femaleRB.Select();

            if (selected == "search")
            {
                M_hide();
                M_searchItemTB.Visible = true;
                M_searchBtn.Location = new Point(783, 30);

                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT *from ITEM where p_id='"+this.pharmacy_id+"'", con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable sdt = new DataTable();
                con.Close();
                if (sdt.Rows.Count > 0)
                {
                    sda.Fill(sdt);
                    searchDGV.DataSource = dt;
                    emptyIconPB.Visible = false;
                }
                else
                {
                    emptyIconPB.Visible = true;
                }
                
               
            }
            else if (selected == "report")
            {
                M_hide();
                reportPanel.Visible = true;
            }else if (selected == "items")
            {
                M_hide();
                itemsPanel.Visible = true;
                addItemBtn =  new RJButton();
            }
            else if (selected == "employee")
            {
                M_hide();
                employeePanel.Visible = true;
                Employee();
            }else if (selected == "setting")
            {
                M_hide();
                M_settingPanel.Visible = true;
            }else if (selected == "welcome")
            {
                M_hide();
                M_welcomePb.Visible = true;
                welcomeLB.Visible = true;
                welcomeLB.BringToFront();
            }
        }
        public void M_hide()
        {
            M_settingPanel.Visible = false;
            reportPanel.Visible = false;
            welcomeLB.Visible = false;
            M_welcomePb.Visible = false;
      
            itemNempPanel.Visible = false;
            employeePanel.Visible = false;
            itemsPanel.Visible = false;
            searchItemsPanel.Visible = false;
            M_searchItemTB.Visible = false;
            M_searchBtn.Anchor = new AnchorStyles();
        
        }

        private void M_Menu_Load(object sender, EventArgs e)
        {
           

        }

        private void Panel2_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void ShowBtn_Click(object sender, EventArgs e)
        {
           
        }

        private void M_hideBtn_Click(object sender, EventArgs e)
        {
           
        }

        private void Button7_Click(object sender, EventArgs e)
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

        private void Button4_Click(object sender, EventArgs e)
        {
            M_hide();
            welcomeLB.Visible = true;
            M_welcomePb.Visible = true;
            ManagerDashboard dash = new ManagerDashboard(this.dataTable);
            dash.Size = new Size(this.Size.Width, this.Size.Height);
            dash.Location = new Point(this.Location.X, this.Location.Y);
            dash.Show();
            this.Hide();

        }

        private void Button9_Click(object sender, EventArgs e)
        {
            M_hide();
            reportPanel.Visible = true;
        }

        private void ItemNemp_PanBtn_Click(object sender, EventArgs e)
        {
            M_hide();
            itemNempPanel.Visible = true;

        }

        private void Button19_Click(object sender, EventArgs e)
        {
            M_hide();
            employeePanel.Visible = true;
            Employee();
            

        }
        public void Employee()
        {
            CashierDGV.DataSource = null;
            pharmacistDGV.DataSource = null;

            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT *from CASHIER WHERE p_id = '"+this.pharmacy_id+"'", con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            CashierDGV.DataSource = dt;


            dt = new DataTable();
            cmd = new SqlCommand("SELECT *from PHARMACIST  WHERE p_id = '" + this.pharmacy_id + "'", con);
            sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            pharmacistDGV.DataSource = dt;
           

           dt = new DataTable();
           cmd = new SqlCommand("SELECT *from OTHERS  WHERE p_id = '"+this.pharmacy_id+"'", con);
           sda = new SqlDataAdapter(cmd);
           sda.Fill(dt);
           othersDGV.DataSource = dt;
           con.Close();
        }
        private void Button22_Click(object sender, EventArgs e)
        {
            
        }

        private void AddItemBtn_Click(object sender, EventArgs e)
        {
            if (aINameTB.Text=="" || aIPriceTB.Text == "" || aIDescTB.Text == "" || aImportDateCB.Text == "" || aIExpDateCB.Text == "" || aISdateCB.Text == "")
            {
            MessageBox.Show("Please fill the form proprly!", "Error", MessageBoxButtons.OK);

            }else{
                SqlCommand cmd = new SqlCommand("insert into ITEM(i_name, i_descr, i_price, i_sdate, i_expdate, i_import_date,i_qty, p_id,m_id) "
                + " values ('" + aINameTB.Text + "','" + aIDescTB.Text + "','" + aIPriceTB.Text + "','"
                + aISdateCB.Value.ToString() + "','" + aIExpDateCB.Value.ToString() + "','"+aImportDateCB.Value.ToString()+"','" + aIQtyTB.Text + "','" + pharmacy_id
                + "','" + this.id + "');", con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Item Successfully Added!", "Add", MessageBoxButtons.OK);
                View_Items("",1);
            }
            
        }

        private void Button18_Click(object sender, EventArgs e)
        {
             M_hide();
            itemsPanel.Visible = true;
        }

        private void UserIdTB_TextChanged(object sender, EventArgs e)
        {
            searchItemsPanel.Visible = true;
            string search;
            search = M_searchItemTB.Text.Trim();
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT *from VIEW_ITEMS WHERE i_id like '%" + search + "%' AND p_id = '"+this.pharmacy_id+"'", con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    emptyIconPB.Visible = false;
                    searchDGV.DataSource = dt;
                }
                else
                {
                    emptyIconPB.Visible = true;
                }con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            M_hide();
            searchItemsPanel.Visible = true;
            M_searchItemTB.Visible = true;
            M_searchBtn.Location = new Point(783, 30);
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT *from VIEW_ITEMS  WHERE p_id = '" + this.pharmacy_id + "'" , con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                emptyIconPB.Visible = false;
                searchDGV.DataSource = dt; 
            }
            else
            {
                emptyIconPB.Visible = true;
            } con.Close();
        }

        private void TextBox21_TextChanged(object sender, EventArgs e)
        {
            string search;
            search = serachItemsInUpdateTb.Text.Trim();
            View_Items(search,0);

        }
       public void View_Items(String search,int i)
        {
            
            try
            {
                String query = "";
                if (i == 0) query = "SELECT *from VIEW_ITEMS WHERE i_id like '%" + search + "%' AND p_id = '" + this.pharmacy_id + "'";
                else query = "SELECT *from VIEW_ITEMS  WHERE p_id = '" + this.pharmacy_id + "'";
                con.Open();
                SqlCommand cmd = new SqlCommand(query,con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    emptyItemPB.Visible = false;
                    DGVinUpdateItems.DataSource = dt;

                DGVinUpdateItems.Columns[0].HeaderText = "ID";
                DGVinUpdateItems.Columns[1].HeaderText = "Name";
                DGVinUpdateItems.Columns[2].HeaderText = "Descripition";
                DGVinUpdateItems.Columns[3].HeaderText = "Price";
                DGVinUpdateItems.Columns[4].HeaderText = "Quantity";
                DGVinUpdateItems.Columns[5].HeaderText = "Mfg Date";
                DGVinUpdateItems.Columns[6].HeaderText = "Import Date";
                DGVinUpdateItems.Columns[7].HeaderText = "Exp-Date";
                }
                else
                {
                    emptyItemPB.Visible = true;
                    DGVinUpdateItems.DataSource = null;
                }
                con.Close();
                

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        private void SerachItemsInUpdateTb_TextChanged(object sender, EventArgs e)
        {
            string search;
            search = serachItemsInUpdateTb.Text.Trim();
            View_Items(search,0);
        }

        private void DGVinUpdateItems_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (DGVinUpdateItems.SelectedRows.Count>0 && DGVinUpdateItems.SelectedRows.Count < 8)
            {
                DataGridViewRow row = this.DGVinUpdateItems.Rows[e.RowIndex];
                aIdLB.Text = row.Cells[0].Value.ToString();
                aINameTB.Text = row.Cells[1].Value.ToString();
                aIDescTB.Text = row.Cells[2].Value.ToString();
                aIPriceTB.Text = row.Cells[3].Value.ToString();
                aIQtyTB.Text = row.Cells[4].Value.ToString();
                aISdateCB.Text = row.Cells[5].Value.ToString();
                aImportDateCB.Text = row.Cells[6].Value.ToString();
                aIExpDateCB.Text = row.Cells[7].Value.ToString();
                
                return;
            }      
        }

        private void UpdateItemsBtn_Click(object sender, EventArgs e)
        {
            if (aINameTB.Text == "" || aIPriceTB.Text == "" || aIDescTB.Text == "" || aImportDateCB.Text == "" || aIExpDateCB.Text == "" || aISdateCB.Text == "")
            {
                MessageBox.Show("Please check/select the Item", "Error", MessageBoxButtons.OK);

            }
            else
            {
                SqlCommand cmd = new SqlCommand("update  ITEM SET " +
                "i_name = '" + aINameTB.Text + "'," +
                "i_descr = '" + aIDescTB.Text + "'," +
                "i_qty = '" + aIQtyTB.Text + "'," +
                "i_price = '" + aIPriceTB.Text + "'," +
                "i_sdate = '" + aISdateCB.Value.ToString() + "'," +
                "i_expdate = '" + aIExpDateCB.Value.ToString() + "' WHERE i_id = '" + aIdLB.Text + "'", con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Item Successfully Updated!", "Update", MessageBoxButtons.OK);
                View_Items("", 1);
            }
        }

        private void TabControl4_MouseClick(object sender, MouseEventArgs e)
        {
            EXP_Items();
        }
        public void EXP_Items()
        {
            expItemDGV.DataSource = null;
            con.Open();
            String date = DateTime.UtcNow.ToString();
            SqlCommand cmd = new SqlCommand("EXP_ITEMS '" + date + "'," + pharmacy_id + " ", con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            expItemDGV.DataSource = dt;
            expItemDGV.Columns[0].HeaderText = "ID";
            expItemDGV.Columns[1].HeaderText = "Name";
            expItemDGV.Columns[2].HeaderText = "Descripition";
            expItemDGV.Columns[3].HeaderText = "Price";
            expItemDGV.Columns[7].HeaderText = "Quantity";
            expItemDGV.Columns[4].HeaderText = "Mfg Date";
            expItemDGV.Columns[5].HeaderText = "Import Date";
            expItemDGV.Columns[6].HeaderText = "Exp-Date";
            con.Close();
        }
        private void ExpItemDGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0 && e.RowIndex >= 0 )
            {
                DataGridViewRow row = this.expItemDGV.Rows[e.RowIndex];
                expItemidTB.Text = row.Cells[0].Value.ToString();
                return;
            }
        }

        private void RemoveExpItemBtn_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure, you want to remove This Item ?", "Remove", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
            SqlCommand cmd = new SqlCommand("Delete From ITEM WHERE i_id = '" + expItemidTB.Text + "'", con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
                MessageBox.Show("Succssefully Removed","Remove",MessageBoxButtons.OK);
                EXP_Items();
            }
            
        }

        private void ExpItemsListTab_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT *from ITEM", con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            expItemsListDGV.DataSource = dt;
            con.Close();
        }

        private void ExpItemsListTab_Click_1(object sender, EventArgs e)
        {
            View_Items("",1);
        }

        private void ExpItemsListTab_Selected(object sender, TabControlEventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT *from EXP_ITEM  WHERE p_id = '" + this.pharmacy_id + "'", con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            expItemsListDGV.DataSource = dt;
            expItemsListDGV.Columns[0].HeaderText = "ID";
            expItemsListDGV.Columns[1].HeaderText = "Name";
            expItemsListDGV.Columns[2].HeaderText = "Descripition";
            expItemsListDGV.Columns[3].HeaderText = "Price";
            expItemsListDGV.Columns[7].HeaderText = "Quantity";
            expItemsListDGV.Columns[4].HeaderText = "Mfg Date";
            expItemsListDGV.Columns[5].HeaderText = "Import Date";
            expItemsListDGV.Columns[6].HeaderText = "Exp-Date";
            con.Close();
        }

        private void M_MenuListPanel_MouseCaptureChanged(object sender, EventArgs e)
        {
            M_MenuListPanel.BringToFront();
        }

        private void M_MenuListPanel_MouseHover(object sender, EventArgs e)
        {
            M_MenuListPanel.BringToFront();
        }

        private void M_MenuListPanel_MouseLeave(object sender, EventArgs e)
        {
            M_MenuBGPanel.BringToFront();
           
        }

        private void Button4_MouseHover(object sender, EventArgs e)
        {
            M_MenuListPanel.BringToFront();
        }

        private void ItemNemp_PanBtn_MouseHover(object sender, EventArgs e)
        {
            M_MenuListPanel.BringToFront();
        }

        private void Button8_MouseHover(object sender, EventArgs e)
        {
            M_MenuListPanel.BringToFront();
        }

        private void Button9_MouseHover(object sender, EventArgs e)
        {
            M_MenuListPanel.BringToFront();
        }

        private void Button1_MouseHover(object sender, EventArgs e)
        {
            M_MenuListPanel.BringToFront();
        }

        private void Button4_MouseLeave(object sender, EventArgs e)
        {
            M_MenuBGPanel.BringToFront();
         
        }

        private void ItemNemp_PanBtn_MouseLeave(object sender, EventArgs e)
        {
            M_MenuBGPanel.BringToFront();
          
        }

        private void Button8_MouseLeave(object sender, EventArgs e)
        {
            M_MenuBGPanel.BringToFront();
            
        }

        private void Button9_MouseLeave(object sender, EventArgs e)
        {
            M_MenuBGPanel.BringToFront();
           
        }

        private void Button1_MouseLeave(object sender, EventArgs e)
        {
            M_MenuBGPanel.BringToFront();
          
        }

        private void LightModeRB_CheckedChanged(object sender, EventArgs e)
        {
            M_MenuListPanel.BackColor = Color.MediumSeaGreen;
            settingSaveBtn.BackColor = Color.MediumSeaGreen;
            settingsGB.BackColor = Color.WhiteSmoke;
            M_headerPanel.BackColor = Color.White;
            manageEmployeeBtn.BackColor = Color.MediumSeaGreen;
            manageEmployeeBtn.ForeColor = Color.White;
            manageItemsBtn.BackColor = Color.White;
            manageItemsBtn.ForeColor = Color.MediumSeaGreen;
            searchDGV.BackgroundColor = Color.White;
            auTab.BackColor = Color.White;
        }

        private void DarkModeRB_CheckedChanged(object sender, EventArgs e)
        {
            
            M_MenuListPanel.BackColor = Color.DarkSlateGray;
            M_headerPanel.BackColor = Color.DarkSlateGray;
            settingSaveBtn.BackColor = Color.DarkSlateGray;
            settingsGB.BackColor = Color.DarkSlateGray;
            manageEmployeeBtn.BackColor = Color.DarkSlateGray;
            manageEmployeeBtn.ForeColor = Color.White;
            manageItemsBtn.BackColor = Color.DarkSlateGray;
            manageItemsBtn.ForeColor = Color.White;
            searchDGV.BackgroundColor = Color.DarkSlateGray;
            auTab.BackColor = Color.DarkSlateGray;
            
        }
        private void DarkRedRB_CheckedChanged(object sender, EventArgs e)
        {

            M_MenuListPanel.BackColor = Color.DarkRed;
            M_headerPanel.BackColor = Color.DarkRed;
            settingSaveBtn.BackColor = Color.DarkRed;
            settingsGB.BackColor = Color.DarkRed;
            manageEmployeeBtn.BackColor = Color.DarkRed;
            manageEmployeeBtn.ForeColor = Color.White;
            manageItemsBtn.BackColor = Color.DarkRed;
            manageItemsBtn.ForeColor = Color.White;
        }
        private void AClearBtn_Click(object sender, EventArgs e)
        {
            aIdLB.Text = "";
            aIDescTB.Text = "";
            aIExpDateCB.Text = "";
            aINameTB.Text = "";
            aIQtyTB.Text = "";
            aISdateCB.Text = "";
            aIPriceTB.Text = "";
            aImportDateCB.Text = "";

        }

        private void ExpItemDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
          
        }

        private void AIPriceTB_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar!='.')
            {
                e.Handled = true;
            }
        }

        private void CashierDGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (CashierDGV.SelectedRows.Count > 0 && CashierDGV.SelectedRows.Count < 10)
            {
                DataGridViewRow row = this.CashierDGV.Rows[e.RowIndex];
                empIDLB.Text = row.Cells[0].Value.ToString();
                eFNameTB.Text = row.Cells[1].Value.ToString();
                eLNameTB.Text = row.Cells[2].Value.ToString();
                ePhoneTB.Text = row.Cells[3].Value.ToString();
                eDobCB.Text = row.Cells[4].Value.ToString();
                eCityCB.Text = row.Cells[5].Value.ToString();
                eAddressTB.Text = row.Cells[6].Value.ToString();
                ePasswordTB.Text = row.Cells[7].Value.ToString();
                eJobCB.Text = "CASHIER";
                if (row.Cells[8].Value.ToString().ToUpper() == "M") eMaleRB.Select();
                else eFemaleRB.Select();
                if (row.Cells[9].Value.ToString().ToUpper() == "ACTIVE") activeRB.Select();
                else deactiveRB.Select();

                return;
            }
        }

        private void AddEmployeeBtn_Click(object sender, EventArgs e)
        {
            if (eFNameTB.Text=="" || eLNameTB.Text == "" || eAddressTB.Text == "" || eCityCB.Text == "" || eDobCB.Text == "" || eAddressTB.Text == "" || ePasswordTB.Text == "" || ePhoneTB.Text == ""  || ! eMaleRB.Checked && ! eFemaleRB.Checked || !activeRB.Checked && !deactiveRB.Checked)
            {
                MessageBox.Show("Please fill the form proprly!", "Error", MessageBoxButtons.OK);

            }
            else
            {
                String query = "", gender = "",status = "";
                if (eMaleRB.Checked) gender = "M";
                else  gender = "F";
                if (activeRB.Checked) status = "Active";
                else status = "Deactive";

                if (eJobCB.Text.ToUpper() == "PHARMACIST")
                    query = "insert into PHARMACIST(ph_name, ph_lname, ph_phone, ph_dob, ph_city, ph_address, ph_gender,ph_password, p_id,ph_status) ";
                else if (eJobCB.Text.ToUpper() == "CASHIER")
                    query = "insert into CASHIER(ca_name, ca_lname, ca_phone, ca_dob, ca_city, ca_address, ca_gender,ca_password, p_id,ca_status ) ";
                else if (eJobCB.Text.ToUpper() == "OTHERS")
                    query = "insert into OTHERS(oe_name, oe_lname, oe_phone, oe_dob, oe_city, oe_address, oe_gender,oe_password, p_id,oe_status,oe_job_pos ) ";

                SqlCommand cmd;
                if (eJobCB.Text.ToUpper() != "OTHERS")
                {
                     cmd = new SqlCommand(query + " values ('" + eFNameTB.Text + "','" + eLNameTB.Text + "','" + ePhoneTB.Text + "','"
                    + eDobCB.Value.ToString() + "','" + eCityCB.Text + "','" + eAddressTB.Text + "','" + gender + "','" + ePasswordTB.Text
                    + "','" + pharmacy_id + "' , '" + status + "');", con);
                }
                else
                {
                     cmd = new SqlCommand(query + " values ('" + eFNameTB.Text + "','" + eLNameTB.Text + "','" + ePhoneTB.Text + "','"
                    + eDobCB.Value.ToString() + "','" + eCityCB.Text + "','" + eAddressTB.Text + "','" + gender + "','" + ePasswordTB.Text
                    + "','" + pharmacy_id + "' , '" + status + "','" + eJobCB.Text + "');", con);
                }
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Succssefully Added!", "Eployee Add", MessageBoxButtons.OK);
                EXP_Items();
                Employee();
            }
        }

        private void ClearAUBtn_Click(object sender, EventArgs e)
        {
            eFNameTB.Text = "";
            eLNameTB.Text = "";
            eCityCB.Text = "";
            eDobCB.Text = "";
            ePasswordTB.Text = "";
            ePhoneTB.Text = "";
            eAddressTB.Text = "";
            eJobCB.Text = "";
            empIDLB.Text = "";
            
        }

        private void UpdateEmpBtn_Click(object sender, EventArgs e)
        {
            if (eFNameTB.Text == "" || eLNameTB.Text == "" || eAddressTB.Text == "" || eCityCB.Text == "" || eDobCB.Text == "" || eAddressTB.Text == "" || ePasswordTB.Text == "" || ePhoneTB.Text == "" || !eMaleRB.Checked && !eFemaleRB.Checked || !activeRB.Checked && !deactiveRB.Checked)
            {
                MessageBox.Show("Please fill the form proprly!", "Error", MessageBoxButtons.OK);

            }
            else
            {
                String query = "", status = "", gender = "";
                if (activeRB.Checked) status = "Active";
                else if (deactiveRB.Checked) status = "Deactive";

                if (eMaleRB.Checked) gender = "M";
                else if (eFemaleRB.Checked) gender = "F";

                if (eJobCB.Text.ToUpper() == "PHARMACIST")
                    query = "update  PHARMACIST SET " +
                    "ph_name = '" + eFemaleRB.Text + "'," +
                    "ph_lname = '" + eLNameTB.Text + "'," +
                    "ph_phone = '" + ePhoneTB.Text + "'," +
                    "ph_dob = '" + eDobCB.Value.ToString() + "'," +
                    "ph_city = '" + eCityCB.Text + "'," +
                    "ph_status = '" + status + "'," +
                    "ph_address = '" + eAddressTB.Text + "' WHERE ph_id = '" + empIDLB.Text + "'";
                else if (eJobCB.Text.ToUpper() == "CASHIER")
                    query = "update  CASHIER SET " +
                   "ca_name = '" + eFNameTB.Text + "'," +
                   "ca_lname = '" + eLNameTB.Text + "'," +
                   "ca_phone = '" + ePhoneTB.Text + "'," +
                   "ca_dob = '" + eDobCB.Value.ToString() + "'," +
                   "ca_city = '" + eCityCB.Text + "'," +
                   "ca_status = '" + status + "'," +
                    "ca_gender = '" + gender + "'," +
                   "ca_address = '" + eAddressTB.Text + "' WHERE ca_id = '" + empIDLB.Text + "'";
                else if (eJobCB.Text.ToUpper() == "OTHERS")
                    query = "update  OTHERS SET " +
                  "oe_name = '" + eFNameTB.Text + "'," +
                  "oe_lname = '" + eLNameTB.Text + "'," +
                  "oe_phone = '" + ePhoneTB.Text + "'," +
                  "oe_dob = '" + eDobCB.Value.ToString() + "'," +
                  "oe_city = '" + eCityCB.Text + "'," +
                  "oe_status = '" + status + "'," +
                  "oe_gender = '" + gender + "'," +
                  "oe_address = '" + eAddressTB.Text + "' WHERE oe_id = '" + empIDLB.Text + "'";

                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Succssefully Updated!", "Update Eployee Info", MessageBoxButtons.OK);
                EXP_Items();
                Employee();
            }
        }

        private void PharmacistDGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(pharmacistDGV.SelectedRows.Count > 0 && pharmacistDGV.SelectedRows.Count < 10)
            {
                DataGridViewRow row = this.pharmacistDGV.Rows[e.RowIndex];
                empIDLB.Text = row.Cells[0].Value.ToString();
                eFNameTB.Text = row.Cells[1].Value.ToString();
                eLNameTB.Text = row.Cells[2].Value.ToString();
                ePhoneTB.Text = row.Cells[3].Value.ToString();
                eDobCB.Text = row.Cells[4].Value.ToString();
                eCityCB.Text = row.Cells[5].Value.ToString();
                eAddressTB.Text = row.Cells[6].Value.ToString();
                ePasswordTB.Text = row.Cells[7].Value.ToString();
                eJobCB.Text = "PHARMACIST";
                if (row.Cells[8].Value.ToString().ToUpper() == "M") eMaleRB.Select();
                else eFemaleRB.Select();
                if (row.Cells[9].Value.ToString().ToUpper() == "ACTIVE") activeRB.Select();
                else deactiveRB.Select();

                return;
            }
        }

        private void OthersDGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (othersDGV.SelectedRows.Count > 0 && CashierDGV.SelectedRows.Count < 10)
            {
                DataGridViewRow row = this.othersDGV.Rows[e.RowIndex];
                empIDLB.Text = row.Cells[0].Value.ToString();
                eFNameTB.Text = row.Cells[1].Value.ToString();
                eLNameTB.Text = row.Cells[2].Value.ToString();
                ePhoneTB.Text = row.Cells[3].Value.ToString();
                eDobCB.Text = row.Cells[4].Value.ToString();
                eCityCB.Text = row.Cells[5].Value.ToString();
                eAddressTB.Text = row.Cells[6].Value.ToString();
                ePasswordTB.Text = row.Cells[7].Value.ToString();
                eJobCB.Text = "OTHERS";
                if (row.Cells[8].Value.ToString().ToUpper() == "M") eMaleRB.Select();
                else eFemaleRB.Select();
                if (row.Cells[9].Value.ToString().ToUpper() == "ACTIVE") activeRB.Select();
                else deactiveRB.Select();

                return;
            }
        }

        private void EPhoneTB_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }
        }

        private void MS_PNumberTB_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }
        }

        private void ExpNotifBtn_Click(object sender, EventArgs e)
        {
         
        }

        private void M_MenuBGPanel_Paint(object sender, PaintEventArgs e)
        {
            M_MenuBGPanel.BringToFront();
         
        }

        private void M_MenuListPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            M_hide();
            M_settingPanel.Visible = true;
        }

        private void Button8_Click(object sender, EventArgs e)
        {
          
        }

        private void Button3_Click(object sender, EventArgs e)
        {

        }

        private void RegisterBtn_Click(object sender, EventArgs e)
        {
            if (MS_AddressTB.Text =="" || MS_bDateLB.Text == "" || MS_CityCB.Text == "" || MS_PNumberTB.Text == "" || MS_FNameTB.Text == "" || MS_LNameTB.Text == "" || !MS_maleRB.Checked && !MS_femaleRB.Checked || MS_nPasswordTB.Text != "" && MS_cPasswordTB.Text=="")
            {

            }
            else
            {
                String query = "update  MANAGER SET " +
                "m_name = '" + MS_FNameTB.Text + "'," +
                "m_lname = '" + MS_LNameTB.Text + "'," +
                "m_phone = '" + MS_PNumberTB.Text + "'," +
                "m_dob = '" + MS_bDateLB.Text + "'," +
                "m_city = '" + MS_CityCB.Text + "'," +
                "m_address = '" + MS_AddressTB.Text;
                if (MS_cPasswordTB.Text != "" && MS_nPasswordTB.Text != "")
                {
                    
                    if (password == MS_cPasswordTB.Text)
                    {

                        query = query + "', m_password = '" + MS_nPasswordTB.Text;

                    }                  
                }
                SqlCommand cmd = new SqlCommand(query+ "' WHERE m_id = '"+this.id+"'",con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            }
            
        }
    }
}
