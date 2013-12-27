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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.button2 = new System.Windows.Forms.Button();
            this.ColumnReturnedDeliveryDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnReturnedDeliveryBranch = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.ColumnUnreturnedDeliveryDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnUnreturnedDeliveryBranch = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnReturnedDeliveryDate,
            this.ColumnReturnedDeliveryBranch});
            this.dataGridView1.Location = new System.Drawing.Point(12, 33);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.Size = new System.Drawing.Size(319, 347);
            this.dataGridView1.TabIndex = 0;
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
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(153, 11);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(178, 20);
            this.dateTimePicker1.TabIndex = 5;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(430, 386);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(135, 23);
            this.button2.TabIndex = 6;
            this.button2.Text = "Add New Delivery";
            this.button2.UseVisualStyleBackColor = true;
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
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.AllowUserToDeleteRows = false;
            this.dataGridView2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnUnreturnedDeliveryDate,
            this.ColumnUnreturnedDeliveryBranch});
            this.dataGridView2.Location = new System.Drawing.Point(430, 33);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.ReadOnly = true;
            this.dataGridView2.RowHeadersVisible = false;
            this.dataGridView2.Size = new System.Drawing.Size(319, 347);
            this.dataGridView2.TabIndex = 7;
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
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "frmDeliveries";
            this.Text = "Deliveries";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnReturnedDeliveryDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnReturnedDeliveryBranch;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnUnreturnedDeliveryDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnUnreturnedDeliveryBranch;
    }
}