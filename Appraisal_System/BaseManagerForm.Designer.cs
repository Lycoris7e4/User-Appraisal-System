namespace Appraisal_System
{
    partial class BaseManagerForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvBase = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BaseType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AppraisalBase = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IsSuspended = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBase)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvBase
            // 
            this.dgvBase.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgvBase.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBase.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.BaseType,
            this.AppraisalBase,
            this.IsSuspended});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvBase.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgvBase.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvBase.Location = new System.Drawing.Point(0, 0);
            this.dgvBase.Name = "dgvBase";
            this.dgvBase.RowHeadersWidth = 62;
            this.dgvBase.RowTemplate.Height = 28;
            this.dgvBase.Size = new System.Drawing.Size(1292, 770);
            this.dgvBase.TabIndex = 0;
            this.dgvBase.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvBase_CellValueChanged);
            // 
            // Id
            // 
            this.Id.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Id.DataPropertyName = "Id";
            this.Id.HeaderText = "ID";
            this.Id.MinimumWidth = 8;
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            this.Id.Width = 62;
            // 
            // BaseType
            // 
            this.BaseType.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.BaseType.DataPropertyName = "BaseType";
            this.BaseType.HeaderText = "Base Type";
            this.BaseType.MinimumWidth = 8;
            this.BaseType.Name = "BaseType";
            this.BaseType.Width = 120;
            // 
            // AppraisalBase
            // 
            this.AppraisalBase.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.AppraisalBase.DataPropertyName = "AppraisalBase";
            this.AppraisalBase.HeaderText = "Appraisal Base";
            this.AppraisalBase.MinimumWidth = 8;
            this.AppraisalBase.Name = "AppraisalBase";
            this.AppraisalBase.Width = 152;
            // 
            // IsSuspended
            // 
            this.IsSuspended.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.IsSuspended.DataPropertyName = "IsSuspended";
            this.IsSuspended.HeaderText = "Suspended";
            this.IsSuspended.MinimumWidth = 8;
            this.IsSuspended.Name = "IsSuspended";
            this.IsSuspended.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.IsSuspended.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.IsSuspended.Width = 127;
            // 
            // BaseManagerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1292, 770);
            this.Controls.Add(this.dgvBase);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "BaseManagerForm";
            this.Text = "BaseManagerForm";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.BaseManagerForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBase)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvBase;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn BaseType;
        private System.Windows.Forms.DataGridViewTextBoxColumn AppraisalBase;
        private System.Windows.Forms.DataGridViewCheckBoxColumn IsSuspended;
    }
}