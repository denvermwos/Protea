namespace Protea
{
    partial class frmDeliveries
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
            this.dataGridViewReturnedDeliveries = new System.Windows.Forms.DataGridView();
            this.ColumnReturnedDeliveryDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnReturnedDeliveryBranch = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dateTimeReturnedDeliveryStartDate = new System.Windows.Forms.DateTimePicker();
            this.btnAddNewDelivery = new System.Windows.Forms.Button();
            this.dataGridViewUnreturnedDeliveries = new System.Windows.Forms.DataGridView();
            this.ColumnUnreturnedDeliveryDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnUnreturnedDeliveryBranch = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewReturnedDeliveries)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewUnreturnedDeliveries)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewReturnedDeliveries
            // 
            this.dataGridViewReturnedDeliveries.AllowUserToAddRows = false;
            this.dataGridViewReturnedDeliveries.AllowUserToDeleteRows = false;
            this.dataGridViewReturnedDeliveries.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridViewReturnedDeliveries.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewReturnedDeliveries.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnReturnedDeliveryDate,
            this.ColumnReturnedDeliveryBranch});
            this.dataGridViewReturnedDeliveries.Location = new System.Drawing.Point(12, 33);
            this.dataGridViewReturnedDeliveries.Name = "dataGridViewReturnedDeliveries";
            this.dataGridViewReturnedDeliveries.ReadOnly = true;
            this.dataGridViewReturnedDeliveries.RowHeadersVisible = false;
            this.dataGridViewReturnedDeliveries.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewReturnedDeliveries.Size = new System.Drawing.Size(319, 347);
            this.dataGridViewReturnedDeliveries.TabIndex = 0;
            this.dataGridViewReturnedDeliveries.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewReturnedDeliveries_CellDoubleClick);
            // 
            // ColumnReturnedDeliveryDate
            // 
            this.ColumnReturnedDeliveryDate.HeaderText = "Delivery Date";
            this.ColumnReturnedDeliveryDate.Name = "ColumnReturnedDeliveryDate";
            this.ColumnReturnedDeliveryDate.ReadOnly = true;
            this.ColumnReturnedDeliveryDate.Width = 96;
            // 
            // ColumnReturnedDeliveryBranch
            // 
            this.ColumnReturnedDeliveryBranch.HeaderText = "Branch";
            this.ColumnReturnedDeliveryBranch.Name = "ColumnReturnedDeliveryBranch";
            this.ColumnReturnedDeliveryBranch.ReadOnly = true;
            this.ColumnReturnedDeliveryBranch.Width = 66;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 386);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(135, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Audit Returned Delivery";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(134, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Returned Deiveries Since :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(427, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(123, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "All Unreturned Deliveries";
            // 
            // dateTimeReturnedDeliveryStartDate
            // 
            this.dateTimeReturnedDeliveryStartDate.Location = new System.Drawing.Point(153, 11);
            this.dateTimeReturnedDeliveryStartDate.Name = "dateTimeReturnedDeliveryStartDate";
            this.dateTimeReturnedDeliveryStartDate.Size = new System.Drawing.Size(178, 20);
            this.dateTimeReturnedDeliveryStartDate.TabIndex = 5;
            this.dateTimeReturnedDeliveryStartDate.ValueChanged += new System.EventHandler(this.dateTimeReturnedDeliveryStartDate_ValueChanged);
            // 
            // btnAddNewDelivery
            // 
            this.btnAddNewDelivery.Location = new System.Drawing.Point(430, 386);
            this.btnAddNewDelivery.Name = "btnAddNewDelivery";
            this.btnAddNewDelivery.Size = new System.Drawing.Size(135, 23);
            this.btnAddNewDelivery.TabIndex = 6;
            this.btnAddNewDelivery.Text = "Add New Delivery";
            this.btnAddNewDelivery.UseVisualStyleBackColor = true;
            // 
            // dataGridViewUnreturnedDeliveries
            // 
            this.dataGridViewUnreturnedDeliveries.AllowUserToAddRows = false;
            this.dataGridViewUnreturnedDeliveries.AllowUserToDeleteRows = false;
            this.dataGridViewUnreturnedDeliveries.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridViewUnreturnedDeliveries.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewUnreturnedDeliveries.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnUnreturnedDeliveryDate,
            this.ColumnUnreturnedDeliveryBranch});
            this.dataGridViewUnreturnedDeliveries.Location = new System.Drawing.Point(430, 33);
            this.dataGridViewUnreturnedDeliveries.Name = "dataGridViewUnreturnedDeliveries";
            this.dataGridViewUnreturnedDeliveries.ReadOnly = true;
            this.dataGridViewUnreturnedDeliveries.RowHeadersVisible = false;
            this.dataGridViewUnreturnedDeliveries.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewUnreturnedDeliveries.Size = new System.Drawing.Size(319, 347);
            this.dataGridViewUnreturnedDeliveries.TabIndex = 7;
            this.dataGridViewUnreturnedDeliveries.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewUnreturnedDeliveries_CellDoubleClick);
            // 
            // ColumnUnreturnedDeliveryDate
            // 
            this.ColumnUnreturnedDeliveryDate.HeaderText = "Delivery Date";
            this.ColumnUnreturnedDeliveryDate.Name = "ColumnUnreturnedDeliveryDate";
            this.ColumnUnreturnedDeliveryDate.ReadOnly = true;
            this.ColumnUnreturnedDeliveryDate.Width = 96;
            // 
            // ColumnUnreturnedDeliveryBranch
            // 
            this.ColumnUnreturnedDeliveryBranch.HeaderText = "Branch";
            this.ColumnUnreturnedDeliveryBranch.Name = "ColumnUnreturnedDeliveryBranch";
            this.ColumnUnreturnedDeliveryBranch.ReadOnly = true;
            this.ColumnUnreturnedDeliveryBranch.Width = 66;
            // 
            // frmDeliveries
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(876, 475);
            this.Controls.Add(this.dataGridViewUnreturnedDeliveries);
            this.Controls.Add(this.btnAddNewDelivery);
            this.Controls.Add(this.dateTimeReturnedDeliveryStartDate);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridViewReturnedDeliveries);
            this.Name = "frmDeliveries";
            this.Text = "Deliveries";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewReturnedDeliveries)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewUnreturnedDeliveries)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewReturnedDeliveries;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dateTimeReturnedDeliveryStartDate;
        private System.Windows.Forms.Button btnAddNewDelivery;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnReturnedDeliveryDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnReturnedDeliveryBranch;
        private System.Windows.Forms.DataGridView dataGridViewUnreturnedDeliveries;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnUnreturnedDeliveryDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnUnreturnedDeliveryBranch;
    }
}