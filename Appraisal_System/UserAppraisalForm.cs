using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using Appraisal_System.Model;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Appraisal_System
{
    public partial class UserAppraisalForm : Form
    {
        public UserAppraisalForm()
        {
            InitializeComponent();
        }

        private void UserAppraisalForm_Load(object sender, EventArgs e)
        {
            List<AppraisalCoefficients> appraisalCoefficients = AppraisalCoefficients.ListAll();
            List<DataGridViewTextBoxColumn> dataGridViewTextBoxColumns = new List<DataGridViewTextBoxColumn>();

            foreach (var app in appraisalCoefficients)
            {
                dataGridViewTextBoxColumns.Add(new DataGridViewTextBoxColumn
                {
                    HeaderText = app.AppraisalType,
                    Name = "AppraisalType" + app.Id.ToString(),
                    DataPropertyName = "AppraisalType" + app.Id.ToString(),
                    ReadOnly = true,
                    Width = 88
                });

                dataGridViewTextBoxColumns.Add(new DataGridViewTextBoxColumn
                {
                    HeaderText = "Coefficient",
                    Name = "AppraisalCoefficient" + app.Id.ToString(),
                    DataPropertyName = "AppraisalCoefficient" + app.Id.ToString(),
                    ReadOnly = true,
                    Visible = false,
                    Width = 88
                });

                dataGridViewTextBoxColumns.Add(new DataGridViewTextBoxColumn
                {
                    HeaderText = "Calculation Method",
                    Name = "Calculation Method" + app.Id.ToString(),
                    DataPropertyName = "Calculation Method" + app.Id.ToString(),
                    ReadOnly = true,
                    Visible = false,
                    Width = 88
                });
            }
            
            dgvUserAppraisal.Columns.AddRange(dataGridViewTextBoxColumns.ToArray());
        }
    }
}
