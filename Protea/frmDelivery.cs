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
    public partial class frmDelivery : Form
    {
        private Delivery Delivery;
        public frmDelivery()
        {
            Delivery = new Delivery();

            InitializeComponent();
            Branch.PopulateCBoxBranches(cboxDeliveryBranch);
            Branch.selectItemInCboxBranch(cboxDeliveryBranch, frmMain.cbUser.UserBranch);
        }
        public frmDelivery(Delivery delivery)
        {
            Delivery = delivery;

            InitializeComponent();
            Branch.PopulateCBoxBranches(cboxDeliveryBranch);
            Branch.selectItemInCboxBranch(cboxDeliveryBranch, Delivery.Branch);
            dtpDeliveryDate.Value = Delivery.DeliveryDate.Date;
            txtDeliveryDescription.Text = Delivery.DeliveryDescription;
            cboxDeliveryReturned.SelectedIndex = (Delivery.DeliveryReturned ? 0 : 1);
            
        }
        private void populateDeliveryClass()
        {
            Delivery.Branch = (Branch)cboxDeliveryBranch.SelectedItem;
            Delivery.DeliveryDate = dtpDeliveryDate.Value.Date;
            Delivery.DeliveryDescription = txtDeliveryDescription.Text;
            //Delivery.DeliveryReturned = cboxDeliveryReturned.
        }
        private string ValidateAllEntries()
        {
            string errormsg = "";
            if (txtDeliveryDescription.Text == "")
            {
                errormsg = "\nPlease fill in a valid description";
            }

            if (cboxDeliveryBranch.SelectedIndex == -1)
            {
                errormsg += "\nPlease select a branch for the delivery";
            }
            if (cboxDeliveryReturned.SelectedIndex == -1)
            {
                errormsg += "\nDelivery returned?";
            }
            
            return errormsg;
        }

        private void btnSaveDelivery_Click(object sender, EventArgs e)
        {
            string errMsg = ValidateAllEntries();
            if (errMsg == "")
            {
                populateDeliveryClass();
                Delivery.Save();
                this.Close();
            }
            else
            {
                MessageBox.Show(errMsg);
            }
        }

    }
}
