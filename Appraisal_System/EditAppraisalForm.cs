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
    public partial class EditAppraisalForm : Form
    {
        private int userId;
        private string year;
        private Action update;

        public EditAppraisalForm()
        {
            InitializeComponent();
        }

        public EditAppraisalForm(int _userId, string _year, Action _update): this()
        {
            userId = _userId;
            year = _year;
            update = _update;
        }

        private void EditAppraisalForm_Load(object sender, EventArgs e)
        {
            CreateControls();

            BindControls();
        }

        private void CreateControls()
        {
            List<AppraisalCoefficients> appraisalCoefficients = AppraisalCoefficients.ListAll();
            foreach (var ac in appraisalCoefficients)
            {
                Panel panel = new Panel();
                Label label = new Label
                {
                    Text = ac.AppraisalType,
                    Width = 60,
                    Location = new Point(0, 4)
                };

                TextBox textBox = new TextBox
                {
                    Location = new Point(66, 0),
                    Width = 120,
                    Height = 26,
                    Tag = ac.Id
                };

                panel.Controls.Add(label);
                panel.Controls.Add(textBox);
                flp.Controls.Add(panel);
            }
        }

        private void BindControls()
        {
            List<UserAppraisals> userAppraisals = UserAppraisals.ListByUserIdAndYear(userId, year);

            var flCtrls = flp.Controls;
            foreach (Control flCtrl in flCtrls)
            {
                if (!(flCtrl is Panel))
                {
                    continue;
                }

                var plCtrls = flCtrl.Controls;
                foreach (Control plCtrl in plCtrls)
                {
                    if (!(plCtrl is TextBox))
                    {
                        continue;
                    }

                    int acId = (int)((TextBox)plCtrl).Tag;
                    UserAppraisals ua = userAppraisals.Find(m => m.CoefficientId == acId);
                    ((TextBox)plCtrl).Text = ua?.Count.ToString();
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var flCtrls = flp.Controls;
            foreach (Control flCtrl in flCtrls)
            {
                if (!(flCtrl is Panel))
                {
                    continue;
                }

                var plCtrls = flCtrl.Controls;
                foreach (Control plCtrl in plCtrls)
                {
                    if (!(plCtrl is TextBox) || ((TextBox)plCtrl).Text == "")
                    {
                        continue;
                    }

                    int acId = (int)((TextBox)plCtrl).Tag;
                    double cnt = Convert.ToDouble(((TextBox)plCtrl).Text);

                    UserAppraisals.Delete(userId, year, acId);
                    UserAppraisals userApp = new UserAppraisals
                    {
                        UserId = userId,
                        CoefficientId = acId,
                        AssessmentYear = Convert.ToInt32(year),
                        Count = cnt,
                        IsSuspended = false
                    };
                    UserAppraisals.Insert(userApp);
                }
            }

            MessageBox.Show("Successfully Saved");
            update();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
