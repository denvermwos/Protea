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
    public partial class frmGroup : Form
    {
        private Group group;
        //private Dictionary<string, GroupAccessItem> GroupsAccessDict;
        public frmGroup()
        {
            InitializeComponent();
            group = new Group("");
            //GroupsAccessDict = GroupAccessItem.GetGroupLessAccessItems();
            PopulateGroupsAccessList();

            
        }
        public frmGroup(Group groupBeingEdited)
        {
            InitializeComponent();
            group = groupBeingEdited;
            txtGroupName.Text = group.GroupName;
            //GroupsAccessDict = GroupAccessItem.GetGroupsAccessItems(group.GroupID);
            PopulateGroupsAccessList();
        }
        private void PopulateGroupsAccessList()
        {
            dgvGroupsAccessItems.Rows.Clear();
            foreach (KeyValuePair<string, GroupAccessItem> pair in group.GroupsAccessDict)
            {
                DataGridViewRow groupaccessrow = new DataGridViewRow();
                groupaccessrow.CreateCells(dgvGroupsAccessItems);
                groupaccessrow.Cells[dgvGroupsAccessItems.Columns["GroupAccessItemsCol"].Index].Value = pair.Key;
                groupaccessrow.Tag = pair.Value;
                if (pair.Value.HasAccess == true)
                {
                    groupaccessrow.DefaultCellStyle.BackColor = Color.Green;
                    groupaccessrow.DefaultCellStyle.ForeColor = Color.White;
                    groupaccessrow.DefaultCellStyle.SelectionBackColor = Color.Green;
                    groupaccessrow.DefaultCellStyle.SelectionForeColor = Color.White;
                }
                else
                {
                    groupaccessrow.DefaultCellStyle.BackColor = Color.White;
                    groupaccessrow.DefaultCellStyle.ForeColor = Color.Black;
                    groupaccessrow.DefaultCellStyle.SelectionBackColor = Color.White;
                    groupaccessrow.DefaultCellStyle.SelectionForeColor = Color.Black;
                }
                dgvGroupsAccessItems.Rows.Add(groupaccessrow);
            }
        }
        public string ValidateAllEntries()
        {
            string errormsg = "";
            if (txtGroupName.Text == "")
            {
                errormsg = "\nYou are required to fill in all fields";
            }
            if (!Group.GroupNameAvailable(group))
            {
                errormsg += "\nGroup name \"" + txtGroupName.Text + "\" is already in use";
            }

            return errormsg;
        }

        private void btnSaveGroup_Click(object sender, EventArgs e)
        {
            if (ValidateAllEntries() == "")
            {
                group.Save();
                
                //GroupAccessItem.SaveDictionary(GroupsAccessDict,group.GroupID);
                
                this.Close();
            }
            else
            {

                MessageBox.Show(ValidateAllEntries());
            }
        }

        private void txtGroupName_TextChanged(object sender, EventArgs e)
        {
            group.GroupName = txtGroupName.Text;
        }

        private void btnSetAccess_Click(object sender, EventArgs e)
        {
            

        }

        private void dgvGroupsAccessItems_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            group.GroupsAccessDict[dgvGroupsAccessItems.SelectedRows[0].Cells[0].Value.ToString()].HasAccess = !((GroupAccessItem)(dgvGroupsAccessItems.SelectedRows[0].Tag)).HasAccess;
            PopulateGroupsAccessList();
        }

        
    }
}
