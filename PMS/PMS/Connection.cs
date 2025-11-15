using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace PMS
{
    public class Connection
    {
        static SqlConnection con = new SqlConnection("data source =LAPTOP-BL3990MK;database = PMS;integrated security = true");
        public static SqlConnection CON()
        {
            return con;
        }
    }
}
