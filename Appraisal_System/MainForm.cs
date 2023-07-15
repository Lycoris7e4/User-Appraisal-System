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

        private void trvMenu_AfterSelect(object sender, TreeViewEventArgs e)
        {
            foreach (TreeNode node in trvMenu.Nodes)
            {
                node.BackColor = Color.White;
                node.ForeColor = Color.Black;
            }
            e.Node.BackColor = SystemColors.Highlight;
            e.Node.ForeColor = Color.White;
        }
    }
}
