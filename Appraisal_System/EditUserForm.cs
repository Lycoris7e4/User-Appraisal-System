﻿using Appraisal_System.Model;
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
        public EditUserForm()
        {
            InitializeComponent();
        }

        private void EditUserForm_Load(object sender, EventArgs e)
        {
            List<AppraisalBases> appraisalBases = new List<AppraisalBases>();
            appraisalBases = AppraisalBases.ListAll();
            cbxIdentity.DataSource = appraisalBases;
            cbxIdentity.DisplayMember = "BaseType";
            cbxIdentity.ValueMember = "Id";
        }
    }
}
