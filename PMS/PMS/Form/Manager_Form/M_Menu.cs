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
    public partial class M_Menu : Form
    {
        Connection connection = new Connection();
        SqlConnection con = Connection.CON();
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
            pnoLabel.Text = phone;
            label26.Text = name;
            if (gender.ToUpper() == "M") MS_maleRB.Select();
            else MS_femaleRB.Select();
            changedColorPanel.Visible = true;
            if (selected == "search")
            {
                search();
                
               
            }
            else if (selected == "report")
            {
                M_hide();
                changedColorPanel.Location = new Point(-4, 269);
                reportPanel.Visible = true;
               
            }
            else if (selected == "items")
            {
                M_hide();
                changedColorPanel.Location = new Point(-4, 228);
                itemsPanel.Visible = true;
                addItemBtn =  new RJButton();
               
            }
            else if (selected == "employee")
            {
                M_hide();
                changedColorPanel.Location = new Point(-4, 228);
                employeePanel.Visible = true;
                Employee();
               
            }
            else if (selected == "setting")
            {
                M_hide();
                changedColorPanel.Location = new Point(-4, 310);
                M_settingPanel.Visible = true;
               
            }
            else if (selected == "welcome")
            {
                M_hide();
                changedColorPanel.Location = new Point(-4, 146);
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
            M_searchBtn.Visible = true;
            itemNempPanel.Visible = false;
            employeePanel.Visible = false;
            itemsPanel.Visible = false;
            searchItemsPanel.Visible = false;
            M_searchItemTB.Visible = false;
            searchIcon.Visible = false;
            hide_report();


        }

        private void M_Menu_Load(object sender, EventArgs e)
        {
            ePasswordTB.Text = " PMS2022"+pharmacy_id;

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
            hide_report();
            M_hide();
            changedColorPanel.Location = new Point(-4, 269);
            reportPanel.Visible = true;
            reportCRV.ReportSource = null;
            TDtransactionreportBtn.Visible = true;
            OOSBtn.Visible = true;
        }

        private void ItemNemp_PanBtn_Click(object sender, EventArgs e)
        {
            M_hide();
            changedColorPanel.Location = new Point(-4, 228);
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
            CashierDGV.CellBorderStyle = DataGridViewCellBorderStyle.None;
            CashierDGV.Columns[0].HeaderText = "ID";
            CashierDGV.Columns[1].HeaderText = "First Name";
            CashierDGV.Columns[2].HeaderText = "Last Name";
            CashierDGV.Columns[3].HeaderText = "PhoneNumber";
            CashierDGV.Columns[4].HeaderText = "Date OF Birth";
            CashierDGV.Columns[5].HeaderText = "City";
            CashierDGV.Columns[6].HeaderText = "Address";
            CashierDGV.Columns[7].HeaderText = "Password";
            CashierDGV.Columns[8].HeaderText = "Gender";
            CashierDGV.Columns[9].HeaderText = "Status";
            CashierDGV.Columns[10].HeaderText = "Salary";
            CashierDGV.Columns[11].HeaderText = "Pharmacy ID";
            CashierDGV.Columns[12].HeaderText = "Profile Picture";


            dt = new DataTable();
            cmd = new SqlCommand("SELECT *from PHARMACIST  WHERE p_id = '" + this.pharmacy_id + "'", con);
            sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            pharmacistDGV.DataSource = dt;
            pharmacistDGV.CellBorderStyle = DataGridViewCellBorderStyle.None;
            pharmacistDGV.Columns[0].HeaderText = "ID";
            pharmacistDGV.Columns[1].HeaderText = "First Name";
            pharmacistDGV.Columns[2].HeaderText = "Last Name";
            pharmacistDGV.Columns[3].HeaderText = "PhoneNumber";
            pharmacistDGV.Columns[4].HeaderText = "Date OF Birth";
            pharmacistDGV.Columns[5].HeaderText = "City";
            pharmacistDGV.Columns[6].HeaderText = "Address";
            pharmacistDGV.Columns[7].HeaderText = "Password";
            pharmacistDGV.Columns[8].HeaderText = "Gender";
            pharmacistDGV.Columns[9].HeaderText = "Status";
            pharmacistDGV.Columns[10].HeaderText = "Salary";
            pharmacistDGV.Columns[11].HeaderText = "Pharmacy ID";
            pharmacistDGV.Columns[12].HeaderText = "Profile Picture";


            dt = new DataTable();
           cmd = new SqlCommand("SELECT *from OTHERS  WHERE p_id = '"+this.pharmacy_id+"'", con);
           sda = new SqlDataAdapter(cmd);
           sda.Fill(dt);
            othersDGV.DataSource = dt;
            othersDGV.CellBorderStyle = DataGridViewCellBorderStyle.None;
            othersDGV.Columns[0].HeaderText = "ID";
            othersDGV.Columns[1].HeaderText = "First Name";
            othersDGV.Columns[2].HeaderText = "Last Name";
            othersDGV.Columns[3].HeaderText = "PhoneNumber";
            othersDGV.Columns[4].HeaderText = "Date OF Birth";
            othersDGV.Columns[5].HeaderText = "City";
            othersDGV.Columns[6].HeaderText = "Address";
            othersDGV.Columns[7].HeaderText = "Gender";
            othersDGV.Columns[8].HeaderText = "Status";
            othersDGV.Columns[9].HeaderText = "Job Position";
            othersDGV.Columns[10].HeaderText = "Salary";
            othersDGV.Columns[11].HeaderText = "Pharmacy ID";
            othersDGV.Columns[12].HeaderText = "Profile Picture";
            con.Close();
        }
        private void Button22_Click(object sender, EventArgs e)
        {
            
        }

        private void AddItemBtn_Click(object sender, EventArgs e)
        {
            if (aINameTB.Text=="" || aIPriceTB.Text == "" || aIpurPrice.Text == "" || aIDescTB.Text == "" || aImportDateCB.Text == "" || aIExpDateCB.Text == "" || aISdateCB.Text == "")
            {
            MessageBox.Show("Please fill the form proprly!", "Error", MessageBoxButtons.OK);

            }else{
                SqlCommand cmd = new SqlCommand("insert into ITEM(i_name, i_descr, i_pur_price,i_sell_price, i_sdate, i_expdate, i_import_date,i_qty, p_id,m_id) "
                + " values ('" + aINameTB.Text + "','" + aIDescTB.Text + "','" +aIpurPrice.Text +"','" + aIPriceTB.Text + "','"
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
                SqlCommand cmd = new SqlCommand("SELECT *from VIEW_ITEMS WHERE i_name like '%" + search + "%' AND  p_id = '" + pharmacy_id + "'"+"OR i_id like '%" + search + "%' AND  p_id = '" + pharmacy_id+"'", con);
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
            search();
        }
       public void search()
        {
            M_hide();
            searchItemsPanel.Visible = true;
            M_searchItemTB.Visible = true;
            searchIcon.Visible = true;
            M_searchBtn.Visible =false;
            changedColorPanel.Location = new Point(-4, 190);
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
                if (i == 0) query = "SELECT *from VIEW_ITEMS WHERE i_name like '%" + search + "%' AND p_id = '" + this.pharmacy_id + "'";
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
                DGVinUpdateItems.Columns[3].HeaderText = "Pur Price";
                DGVinUpdateItems.Columns[4].HeaderText = "Sell Price";
                DGVinUpdateItems.Columns[5].HeaderText = "Quantity";
                DGVinUpdateItems.Columns[6].HeaderText = "Mfg Date";
                DGVinUpdateItems.Columns[7].HeaderText = "Import Date";
                DGVinUpdateItems.Columns[8].HeaderText = "Exp-Date";
                DGVinUpdateItems.Columns[9].HeaderText = "Pharmacy ID";
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
                aIPriceTB.Text = row.Cells[4].Value.ToString();
                aIpurPrice.Text = row.Cells[3].Value.ToString();
                aIQtyTB.Text = row.Cells[5].Value.ToString();
                aISdateCB.Text = row.Cells[6].Value.ToString();
                aImportDateCB.Text = row.Cells[7].Value.ToString();
                aIExpDateCB.Text = row.Cells[8].Value.ToString();
                
                return;
            }      
        }

        private void UpdateItemsBtn_Click(object sender, EventArgs e)
        {
            if (aINameTB.Text == "" || aIPriceTB.Text == "" || aIpurPrice.Text == "" || aIDescTB.Text == "" || aImportDateCB.Text == "" || aIExpDateCB.Text == "" || aISdateCB.Text == "")
            {
                MessageBox.Show("Please check/select the Item", "Error", MessageBoxButtons.OK);

            }
            else
            {
                SqlCommand cmd = new SqlCommand("update  ITEM SET " +
                "i_name = '" + aINameTB.Text + "'," +
                "i_descr = '" + aIDescTB.Text + "'," +
                "i_qty = '" + aIQtyTB.Text + "'," +
                "i_sell_price = '" + aIPriceTB.Text + "'," +
                 "i_pur_price = '" + aIpurPrice.Text + "'," +
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
            expItemDGV.Columns[3].HeaderText = "Purchase Price";
            expItemDGV.Columns[4].HeaderText = "Sell Price";
            expItemDGV.Columns[8].HeaderText = "Quantity";
            expItemDGV.Columns[5].HeaderText = "Mfg Date";
            expItemDGV.Columns[6].HeaderText = "Import Date";
            expItemDGV.Columns[7].HeaderText = "Exp-Date";
            expItemDGV.Columns[9].HeaderText = "Manager ID";
            expItemDGV.Columns[10].HeaderText = "Pharmacy ID";
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
            expItemsListDGV.Columns[3].HeaderText = "Pur Price";
            expItemsListDGV.Columns[4].HeaderText = "Sell Price";
            expItemsListDGV.Columns[5].HeaderText = "Quantity";
            expItemsListDGV.Columns[6].HeaderText = "Mfg Date";
            expItemsListDGV.Columns[7].HeaderText = "Import Date";
            expItemsListDGV.Columns[8].HeaderText = "Exp-Date";
            expItemsListDGV.Columns[9].HeaderText = "Manager ID";
            expItemsListDGV.Columns[10].HeaderText = "Pharmacy ID";
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
                eSalaryTB.Text = row.Cells[10].Value.ToString();
                MemoryStream ms = new MemoryStream((byte[])row.Cells[12].Value);
                EmployeePP.Image = Image.FromStream(ms);
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
            if (eFNameTB.Text=="" || eLNameTB.Text == "" || eAddressTB.Text == "" || eCityCB.Text == "" || eDobCB.Text == "" || eSalaryTB.Text == "" || eAddressTB.Text == ""  || ePhoneTB.Text == ""  || ! eMaleRB.Checked && ! eFemaleRB.Checked || !activeRB.Checked && !deactiveRB.Checked)
            {
                MessageBox.Show("Please fill the form proprly!", "Error", MessageBoxButtons.OK);

            }
            else
            {
                PED ped = new PED();
                String query = "", gender = "",status = "" ,password = "";
                if (eMaleRB.Checked) gender = "M";
                else  gender = "F";
                if (activeRB.Checked) status = "Active";
                else status = "Deactive";

                
                password=ped.Enc(ePasswordTB.Text);


                if (eJobCB.Text.ToUpper() == "PHARMACIST")
                    query = "insert into PHARMACIST(ph_name, ph_lname, ph_phone, ph_dob, ph_city, ph_address, ph_gender,ph_password, p_id,ph_status,ph_salary,ph_profile_pic ) ";
                else if (eJobCB.Text.ToUpper() == "CASHIER")
                    query = "insert into CASHIER(ca_name, ca_lname, ca_phone, ca_dob, ca_city, ca_address, ca_gender,ca_password, p_id,ca_status,ca_salary,ca_profile_pic) ";
                else if(eJobCB.Text.ToUpper() != "CASHIER" && eJobCB.Text.ToUpper() != "PHARMACIST")
                    query = "insert into OTHERS(oe_name, oe_lname, oe_phone, oe_dob, oe_city, oe_address, oe_gender, p_id,oe_status,oe_job_pos,oe_salary,oe_profile_pic ) ";

                SqlCommand cmd;
                if (eJobCB.Text.ToUpper() == "PHARMACIST" || eJobCB.Text.ToUpper() == "CASHIER")
                {
                     cmd = new SqlCommand(query + " values ('" + eFNameTB.Text + "','" + eLNameTB.Text + "','" + ePhoneTB.Text + "','"
                    + eDobCB.Value.ToString() + "','" + eCityCB.Text + "','" + eAddressTB.Text + "','" + gender + "','" + password
                    + "','" + pharmacy_id + "' , '" + status + "' , '" +eSalaryTB.Text + "',@PP);", con);
                }
                else
                {
                     cmd = new SqlCommand(query + " values ('" + eFNameTB.Text + "','" + eLNameTB.Text + "','" + ePhoneTB.Text + "','"
                    + eDobCB.Value.ToString() + "','" + eCityCB.Text + "','" + eAddressTB.Text + "','" + gender + "','" 
                    + pharmacy_id + "' , '" + status + "','" + eJobCB.Text + "' , '"+eSalaryTB.Text+ "', @PP);", con);
                }
                MemoryStream stream = new MemoryStream();
                EmployeePP.Image.Save(stream, ImageFormat.Jpeg);
                byte[] pPicture = stream.ToArray();
                cmd.Parameters.AddWithValue("@PP", pPicture);

                con.Open();
                try
                {
                    cmd.ExecuteNonQuery();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                con.Close();
                MessageBox.Show("Succssefully Added!", "Eployee Add", MessageBoxButtons.OK);
                Employee();
            }
        }

        private void ClearAUBtn_Click(object sender, EventArgs e)
        {
            eFNameTB.Text = "";
            eLNameTB.Text = "";
            eCityCB.Text = "";
            eDobCB.Text = "";
            ePasswordTB.Text = "PMS2022"+pharmacy_id;
            ePhoneTB.Text = "";
            eAddressTB.Text = "";
            eJobCB.Text = "";
            empIDLB.Text = "";
            eSalaryTB.Text = "";
            EmployeePP.Image = homeProfilePicture.Image;
            
            
        }

        private void UpdateEmpBtn_Click(object sender, EventArgs e)
        {
            if (eFNameTB.Text == "" || eLNameTB.Text == "" || eSalaryTB.Text == "" || eAddressTB.Text == "" || eCityCB.Text == "" || eDobCB.Text == "" || eAddressTB.Text == "" || ePasswordTB.Text == "" || ePhoneTB.Text == "" || !eMaleRB.Checked && !eFemaleRB.Checked || !activeRB.Checked && !deactiveRB.Checked)
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
                     "ph_salary = '" + eSalaryTB.Text + "'," +
                    "ph_status = '" + status + "'," +
                    "ph_profile_pic = @PP," +
                    "ph_address = '" + eAddressTB.Text + "' WHERE ph_id = '" + empIDLB.Text + "'";
                else if (eJobCB.Text.ToUpper() == "CASHIER")
                    query = "update  CASHIER SET " +
                   "ca_name = '" + eFNameTB.Text + "'," +
                   "ca_lname = '" + eLNameTB.Text + "'," +
                   "ca_phone = '" + ePhoneTB.Text + "'," +
                   "ca_dob = '" + eDobCB.Value.ToString() + "'," +
                   "ca_city = '" + eCityCB.Text + "'," +
                   "ca_status = '" + status + "'," +
                   "ca_salary = '" + eSalaryTB.Text + "'," +
                   "ca_gender = '" + gender + "'," +
                   "ca_profile_pic = @PP," +
                   "ca_address = '" + eAddressTB.Text + "' WHERE ca_id = '" + empIDLB.Text + "'";
                else 
                    query = "update  OTHERS SET " +
                  "oe_name = '" + eFNameTB.Text + "'," +
                  "oe_lname = '" + eLNameTB.Text + "'," +
                  "oe_phone = '" + ePhoneTB.Text + "'," +
                  "oe_dob = '" + eDobCB.Value.ToString() + "'," +
                  "oe_city = '" + eCityCB.Text + "'," +
                  "oe_status = '" + status + "'," +
                  "oe_gender = '" + gender + "'," +
                  "oe_job_pos = '" + eJobCB.Text + "'," +
                  "oe_salary = '" + eSalaryTB.Text + "'," +
                  "oe_profile_pic = @PP," +
                  "oe_address = '" + eAddressTB.Text + "' WHERE oe_id = '" + empIDLB.Text + "'";
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);

                MemoryStream stream = new MemoryStream();
                EmployeePP.Image.Save(stream, ImageFormat.Jpeg);
                byte[] pPicture = stream.ToArray();
                cmd.Parameters.Add(new SqlParameter("@PP",pPicture));

                
                cmd.ExecuteNonQuery();
               
                con.Close();
                MessageBox.Show("Succssefully Updated!", "Update Eployee Info", MessageBoxButtons.OK);
                EXP_Items();
                Employee();
            }
        }
       
        private void PharmacistDGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (pharmacistDGV.SelectedRows.Count > 0 && pharmacistDGV.SelectedRows.Count < 10)
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
                eSalaryTB.Text = row.Cells[10].Value.ToString();

                MemoryStream ms = new MemoryStream((byte[])row.Cells[12].Value);
                EmployeePP.Image = Image.FromStream(ms);


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
                eSalaryTB.Text = row.Cells[10].Value.ToString();
                MemoryStream ms = new MemoryStream((byte[])row.Cells[12].Value);
                EmployeePP.Image = Image.FromStream(ms);
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

        private void RefreshOFS_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("OUT_OFF_STOCK_ITEMS  10,'" + this.pharmacy_id + "'", con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            outOfStockDGV.DataSource = dt;
            outOfStockDGV.Columns[0].HeaderText = "ID";
            outOfStockDGV.Columns[1].HeaderText = "Name";
            outOfStockDGV.Columns[2].HeaderText = "Descripition";
            outOfStockDGV.Columns[3].HeaderText = "Purchase Price";
            outOfStockDGV.Columns[4].HeaderText = "Sell Price";
            outOfStockDGV.Columns[5].HeaderText = "Quantity";
            outOfStockDGV.Columns[6].HeaderText = "Pharmacy ID";
            con.Close();
        }
    
 
        private void OutOfStockDGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0 && e.RowIndex >=0)
            {
                DataGridViewRow row = this.outOfStockDGV.Rows[e.RowIndex];
                oosProductID.Text = row.Cells[0].Value.ToString();
                return;
            }
        }

        private void OOSRemoveBtn_Click(object sender, EventArgs e)
        {
           
           
            DialogResult dialogResult = MessageBox.Show("Are you sure, you want to remove This product?", "Remove", MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                SqlCommand cmd = new SqlCommand("Delete From ITEM WHERE i_id = '" + oosProductID.Text + "' AND i_qty=0", con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                EXP_Items();
            }
        }

        private void ItemSearchBtn_Click(object sender, EventArgs e)
        {
            search();
        }

        private void ItemSearchBtn_MouseHover(object sender, EventArgs e)
        {
            M_MenuListPanel.BringToFront();
        }

        private void ItemSearchBtn_MouseLeave(object sender, EventArgs e)
        {
            M_MenuBGPanel.BringToFront();
        }

        private void selectCatagoryBtn_Click(object sender, EventArgs e)
        {
            show_report();
            TDtransactionreportBtn.Visible = false;
            OOSBtn.Visible = false;
            con.Open();
            if(reportCatagoryCB.Text== "Transaction Records")
            {
                
                
                SqlCommand cmd = new SqlCommand("TRAN_REPORT " + pharmacy_id + "", con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                PMS.Report.TransactionReport report = new Report.TransactionReport();
                report.Database.Tables["TRANSACTION_RECORD"].SetDataSource(dt);
                reportCRV.ReportSource = null;
                reportCRV.ReportSource = report;
            }
            else if (reportCatagoryCB.Text== "Stock Product")
            {
                SqlCommand cmd = new SqlCommand("OUT_OFF_STOCK_ITEMS 15,"+pharmacy_id, con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);


                PMS.Report.OutOfStockProduct_Report_ report = new Report.OutOfStockProduct_Report_();
                report.Database.Tables["ITEM"].SetDataSource(dt);
                reportCRV.ReportSource = null;
                reportCRV.ReportSource = report;

            }
            else if (reportCatagoryCB.Text== "Exp Product")
            {
                SqlDataAdapter sqlDa = new SqlDataAdapter("EXP_REPORT", con);
                sqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataTable dt = new DataTable();
                sqlDa.Fill(dt);
              
                PMS.Report.EXProduct_Report report = new Report.EXProduct_Report();
                report.Database.Tables["EXP_ITEM"].SetDataSource(dt);
                reportCRV.ReportSource = null;
                reportCRV.ReportSource = report;
            }
            con.Close();
        }

        public void hide_report()
        {
            startFromCB.Checked = false;
            endUpToCB.Checked = false;
            reportCRV.Visible = false;
            selectCatagoryBtn.Visible = false;
            reportCatagoryCB.Visible = false;
            expireReportBtn.Visible = true;
            selectedTrsRecordBtn.Visible = true;
            datepickerGB.Visible = true;
            TDtransactionreportBtn.Visible = true;
            OOSBtn.Visible = true;
        }
        public void show_report()
        {
            selectCatagoryBtn.Visible = true;
            reportCatagoryCB.Visible = true;
            expireReportBtn.Visible = false;
            reportCRV.Visible = true;
            selectedTrsRecordBtn.Visible = false;
            datepickerGB.Visible = false;
            TDtransactionreportBtn.Visible = false;
            OOSBtn.Visible = false;
        }
        private void transactionreportBtn_Click(object sender, EventArgs e)
        {
            show_report();
           
            string date = DateTime.UtcNow.ToString("yyyy-MM-dd");
            SqlCommand cmd = new SqlCommand("TD_TRAN_REPORT " + pharmacy_id+",'"+date+"'", con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);

            PMS.Report.TodaysTransactionReport_ report = new Report.TodaysTransactionReport_();
            report.Database.Tables["TRANSACTION_RECORD"].SetDataSource(dt);
            reportCRV.ReportSource = null;
            reportCRV.ReportSource = report;
        }

        private void OOSBtn_Click(object sender, EventArgs e)
        {
            show_report();
          
            SqlCommand cmd = new SqlCommand("OUT_OFF_STOCK_ITEMS 15," + pharmacy_id, con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);

            PMS.Report.OutOfStockProduct_Report_ report = new Report.OutOfStockProduct_Report_();
            report.Database.Tables["ITEM"].SetDataSource(dt);
            reportCRV.ReportSource = null;
            reportCRV.ReportSource = report;
        }

        private void SelectedTrsRecordBtn_Click(object sender, EventArgs e)
        {
            show_report();
           
            string sdate = DateTime.UtcNow.ToString("yyyy-MM-dd");
            SqlCommand cmd = new SqlCommand("SELECTED_TRAN_REPORT "+pharmacy_id+",'" + startFromCB.Value.ToString() + "','" + endUpToCB.Value.ToString() + "'", con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);

            PMS.Report.TransactionReport report = new Report.TransactionReport();
            report.Database.Tables["TRANSACTION_RECORD"].SetDataSource(dt);
            reportCRV.ReportSource = null;
            reportCRV.ReportSource = report;
        }

        private void ExpireReportBtn_Click(object sender, EventArgs e)
        {
            show_report();
            SqlDataAdapter sqlDa = new SqlDataAdapter("EXP_REPORT", con);
            sqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            sqlDa.Fill(dt);

            PMS.Report.EXProduct_Report report = new Report.EXProduct_Report();
            report.Database.Tables["EXP_ITEM"].SetDataSource(dt);
            reportCRV.ReportSource = null;
            reportCRV.ReportSource = report;
        }

        private void ResetKeyCB_Click(object sender, EventArgs e)
        {
            if (resetKeyCB.Checked)
            {
                passResetKeyTB.Visible = true;
                setResetKeyBtn.Visible = true;
            }
            else
            {
                passResetKeyTB.Visible = false;
                setResetKeyBtn.Visible = false;
            }
        }

        private void SetResetKeyBtn_Click(object sender, EventArgs e)
        {
            string query;
              SqlCommand cmd;
            con.Open();
            if (passResetKeyTB.Text != "")
            {
                query = "update  PHARMACY SET " +
                        "e_reset_key = '" + passResetKeyTB.Text +
                        "' WHERE p_id = " + pharmacy_id;
                cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Reset Key Succssefully Added!", "Reset Key", MessageBoxButtons.OK);
            }
            con.Close();

        }
        Image i;
        Bitmap b;
        private void ChangeProfileBtn_Click(object sender, EventArgs e)
        {

            SelectProfilePicture();

        }
            public void SelectProfilePicture()
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "JPG Files(*.jpg)|*.jpg|PNG Files(*.png)|*.png|All Files(*.*)|*.*";
            DialogResult dr = ofd.ShowDialog();
            if (dr == DialogResult.OK)
            {
                i = Image.FromFile(ofd.FileName);
                b = (Bitmap)i;
                EmployeePP.Image = b;
            }
        }
        private void EmployeePP_Click(object sender, EventArgs e)
        {
            SelectProfilePicture();
        }

        private void GetManualBtn_Click(object sender, EventArgs e)
        {
            

        }

        private void GetManualBtn_Click_1(object sender, EventArgs e)
        {
            string pdf = "Manager_manual.pdf";
            System.Diagnostics.Process.Start(pdf);
        }

        private void GetManualBtn_MouseHover(object sender, EventArgs e)
        {
            UserManualplaceholder.Visible = true;
            UserManualplaceholder.BringToFront();

        }

        private void GetManualBtn_MouseLeave(object sender, EventArgs e)
        {
            UserManualplaceholder.Visible = false;
            
        }

        private void M_searchBtn_MouseHover(object sender, EventArgs e)
        {
            serachPlaceholderPB.Visible = true;
            serachPlaceholderPB.BringToFront();
        }

        private void M_searchBtn_MouseLeave(object sender, EventArgs e)
        {
            serachPlaceholderPB.Visible = false;
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
            changedColorPanel.Location = new Point(-4, 310);
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
            PED ped = new PED();
           
            if (MS_AddressTB.Text =="" || MS_bDateLB.Text == "" || MS_CityCB.Text == "" || MS_PNumberTB.Text == "" || MS_FNameTB.Text == "" || MS_LNameTB.Text == "" || !MS_maleRB.Checked && !MS_femaleRB.Checked || MS_nPasswordTB.Text != "" && MS_cPasswordTB.Text=="")
            {

            }
            else
            {
                String query = "update  MANAGER SET " +
                "m_name = '" + MS_FNameTB.Text + "'," +
                "m_lname = '" + MS_LNameTB.Text + "'," +
                "m_phone = '" + MS_PNumberTB.Text + "'," +
                "m_dob = '" + MS_bDateLB.Value.ToString() + "'," +
                "m_city = '" + MS_CityCB.Text + "'," +
                "m_address = '" + MS_AddressTB.Text;
                if (MS_cPasswordTB.Text != "" && MS_nPasswordTB.Text != "")
                {
                    
                    if (password == ped.Enc(MS_cPasswordTB.Text))
                    {

                        if (MS_nPasswordTB.Text.Length >= 8)
                        {
                            
                            query = query + "', m_password = '" + ped.Enc(MS_nPasswordTB.Text);
                            passErorr.Text= "Successfully Changed!";
                            passErorr.Visible = true;
                            passErorr.ForeColor = Color.Green;
                            password = MS_nPasswordTB.Text;
                        }
                        else
                        {
                            passErorr.Visible = true;
                            passErorr.Text = "Password must contain at least 8 characters!";
                            passErorr.ForeColor = Color.Red;
                        }

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
