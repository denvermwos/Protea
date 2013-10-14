namespace Protea
{
    partial class frmTransactions
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
            this.btnAddTransaction = new System.Windows.Forms.Button();
            this.btnExitTransaction = new System.Windows.Forms.Button();
            this.dgvTransactions = new System.Windows.Forms.DataGridView();
            this.TransDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PBranch = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.PUser = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTransactions)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAddTransaction
            // 
            this.btnAddTransaction.Location = new System.Drawing.Point(13, 13);
            this.btnAddTransaction.Name = "btnAddTransaction";
            this.btnAddTransaction.Size = new System.Drawing.Size(114, 23);
            this.btnAddTransaction.TabIndex = 0;
            this.btnAddTransaction.Text = "Add Transaction";
            this.btnAddTransaction.UseVisualStyleBackColor = true;
            this.btnAddTransaction.Click += new System.EventHandler(this.btnAddTransaction_Click);
            // 
            // btnExitTransaction
            // 
            this.btnExitTransaction.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnExitTransaction.Location = new System.Drawing.Point(359, 14);
            this.btnExitTransaction.Name = "btnExitTransaction";
            this.btnExitTransaction.Size = new System.Drawing.Size(75, 23);
            this.btnExitTransaction.TabIndex = 1;
            this.btnExitTransaction.Text = "Exit";
            this.btnExitTransaction.UseVisualStyleBackColor = true;
            // 
            // dgvTransactions
            // 
            this.dgvTransactions.AllowUserToAddRows = false;
            this.dgvTransactions.AllowUserToDeleteRows = false;
            this.dgvTransactions.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvTransactions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTransactions.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.TransDescription,
            this.PBranch,
            this.PUser});
            this.dgvTransactions.Location = new System.Drawing.Point(13, 43);
            this.dgvTransactions.MultiSelect = false;
            this.dgvTransactions.Name = "dgvTransactions";
            this.dgvTransactions.ReadOnly = true;
            this.dgvTransactions.RowHeadersVisible = false;
            this.dgvTransactions.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTransactions.Size = new System.Drawing.Size(421, 207);
            this.dgvTransactions.TabIndex = 2;
            this.dgvTransactions.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTransactions_CellContentClick);
            this.dgvTransactions.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTransactions_CellDoubleClick);
            // 
            // TransDescription
            // 
            this.TransDescription.HeaderText = "Description";
            this.TransDescription.Name = "TransDescription";
            this.TransDescription.ReadOnly = true;
            this.TransDescription.Width = 85;
            // 
            // PBranch
            // 
            this.PBranch.HeaderText = "PBranch";
            this.PBranch.Name = "PBranch";
            this.PBranch.ReadOnly = true;
            this.PBranch.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.PBranch.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.PBranch.Width = 73;
            // 
            // PUser
            // 
            this.PUser.HeaderText = "PUser";
            this.PUser.Name = "PUser";
            this.PUser.ReadOnly = true;
            this.PUser.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.PUser.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.PUser.Width = 61;
            // 
            // frmTransactions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnExitTransaction;
            this.ClientSize = new System.Drawing.Size(446, 262);
            this.Controls.Add(this.dgvTransactions);
            this.Controls.Add(this.btnExitTransaction);
            this.Controls.Add(this.btnAddTransaction);
            this.Name = "frmTransactions";
            this.Text = "All Transactions";
            ((System.ComponentModel.ISupportInitialize)(this.dgvTransactions)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnAddTransaction;
        private System.Windows.Forms.Button btnExitTransaction;
        private System.Windows.Forms.DataGridView dgvTransactions;
        private System.Windows.Forms.DataGridViewTextBoxColumn TransDescription;
        private System.Windows.Forms.DataGridViewCheckBoxColumn PBranch;
        private System.Windows.Forms.DataGridViewCheckBoxColumn PUser;
    }
}