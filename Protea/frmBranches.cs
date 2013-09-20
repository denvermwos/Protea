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
    public partial class frmBranches : Form
    {
        public frmBranches()
        {
            InitializeComponent();
            PopulateBranchList();
        }

        private void PopulateBranchList()
        {
            dgvBranches.Rows.Clear();
            List<Branch> branches = Branch.GetBranches();

            for (int i = 0; i < branches.Count(); i++)
            {
                Branch tempbranch = branches.ToList()[i];
                DataGridViewRow branchrow = new DataGridViewRow();
                branchrow.CreateCells(dgvBranches);

                branchrow.Cells[dgvBranches.Columns["BranchName"].Index].Value = tempbranch.BranchName;


                branchrow.Tag = tempbranch;

                dgvBranches.Rows.Add(branchrow);
            }
        }
        private void btnAddBranch_Click(object sender, EventArgs e)
        {
            frmBranch branch = new frmBranch();
            branch.ShowDialog();
            PopulateBranchList();
        }

        private void dgvBranches_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            frmBranch branch = new frmBranch((Branch)(dgvBranches.SelectedRows[0].Tag));
            branch.ShowDialog();
            PopulateBranchList();
        }

        private void frmBranches_Load(object sender, EventArgs e)
        {

        }

        
    }
}
