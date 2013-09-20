namespace Protea
{
    partial class frmBranches
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
            this.btnAddBranch = new System.Windows.Forms.Button();
            this.btnExitBranches = new System.Windows.Forms.Button();
            this.dgvBranches = new System.Windows.Forms.DataGridView();
            this.BranchName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBranches)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAddBranch
            // 
            this.btnAddBranch.Location = new System.Drawing.Point(13, 13);
            this.btnAddBranch.Name = "btnAddBranch";
            this.btnAddBranch.Size = new System.Drawing.Size(75, 23);
            this.btnAddBranch.TabIndex = 0;
            this.btnAddBranch.Text = "Add Branch";
            this.btnAddBranch.UseVisualStyleBackColor = true;
            this.btnAddBranch.Click += new System.EventHandler(this.btnAddBranch_Click);
            // 
            // btnExitBranches
            // 
            this.btnExitBranches.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExitBranches.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnExitBranches.Location = new System.Drawing.Point(197, 13);
            this.btnExitBranches.Name = "btnExitBranches";
            this.btnExitBranches.Size = new System.Drawing.Size(75, 23);
            this.btnExitBranches.TabIndex = 1;
            this.btnExitBranches.Text = "Exit";
            this.btnExitBranches.UseVisualStyleBackColor = true;
            // 
            // dgvBranches
            // 
            this.dgvBranches.AllowUserToAddRows = false;
            this.dgvBranches.AllowUserToDeleteRows = false;
            this.dgvBranches.AllowUserToResizeColumns = false;
            this.dgvBranches.AllowUserToResizeRows = false;
            this.dgvBranches.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvBranches.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBranches.ColumnHeadersVisible = false;
            this.dgvBranches.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.BranchName});
            this.dgvBranches.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvBranches.Location = new System.Drawing.Point(13, 43);
            this.dgvBranches.MultiSelect = false;
            this.dgvBranches.Name = "dgvBranches";
            this.dgvBranches.ReadOnly = true;
            this.dgvBranches.RowHeadersVisible = false;
            this.dgvBranches.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvBranches.Size = new System.Drawing.Size(259, 219);
            this.dgvBranches.TabIndex = 2;
            this.dgvBranches.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvBranches_CellDoubleClick);
            // 
            // BranchName
            // 
            this.BranchName.HeaderText = "";
            this.BranchName.Name = "BranchName";
            this.BranchName.ReadOnly = true;
            // 
            // frmBranches
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnExitBranches;
            this.ClientSize = new System.Drawing.Size(284, 274);
            this.Controls.Add(this.dgvBranches);
            this.Controls.Add(this.btnExitBranches);
            this.Controls.Add(this.btnAddBranch);
            this.MinimumSize = new System.Drawing.Size(300, 312);
            this.Name = "frmBranches";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "All Branches";
            this.Load += new System.EventHandler(this.frmBranches_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBranches)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnAddBranch;
        private System.Windows.Forms.Button btnExitBranches;
        private System.Windows.Forms.DataGridView dgvBranches;
        private System.Windows.Forms.DataGridViewTextBoxColumn BranchName;
    }
}