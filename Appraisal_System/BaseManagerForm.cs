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
    public partial class BaseManagerForm : Form
    {
        public BaseManagerForm()
        {
            InitializeComponent();
        }

        private void BaseManagerForm_Load(object sender, EventArgs e)
        {
            dgvBase.DataSource = AppraisalBases.ListAll();
        }

        private void dgvBase_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            AppraisalBases appraisalBase = (AppraisalBases)dgvBase.Rows[e.RowIndex].DataBoundItem;
            AppraisalBases.Update(appraisalBase);
        }
    }
}
