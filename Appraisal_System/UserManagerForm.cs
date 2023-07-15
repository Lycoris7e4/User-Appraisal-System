using Appraisal_System.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Appraisal_System
{
    public partial class UserManagerForm : Form
    {
        public UserManagerForm()
        {
            InitializeComponent();
        }

        private void UserManagerForm_Load(object sender, EventArgs e)
        {
            BindCbx();
            BindDgv();
        }

        private void BindCbx()
        {
            List<AppraisalBases> appraisalBases = new List<AppraisalBases>();

            /* Get Data From DataBase */
            // Method 1
            // appraisalBases.Add(new AppraisalBases
            // {
            //     Id = 0,
            //     BaseType = "--List All--",
            //     AppraisalBase = 0,
            //     IsDel = false
            // });
            // appraisalBases.AddRange(AppraisalBases.ListAll());

            // Method 2
            appraisalBases = AppraisalBases.ListAll();
            appraisalBases.Insert(0, new AppraisalBases
            {
                Id = 0,
                BaseType = "--List All--",
                AppraisalBase = 0,
                IsDel = false
            });

            /* Initialize Identity ComboBox */
            // Method 1 (Only Text)
            // foreach (var appraisalBase in appraisalBases)
            // {
            //     cbxIdentity.Items.Add(appraisalBase.BaseType);
            // }

            // Method 2
            cbxIdentity.DataSource = appraisalBases;
            cbxIdentity.DisplayMember = "BaseType";
            cbxIdentity.ValueMember = "Id";

            cbxIdentity.SelectedIndex = 0;
        }
        private void BindDgv()
        {
            dgvUserAppraisal.AutoGenerateColumns = false;

            string userName = tbxUserName.Text.Trim();
            int baseTypeId = (int)cbxIdentity.SelectedValue;
            bool isSuspended = cbxSuspended.Checked;

            List<UserAppraisalBases> userAppraisalBases = UserAppraisalBases.GetListJoinAppraisal();
            if (baseTypeId == 0)
            {
                dgvUserAppraisal.DataSource = userAppraisalBases.FindAll
                    (m => m.UserName.Contains(userName) &&
                     m.IsDel == isSuspended);
            }
            else
            {
                dgvUserAppraisal.DataSource = userAppraisalBases.FindAll
                    (m => m.UserName.Contains(userName) &&
                     m.BaseTypeId == baseTypeId &&
                     m.IsDel == isSuspended);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            BindDgv();
        }
    }
}
