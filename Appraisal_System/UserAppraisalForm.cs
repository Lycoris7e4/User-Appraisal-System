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
            SetCol();

            SetUserDt(GetUserDt());
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

        private DataTable GetUserDt()
        {
            DataTable dtUser = UserAppraisalBases.GetDtJoinAppraisal();
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

            return dtUser;
        }

        private void SetUserDt(DataTable dtUser)
        {
            List<UserAppraisalCoefficients> userAppraisalCoefficients
                = UserAppraisalCoefficients.ListAll();
            for (int i = 0; i < dtUser.Rows.Count; ++i)
            {
                var uacFilter = userAppraisalCoefficients.FindAll(m => 
                    m.UserId == (int)dtUser.Rows[i]["Id"] &&
                    m.AssessmentYear == Convert.ToInt32(cbxYear.Text));
                double[] yearBonusArray = new double[uacFilter.Count];

                for (int j = 0; j < uacFilter.Count; ++j)
                {
                    string appraisalTypeKey = "AppraisalType" + uacFilter[j].CoefficientId;
                    string appraisalCoefficientKey = "AppraisalCoefficient" + uacFilter[j].CoefficientId;
                    string calculationMethodKey = "CalculationMethod" + uacFilter[j].CoefficientId;

                    double appraisalTypeCountValue = uacFilter[j].Count;
                    double appraisalCoefficientValue = uacFilter[j].AppraisalCoefficient;
                    int calculationMethodKeyValue = (int)uacFilter[j].CalculationMethod;

                    dtUser.Rows[i][appraisalTypeKey] = appraisalTypeCountValue;
                    dtUser.Rows[i][appraisalCoefficientKey] = appraisalCoefficientValue;
                    dtUser.Rows[i][calculationMethodKey] = calculationMethodKeyValue;

                    yearBonusArray[j] = appraisalCoefficientValue * 
                                        appraisalTypeCountValue * 
                                        calculationMethodKeyValue;
                }

                dtUser.Rows[i]["AssessmentYear"] = cbxYear.Text;
                
                double yearBonusAll = 0;
                for (int j = 0; j < yearBonusArray.Length; j++)
                {
                    yearBonusAll += yearBonusArray[j];
                }

                double yearBonus = (1 + yearBonusAll) * Convert.ToDouble(dtUser.Rows[i]["AppraisalBase"]);

                dtUser.Rows[i]["YearBonus"] = Math.Max(yearBonus, 0);
            }

            dgvUserAppraisal.AutoGenerateColumns = false;
            dgvUserAppraisal.DataSource = dtUser;
        }
    }
}
