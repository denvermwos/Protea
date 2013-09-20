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
    public partial class frmUsers : Form
    {
        public User frmUsersUser;
        public frmUsers()
        {
            InitializeComponent();
            PopulateUserList();
            

        }

        private void btnRefreshUsers_Click(object sender, EventArgs e)
        {

            PopulateUserList();
        }
        private void PopulateUserList()
        {
            dgvUsers.Rows.Clear();
            List<User> users = User.GetUsers();
            
            for (int i = 0; i < users.Count(); i++)
            {
                User tempuser = users.ToList()[i];
                DataGridViewRow userrow = new DataGridViewRow();
                userrow.CreateCells(dgvUsers);

                userrow.Cells[dgvUsers.Columns["StaffNo"].Index].Value = tempuser.StaffNo.ToString();

                userrow.Cells[dgvUsers.Columns["FirstName"].Index].Value = tempuser.FName;

                userrow.Cells[dgvUsers.Columns["LastName"].Index].Value = tempuser.LName;

                userrow.Cells[dgvUsers.Columns["Branch"].Index].Value = tempuser.UserBranch.BranchName;

                userrow.Cells[dgvUsers.Columns["Group"].Index].Value = tempuser.UserGroup.GroupName;

                userrow.Cells[dgvUsers.Columns["Login"].Index].Value = tempuser.Username;

                userrow.Tag = tempuser;

                dgvUsers.Rows.Add(userrow);
            }
        }

        private void dgvUsers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvUsers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dgvUsers_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            frmUser user = new frmUser((User)(dgvUsers.SelectedRows[0].Tag));
            user.ShowDialog();
            PopulateUserList();
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            frmUser user = new frmUser();
            user.ShowDialog();
            PopulateUserList();
        }

        private void btnExitAllUsers_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
