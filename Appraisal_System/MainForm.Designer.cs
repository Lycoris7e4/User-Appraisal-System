﻿namespace Appraisal_System
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("UserManager");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("BaseManager");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("CoefficientManager");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("UserAppraisal");
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.trvMenu = new System.Windows.Forms.TreeView();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.trvMenu);
            this.splitContainer1.Size = new System.Drawing.Size(1310, 718);
            this.splitContainer1.SplitterDistance = 323;
            this.splitContainer1.TabIndex = 0;
            // 
            // trvMenu
            // 
            this.trvMenu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.trvMenu.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.trvMenu.FullRowSelect = true;
            this.trvMenu.ItemHeight = 60;
            this.trvMenu.Location = new System.Drawing.Point(0, 0);
            this.trvMenu.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.trvMenu.Name = "trvMenu";
            treeNode1.Name = "tnUserManager";
            treeNode1.Tag = "UserManagerForm";
            treeNode1.Text = "UserManager";
            treeNode2.Name = "tnBaseManager";
            treeNode2.Tag = "BaseManagerForm";
            treeNode2.Text = "BaseManager";
            treeNode3.Name = "tnCoefficientManager";
            treeNode3.Tag = "";
            treeNode3.Text = "CoefficientManager";
            treeNode4.Name = "tnUserAppraisal";
            treeNode4.Tag = "UserAppraisalForm";
            treeNode4.Text = "UserAppraisal";
            this.trvMenu.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2,
            treeNode3,
            treeNode4});
            this.trvMenu.ShowLines = false;
            this.trvMenu.Size = new System.Drawing.Size(323, 718);
            this.trvMenu.TabIndex = 0;
            this.trvMenu.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.trvMenu_AfterSelect);
            // 
            // MainForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1310, 718);
            this.Controls.Add(this.splitContainer1);
            this.IsMdiContainer = true;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "MainForm";
            this.Text = "User Appraisal System";
            this.splitContainer1.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TreeView trvMenu;
    }
}

