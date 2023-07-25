﻿using Appraisal_System.Utility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appraisal_System.Model
{
    public class UserAppraisalBases
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Sex { get; set; }
        public int BaseTypeId { get; set; }
        public string BaseType { get; set; }
        public int AppraisalBase { get; set; }
        public bool IsSuspended { get; set; }

        public static List<UserAppraisalBases> GetListJoinAppraisal()
        {
            List<UserAppraisalBases> userAppraisalBases = new List<UserAppraisalBases>();
            DataTable dt = SqlHelper.ExecuteTable(
                "SELECT u.Id, u.UserName, u.Sex, u.BaseTypeId, u.IsSuspended, a.AppraisalBase, a.BaseType " +
                "FROM Users u LEFT JOIN AppraisalBases a ON u.BaseTypeId = a.Id");
            foreach (DataRow dr in dt.Rows)
            {
                userAppraisalBases.Add(ToModel(dr));
            }

            return userAppraisalBases;
        }

        public static DataTable GetDtJoinAppraisal()
        {
            return SqlHelper.ExecuteTable(
                "SELECT u.Id, u.UserName, u.Sex, u.BaseTypeId, u.IsSuspended, a.AppraisalBase, a.BaseType " +
                "FROM Users u LEFT JOIN AppraisalBases a ON u.BaseTypeId = a.Id");
        }

        private static UserAppraisalBases ToModel(DataRow dr)
        {
            UserAppraisalBases userAppraisalBase = new UserAppraisalBases();
            userAppraisalBase.Id = (int)dr["Id"];
            userAppraisalBase.UserName = dr["UserName"].ToString();
            userAppraisalBase.Sex = dr["Sex"].ToString();
            userAppraisalBase.BaseTypeId = (int)dr["BaseTypeId"];
            userAppraisalBase.BaseType = dr["BaseType"].ToString();
            userAppraisalBase.AppraisalBase = (int)dr["AppraisalBase"];
            userAppraisalBase.IsSuspended = (bool)dr["IsSuspended"];
            return userAppraisalBase;
        }
    }
}
