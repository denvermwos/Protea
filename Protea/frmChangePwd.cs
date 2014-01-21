using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Protea
{

    public partial class frmChangePwd : Form
    {
        public User ChangePwdUser;
        public frmChangePwd()
        {
            InitializeComponent();
        }
        public frmChangePwd(User user)
        {
            ChangePwdUser = user;
            InitializeComponent();
        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            if (txtPassword.Text == "")
            {
                MessageBox.Show("Password cannot be blank");
            }
            else if (txtPassword.Text != txtConfirmPassword.Text)
            {
                MessageBox.Show("Password and confirmed password do not match");
            }
            else if (txtPassword.Text == txtConfirmPassword.Text)
            {
                ChangePwdUser.ChangePassword(txtPassword.Text);
                //ChangePwdUser = User.GetUserByID(ChangePwdUser.UserID);//updates the user instance
                //MessageBox.Show("Password has been changed.");
                this.DialogResult = DialogResult.OK;

            }
        }
    }
}
