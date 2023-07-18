using Appraisal_System.Model;
using Appraisal_System.Models;
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
    public partial class EditUserForm : Form
    {
        private DelBindDgv _delBindDgv;

        public EditUserForm(DelBindDgv delBindDgv)
        {
            InitializeComponent();
            _delBindDgv = delBindDgv;
        }

        private void EditUserForm_Load(object sender, EventArgs e)
        {
            List<AppraisalBases> appraisalBases = new List<AppraisalBases>();
            appraisalBases = AppraisalBases.ListAll();
            cbxIdentity.DataSource = appraisalBases;
            cbxIdentity.DisplayMember = "BaseType";
            cbxIdentity.ValueMember = "Id";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string userName = tbxUserName.Text.Trim();
            int baseTypeId = (int)cbxIdentity.SelectedValue;
            string sex = cbxSex.Text;
            bool isSuspended = chxSuspended.Checked;

            Users user = new Users
            {
                UserName = userName,
                BaseTypeId = baseTypeId,
                Password = "111",
                Sex = sex,
                IsSuspended = isSuspended,
            };
            Users.Insert(user);

            MessageBox.Show("Successfully add user: " + userName);
            _delBindDgv();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
