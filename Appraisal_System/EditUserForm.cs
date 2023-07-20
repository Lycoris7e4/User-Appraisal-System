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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Appraisal_System
{
    public partial class EditUserForm : Form
    {
        private DelBindDgv _delBindDgv;
        private Users _user;

        public EditUserForm(DelBindDgv delBindDgv)
        {
            InitializeComponent();
            _delBindDgv = delBindDgv;
        }

        public EditUserForm(DelBindDgv delBindDgv, int userId): this(delBindDgv)
        {
            _user = Users.ListAll().Find(m => m.Id == userId);
        }

        private void EditUserForm_Load(object sender, EventArgs e)
        {
            List<AppraisalBases> appraisalBases = new List<AppraisalBases>();
            appraisalBases = AppraisalBases.ListAll();
            cbxIdentity.DataSource = appraisalBases;
            cbxIdentity.DisplayMember = "BaseType";
            cbxIdentity.ValueMember = "Id";

            if (_user != null)
            {
                tbxUserName.Text = _user.UserName;
                cbxIdentity.SelectedValue = _user.BaseTypeId;
                cbxSex.Text = _user.Sex;
                chxSuspended.Checked = _user.IsSuspended;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string userName = tbxUserName.Text.Trim();
            int baseTypeId = (int)cbxIdentity.SelectedValue;
            string sex = cbxSex.Text;
            bool isSuspended = chxSuspended.Checked;

            if (_user == null)
            {
                Users user = new Users
                {
                    UserName = userName,
                    BaseTypeId = baseTypeId,
                    Password = "111",
                    Sex = sex,
                    IsSuspended = isSuspended
                };
                Users.Insert(user);
                MessageBox.Show("Successfully add user: " + userName);
            } else
            {
                _user.UserName = userName;
                _user.BaseTypeId = baseTypeId;
                _user.Sex = sex;
                _user.IsSuspended = isSuspended;
                Users.Update(_user);
                MessageBox.Show("Successfully update user: " + userName);
            }

            _delBindDgv();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
