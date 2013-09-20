namespace Protea
{
    partial class frmGroup
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
            this.txtGroupName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSaveGroup = new System.Windows.Forms.Button();
            this.btnCancelGroup = new System.Windows.Forms.Button();
            this.dgvGroupsAccessItems = new System.Windows.Forms.DataGridView();
            this.GroupAccessItemsCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGroupsAccessItems)).BeginInit();
            this.SuspendLayout();
            // 
            // txtGroupName
            // 
            this.txtGroupName.Location = new System.Drawing.Point(54, 12);
            this.txtGroupName.Name = "txtGroupName";
            this.txtGroupName.Size = new System.Drawing.Size(218, 20);
            this.txtGroupName.TabIndex = 0;
            this.txtGroupName.TextChanged += new System.EventHandler(this.txtGroupName_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Name";
            // 
            // btnSaveGroup
            // 
            this.btnSaveGroup.Location = new System.Drawing.Point(54, 284);
            this.btnSaveGroup.Name = "btnSaveGroup";
            this.btnSaveGroup.Size = new System.Drawing.Size(75, 23);
            this.btnSaveGroup.TabIndex = 2;
            this.btnSaveGroup.Text = "Save";
            this.btnSaveGroup.UseVisualStyleBackColor = true;
            this.btnSaveGroup.Click += new System.EventHandler(this.btnSaveGroup_Click);
            // 
            // btnCancelGroup
            // 
            this.btnCancelGroup.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelGroup.Location = new System.Drawing.Point(163, 284);
            this.btnCancelGroup.Name = "btnCancelGroup";
            this.btnCancelGroup.Size = new System.Drawing.Size(75, 23);
            this.btnCancelGroup.TabIndex = 3;
            this.btnCancelGroup.Text = "Cancel";
            this.btnCancelGroup.UseVisualStyleBackColor = true;
            // 
            // dgvGroupsAccessItems
            // 
            this.dgvGroupsAccessItems.AllowUserToAddRows = false;
            this.dgvGroupsAccessItems.AllowUserToDeleteRows = false;
            this.dgvGroupsAccessItems.AllowUserToOrderColumns = true;
            this.dgvGroupsAccessItems.AllowUserToResizeColumns = false;
            this.dgvGroupsAccessItems.AllowUserToResizeRows = false;
            this.dgvGroupsAccessItems.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvGroupsAccessItems.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvGroupsAccessItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGroupsAccessItems.ColumnHeadersVisible = false;
            this.dgvGroupsAccessItems.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.GroupAccessItemsCol});
            this.dgvGroupsAccessItems.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvGroupsAccessItems.Location = new System.Drawing.Point(26, 62);
            this.dgvGroupsAccessItems.Name = "dgvGroupsAccessItems";
            this.dgvGroupsAccessItems.RowHeadersVisible = false;
            this.dgvGroupsAccessItems.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvGroupsAccessItems.Size = new System.Drawing.Size(232, 194);
            this.dgvGroupsAccessItems.TabIndex = 5;
            this.dgvGroupsAccessItems.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvGroupsAccessItems_CellClick);
            // 
            // GroupAccessItemsCol
            // 
            this.GroupAccessItemsCol.HeaderText = "GroupAccessItemsCol";
            this.GroupAccessItemsCol.Name = "GroupAccessItemsCol";
            this.GroupAccessItemsCol.Width = 5;
            // 
            // frmGroup
            // 
            this.AcceptButton = this.btnSaveGroup;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancelGroup;
            this.ClientSize = new System.Drawing.Size(284, 319);
            this.Controls.Add(this.dgvGroupsAccessItems);
            this.Controls.Add(this.btnCancelGroup);
            this.Controls.Add(this.btnSaveGroup);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtGroupName);
            this.Name = "frmGroup";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Group";
            ((System.ComponentModel.ISupportInitialize)(this.dgvGroupsAccessItems)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtGroupName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSaveGroup;
        private System.Windows.Forms.Button btnCancelGroup;
        private System.Windows.Forms.DataGridView dgvGroupsAccessItems;
        private System.Windows.Forms.DataGridViewTextBoxColumn GroupAccessItemsCol;
    }
}