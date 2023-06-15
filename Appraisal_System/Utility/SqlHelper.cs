using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appraisal_System.Utility
{
    public class SqlHelper
    {
        public static string Constr { get; set; }

        public static DataTable ExecuteTable(string cmdText)
        {
            using (SqlConnection conn = new SqlConnection(Constr))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(cmdText, conn);
                SqlDataAdapter sda = new SqlDataAdapter();
                DataSet ds = new DataSet();
                sda.Fill(ds);
                return ds.Tables[0];
            }
        }
        
        public static int ExecuteNonQuery(string cmdText)
        {
            using (SqlConnection conn = new SqlConnection(Constr))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(cmdText, conn);
                int rows = cmd.ExecuteNonQuery();
                if (rows <= 0) throw new Exception("DataSet cmd fails.");
                return rows;
            }
        }
    }
}
