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
    public partial class CSH_Menu : Form
    {
        Connection connection = new Connection();
        SqlConnection con = Connection.CON();
        DataTable dataTable;
        String id = "", name = "", lName = "", phone = "", pharmacy_id = "";
        String city = "", address = "", dob = "", gender = "", password = "";
        double selectedItemPrice = 0, selectedItemPurchasePrice = 0;
        int selectedItemTotalQty = 0;
        string IName, IDescr, ISdate, ImportDate, IExpDate;
        int iQty = 0;
        double totalprice = 0;



        public CSH_Menu(DataTable dt)
        {
            InitializeComponent();


            this.dataTable = dt;
            MemoryStream ms = null;
            foreach (DataRow row in dt.Rows)
            {
                id = row["ca_id"].ToString();
                name = row["ca_name"].ToString();
                lName = row["ca_lname"].ToString();
                phone = row["ca_phone"].ToString();
                city = row["ca_city"].ToString();
                address = row["ca_address"].ToString();
                dob = row["ca_dob"].ToString();
                gender = row["ca_gender"].ToString();
                pharmacy_id = row["p_id"].ToString();
                password = row["ca_password"].ToString();
                ms = new MemoryStream((byte[])row["ca_profile_pic"]);

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

        private void C_MenuListPanel_MouseHover(object sender, EventArgs e)
        {
            C_MenuListPanel.BringToFront();
        }

        private void C_MenuListPanel_MouseLeave(object sender, EventArgs e)
        {
            C_MenuBGPanel.BringToFront();
        }

        private void CSH_MenuSettingsBtn_MouseHover(object sender, EventArgs e)
        {
            C_MenuListPanel.BringToFront();
        }

        private void CSH_MenuSettingsBtn_MouseLeave(object sender, EventArgs e)
        {
            C_MenuBGPanel.BringToFront();
        }

        private void Purchase_PanBtn_MouseHover(object sender, EventArgs e)
        {
            C_MenuListPanel.BringToFront();
        }

        private void Purchase_PanBtn_MouseLeave(object sender, EventArgs e)
        {
            C_MenuBGPanel.BringToFront();
        }

        private void ReportBtn_MouseHover(object sender, EventArgs e)
        {
            C_MenuListPanel.BringToFront();
        }

        private void ReportBtn_MouseLeave(object sender, EventArgs e)
        {
            C_MenuBGPanel.BringToFront();
        }

        public void View_Items(String search, int i)
        {

            try
            {
                String query = "";
                if (i == 0) query = "SELECT *from VIEW_ITEMS WHERE i_id like '%" + search + "%' AND p_id = '" + this.pharmacy_id + "'";
                else query = "SELECT *from VIEW_ITEMS  WHERE p_id = '" + this.pharmacy_id + "'";
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    emptyItemToPurchasePB.Visible = false;
                    ItemsDGVinPurchase.DataSource = dt;

                    ItemsDGVinPurchase.Columns[0].HeaderText = "ID";
                    ItemsDGVinPurchase.Columns[1].HeaderText = "Name";
                    ItemsDGVinPurchase.Columns[2].HeaderText = "Discreption";
                    ItemsDGVinPurchase.Columns[3].HeaderText = "Purchase Price";
                    ItemsDGVinPurchase.Columns[4].HeaderText = "Sell Price";
                    ItemsDGVinPurchase.Columns[5].HeaderText = "Quantity";
                    ItemsDGVinPurchase.Columns[6].HeaderText = "Mfg Date";
                    ItemsDGVinPurchase.Columns[7].HeaderText = "Import Date";
                    ItemsDGVinPurchase.Columns[8].HeaderText = "Expire Date";
                    ItemsDGVinPurchase.Columns[9].HeaderText = "Pharmacy ID";
                }
                else
                {
                    emptyItemToPurchasePB.Visible = true;
                    ItemsDGVinPurchase.DataSource = null;
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

        private void ClearSelectedItem_Click(object sender, EventArgs e)
        {

        }

        private void SettingSaveBtn_Click(object sender, EventArgs e)
        {
            PED ped = new PED();
            if (MS_AddressTB.Text == "" || MS_bDateLB.Text == "" || MS_CityCB.Text == "" || MS_PNumberTB.Text == "" || MS_FNameTB.Text == "" || MS_LNameTB.Text == "" || !MS_maleRB.Checked && !MS_femaleRB.Checked || MS_nPasswordTB.Text != "" && MS_cPasswordTB.Text == "")
            {
                MessageBox.Show("Please Fill The Form Properly!", "Settings", MessageBoxButtons.OK);
            }
            else
            {
                String query = "update  CASHIER SET " +
                "ca_name = '" + MS_FNameTB.Text + "'," +
                "ca_lname = '" + MS_LNameTB.Text + "'," +
                "ca_phone = '" + MS_PNumberTB.Text + "'," +
                "ca_dob = '" + MS_bDateLB.Value.ToString() + "'," +
                "ca_city = '" + MS_CityCB.Text + "'," +
                "ca_address = '" + MS_AddressTB.Text;
                if (MS_cPasswordTB.Text != "" && MS_nPasswordTB.Text != "")
                {

                    if (password == ped.Enc(MS_cPasswordTB.Text))
                    {

                        if (MS_nPasswordTB.Text.Length >= 8)
                        {
                            passErorr.Visible = false;
                            query = query + "', ca_password = '" + ped.Enc(MS_nPasswordTB.Text);
                        }
                        else
                        {
                            passErorr.Visible = true;
                        }


                    }
                }
                SqlCommand cmd = new SqlCommand(query + "' WHERE ca_id = '" + this.id + "'", con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

            }

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

        private void reportBtn_Click(object sender, EventArgs e)
        {
            M_hide();
            panel1.Visible = true;

            string date = DateTime.UtcNow.ToString("yyyy-MM-dd");
            SqlCommand cmd = new SqlCommand("TD_TRAN_REPORT " + pharmacy_id + ",'" + date + "'", con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);

            PMS.Report.TodaysTransactionReport_ report = new Report.TodaysTransactionReport_();
            report.Database.Tables["TRANSACTION_RECORD"].SetDataSource(dt);
            CreportCRV.ReportSource = null;
            CreportCRV.ReportSource = report;
        }

        private void serach_Click(object sender, EventArgs e)
        {
            M_hide();
            C_searchItemsPanel.Visible = true;
            M_searchItemTB.Visible = true;
            searchIcon.Visible = true;
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

        private void ChangePPictureBtn_Click(object sender, EventArgs e)
        {
            SelectProfilePicture();


            string query = "update  CASHIER SET " +
                "ca_profile_pic = @PP" +
                 " WHERE ca_id = '" + id + "'";
            con.Open();
            SqlCommand cmd = new SqlCommand(query, con);

            MemoryStream stream = new MemoryStream();
            profilepicture.Image.Save(stream, ImageFormat.Jpeg);
            byte[] pPicture = stream.ToArray();
            cmd.Parameters.Add(new SqlParameter("@PP", pPicture));

            cmd.ExecuteNonQuery();
            con.Close();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            M_hide();
            panel1.Visible = true;

            string date = DateTime.UtcNow.ToString("yyyy-MM-dd");
            SqlCommand cmd = new SqlCommand("TD_TRAN_REPORT " + pharmacy_id + ",'" + date + "'", con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);

            PMS.Report.TodaysTransactionReport_ report = new Report.TodaysTransactionReport_();
            report.Database.Tables["TRANSACTION_RECORD"].SetDataSource(dt);
            CreportCRV.ReportSource = null;
            CreportCRV.ReportSource = report;
        }

        private void ReceiptBtn_Click(object sender, EventArgs e)
        {
            if(orders == 0)
            {
                checkOrder.Visible = true;
            }
            else
            {
                checkOrder.Visible = false;
                receiptPanel.Visible = true;
                receiptPanel.BringToFront();
                rdate.Text = rcDate;
                rtotal.Text = rTotalprice.ToString();
                rorderqty.Text = orders.ToString();
                rcashier.Text = name + " " + lName;
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT *from PHARMACY  WHERE p_id = '" + this.pharmacy_id + "'", con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                foreach (DataRow row in dt.Rows)
                {
                    rcityLocation.Text = row["p_city"].ToString();
                    raddlocation.Text = "/" + row["p_address"].ToString();
                    rpnumber.Text = row["p_phone"].ToString();
                }
                con.Close();
     
            }
        }

        private void M_searchBtn_Click(object sender, EventArgs e)
        {
            M_hide();
            C_searchItemsPanel.Visible = true;
            M_searchItemTB.Visible = true;
            searchIcon.Visible = true;
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
       public static int orders = 0;
        public double rTotalprice;
        public string rcDate = DateTime.UtcNow.ToString();
        public class Receipt
        {

            public string iname, pdate;
            public int qty;
            public double Totalprice, price;

            //Receipt(string name,float price,string date,int qty,double totalprice)
            //{
            //    this.iname = name;
            //    this.pdate = date;
            //    this.qty = qty;
            //    this.Totalprice = (float)totalprice;
            //    this.price = price;
            //}
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

        private void GetManualBtn_Click(object sender, EventArgs e)
        {
            string pdf = "Cashier Manual.pdf";
            System.Diagnostics.Process.Start(pdf);
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            
            M_hide();
            panel1.Visible = true;

            string date = DateTime.UtcNow.ToString("yyyy-MM-dd");
            SqlCommand cmd = new SqlCommand("TD_TRAN_REPORT " + pharmacy_id + ",'" + date + "'", con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);

            PMS.Report.TodaysTransactionReport_ report = new Report.TodaysTransactionReport_();
            report.Database.Tables["TRANSACTION_RECORD"].SetDataSource(dt);
            CreportCRV.ReportSource = null;
            CreportCRV.ReportSource = report;

        }

        private void cancelReceipt_Click(object sender, EventArgs e)
        {
            receiptPanel.Visible = false;

            orders = 0;
            rdate.Text = "";
            rtotal.Text = "";
            rorderqty.Text = "";
            rcashier.Text = "";
            rcityLocation.Text = "";
            raddlocation.Text = "";
            rpnumber.Text = "";
        }

        private void MS_nPasswordTB_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        List<Receipt> list = new List<Receipt>();
        private void PurchaseItemBtn_Click_1(object sender, EventArgs e)
        {

            try
            {

                if (pItemIDTB.Text == "" || phrIDinPurchaseTb.Text == "" || pItemQtyTB.Value.ToString() == "")
                {
                    emptyFormErorrLabel.Visible = true;
                }
                else
                {

                    emptyFormErorrLabel.Visible = false;
                    String query = "insert into TRANSACTION_RECORD(i_id,i_name, i_descr, i_pur_price,i_sell_price, i_sdate, i_expdate, i_import_date,i_qty, p_id,ca_id,ph_id,pur_date,total_price ) ";
                    SqlCommand cmd = new SqlCommand(query + " values ('" + pItemIDTB.Text + "','" + IName + "','" + IDescr + "','"
                       + selectedItemPurchasePrice + "','" + selectedItemPrice + "','" + ISdate + "','" + IExpDate + "','" + ImportDate + "','" + pItemQtyTB.Value.ToString()
                       + "','" + pharmacy_id + "' , '" + id + "' , '" + phrIDinPurchaseTb.Text + "' ,GETDATE(),'" + pTotalPriceTB.Text + "');", con);
                    con.Open();
                    cmd.ExecuteNonQuery();
                  
                    selectedItemTotalQty = selectedItemTotalQty - iQty;
                   
                        query = "update  ITEM SET " +
                            "i_qty = '" + selectedItemTotalQty + "' WHERE i_id = '" + pItemIDTB.Text + "'";
                        cmd = new SqlCommand(query, con);
                        cmd.ExecuteNonQuery();

                    
                    con.Close();
                    MessageBox.Show("Item Successfully Purchased!", "Purchase", MessageBoxButtons.OK);

                    rTotalprice = rTotalprice + Convert.ToDouble(pTotalPriceTB.Text);
                    orders++;

                    pItemIDTB.Text = "";
                    pItemQtyTB.Value = 0;
                    pTotalPriceTB.Text = "";
                    View_Items("", 1); con.Close();
                }

            }
            catch (Exception ex)
            {
                chkErorrLabel.Visible = true;
            }

        }

        private void ClearSelectedItem_Click_1(object sender, EventArgs e)
        {

            phrIDinPurchaseTb.Text = "";
            pItemIDTB.Text = "";
            pItemQtyTB.Value = 0;
            pTotalPriceTB.Text = "";

            orders = 0;
            rdate.Text = "";
            rtotal.Text = "";
            rorderqty.Text = "";
            rcashier.Text = "";
            rcityLocation.Text = "";
            raddlocation.Text = "";
            rpnumber.Text = "";

        }

        private void ItemsDGVinPurchase_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        
        }

        private void ItemsDGVinPurchase_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (ItemsDGVinPurchase.SelectedRows.Count > 0 && ItemsDGVinPurchase.SelectedRows.Count < 8)
            {
                DataGridViewRow row = this.ItemsDGVinPurchase.Rows[e.RowIndex];
                pItemIDTB.Text = row.Cells[0].Value.ToString();
                selectedItemPrice = Convert.ToDouble(row.Cells[4].Value.ToString());
                selectedItemPurchasePrice = Convert.ToDouble(row.Cells[3].Value.ToString());
                selectedItemTotalQty = Convert.ToInt32(row.Cells[5].Value.ToString());
                IName = row.Cells[1].Value.ToString();
                IDescr = row.Cells[2].Value.ToString();
                ISdate = row.Cells[6].Value.ToString();
                ImportDate = row.Cells[7].Value.ToString();
                IExpDate = row.Cells[8].Value.ToString();
                return;
            }
        }

        private void PItemQtyTB_ValueChanged(object sender, EventArgs e)
        {
            iQty = Convert.ToInt32(pItemQtyTB.Value.ToString());
            if (iQty==0){
                totalprice = 0;
            }else if(iQty<=selectedItemTotalQty){
                totalprice = selectedItemPrice * iQty;
            }else{
                MessageBox.Show("There is only "+selectedItemTotalQty+"Item avalibale in The store", "Item Quantity", MessageBoxButtons.OK);
                pItemQtyTB.Value = 0;
            }
            pTotalPriceTB.Text = totalprice.ToString();
        }

        private void PurchaseItemBtn_Click(object sender, EventArgs e)
        {

            
        }
       

        private void SerachItemsInPurchaseTb_TextChanged(object sender, EventArgs e)
        {
            string search;
            search = serachItemsInPurchaseTb.Text.Trim();
            View_Items(search, 0);
        }

        private void Purchase_PanBtn_Click(object sender, EventArgs e)
        {
            M_hide();
            purchasePanel.Visible = true;
            View_Items("", 1);
        }

        private void M_searchItemTB_TextChanged(object sender, EventArgs e)
        {
            C_searchItemsPanel.Visible = true;
            string search;
            search = M_searchItemTB.Text.Trim();
            try
            {
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }

        }

        public void M_hide()
        {
            C_settingPanel.Visible = false;
            searchIcon.Visible = false;
            welcomeLB.Visible = false;
            M_welcomePb.Visible = false;
            C_searchItemsPanel.Visible = false;
            purchasePanel.Visible = false;
            M_searchItemTB.Visible = false;
            M_searchBtn.Anchor = new AnchorStyles();
            panel1.Visible = false;
            receiptPanel.Visible = false;

        }
        private void CSH_MenuSettingsBtn_Click(object sender, EventArgs e)
        {
            M_hide();
            C_settingPanel.Visible = true;
        }

        private void CSH_Menu_Load(object sender, EventArgs e)
        {
            cashierIDinPurchaseTB.Text = id;
        }
    }
}
