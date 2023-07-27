using Appraisal_System.Utility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appraisal_System.Model
{
    public class Users
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Sex { get; set; }
        public int BaseTypeId { get; set; }
        public bool IsSuspended { get; set; }

        public static List<Users> ListAll()
        {
            DataTable dt = SqlHelper.ExecuteTable(
                "SELECT u.Id, u.UserName, u.Password, u.Sex, u.BaseTypeId, u.IsSuspended " +
                "FROM Users u");
            List<Users> users = new List<Users>();
            foreach (DataRow dr in dt.Rows)
            {
                users.Add(dr.DataRowToModel<Users>());
            }
            return users;
        }

        public static int Insert(Users user)
        {
            return SqlHelper.ExecuteNonQuery(
                $"INSERT INTO Users(UserName, Password, Sex, BaseTypeId, IsSuspended) " +
                "VALUES(@UserName, @Password, @Sex, @BaseTypeId, @IsSuspended)",
                new SqlParameter("@UserName", user.UserName),
                new SqlParameter("@Password", user.Password),
                new SqlParameter("@Sex", user.Sex),
                new SqlParameter("@BaseTypeId", user.BaseTypeId),
                new SqlParameter("@IsSuspended", user.IsSuspended));
        }

        public static int Update(Users user)
        {
            return SqlHelper.ExecuteNonQuery(
                "UPDATE Users SET " +
                "UserName = @UserName," +
                "Password = @Password," +
                "Sex = @Sex," +
                "BaseTypeId = @BaseTypeId," +
                "IsSuspended = @IsSuspended " +
                "WHERE Id = @Id",
                new SqlParameter("@Id", user.Id),
                new SqlParameter("@UserName", user.UserName),
                new SqlParameter("@Password", user.Password),
                new SqlParameter("@Sex", user.Sex),
                new SqlParameter("@BaseTypeId", user.BaseTypeId),
                new SqlParameter("@IsSuspended", user.IsSuspended));
        }
    }
}
