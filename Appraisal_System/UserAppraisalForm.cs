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
        private DataTable dtUser;
        Action update;

        public UserAppraisalForm()
        {
            InitializeComponent();
        }

        private void UserAppraisalForm_Load(object sender, EventArgs e)
        {
            update = UpdateDt;

            SetCol();

            InitDt();
            UpdateDt();
        }

        private void SetCol()
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
                    Name = "CalculationMethod" + app.Id.ToString(),
                    DataPropertyName = "CalculationMethod" + app.Id.ToString(),
                    ReadOnly = true,
                    Visible = false,
                    Width = 88
                });
            }

            dgvUserAppraisal.Columns.AddRange(dataGridViewTextBoxColumns.ToArray());

            dgvUserAppraisal.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Assessment Year",
                Name = "AssessmentYear",
                DataPropertyName = "AssessmentYear",
                ReadOnly = true,
                Width = 166
            });
            dgvUserAppraisal.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Year-end Bonus",
                Name = "YearBonus",
                DataPropertyName = "YearBonus",
                ReadOnly = true,
                Width = 166
            });
        }

        private void InitDt()
        {
            dtUser = UserAppraisalBases.GetDtJoinAppraisal();
            List<AppraisalCoefficients> appraisalCoefficients = AppraisalCoefficients.ListAll();

            foreach (var item in appraisalCoefficients)
            {
                dtUser.Columns.Add(new DataColumn
                {
                    ColumnName = "AppraisalType" + item.Id
                });

                dtUser.Columns.Add(new DataColumn
                {
                    ColumnName = "AppraisalCoefficient" + item.Id
                });

                dtUser.Columns.Add(new DataColumn
                {
                    ColumnName = "CalculationMethod" + item.Id
                });
            }

            dtUser.Columns.Add(new DataColumn
            {
                ColumnName = "AssessmentYear"
            });

            dtUser.Columns.Add(new DataColumn
            {
                ColumnName = "YearBonus"
            });
        }

        private void UpdateDt()
        {

            List<UserAppraisalCoefficients> uac = UserAppraisalCoefficients.ListAll();
            for (int i = 0; i < dtUser.Rows.Count; ++i)
            {
                var uacCurUser = uac.FindAll(m => m.UserId == (int)dtUser.Rows[i]["Id"]);

                double[] yearBonusArray = new double[uacCurUser.Count];
                for (int j = 0; j < uacCurUser.Count; ++j)
                {
                    string appraisalTypeKey = "AppraisalType" + uacCurUser[j].CoefficientId;
                    string appraisalCoefficientKey = "AppraisalCoefficient" + uacCurUser[j].CoefficientId;
                    string calculationMethodKey = "CalculationMethod" + uacCurUser[j].CoefficientId;

                    double appraisalTypeCountValue = uacCurUser[j].Count;
                    double appraisalCoefficientValue = uacCurUser[j].AppraisalCoefficient;
                    int calculationMethodKeyValue = (int)uacCurUser[j].CalculationMethod;

                    dtUser.Rows[i][appraisalCoefficientKey] = appraisalCoefficientValue;
                    dtUser.Rows[i][calculationMethodKey] = calculationMethodKeyValue;

                    if (uacCurUser[j].AssessmentYear == Convert.ToInt32(cbxYear.Text) && 
                        appraisalTypeCountValue != 0)
                    {
                        dtUser.Rows[i][appraisalTypeKey] = appraisalTypeCountValue;
                        
                        yearBonusArray[j] = appraisalCoefficientValue * 
                                            appraisalTypeCountValue * 
                                            calculationMethodKeyValue;
                    } else {
                        dtUser.Rows[i][appraisalTypeKey] = "";
                    }
                }

                dtUser.Rows[i]["AssessmentYear"] = cbxYear.Text;

                double yearBonusAll = yearBonusArray.Sum();
                double yearBonus = (1 + yearBonusAll) * Convert.ToDouble(dtUser.Rows[i]["AppraisalBase"]);

                dtUser.Rows[i]["YearBonus"] = Math.Max(yearBonus, 0);
            }

            dgvUserAppraisal.AutoGenerateColumns = false;
            dgvUserAppraisal.DataSource = dtUser;
        }

        private void cbxYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateDt();
        }

        private void dgvUserAppraisal_MouseDown(object sender, MouseEventArgs e)
        {
            dgvUserAppraisal.ClearSelection();

            tsmEdit.Visible = false;
        }

        private void dgvUserAppraisal_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            dgvUserAppraisal.ClearSelection();

            if (e.Button == MouseButtons.Right && e.RowIndex > -1)
            {
                dgvUserAppraisal.Rows[e.RowIndex].Selected = true;
                tsmEdit.Visible = true;
            }
        }

        private void tsmEdit_Click(object sender, EventArgs e)
        {
            int userId = (int)dgvUserAppraisal.SelectedRows[0].Cells["Id"].Value;
            string year = cbxYear.Text;

            EditAppraisalForm editAppraisalForm = new EditAppraisalForm(userId, year, update);
            editAppraisalForm.ShowDialog();
        }

        private void UserAppraisalForm_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible)
            {
                InitDt();
                UpdateDt();
            }
        }
    }
}
