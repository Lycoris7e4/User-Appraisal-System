using Appraisal_System.Utility;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appraisal_System.Model
{
    public class AppraisalBases
    {
        public int Id { get; set; }
        public string BaseType { get; set; }
        public int AppraisalBase { get; set; }
        public bool IsSuspended { get; set; }

        public static List<AppraisalBases> ListAll()
        {
            List<AppraisalBases> appraisalBases = new List<AppraisalBases>();
            DataTable dt = SqlHelper.ExecuteTable(
                "SELECT * FROM AppraisalBases");
            foreach (DataRow dr in dt.Rows)
            {
                appraisalBases.Add(dr.DataRowToModel<AppraisalBases>());
            }
            return appraisalBases;
        }

        public static int Update(AppraisalBases appraisalBases)
        {
            return SqlHelper.ExecuteNonQuery(
                "UPDATE AppraisalBases SET " +
                "BaseType = @BaseType," +
                "AppraisalBase = @AppraisalBase," +
                "IsSuspended = @IsSuspended " +
                "WHERE Id = @Id",
                new SqlParameter("@Id", appraisalBases.Id),
                new SqlParameter("@BaseType", appraisalBases.BaseType),
                new SqlParameter("@AppraisalBase", appraisalBases.AppraisalBase),
                new SqlParameter("@IsSuspended", appraisalBases.IsSuspended));
        }
    }
}
