namespace Protea
{
    partial class frmBranch
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
            this.btnCancelBranch = new System.Windows.Forms.Button();
            this.btnSaveBranch = new System.Windows.Forms.Button();
            this.txtBranchName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblCBBalance = new System.Windows.Forms.Label();
            this.lblDropBalance = new System.Windows.Forms.Label();
            this.txtCBBalance = new System.Windows.Forms.TextBox();
            this.txtDropBalance = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnCancelBranch
            // 
            this.btnCancelBranch.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelBranch.Location = new System.Drawing.Point(146, 104);
            this.btnCancelBranch.Name = "btnCancelBranch";
            this.btnCancelBranch.Size = new System.Drawing.Size(75, 23);
            this.btnCancelBranch.TabIndex = 3;
            this.btnCancelBranch.Text = "Cancel";
            this.btnCancelBranch.UseVisualStyleBackColor = true;
            this.btnCancelBranch.Click += new System.EventHandler(this.btnCancelBranch_Click);
            // 
            // btnSaveBranch
            // 
            this.btnSaveBranch.Location = new System.Drawing.Point(65, 104);
            this.btnSaveBranch.Name = "btnSaveBranch";
            this.btnSaveBranch.Size = new System.Drawing.Size(75, 23);
            this.btnSaveBranch.TabIndex = 2;
            this.btnSaveBranch.Text = "Save";
            this.btnSaveBranch.UseVisualStyleBackColor = true;
            this.btnSaveBranch.Click += new System.EventHandler(this.btnSaveBranch_Click);
            // 
            // txtBranchName
            // 
            this.txtBranchName.Location = new System.Drawing.Point(53, 12);
            this.txtBranchName.Name = "txtBranchName";
            this.txtBranchName.Size = new System.Drawing.Size(219, 20);
            this.txtBranchName.TabIndex = 1;
            this.txtBranchName.TextChanged += new System.EventHandler(this.txtBranchName_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Name";
            // 
            // lblCBBalance
            // 
            this.lblCBBalance.AutoSize = true;
            this.lblCBBalance.Location = new System.Drawing.Point(12, 41);
            this.lblCBBalance.Name = "lblCBBalance";
            this.lblCBBalance.Size = new System.Drawing.Size(97, 13);
            this.lblCBBalance.TabIndex = 6;
            this.lblCBBalance.Text = "Cashbook Balance";
            // 
            // lblDropBalance
            // 
            this.lblDropBalance.AutoSize = true;
            this.lblDropBalance.Location = new System.Drawing.Point(12, 67);
            this.lblDropBalance.Name = "lblDropBalance";
            this.lblDropBalance.Size = new System.Drawing.Size(97, 13);
            this.lblDropBalance.TabIndex = 7;
            this.lblDropBalance.Text = "Drop Safe Balance";
            // 
            // txtCBBalance
            // 
            this.txtCBBalance.Location = new System.Drawing.Point(115, 38);
            this.txtCBBalance.Name = "txtCBBalance";
            this.txtCBBalance.Size = new System.Drawing.Size(157, 20);
            this.txtCBBalance.TabIndex = 8;
            this.txtCBBalance.TextChanged += new System.EventHandler(this.txtCBBalance_TextChanged);
            // 
            // txtDropBalance
            // 
            this.txtDropBalance.Location = new System.Drawing.Point(115, 64);
            this.txtDropBalance.Name = "txtDropBalance";
            this.txtDropBalance.Size = new System.Drawing.Size(157, 20);
            this.txtDropBalance.TabIndex = 9;
            this.txtDropBalance.TextChanged += new System.EventHandler(this.txtDropBalance_TextChanged);
            // 
            // frmBranch
            // 
            this.AcceptButton = this.btnSaveBranch;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancelBranch;
            this.ClientSize = new System.Drawing.Size(284, 139);
            this.Controls.Add(this.txtDropBalance);
            this.Controls.Add(this.txtCBBalance);
            this.Controls.Add(this.lblDropBalance);
            this.Controls.Add(this.lblCBBalance);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtBranchName);
            this.Controls.Add(this.btnCancelBranch);
            this.Controls.Add(this.btnSaveBranch);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmBranch";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Branch";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancelBranch;
        private System.Windows.Forms.Button btnSaveBranch;
        private System.Windows.Forms.TextBox txtBranchName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblCBBalance;
        private System.Windows.Forms.Label lblDropBalance;
        private System.Windows.Forms.TextBox txtCBBalance;
        private System.Windows.Forms.TextBox txtDropBalance;
    }
}