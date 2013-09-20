namespace Protea
{
    partial class frmUser
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
            this.btnSaveUser = new System.Windows.Forms.Button();
            this.btnCancelUser = new System.Windows.Forms.Button();
            this.txtFName = new System.Windows.Forms.TextBox();
            this.txtLName = new System.Windows.Forms.TextBox();
            this.txtStaffNo = new System.Windows.Forms.TextBox();
            this.txtNewPassword = new System.Windows.Forms.TextBox();
            this.txtConfirmNewPassword = new System.Windows.Forms.TextBox();
            this.chkbxChangePassword = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblPasswordChangeError = new System.Windows.Forms.Label();
            this.chkbxChangeAtNextLogin = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cboxUserGroup = new System.Windows.Forms.ComboBox();
            this.cboxUserBranch = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtLogin = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSaveUser
            // 
            this.btnSaveUser.Location = new System.Drawing.Point(183, 334);
            this.btnSaveUser.Name = "btnSaveUser";
            this.btnSaveUser.Size = new System.Drawing.Size(75, 23);
            this.btnSaveUser.TabIndex = 11;
            this.btnSaveUser.Text = "Save";
            this.btnSaveUser.UseVisualStyleBackColor = true;
            this.btnSaveUser.Click += new System.EventHandler(this.btnSaveUser_Click);
            // 
            // btnCancelUser
            // 
            this.btnCancelUser.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelUser.Location = new System.Drawing.Point(264, 334);
            this.btnCancelUser.Name = "btnCancelUser";
            this.btnCancelUser.Size = new System.Drawing.Size(75, 23);
            this.btnCancelUser.TabIndex = 12;
            this.btnCancelUser.Text = "Cancel";
            this.btnCancelUser.UseVisualStyleBackColor = true;
            this.btnCancelUser.Click += new System.EventHandler(this.btnCancelUser_Click);
            // 
            // txtFName
            // 
            this.txtFName.Location = new System.Drawing.Point(101, 13);
            this.txtFName.Name = "txtFName";
            this.txtFName.Size = new System.Drawing.Size(392, 20);
            this.txtFName.TabIndex = 1;
            this.txtFName.TextChanged += new System.EventHandler(this.txtFName_TextChanged);
            // 
            // txtLName
            // 
            this.txtLName.Location = new System.Drawing.Point(101, 40);
            this.txtLName.Name = "txtLName";
            this.txtLName.Size = new System.Drawing.Size(392, 20);
            this.txtLName.TabIndex = 2;
            this.txtLName.TextChanged += new System.EventHandler(this.txtLName_TextChanged);
            // 
            // txtStaffNo
            // 
            this.txtStaffNo.Location = new System.Drawing.Point(101, 67);
            this.txtStaffNo.Name = "txtStaffNo";
            this.txtStaffNo.Size = new System.Drawing.Size(121, 20);
            this.txtStaffNo.TabIndex = 3;
            this.txtStaffNo.TextChanged += new System.EventHandler(this.txtStaffNo_TextChanged);
            // 
            // txtNewPassword
            // 
            this.txtNewPassword.Enabled = false;
            this.txtNewPassword.Location = new System.Drawing.Point(129, 64);
            this.txtNewPassword.Name = "txtNewPassword";
            this.txtNewPassword.PasswordChar = '●';
            this.txtNewPassword.Size = new System.Drawing.Size(357, 20);
            this.txtNewPassword.TabIndex = 9;
            this.txtNewPassword.TextChanged += new System.EventHandler(this.txtNewPassword_TextChanged);
            // 
            // txtConfirmNewPassword
            // 
            this.txtConfirmNewPassword.Enabled = false;
            this.txtConfirmNewPassword.Location = new System.Drawing.Point(129, 91);
            this.txtConfirmNewPassword.Name = "txtConfirmNewPassword";
            this.txtConfirmNewPassword.PasswordChar = '●';
            this.txtConfirmNewPassword.Size = new System.Drawing.Size(357, 20);
            this.txtConfirmNewPassword.TabIndex = 10;
            this.txtConfirmNewPassword.TextChanged += new System.EventHandler(this.txtConfirmNewPassword_TextChanged);
            // 
            // chkbxChangePassword
            // 
            this.chkbxChangePassword.AutoSize = true;
            this.chkbxChangePassword.Location = new System.Drawing.Point(6, 19);
            this.chkbxChangePassword.Name = "chkbxChangePassword";
            this.chkbxChangePassword.Size = new System.Drawing.Size(112, 17);
            this.chkbxChangePassword.TabIndex = 7;
            this.chkbxChangePassword.Text = "Change Password";
            this.chkbxChangePassword.UseVisualStyleBackColor = true;
            this.chkbxChangePassword.CheckedChanged += new System.EventHandler(this.chkbxChangePassword_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblPasswordChangeError);
            this.groupBox1.Controls.Add(this.chkbxChangeAtNextLogin);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtNewPassword);
            this.groupBox1.Controls.Add(this.chkbxChangePassword);
            this.groupBox1.Controls.Add(this.txtConfirmNewPassword);
            this.groupBox1.Location = new System.Drawing.Point(7, 193);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(492, 135);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Password";
            // 
            // lblPasswordChangeError
            // 
            this.lblPasswordChangeError.AutoSize = true;
            this.lblPasswordChangeError.ForeColor = System.Drawing.Color.Red;
            this.lblPasswordChangeError.Location = new System.Drawing.Point(129, 118);
            this.lblPasswordChangeError.Name = "lblPasswordChangeError";
            this.lblPasswordChangeError.Size = new System.Drawing.Size(0, 13);
            this.lblPasswordChangeError.TabIndex = 12;
            // 
            // chkbxChangeAtNextLogin
            // 
            this.chkbxChangeAtNextLogin.AutoSize = true;
            this.chkbxChangeAtNextLogin.Location = new System.Drawing.Point(314, 19);
            this.chkbxChangeAtNextLogin.Name = "chkbxChangeAtNextLogin";
            this.chkbxChangeAtNextLogin.Size = new System.Drawing.Size(172, 17);
            this.chkbxChangeAtNextLogin.TabIndex = 8;
            this.chkbxChangeAtNextLogin.Text = "User must change at next login";
            this.chkbxChangeAtNextLogin.UseVisualStyleBackColor = true;
            this.chkbxChangeAtNextLogin.CheckedChanged += new System.EventHandler(this.chkbxChangeAtNextLogin_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 94);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(116, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Confirm New Password";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 67);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "New Password";
            // 
            // cboxUserGroup
            // 
            this.cboxUserGroup.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxUserGroup.FormattingEnabled = true;
            this.cboxUserGroup.Location = new System.Drawing.Point(101, 118);
            this.cboxUserGroup.Name = "cboxUserGroup";
            this.cboxUserGroup.Size = new System.Drawing.Size(121, 21);
            this.cboxUserGroup.TabIndex = 5;
            this.cboxUserGroup.SelectedIndexChanged += new System.EventHandler(this.cboxUserGroup_SelectedIndexChanged);
            // 
            // cboxUserBranch
            // 
            this.cboxUserBranch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxUserBranch.FormattingEnabled = true;
            this.cboxUserBranch.Location = new System.Drawing.Point(101, 156);
            this.cboxUserBranch.Name = "cboxUserBranch";
            this.cboxUserBranch.Size = new System.Drawing.Size(121, 21);
            this.cboxUserBranch.TabIndex = 6;
            this.cboxUserBranch.SelectedIndexChanged += new System.EventHandler(this.cboxUserBranch_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "First Names";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 43);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Last Name";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(14, 70);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "Staff No.";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(14, 121);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(36, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "Group";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(14, 159);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 13);
            this.label7.TabIndex = 15;
            this.label7.Text = "Branch";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(14, 96);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(33, 13);
            this.label8.TabIndex = 17;
            this.label8.Text = "Login";
            // 
            // txtLogin
            // 
            this.txtLogin.Location = new System.Drawing.Point(101, 93);
            this.txtLogin.Name = "txtLogin";
            this.txtLogin.Size = new System.Drawing.Size(121, 20);
            this.txtLogin.TabIndex = 4;
            this.txtLogin.TextChanged += new System.EventHandler(this.txtLogin_TextChanged);
            // 
            // frmUser
            // 
            this.AcceptButton = this.btnSaveUser;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancelUser;
            this.ClientSize = new System.Drawing.Size(511, 369);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtLogin);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cboxUserBranch);
            this.Controls.Add(this.cboxUserGroup);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txtStaffNo);
            this.Controls.Add(this.txtLName);
            this.Controls.Add(this.txtFName);
            this.Controls.Add(this.btnCancelUser);
            this.Controls.Add(this.btnSaveUser);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(527, 407);
            this.MinimumSize = new System.Drawing.Size(527, 407);
            this.Name = "frmUser";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "User";
            this.Load += new System.EventHandler(this.frmUser_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSaveUser;
        private System.Windows.Forms.Button btnCancelUser;
        private System.Windows.Forms.TextBox txtFName;
        private System.Windows.Forms.TextBox txtLName;
        private System.Windows.Forms.TextBox txtStaffNo;
        private System.Windows.Forms.TextBox txtNewPassword;
        private System.Windows.Forms.TextBox txtConfirmNewPassword;
        private System.Windows.Forms.CheckBox chkbxChangePassword;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboxUserGroup;
        private System.Windows.Forms.ComboBox cboxUserBranch;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckBox chkbxChangeAtNextLogin;
        private System.Windows.Forms.Label lblPasswordChangeError;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtLogin;
    }
}