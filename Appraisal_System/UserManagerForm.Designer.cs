namespace Appraisal_System
{
    partial class UserManagerForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.gbxFilter = new System.Windows.Forms.GroupBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.cbxSuspended = new System.Windows.Forms.CheckBox();
            this.cbxIdentity = new System.Windows.Forms.ComboBox();
            this.IbIdentity = new System.Windows.Forms.Label();
            this.tbxUserName = new System.Windows.Forms.TextBox();
            this.lbUserName = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.gbxFilter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // gbxFilter
            // 
            this.gbxFilter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbxFilter.Controls.Add(this.btnSearch);
            this.gbxFilter.Controls.Add(this.cbxSuspended);
            this.gbxFilter.Controls.Add(this.cbxIdentity);
            this.gbxFilter.Controls.Add(this.IbIdentity);
            this.gbxFilter.Controls.Add(this.tbxUserName);
            this.gbxFilter.Controls.Add(this.lbUserName);
            this.gbxFilter.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbxFilter.Location = new System.Drawing.Point(12, 12);
            this.gbxFilter.Name = "gbxFilter";
            this.gbxFilter.Size = new System.Drawing.Size(1415, 143);
            this.gbxFilter.TabIndex = 0;
            this.gbxFilter.TabStop = false;
            this.gbxFilter.Text = "Filter";
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearch.Location = new System.Drawing.Point(1275, 59);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(117, 39);
            this.btnSearch.TabIndex = 5;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            // 
            // cbxSuspended
            // 
            this.cbxSuspended.AutoSize = true;
            this.cbxSuspended.Location = new System.Drawing.Point(1023, 63);
            this.cbxSuspended.Name = "cbxSuspended";
            this.cbxSuspended.Size = new System.Drawing.Size(159, 33);
            this.cbxSuspended.TabIndex = 4;
            this.cbxSuspended.Text = "suspended";
            this.cbxSuspended.UseVisualStyleBackColor = true;
            // 
            // cbxIdentity
            // 
            this.cbxIdentity.FormattingEnabled = true;
            this.cbxIdentity.Location = new System.Drawing.Point(443, 61);
            this.cbxIdentity.Name = "cbxIdentity";
            this.cbxIdentity.Size = new System.Drawing.Size(553, 37);
            this.cbxIdentity.TabIndex = 3;
            // 
            // IbIdentity
            // 
            this.IbIdentity.AutoSize = true;
            this.IbIdentity.Location = new System.Drawing.Point(348, 64);
            this.IbIdentity.Name = "IbIdentity";
            this.IbIdentity.Size = new System.Drawing.Size(89, 29);
            this.IbIdentity.TabIndex = 2;
            this.IbIdentity.Text = "Identity";
            // 
            // tbxUserName
            // 
            this.tbxUserName.Location = new System.Drawing.Point(175, 61);
            this.tbxUserName.Name = "tbxUserName";
            this.tbxUserName.Size = new System.Drawing.Size(151, 35);
            this.tbxUserName.TabIndex = 1;
            // 
            // lbUserName
            // 
            this.lbUserName.AutoSize = true;
            this.lbUserName.Location = new System.Drawing.Point(40, 64);
            this.lbUserName.Name = "lbUserName";
            this.lbUserName.Size = new System.Drawing.Size(129, 29);
            this.lbUserName.TabIndex = 0;
            this.lbUserName.Text = "UserName";
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 161);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.RowTemplate.Height = 28;
            this.dataGridView1.Size = new System.Drawing.Size(1415, 775);
            this.dataGridView1.TabIndex = 0;
            // 
            // UserManagerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1439, 948);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.gbxFilter);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "UserManagerForm";
            this.Text = "UserManager";
            this.Load += new System.EventHandler(this.UserManagerForm_Load);
            this.gbxFilter.ResumeLayout(false);
            this.gbxFilter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbxFilter;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label lbUserName;
        private System.Windows.Forms.Label IbIdentity;
        private System.Windows.Forms.TextBox tbxUserName;
        private System.Windows.Forms.ComboBox cbxIdentity;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.CheckBox cbxSuspended;
    }
}