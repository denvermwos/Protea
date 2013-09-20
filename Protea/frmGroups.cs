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
    public partial class frmGroups : Form
    {
        public frmGroups()
        {
            InitializeComponent();
            PopulateGroupsList();
        }

        private void btnAddGroup_Click(object sender, EventArgs e)
        {
            frmGroup group = new frmGroup();
            group.ShowDialog();
            PopulateGroupsList();
        }
        private void PopulateGroupsList()
        {
            dgvGroups.Rows.Clear();
            List<Group> groups = Group.GetGroups();

            for (int i = 0; i < groups.Count(); i++)
            {
                Group tempgroup = groups.ToList()[i];
                DataGridViewRow userrow = new DataGridViewRow();
                userrow.CreateCells(dgvGroups);

                userrow.Cells[dgvGroups.Columns["GroupNameCol"].Index].Value = tempgroup.GroupName;


                userrow.Tag = tempgroup;

                dgvGroups.Rows.Add(userrow);
            }
        }

        private void dgvGroups_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvGroups_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            frmGroup group = new frmGroup((Group)(dgvGroups.SelectedRows[0].Tag));
            group.ShowDialog();
            PopulateGroupsList();
        }
    }
}
