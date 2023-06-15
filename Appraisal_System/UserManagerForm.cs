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
            List<AppraisalBases> appraisalBases = new List<AppraisalBases>();

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

            // Method 1
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
    }
}
