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
    public partial class frmTransaction : Form
    {
        private TransType transType;
        
        public frmTransaction()
        {
            InitializeComponent();
            transType = new TransType();
        }

        public frmTransaction(TransType transtypeBeingEdited)
        {
            InitializeComponent();
            transType = transtypeBeingEdited;
            txtTransTypeDescription.Text = transType.TransDescription;
            rbNone.Checked = true;
            if (transType.NeedsPBranch)
            {
                rbPBranch.Checked = true;
            }
            else if (transType.NeedsPUser)
            {
                rbPUser.Checked = true;
            }
            else
            {
                rbNone.Checked = true;
            }

            gbEntryTag.Enabled = false;

        }

        private void btnSaveTransaction_Click(object sender, EventArgs e)
        {
            if (ValidateAllEntries() == "")
            {
                transType.Save();
                this.Close();
            }
            else
            {

                MessageBox.Show(ValidateAllEntries());
            }
        }
        private string ValidateAllEntries()
        {
            string errormsg = "";

            if (txtTransTypeDescription.Text == "")
            {
                errormsg += "\nYou are required to fill in all fields.";
            }


            return errormsg;
        }

        private void txtTransTypeDescription_TextChanged(object sender, EventArgs e)
        {
            transType.TransDescription = txtTransTypeDescription.Text;
        }

        private void rbNone_CheckedChanged(object sender, EventArgs e)
        {
            SetCounterEntries();   
        }

        private void rbDropSafe_CheckedChanged(object sender, EventArgs e)
        {
            SetCounterEntries();
        }

        private void rbRecon_CheckedChanged(object sender, EventArgs e)
        {
            SetCounterEntries();
        }

        private void SetCounterEntries()
        {
            transType.DropSafe = false;
            transType.Recon = false;

            if (rbPBranch.Checked == true)
            {
                transType.DropSafe = true;
                transType.Recon = false;
            }
            if (rbPUser.Checked == true)
            {
                transType.DropSafe = false;
                transType.Recon = true;
            }
        }
        
    }
}
