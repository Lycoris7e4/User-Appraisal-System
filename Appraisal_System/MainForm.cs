using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Appraisal_System
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            UserManagerForm userManagerForm = new UserManagerForm();
            userManagerForm.MdiParent = this;
            userManagerForm.Parent = splitContainer1.Panel2;
            userManagerForm.Dock = DockStyle.Fill;
            userManagerForm.Show();
        }
    }
}
