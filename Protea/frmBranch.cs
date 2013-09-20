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
    public partial class frmBranch : Form
    {
        private Branch branch;
        public frmBranch()
        {
            InitializeComponent();
            branch = new Branch("");
            
        }

        public frmBranch(Branch branchBeingEdited)
        {
            InitializeComponent();
            branch = branchBeingEdited;
            txtBranchName.Text = branch.BranchName;
            lblCBBalance.Visible = false;
            lblDropBalance.Visible = false;
            txtCBBalance.Visible = false;
            txtDropBalance.Visible = false;
        }
        private void btnCancelBranch_Click(object sender, EventArgs e)
        {

        }

        private void btnSaveBranch_Click(object sender, EventArgs e)
        {
            if (ValidateAllEntries() == "")
            {
                branch.Save();
                this.Close();
            }
            else
            {

                MessageBox.Show(ValidateAllEntries());
            }
                
        }

        private void txtBranchName_TextChanged(object sender, EventArgs e)
        {
            branch.BranchName = txtBranchName.Text;
        }

        public string ValidateAllEntries()
        {
            string errormsg = "";
            if (txtBranchName.Text == "")
            {
                errormsg = "\nYou are required to fill in all fields";
            }
            if (!Branch.BranchNameAvailable(branch))
            {
                errormsg += "\nBranch name \"" + txtBranchName.Text + "\" is already in use";
            }
            Decimal i;
            if ((!Decimal.TryParse(txtCBBalance.Text, out i)) && (txtCBBalance.Text != ""))
            {
                errormsg += "\nCashbook Balance needs to be a Decimal";
            }
            Decimal j;
            if ((!Decimal.TryParse(txtDropBalance.Text, out j)) && (txtDropBalance.Text != ""))
            {
                errormsg += "\nDrop Safe Balance needs to be a Decimal";
            }
            return errormsg;
        }

        private void txtCBBalance_TextChanged(object sender, EventArgs e)
        {
            if (branch.branchIsNew)
            {
                try
                {
                    branch.CBBalance = Convert.ToDecimal(txtCBBalance.Text);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }

        private void txtDropBalance_TextChanged(object sender, EventArgs e)
        {
            if (branch.branchIsNew)
            {
                try
                {
                    branch.DropBalance = Convert.ToDecimal(txtDropBalance.Text);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }
    }
}
