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
    public partial class frmUser : Form
    {
        public User user;
        public bool userIsNew;
        public frmUser()
        {
            InitializeComponent();
            userIsNew = true;

            user = new User(0, "", "", "", "", null, null, false);
            PopulateUserBranchCombobox();
            PopulateUserGroupCombobox();
            cboxUserGroup.SelectedIndex = 0;
            cboxUserBranch.SelectedIndex = 0;
            chkbxChangePassword.Checked = true;
            chkbxChangePassword.Visible = false;
            chkbxChangeAtNextLogin.Checked = true;
        }

        public frmUser(User userBeingEdited)
        {
            InitializeComponent();
            userIsNew = false;
            user = userBeingEdited;

            txtFName.Text = user.FName;
            txtLName.Text = user.LName;
            txtLogin.Text = user.Username;
            txtStaffNo.Text = user.StaffNo.ToString();

            chkbxChangeAtNextLogin.Checked = user.ChangePwd;
            
            PopulateUserBranchCombobox();
            PopulateUserGroupCombobox();

        }

        private void PopulateUserBranchCombobox()
        {


            cboxUserBranch.Items.Clear();
            List<Branch> branches = Branch.GetBranches();
            for (int i = 0; i < branches.Count(); i++)
            {
                Branch tempuser = branches.ToList()[i];
                cboxUserBranch.Items.Add(tempuser);
            }
            if (user.UserBranch != null)
            {
                selectItemInCboxUserBranch(user.UserBranch);
            }
        }
        private void PopulateUserGroupCombobox()
        {


            cboxUserGroup.Items.Clear();
            List<Group> groups = Group.GetGroups();
            for (int i = 0; i < groups.Count(); i++)
            {
                Group tempgroup = groups.ToList()[i];
                cboxUserGroup.Items.Add(tempgroup);
            }
            if (user.UserGroup != null)
            {
                selectItemInCboxUserGroup(user.UserGroup);
            }
        }
        private void selectItemInCboxUserBranch(Branch branchToSelect)
        {
            for (int i = 0; i < cboxUserBranch.Items.Count; i++)
            {
                if (((Branch)(cboxUserBranch.Items[i])).BranchID == branchToSelect.BranchID)
                {
                    cboxUserBranch.SelectedIndex = i;
                }
            }
        }
        private void selectItemInCboxUserGroup(Group groupToSelect)
        {
            for (int i = 0; i < cboxUserGroup.Items.Count; i++)
            {
                if (((Group)(cboxUserGroup.Items[i])).GroupID == groupToSelect.GroupID)
                {
                    cboxUserGroup.SelectedIndex = i;
                }
            }
        }
        

        private void btnSaveUser_Click(object sender, EventArgs e)
        {
            if (ValidateAllEntries() == "")

            {
                //form validated ok so we can set password if we need to, had to do this here
                //in case user checked ,entered a new password,and then unchecked the change password box...
                //wouldnt work just to assign text to userpassword on textchanged like others
                if (chkbxChangePassword.Checked == true)
                {
                    user.UserPassword = txtNewPassword.Text;
                }
                user.Save();
                this.Close();
            }
            else
            {
                
                MessageBox.Show(ValidateAllEntries());
            }
            
        }

        private void frmUser_Load(object sender, EventArgs e)
        {

        }

        private void chkbxChangePassword_CheckedChanged(object sender, EventArgs e)
        {
            if (chkbxChangePassword.Checked == false)
            {
                txtNewPassword.Enabled = false;
                txtConfirmNewPassword.Enabled = false;
            }
            else
            {
                txtNewPassword.Enabled = true;
                txtConfirmNewPassword.Enabled = true;
            }
        }

        private void txtFName_TextChanged(object sender, EventArgs e)
        {
            user.FName = txtFName.Text;
        }

        private void txtLName_TextChanged(object sender, EventArgs e)
        {
            user.LName = txtLName.Text;
        }

        private void txtStaffNo_TextChanged(object sender, EventArgs e)
        {
            try
            {
                user.StaffNo = Convert.ToInt32(txtStaffNo.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }

        private void cboxUserGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            user.UserGroup = ((Group)(cboxUserGroup.SelectedItem));
        }

        private void cboxUserBranch_SelectedIndexChanged(object sender, EventArgs e)
        {
            user.UserBranch = ((Branch)(cboxUserBranch.SelectedItem));
        }

        private void chkbxChangeAtNextLogin_CheckedChanged(object sender, EventArgs e)
        {
            user.ChangePwd = chkbxChangeAtNextLogin.Checked;
        }

        private void btnCancelUser_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtNewPassword_TextChanged(object sender, EventArgs e)
        {
            
        }
        

        private void txtConfirmNewPassword_TextChanged(object sender, EventArgs e)
        {
            
            
        }
        
        public string ValidateAllEntries()
        {
            string errormsg = "";
            if ((txtFName.Text == "") || (txtLName.Text == "") || (txtStaffNo.Text == "") || (txtLogin.Text == ""))
            {
                errormsg = "\nYou are required to fill in all fields";
            }
            
            int i;
            if ((!int.TryParse(txtStaffNo.Text, out i))&&(txtStaffNo.Text!=""))
            {
                errormsg += "\nStaff No. needs to be a numeric value";
            }
            
            if (!User.UsernameAvailable(user))
            {
                errormsg += "\nLogin name \"" + txtLogin.Text + "\" is already in use by another user";
            }
            if (cboxUserBranch.SelectedIndex == -1)
            {
                errormsg += "\nPlease select a branch for user";
            }
            if (cboxUserGroup.SelectedIndex == -1)
            {
                errormsg += "\nPlease select a group for user";
            }
            if ((txtConfirmNewPassword.Text != txtNewPassword.Text)&& (chkbxChangePassword.Checked == true))
            {
                errormsg += "\nPassword does not match password confirmation";
            }
            else if((txtNewPassword.Text == "")&&(chkbxChangePassword.Checked == true))
            {
                errormsg += "\nPassword cannot be blank";
            }
            return errormsg;
        }
        private void txtLogin_TextChanged(object sender, EventArgs e)
        {
            user.Username = txtLogin.Text;
        }
    }
}
