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
    public delegate void DelBindDgv();

    public partial class UserManagerForm : Form
    {
        DelBindDgv delBindDgv;

        public UserManagerForm()
        {
            InitializeComponent();
        }

        private void UserManagerForm_Load(object sender, EventArgs e)
        {
            BindCbx();
            BindDgv();
            delBindDgv = BindDgv;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            BindDgv();
        }

        private void dgvUserAppraisal_MouseDown(object sender, MouseEventArgs e)
        {
            clearDGVSelectedItems();

            if (e.Button == MouseButtons.Right)
            {
                tsmAdd.Visible = true;
                tsmEdit.Visible = false;
                tsmEnable.Visible = false;
                tsmDisable.Visible = false;
            }
        }

        private void dgvUserAppraisal_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            clearDGVSelectedItems();

            if (e.Button == MouseButtons.Right && e.RowIndex > -1)
            {
                dgvUserAppraisal.Rows[e.RowIndex].Selected = true;
                tsmAdd.Visible = true;
                tsmEdit.Visible = true;

                bool isSuspended = (bool)dgvUserAppraisal.SelectedRows[0].Cells["IsSuspended"].Value;
                tsmEnable.Visible = isSuspended;
                tsmDisable.Visible = !isSuspended;
            }
        }

        private void clearDGVSelectedItems()
        {
            foreach (DataGridViewCell cell in dgvUserAppraisal.SelectedCells)
            {
                cell.Selected = false;
            }

            foreach (DataGridViewRow row in dgvUserAppraisal.SelectedRows)
            {
                row.Selected = false;
            }
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
                IsSuspended = false
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
            bool isSuspended = chxSuspended.Checked;

            List<UserAppraisalBases> userAppraisalBases = UserAppraisalBases.GetListJoinAppraisal();
            if (baseTypeId == 0)
            {
                dgvUserAppraisal.DataSource = userAppraisalBases.FindAll
                    (m => m.UserName.Contains(userName) &&
                     m.IsSuspended == isSuspended);
            }
            else
            {
                dgvUserAppraisal.DataSource = userAppraisalBases.FindAll
                    (m => m.UserName.Contains(userName) &&
                     m.BaseTypeId == baseTypeId &&
                     m.IsSuspended == isSuspended);
            }
        }

        private void tsmAdd_Click(object sender, EventArgs e)
        {
            EditUserForm editUserForm = new EditUserForm(delBindDgv);
            editUserForm.ShowDialog();
        }
    }
}
