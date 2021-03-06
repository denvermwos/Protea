﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Globalization;
//*****************************
using System.Collections;
using Excel = Microsoft.Office.Interop.Excel;
using System.IO;
//*****************************

namespace Protea
{
    public partial class frmMain : Form
    {
        public string UserName;
        public int UserID;
        public bool IsAdmin;
        public bool cboxTransTypeDoneLoading = false;
        public static User cbUser;
        public bool CurrentCBLocked = true;
        //private Dictionary<string, int> branchesDict = new Dictionary<string, int>();
        private bool cboxBranchesDoneLoading = false;
        //*************************************************************************
        #region Member Variables
        const string strConnectionString = "data source=localhost;Integrated Security=SSPI;Initial Catalog=Northwind;";
        StringFormat strFormat; //Used to format the grid rows.
        ArrayList arrColumnLefts = new ArrayList();//Used to save left coordinates of columns
        ArrayList arrColumnWidths = new ArrayList();//Used to save column widths
        int iCellHeight = 0; //Used to get/set the datagridview cell height
        int iTotalWidth = 0; //
        int iRow = 0;//Used as counter
        bool bFirstPage = false; //Used to check whether we are printing first page
        bool bNewPage = false;// Used to check whether we are printing a new page
        int iHeaderHeight = 0; //Used for the header height
        #endregion
        //*************************************************************************
        public frmMain()
        {
            InitializeComponent();
        }
        public frmMain(User cbuser)
        {


            cbUser = cbuser;

            InitializeComponent();
            LoadDataToControls();
            ApplyAccess();


        }
        private void UpdateCashbookBalanceAndDropSafe()
        {
            Branch Branch = Branch.GetBranchByID(((Branch)(cboxBranch.SelectedItem)).BranchID);
            textBoxCashbookBalance.Text = Branch.CBBalance.ToString();
            textBoxDropSafe.Text = Branch.DropBalance.ToString();
        }
        private void ApplyAccess()
        {
            if (!cbUser.UserGroup.GroupsAccessDict["Branch Cashbook and Drop Figures Display"].HasAccess)
            {
                tcProtea.TabPages.Remove(tcProtea.TabPages[tpBranchCashbookAndDropFigures.Name]);//"tpBranchCashbookAndDropFigures"]);

            }
            if (!cbUser.UserGroup.GroupsAccessDict["Cashbook"].HasAccess)
            {
                tcProtea.TabPages.Remove(tcProtea.TabPages[tpCashbook.Name]);//"tpCashbook"]);

            }
            if (!cbUser.UserGroup.GroupsAccessDict["Recon"].HasAccess)
            {
                tcProtea.TabPages.Remove(tcProtea.TabPages[tpRecon.Name]);//"tpRecon"]);

            }
            //View Totals By PUser
            if (!cbUser.UserGroup.GroupsAccessDict["View Totals By PUser"].HasAccess)
            {
                tcProtea.TabPages.Remove(tcProtea.TabPages[tabPageTransactionTotalByPUser.Name]);//"tabPageTransactionTotalByPUser"]);

            }
            //View Totals By PBranch
            if (!cbUser.UserGroup.GroupsAccessDict["View Totals By PBranch"].HasAccess)
            {
                tcProtea.TabPages.Remove(tcProtea.TabPages[tabPageTransactionTotalByPBranch.Name]);//"tabPageTransactionTotalByPUser"]);

            }
            if (!cbUser.UserGroup.GroupsAccessDict["Racecards Sales and Deliveries"].HasAccess)
            {
                tcProtea.TabPages.Remove(tcProtea.TabPages[tabPageRaceCards.Name]);
            }


            if (!cbUser.UserGroup.GroupsAccessDict["Edit Users Branches Transactions Groups"].HasAccess)
            {
                gbEditEntities.Visible = false;

            }
            if (!cbUser.UserGroup.GroupsAccessDict["Edit Users"].HasAccess)
            {
                gbEditUsers.Visible = false;

            }
            if (!cbUser.UserGroup.GroupsAccessDict["Change Own Branch"].HasAccess)
            {
                cboxBranch.Enabled = false;
            }
            if (!cbUser.UserGroup.GroupsAccessDict["Change Recon Viewer User"].HasAccess)
            {
                cboxReconUserBeingViewed.Visible = false;
            }
            if (!cbUser.UserGroup.GroupsAccessDict["Change Recon Viewer Date"].HasAccess)
            {
                dtpReconViewerDateTime.Visible = false;
            }
            if (!cbUser.UserGroup.GroupsAccessDict["View Pending Recon Entries"].HasAccess)
            {
                gbPendingTransfers.Visible = false;
            }
            
        }
        private void PopulateUserRecon()
        {
            PopulateUserReconDGV(dgvReconCompleted, true);
            PopulateUserReconDGV(dgvReconPending, false);
        }
        private void PopulatePublicationSalesDGV()
        {
            dataGridViewPublicationSalesHistory.Rows.Clear();
            List<PublicationSale> publicationSalesList = PublicationSale.GetPublicationSales(dateTimePickerPublicationSalesHistory.Value.Date, cbUser.UserBranch);
            for (int i = 0; i < publicationSalesList.Count(); i++)
            {
                PublicationSale tempPublicationSale = publicationSalesList.ToList()[i];
                DataGridViewRow publicationSaleRow = new DataGridViewRow();
                publicationSaleRow.CreateCells(dataGridViewPublicationSalesHistory);

                publicationSaleRow.Cells[ColumnSalesHistoryDeliveryDate.Index].Value = tempPublicationSale.PublicationDeliveryDate.ToString("dd MMM");
                publicationSaleRow.Cells[ColumnSalesHistoryPublicationName.Index].Value = tempPublicationSale.Publication.PublicationName;
                //publicationSaleRow.Cells[ColumnSalesHistoryQuantity.Index].Value = tempPublicationSale.Quantity.ToString();
                publicationSaleRow.Cells[ColumnSalesHistoryTotalPrice.Index].Value = tempPublicationSale.Price.ToString();
                dataGridViewPublicationSalesHistory.Rows.Add(publicationSaleRow);
            }
        }
        private void PopulateUserReconDGV(DataGridView dgv, bool viewFinalTransfers)
        {

            dgv.Rows.Clear();
            List<ReconEntry> reconentries = ReconEntry.GetReconEntries(cbUser.UserBranch, (User)(cboxReconUserBeingViewed.SelectedItem), dtpReconViewerDateTime.Value, viewFinalTransfers);
            if (reconentries.Count != 0)
            {
                for (int i = 0; i < reconentries.Count(); i++)
                {
                    ReconEntry tempreconentry = reconentries.ToList()[i];
                    DataGridViewRow userrow = new DataGridViewRow();
                    userrow.CreateCells(dgvReconCompleted);

                    userrow.Cells[dgvReconCompleted.Columns["ReconDescCol"].Index].Value = tempreconentry.ReconDescription;

                    userrow.Cells[dgvReconCompleted.Columns["ReconAmountCol"].Index].Value = tempreconentry.TransferAmount;

                    userrow.Cells[dgvReconCompleted.Columns["ReconCapturerCol"].Index].Value = tempreconentry.CapturerUser.FName + " " + tempreconentry.CapturerUser.LName;


                    userrow.Tag = tempreconentry;

                    dgv.Rows.Add(userrow);

                }
            }
            DataGridViewRow recontotalrow = new DataGridViewRow();
            recontotalrow.DefaultCellStyle.BackColor = Color.DarkGreen;
            recontotalrow.DefaultCellStyle.ForeColor = Color.White;
            recontotalrow.DefaultCellStyle.SelectionBackColor = Color.DarkGreen;
            recontotalrow.DefaultCellStyle.SelectionForeColor = Color.White;
            recontotalrow.CreateCells(dgvReconCompleted);
            recontotalrow.Cells[dgvReconCompleted.Columns["ReconDescCol"].Index].Value = "Daily Total";

            recontotalrow.Cells[dgvReconCompleted.Columns["ReconAmountCol"].Index].Value = ReconEntry.GetReconEntriesTotal(cbUser.UserBranch, (User)(cboxReconUserBeingViewed.SelectedItem), dtpReconViewerDateTime.Value, viewFinalTransfers).ToString();
            dgv.Rows.Add(recontotalrow);
        }
        private void LoadDataToControls()
        {
            FormHeaderText();
            PopulatePublicationsCombobox();
            dataGridViewTransactionByPBranch.Rows.Clear();
            cboxTransTypeDoneLoading = false;
            PopulateTransactionsCombobox(cboxTransType, false);
            cboxTransTypeDoneLoading = true;

            PopulateTransactionsCombobox(cboxTransTypeFilter, true);

            PopulateComboboxTransactionTotalByPBranchFilter();
            PopulateComboboxTransactionTotalByPUserFilter();
            cboxTransTypeFilter.SelectedIndex = 0;

            PopulateDorCCombobox();
            //PopulatePublicationSalesDGV();

            LoadBranchSpecificDataToControls();
        }
        private void ClearDataGrids()
        {
            dgvCashbookEntries.Rows.Clear();
            dgvReconCompleted.Rows.Clear();
            dgvReconPending.Rows.Clear();
            dgvBranchBalances.Rows.Clear();
            dataGridViewTransactionByPBranch.Rows.Clear();
            dataGridViewTransactionByPUser.Rows.Clear();
        }
        private void LoadBranchSpecificDataToControls()
        {
            ClearDataGrids();
            ColumnTotalFromCashbook.HeaderText = "Total from " + cbUser.UserBranch.BranchName + "'s Cashbook";
            PopulateUserBox(cboxTransferPartner, false);
            PopulateUserBox(cboxReconUserBeingViewed, true);
            PopulatePUserBox();
            selectItemInCBoxUser(cboxReconUserBeingViewed, cbUser);
            PopulateBranchCombobox();
            PopulatePBranchCombobox();
            //PopulateTransactionList();
            PopulateUserRecon();
            UpdateCashbookBalanceAndDropSafe();
        }
        private void selectItemInCboxBranch(Branch branchToSelect)
        {
            for (int i = 0; i < cboxBranch.Items.Count; i++)
            {
                if (((Branch)(cboxBranch.Items[i])).BranchID == branchToSelect.BranchID)
                {
                    cboxBranch.SelectedIndex = i;
                }
            }
        }
        private void selectItemInCBoxUser(ComboBox cb, User user)
        {
            for (int i = 0; i < cb.Items.Count; i++)
            {
                if (((User)(cb.Items[i])).UserID == user.UserID)
                {
                    cb.SelectedIndex = i;
                }
            }
        }
        private void FormHeaderText()
        {
            this.Text = "Protea :: " + cbUser.ToString() + " : " + cbUser.UserBranch + " : " + cbUser.UserGroup;
        }
        private void btnSubmitTransaction_Click(object sender, EventArgs e)
        {
            string err = ValidateTransactionFields();
            if (err == "")
            {
                try
                {
                    CashbookEntry cb = new CashbookEntry(((Branch)(cboxBranch.SelectedItem)), ((Branch)(comboBoxPBranchForCashbookEntryCapture.SelectedItem)), cbUser, ((User)(comboBoxPUsersForCashbookEntryCapture.SelectedItem)),((TransType)cboxTransType.SelectedItem), txtCBDescription.Text, ((cboxDCItem)(cboxDorC.SelectedItem)).DorCInt * Convert.ToDecimal(txtCBAmount.Text), "");
                    long newID = cb.Create();

                    txtCBDescription.Text = "";
                    txtCBAmount.Text = "";
                    PopulateTransactionList();
                }
                catch (Exception ex)
                {

                    ExceptionLogger.LogMessage(ex);
                }
            }
            else
            {
                MessageBox.Show(err);
            }

            PopulateUserRecon();
            UpdateCashbookBalanceAndDropSafe();
        }

        private void PopulatePublicationsCombobox()
        {
            comboBoxPublications.Items.Clear();


            List<Publication> publicationList = Publication.GetPublications();


            for (int i = 0; i < publicationList.Count(); i++)
            {
                Publication item = publicationList[i];
                comboBoxPublications.Items.Add(item);
            }

            if (comboBoxPublications.Items.Count != 0)
            {
                comboBoxPublications.SelectedIndex = 0;
            }
        }
        private void PopulateTransactionsCombobox(ComboBox cb, bool addAllTransactions)
        {
            
            cb.Items.Clear();
            if (addAllTransactions)
            {
                cb.Items.Add(new TransType(0, "All Transactions", false, false,false,false));
            }

            List<TransType> transTypeList = TransType.GetTransTypes();


            for (int i = 0; i < transTypeList.Count(); i++)
            {
                TransType item = transTypeList[i];
                cb.Items.Add(item);
            }

            if (cboxTransType.Items.Count != 0)
            {
                cboxTransType.SelectedIndex = 0;
                if (((TransType)cboxTransType.SelectedItem).NeedsPBranch)
                {
                    comboBoxPBranchForCashbookEntryCapture.Visible = true;
                    labelPBranch.Visible = true;
                }
                else
                {
                    comboBoxPBranchForCashbookEntryCapture.Visible = false;
                    labelPBranch.Visible = false;
                }

            }
            
        }
        private void PopulateComboboxTransactionTotalByPBranchFilter()
        {
            comboBoxTransactionTotalByPBranchFilter.Items.Clear();
            

            List<TransType> transTypeList = TransType.GetTransTypesWithPBranch();


            for (int i = 0; i < transTypeList.Count(); i++)
            {
                TransType item = transTypeList[i];
                comboBoxTransactionTotalByPBranchFilter.Items.Add(item);
            }

            if (comboBoxTransactionTotalByPBranchFilter.Items.Count != 0)
            {
                comboBoxTransactionTotalByPBranchFilter.SelectedIndex = 0;
            }
        }
        private void PopulateComboboxTransactionTotalByPUserFilter()
        {
            comboBoxTransactionTotalByPUserFilter.Items.Clear();


            List<TransType> transTypeList = TransType.GetTransTypesWithPUser();


            for (int i = 0; i < transTypeList.Count(); i++)
            {
                TransType item = transTypeList[i];
                comboBoxTransactionTotalByPUserFilter.Items.Add(item);
            }

            if (comboBoxTransactionTotalByPUserFilter.Items.Count != 0)
            {
                comboBoxTransactionTotalByPUserFilter.SelectedIndex = 0;
            }
        }
        private void PopulateDorCCombobox()
        {
            cboxDorC.Items.Clear();

            cboxDCItem debit = new cboxDCItem("Debit (Out)", -1);
            cboxDCItem credit = new cboxDCItem("Credit (In)", +1);

            cboxDorC.Items.Add(debit);
            cboxDorC.Items.Add(credit);
            cboxDorC.SelectedIndex = 0;
        }
          
        private void PopulateUserBox(ComboBox cb, bool includeCBUser)
        {
            cb.Items.Clear();
            List<User> users = User.GetUsersFromBranch(cbUser, includeCBUser);
            for (int i = 0; i < users.Count(); i++)
            {
                User tempuser = users.ToList()[i];
                cb.Items.Add(tempuser);
            }
            if (cb.Items.Count > 0)
            {
                cb.SelectedIndex = 0;
            }

        }
        private void PopulatePUserBox()
        {
            comboBoxPUsersForCashbookEntryCapture.Items.Clear();
            List<User> users = User.GetUsers();
            for (int i = 0; i < users.Count(); i++)
            {
                User tempuser = users.ToList()[i];
                comboBoxPUsersForCashbookEntryCapture.Items.Add(tempuser);
            }
            

        }

        private void frmMain_Load(object sender, EventArgs e)
        {

        }

        private void cboxTransType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboxTransTypeDoneLoading)
            {
                if (((TransType)cboxTransType.SelectedItem).NeedsPBranch)
                {
                    comboBoxPBranchForCashbookEntryCapture.Visible = true;
                    labelPBranch.Visible = true;
                }
                else
                {
                    comboBoxPBranchForCashbookEntryCapture.Visible = false;
                    labelPBranch.Visible = false;
                    comboBoxPBranchForCashbookEntryCapture.SelectedItem = null;
                    comboBoxPBranchForCashbookEntryCapture.Text = "";
                }

                if (((TransType)cboxTransType.SelectedItem).NeedsPUser)
                {
                    comboBoxPUsersForCashbookEntryCapture.Visible = true;
                    labelPUser.Visible = true;
                }
                else
                {
                    comboBoxPUsersForCashbookEntryCapture.Visible = false;
                    labelPUser.Visible = false;
                    comboBoxPUsersForCashbookEntryCapture.SelectedItem = null;
                    comboBoxPUsersForCashbookEntryCapture.Text = "";
                }




            }
        }
        private void PopulateBranchCombobox()
        {

            cboxBranchesDoneLoading = false;
            cboxBranch.Items.Clear();
            List<Branch> branches = Branch.GetBranches();
            for (int i = 0; i < branches.Count(); i++)
            {
                Branch branch = branches.ToList()[i];
                cboxBranch.Items.Add(branch);
            }
            selectItemInCboxBranch(cbUser.UserBranch);
            cboxBranchesDoneLoading = true;
        }
        private void PopulatePBranchCombobox()
        {


            comboBoxPBranchForCashbookEntryCapture.Items.Clear();
            List<Branch> branches = Branch.GetPBranches(cbUser.UserBranch);
            for (int i = 0; i < branches.Count(); i++)
            {
                Branch tempBranch = branches.ToList()[i];
                comboBoxPBranchForCashbookEntryCapture.Items.Add(tempBranch);
            }
            //selectItemInCboxBranch(cbUser.UserBranch);
        }
        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void PopulateTransactionList()
        {

            decimal[] BalanceBFwdandPageTotal = CashbookEntry.GetBalanceBFwdandPageTotal((Branch)(cboxBranch.SelectedItem), (TransType)(cboxTransTypeFilter.SelectedItem), dtpStartDate.Value.Date, dtpEndDate.Value.Date);
            dgvCashbookEntries.Rows.Clear();

            DataGridViewRow bbfwdrow = new DataGridViewRow();
            bbfwdrow.CreateCells(dgvCashbookEntries);


            bbfwdrow.Cells[dgvCashbookEntries.Columns["id"].Index].Value = "";
            bbfwdrow.Cells[dgvCashbookEntries.Columns["DateandTime"].Index].Value = "";
            bbfwdrow.Cells[dgvCashbookEntries.Columns["BranchCol"].Index].Value = "";
            bbfwdrow.Cells[dgvCashbookEntries.Columns["EntryType"].Index].Value = "";
            bbfwdrow.Cells[dgvCashbookEntries.Columns["Description"].Index].Value = "Balance BFwd - " + ((TransType)(cboxTransTypeFilter.SelectedItem)).TransDescription;
            bbfwdrow.Cells[dgvCashbookEntries.Columns["Amount"].Index].Value = BalanceBFwdandPageTotal[0].ToString();
            bbfwdrow.Cells[dgvCashbookEntries.Columns["Total"].Index].Value = BalanceBFwdandPageTotal[0].ToString();
            decimal runningTotal = BalanceBFwdandPageTotal[0];
            bbfwdrow.Cells[dgvCashbookEntries.Columns["ScannedFile"].Index].Value = "";
            bbfwdrow.Cells[dgvCashbookEntries.Columns["CapturedBy"].Index].Value = "";
            bbfwdrow.DefaultCellStyle.SelectionBackColor = Color.White;
            bbfwdrow.DefaultCellStyle.SelectionForeColor = Color.Black;
            dgvCashbookEntries.Rows.Add(bbfwdrow);


            if (chkboxShowTransactions.Checked == true)
            {
                List<CashbookEntry> cashbookEntries = CashbookEntry.GetCashbookEntries((Branch)(cboxBranch.SelectedItem), (TransType)(cboxTransTypeFilter.SelectedItem), dtpStartDate.Value.Date, dtpEndDate.Value.Date);
                for (int i = 0; i < cashbookEntries.Count(); i++)
                {
                    CashbookEntry tempCashbookEntry = cashbookEntries.ToList()[i];

                    DataGridViewRow row = new DataGridViewRow();
                    row.CreateCells(dgvCashbookEntries);
                    //add cashbookentry object to tag
                    row.Tag = tempCashbookEntry;
                    
                    //add text to datagridviewrows
                    row.Cells[dgvCashbookEntries.Columns["id"].Index].Value = tempCashbookEntry.EntryID.ToString("0000000000");
                    row.Cells[dgvCashbookEntries.Columns["DateandTime"].Index].Value = tempCashbookEntry.EntryDate.ToString("ddd dd MMM HH:mm");
                    row.Cells[dgvCashbookEntries.Columns["BranchCol"].Index].Value = tempCashbookEntry.CBEBranch.BranchName;
                    row.Cells[dgvCashbookEntries.Columns["PBranchCol"].Index].Value = tempCashbookEntry.BranchTag.BranchName;
                    row.Cells[ColumnTransactionListPUser.Index].Value = tempCashbookEntry.UserTag.FName + " " + tempCashbookEntry.UserTag.LName;
                    row.Cells[dgvCashbookEntries.Columns["EntryType"].Index].Value = tempCashbookEntry.TransType.ToString();
                    row.Cells[dgvCashbookEntries.Columns["Description"].Index].Value = tempCashbookEntry.EntryDescription.ToString();
                    row.Cells[dgvCashbookEntries.Columns["Amount"].Index].Value = tempCashbookEntry.Amount.ToString();
                    runningTotal += tempCashbookEntry.Amount;
                    row.Cells[dgvCashbookEntries.Columns["Total"].Index].Value = runningTotal.ToString();
                    row.Cells[dgvCashbookEntries.Columns["ScannedFile"].Index].Value = tempCashbookEntry.ScannedFile.ToString();
                    row.Cells[dgvCashbookEntries.Columns["CapturedBy"].Index].Value = tempCashbookEntry.Capturer.ToString();
                    

                    dgvCashbookEntries.Rows.Add(row);
                }
            }



            CashbookEntry pagetotal = GetPageTotal();
            DataGridViewRow pagetotalrow = new DataGridViewRow();
            pagetotalrow.CreateCells(dgvCashbookEntries);
            //add cashbookentry object to tag
            //pagetotalrow.Tag = pagetotal;

            pagetotalrow.Cells[dgvCashbookEntries.Columns["id"].Index].Value = "";
            pagetotalrow.Cells[dgvCashbookEntries.Columns["DateandTime"].Index].Value = "";
            pagetotalrow.Cells[dgvCashbookEntries.Columns["BranchCol"].Index].Value = "";
            pagetotalrow.Cells[dgvCashbookEntries.Columns["EntryType"].Index].Value = "";
            pagetotalrow.Cells[dgvCashbookEntries.Columns["Description"].Index].Value = pagetotal.EntryDescription;
            pagetotalrow.Cells[dgvCashbookEntries.Columns["Amount"].Index].Value = BalanceBFwdandPageTotal[1].ToString("F", CultureInfo.InvariantCulture);
            pagetotalrow.Cells[dgvCashbookEntries.Columns["Total"].Index].Value = "";
            pagetotalrow.Cells[dgvCashbookEntries.Columns["ScannedFile"].Index].Value = "";
            pagetotalrow.Cells[dgvCashbookEntries.Columns["CapturedBy"].Index].Value = "";
            pagetotalrow.DefaultCellStyle.BackColor = Color.DarkGreen;
            pagetotalrow.DefaultCellStyle.ForeColor = Color.White;
            pagetotalrow.DefaultCellStyle.SelectionBackColor = Color.DarkGreen;
            pagetotalrow.DefaultCellStyle.SelectionForeColor = Color.White;
            dgvCashbookEntries.Rows.Add(pagetotalrow);

        }

        private void PopulateTransactionByPBranchDatagridView()
        {

            dataGridViewTransactionByPBranch.Rows.Clear();
            List<PBranchAudit> branches = PBranchAudit.DoPBranchAudit(cbUser.UserBranch,(TransType)comboBoxTransactionTotalByPBranchFilter.SelectedItem,dateTimePickerPBranchAuditStart.Value.Date,dateTimePickerPBranchAuditEnd.Value.Date);

            for (int i = 0; i < branches.Count(); i++)
            {
                PBranchAudit pBranchAudit = branches.ToList()[i];
                DataGridViewRow branchrow = new DataGridViewRow();
                branchrow.CreateCells(dataGridViewTransactionByPBranch);

                branchrow.Cells[ColumnPBranch.Index].Value = pBranchAudit.PBranch.BranchName;
                branchrow.Cells[ColumnTotalFromPBranchsCashbook.Index].Value = pBranchAudit.PBranchesCBTotalAmount.ToString();
                branchrow.Cells[ColumnTotalFromCashbook.Index].Value = pBranchAudit.BranchesCBTotalAmount.ToString();
                branchrow.Cells[ColumnNetOfBranchAndPBranch.Index].Value = pBranchAudit.Variance.ToString();

                branchrow.Tag = pBranchAudit;

                dataGridViewTransactionByPBranch.Rows.Add(branchrow);
            }
        }

        private void PopulateTransactionByPUserDatagridView()
        {

            dataGridViewTransactionByPUser.Rows.Clear();
            List<PUserAudit> pUserAudits = PUserAudit.DoPUserAudit(cbUser.UserBranch, (TransType)comboBoxTransactionTotalByPUserFilter.SelectedItem, dateTimePickerPUserAuditStart.Value.Date, dateTimePickerPUserAuditEnd.Value.Date);

            for (int i = 0; i < pUserAudits.Count(); i++)
            {
                PUserAudit pBranchAudit = pUserAudits.ToList()[i];
                DataGridViewRow pUserRow = new DataGridViewRow();
                pUserRow.CreateCells(dataGridViewTransactionByPUser);

                pUserRow.Cells[ColumnPUserStaffNo.Index].Value = pBranchAudit.User.StaffNo.ToString();
                pUserRow.Cells[ColumnPUserName.Index].Value = pBranchAudit.User.ToString();
                pUserRow.Cells[ColumnPUserTotal.Index].Value = pBranchAudit.Total.ToString();
                

                pUserRow.Tag = pBranchAudit;

                dataGridViewTransactionByPUser.Rows.Add(pUserRow);
            }
        }
        private CashbookEntry GetPageTotal()
        {
            CashbookEntry pagetotal = new CashbookEntry(new Branch(), new Branch(), new User(), new User(), new TransType(), "Page Total", CashbookEntry.GetPageTotal((Branch)(cboxBranch.SelectedItem), (TransType)(cboxTransTypeFilter.SelectedItem), dtpStartDate.Value, dtpEndDate.Value), ""); ;

            return pagetotal;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            //if (cboxTransTypeFilter.SelectedItem != null)
            //{

                if (dtpEndDate.Value.Date < dtpStartDate.Value.Date)
                {
                    dtpEndDate.Value = dtpStartDate.Value;
                }
                PopulateTransactionList();
            //}
            //else
            //{
            //    MessageBox.Show("Please select a valid transaction type to filter by.");
            //}
        }

        private void dtpStartDate_ValueChanged(object sender, EventArgs e)
        {

        }

        private void PopulateBranchCBAndDropTotals()
        {



            dgvBranchBalances.Rows.Clear();
            List<Branch> branches = Branch.GetBranches();

            for (int i = 0; i < branches.Count(); i++)
            {
                Branch tempbranch = branches.ToList()[i];
                DataGridViewRow branchrow = new DataGridViewRow();
                branchrow.CreateCells(dgvBranchBalances);

                branchrow.Cells[dgvBranchBalances.Columns["CompanysBranch"].Index].Value = tempbranch.BranchName;

                branchrow.Cells[dgvBranchBalances.Columns["CBBalance"].Index].Value = tempbranch.CBBalance.ToString();

                branchrow.Cells[dgvBranchBalances.Columns["DropSafe"].Index].Value = tempbranch.DropBalance.ToString();

                branchrow.Tag = tempbranch;

                dgvBranchBalances.Rows.Add(branchrow);
            }

        }


        private void btnDropRefresh_Click(object sender, EventArgs e)
        {
            PopulateBranchCBAndDropTotals();
        }

        private void BranchFigures_Enter(object sender, EventArgs e)
        {
            PopulateBranchCBAndDropTotals();
        }

        

        private void cboxBranch_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboxBranchesDoneLoading)
            {
                UpdateCBUSerBranch();
                UpdateCashbookBalanceAndDropSafe();
                LoadBranchSpecificDataToControls();
            }
        }

        private void btnUsers_Click(object sender, EventArgs e)
        {
            frmUsers UserForm = new frmUsers();
            UserForm.ShowDialog();
            cbUser = User.GetUserByID(cbUser.UserID);
            LoadDataToControls();
        }

        private void btnTransactions_Click(object sender, EventArgs e)
        {
            frmTransactions TransactionsForm = new frmTransactions();
            TransactionsForm.ShowDialog();
            LoadDataToControls();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void dtpEndDate_ValueChanged(object sender, EventArgs e)
        {

        }

        private void cboxTransTypeFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        public string ValidateTransactionFields()
        {
            string result = "";
            decimal d;
            if ((comboBoxPUsersForCashbookEntryCapture.SelectedIndex == -1) && ((TransType)cboxTransType.SelectedItem).NeedsPUser)
            {
                result += "\nA Valid #User needs to be selected";
            }

            if ((comboBoxPBranchForCashbookEntryCapture.SelectedIndex == -1) && ((TransType)cboxTransType.SelectedItem).NeedsPBranch)
            {
                result += "\nA Valid #Branch needs to be selected";
            }

            if (!decimal.TryParse(txtCBAmount.Text, out d) && (txtCBAmount.Text != ""))
            {
                result += "\nAmount must be a decimal";
            }
            if ((txtCBAmount.Text == ""))// || (txtCBDescription.Text == ""))
            {
                result += "\nYou are required to fill in all fields";
            }


            return result;
        }
        private string ValidatePublicationSaleFields()
        {
            string result = "";

            if (comboBoxPublications.SelectedItem == null)
            {
                result = "Please select a valid publication";
            }


            return result;
        }

        private void cboxBranch_Leave(object sender, EventArgs e)
        {
            ////cboxBranch_DropDownClosed needs to belooked at
            //UpdateCBUSerBranch();
            //UpdateCashbookBalanceAndDropSafe();
        }

        private void cboxBranch_DropDownClosed(object sender, EventArgs e)
        {
            ////cboxBranch_Leave needs to be looked at
            //UpdateCBUSerBranch();
            //UpdateCashbookBalanceAndDropSafe();
        }
        
        private void UpdateCBUSerBranch()
        {
            cbUser.UserBranch = (Branch)cboxBranch.SelectedItem;
            cbUser.Save();
            LoadBranchSpecificDataToControls();
        }


        private void btnProcessTransfer_Click(object sender, EventArgs e)
        {
            string errormsg = ValidateReconEntry();
            if (errormsg == "")
            {
                decimal amount = Convert.ToDecimal(txtTransferAmount.Text);
                if (rbGiveCashTo.Checked == true)
                {
                    ReconEntry.TransferCash(amount, cbUser, (User)(cboxTransferPartner.SelectedItem), cbUser.UserBranch, DateTime.Now);
                }
                if (rbRecieveCashFrom.Checked == true)
                {
                    int i = ReconEntry.AcceptCash(amount, (User)(cboxTransferPartner.SelectedItem), cbUser, cbUser.UserBranch, DateTime.Now);
                    if (i > 0)
                    {
                        MessageBox.Show("There is no pending transfer to you which matches your entry");
                    }

                }
                PopulateUserRecon();
                txtTransferAmount.Text = "";
            }
            else
            {
                MessageBox.Show(errormsg);
            }
        }

        private void cbReconUserBeingViewed_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cbReconUserBeingViewed_DropDownClosed(object sender, EventArgs e)
        {
            PopulateUserRecon();
        }

        private void dtpReconViewerDateTime_ValueChanged(object sender, EventArgs e)
        {
            PopulateUserRecon();
        }

        private void btnCancelTransfer_Click(object sender, EventArgs e)
        {
            txtTransferAmount.Text = "";
        }

        private void btnGroups_Click(object sender, EventArgs e)
        {
            frmGroups GroupsForm = new frmGroups();
            GroupsForm.ShowDialog();
        }
        private string ValidateReconEntry()
        {
            string errormsg = "";
            if (txtTransferAmount.Text == "")
            {
                errormsg += "\nYou are required to enter a transfer amount";
            }
            decimal d;
            if ((txtTransferAmount.Text != "") && (!decimal.TryParse(txtTransferAmount.Text, out d)))
            {
                errormsg += "\nThe transfer amount is not a valid number";
            }

            if ((User)(cboxTransferPartner.SelectedItem) == null)
            {
                errormsg += "\nYou are required to select a User to transfer with";
            }
            return errormsg;


        }

        private void dgvCashbookEntries_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnBranches_Click(object sender, EventArgs e)
        {
            frmBranches BranchesForm = new frmBranches();
            BranchesForm.ShowDialog();
            LoadDataToControls();
        }

        private void timer30sec_Tick(object sender, EventArgs e)
        {
            UpdateCashbookBalanceAndDropSafe();
            
        }

        private void cboxTransTypeFilter_Validating(object sender, CancelEventArgs e)
        {
            if (cboxTransTypeFilter.SelectedItem == null)
            {
                cboxTransTypeFilter.SelectedIndex = 0;
            }
        }

        private void cboxBranch_Validating(object sender, CancelEventArgs e)
        {
            //if (cboxBranch.SelectedItem == null)
            //{
            //    cboxBranch.SelectedIndex = 0;
            //}
            //UpdateCBUSerBranch();
            //UpdateCashbookBalanceAndDropSafe();
        }

        private void cboxTransType_Validating(object sender, CancelEventArgs e)
        {
            if (cboxTransType.SelectedItem == null)
            {
                cboxTransType.SelectedIndex = 0;
            }
        }

        private void cboxPBranch_Validating(object sender, CancelEventArgs e)
        {
            //if (comboBoxPBranchForCashbookEntryCapture.SelectedItem == null)
            //{
                
            //    comboBoxPBranchForCashbookEntryCapture.SelectedIndex = 0;
                
            //}
        }

        

        private void buttonDoPUserAudit_Click(object sender, EventArgs e)
        {
            PopulateTransactionByPUserDatagridView();
        }

        private void buttonDoPBranchAudit_Click(object sender, EventArgs e)
        {
            PopulateTransactionByPBranchDatagridView();
        }

        private void comboBoxPUsersForCashbookEntryCapture_Validating(object sender, CancelEventArgs e)
        {
            //if (comboBoxPUsersForCashbookEntryCapture.SelectedItem == null)
            //{
            //    comboBoxPUsersForCashbookEntryCapture.SelectedIndex = 0;
            //}
        }

        private void comboBoxTransactionTotalByPBranchFilter_Validating(object sender, CancelEventArgs e)
        {
            if (comboBoxTransactionTotalByPBranchFilter.SelectedItem == null)
            {
                comboBoxTransactionTotalByPBranchFilter.SelectedIndex = 0;
            }
        }

        private void comboBoxTransactionTotalByPUserFilter_Validating(object sender, CancelEventArgs e)
        {
            if (comboBoxTransactionTotalByPUserFilter.SelectedItem == null)
            {
                comboBoxTransactionTotalByPUserFilter.SelectedIndex = 0;
            }
        }

        private void txtCBDescription_KeyDown(object sender, KeyEventArgs e)
        {

        }
        private void EnterToNextControlHandler(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                e.Handled = true;
                (this).SelectNextControl((Control)sender, true, true, true, false);
            }
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void tabPageRaceCards_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePickerPublicationSalesHistory_ValueChanged(object sender, EventArgs e)
        {
            //PopulatePublicationSalesDGV();
        }

        private void buttonPurchasePublications_Click(object sender, EventArgs e)
        {
            string err = ValidatePublicationSaleFields();
            if (err == "")
            {
                try
                {
                    //todo code for purchase
                    //PublicationSale publicationSale = new PublicationSale(DateTime.Now.Date, monthCalendarDeliveryDate);
                }
                catch (Exception ex)
                {

                    ExceptionLogger.LogMessage(ex);
                }
            }
            else
            {
                MessageBox.Show(err);
            }
        }

        private void buttonDeliveries_Click(object sender, EventArgs e)
        {
            frmDeliveries frmDeliveries = new frmDeliveries();
            frmDeliveries.Show();
        }

        private void cboxTransType_KeyPress(object sender, KeyPressEventArgs e)
        {
            CloseComboxBoxDropDownIfUserTyped(sender, e);
        }
        private void CloseComboxBoxDropDownIfUserTyped(object sender, KeyPressEventArgs e)
        {
            base.OnKeyPress(e);
            if (char.IsLetter(e.KeyChar) || char.IsDigit(e.KeyChar))
            {
                ((ComboBox)sender).DroppedDown = false;
            }
            else
            {
                // char is neither letter or digit.
                // there are more methods you can use to determine the
                // type of char, e.g. char.IsSymbol
            }
        }
        private void comboBoxPBranchForCashbookEntryCapture_KeyPress(object sender, KeyPressEventArgs e)
        {
            CloseComboxBoxDropDownIfUserTyped(sender, e);
        }

        private void cboxDorC_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        #region Transaction Printing
        private void btnPrintTransactions_Click(object sender, EventArgs e)
        {
            //Open the print dialog
            PrintDialog printDialog = new PrintDialog();
            printDialog.Document = prntdocTransactions;
            printDialog.UseEXDialog = true;

            //Get the document
            if (DialogResult.OK == printDialog.ShowDialog())
            {
                prntdocTransactions.DocumentName = "Test Page Print";
                prntdocTransactions.DefaultPageSettings.Landscape = true;
                prntdocTransactions.Print();
            }

            ////Open the print preview dialog
            //PrintPreviewDialog objPPdialog = new PrintPreviewDialog();
            //objPPdialog.Document = prntdocTransactions;
            //objPPdialog.Document.DefaultPageSettings.Landscape = true;
            //objPPdialog.ShowDialog();
        }

        private void prntdocTransactions_BeginPrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            try
            {
                strFormat = new StringFormat();
                strFormat.Alignment = StringAlignment.Near;
                strFormat.LineAlignment = StringAlignment.Center;
                strFormat.Trimming = StringTrimming.EllipsisCharacter;

                arrColumnLefts.Clear();
                arrColumnWidths.Clear();
                iCellHeight = 0;
                iRow = 0;
                bFirstPage = true;
                bNewPage = true;
                
                // Calculating Total Widths
                iTotalWidth = 0;
                foreach (DataGridViewColumn dgvGridCol in dgvCashbookEntries.Columns)
                {
                    iTotalWidth += dgvGridCol.Width;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void prntdocTransactions_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            try
            {
                //Set the left margin
                int iLeftMargin = e.MarginBounds.Left;
                //Set the top margin
                int iTopMargin = e.MarginBounds.Top;
                //Whether more pages have to print or not
                bool bMorePagesToPrint = false;
                int iTmpWidth = 0;

                //For the first page to print set the cell width and header height
                if (bFirstPage)
                {
                    foreach (DataGridViewColumn GridCol in dgvCashbookEntries.Columns)
                    {
                        iTmpWidth = (int)(Math.Floor((double)((double)GridCol.Width /
                                       (double)iTotalWidth * (double)iTotalWidth *
                                       ((double)e.MarginBounds.Width / (double)iTotalWidth))));

                        iHeaderHeight = (int)(e.Graphics.MeasureString(GridCol.HeaderText,
                                    GridCol.InheritedStyle.Font, iTmpWidth).Height) + 11;

                        // Save width and height of headres
                        arrColumnLefts.Add(iLeftMargin);
                        arrColumnWidths.Add(iTmpWidth);
                        iLeftMargin += iTmpWidth;
                    }
                }
                //Loop till all the grid rows not get printed
                while (iRow <= dgvCashbookEntries.Rows.Count - 1)
                {
                    DataGridViewRow GridRow = dgvCashbookEntries.Rows[iRow];
                    //Set the cell height
                    iCellHeight = GridRow.Height + 5;
                    int iCount = 0;
                    //Check whether the current page settings allo more rows to print
                    if (iTopMargin + iCellHeight >= e.MarginBounds.Height + e.MarginBounds.Top)
                    {
                        bNewPage = true;
                        bFirstPage = false;
                        bMorePagesToPrint = true;
                        break;
                    }
                    else
                    {
                        if (bNewPage)
                        {
                            //Draw Header
                            string strHeader = cbUser.UserBranch.BranchName + " - " + cboxTransTypeFilter.Text;
                            e.Graphics.DrawString(strHeader, new Font(dgvCashbookEntries.Font, FontStyle.Bold),
                                    Brushes.Black, e.MarginBounds.Left, e.MarginBounds.Top -
                                    e.Graphics.MeasureString(strHeader, new Font(dgvCashbookEntries.Font,
                                    FontStyle.Bold), e.MarginBounds.Width).Height - 13);

                            String strDate = dtpStartDate.Value.ToString("dd MMM yyyy") + "  to " + dtpEndDate.Value.ToString("dd MMM yyyy");
                            //Draw Date
                            e.Graphics.DrawString(strDate, new Font(dgvCashbookEntries.Font, FontStyle.Bold),
                                    Brushes.Black, e.MarginBounds.Left + (e.MarginBounds.Width -
                                    e.Graphics.MeasureString(strDate, new Font(dgvCashbookEntries.Font,
                                    FontStyle.Bold), e.MarginBounds.Width).Width), e.MarginBounds.Top -
                                    e.Graphics.MeasureString(strHeader, new Font(new Font(dgvCashbookEntries.Font,
                                    FontStyle.Bold), FontStyle.Bold), e.MarginBounds.Width).Height - 13);

                            //Draw Columns                 
                            iTopMargin = e.MarginBounds.Top;
                            foreach (DataGridViewColumn GridCol in dgvCashbookEntries.Columns)
                            {
                                e.Graphics.FillRectangle(new SolidBrush(Color.LightGray),
                                    new Rectangle((int)arrColumnLefts[iCount], iTopMargin,
                                    (int)arrColumnWidths[iCount], iHeaderHeight));

                                e.Graphics.DrawRectangle(Pens.Black,
                                    new Rectangle((int)arrColumnLefts[iCount], iTopMargin,
                                    (int)arrColumnWidths[iCount], iHeaderHeight));

                                e.Graphics.DrawString(GridCol.HeaderText, GridCol.InheritedStyle.Font,
                                    new SolidBrush(GridCol.InheritedStyle.ForeColor),
                                    new RectangleF((int)arrColumnLefts[iCount], iTopMargin,
                                    (int)arrColumnWidths[iCount], iHeaderHeight), strFormat);
                                iCount++;
                            }
                            bNewPage = false;
                            iTopMargin += iHeaderHeight;
                        }
                        iCount = 0;
                        //Draw Columns Contents                
                        foreach (DataGridViewCell Cel in GridRow.Cells)
                        {
                            if (Cel.Value != null)
                            {
                                
                                e.Graphics.DrawString(Cel.Value.ToString(), new Font("Microsoft Sans Serif", 7.0f),
                                            new SolidBrush(Color.Black),
                                            new RectangleF((int)arrColumnLefts[iCount], (float)iTopMargin,
                                            (int)arrColumnWidths[iCount], (float)iCellHeight), strFormat);
                            }
                            //Drawing Cells Borders 
                            e.Graphics.DrawRectangle(Pens.Black, new Rectangle((int)arrColumnLefts[iCount],
                                    iTopMargin, (int)arrColumnWidths[iCount], iCellHeight));

                            iCount++;
                        }
                    }
                    iRow++;
                    iTopMargin += iCellHeight;
                }

                //If more lines exist, print another page.
                if (bMorePagesToPrint)
                    e.HasMorePages = true;
                else
                    e.HasMorePages = false;
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region Transaction Export to Excel

        private void ExportToExcel(DataGridView dgv, string Filename)
        {
            if (dgv.RowCount > 0)
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "Excel Documents (*.xls)|*.xls";
                sfd.FileName = Filename + ".xls";
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    // Copy DataGridView results to clipboard
                    copyAlltoClipboard(dgv);

                    object misValue = System.Reflection.Missing.Value;
                    Excel.Application xlexcel = new Excel.Application();

                    xlexcel.DisplayAlerts = false; // Without this you will get two confirm overwrite prompts
                    Excel.Workbook xlWorkBook = xlexcel.Workbooks.Add(misValue);
                    Excel.Worksheet xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);

                    // Format column D as text before pasting results, this was required for my data
                    Excel.Range rng = xlWorkSheet.get_Range("D:D").Cells;
                    rng.NumberFormat = "@";

                    // Paste clipboard results to worksheet range
                    Excel.Range CR = (Excel.Range)xlWorkSheet.Cells[1, 1];
                    CR.Select();
                    xlWorkSheet.PasteSpecial(CR, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, true);

                    // For some reason column A is always blank in the worksheet. ¯\_(ツ)_/¯
                    // Delete blank column A and select cell A1
                    //Excel.Range delRng = xlWorkSheet.get_Range("A:A").Cells;
                    //delRng.Delete(Type.Missing);
                    //xlWorkSheet.get_Range("A1").Select();

                    // Save the excel file under the captured location from the SaveFileDialog
                    xlWorkBook.SaveAs(sfd.FileName, Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
                    xlexcel.DisplayAlerts = true;
                    xlWorkBook.Close(true, misValue, misValue);
                    xlexcel.Quit();

                    releaseObject(xlWorkSheet);
                    releaseObject(xlWorkBook);
                    releaseObject(xlexcel);

                    // Clear Clipboard and DataGridView selection
                    Clipboard.Clear();
                    dgv.ClearSelection();

                    // Open the newly saved excel file
                    if (File.Exists(sfd.FileName))
                        System.Diagnostics.Process.Start(sfd.FileName);
                }
            }
            else
            {
                MessageBox.Show("No rows to export.");
            }
        }


        private void copyAlltoClipboard(DataGridView dgv)
        {
            dgv.SelectAll();
            DataObject dataObj = dgv.GetClipboardContent();
            if (dataObj != null)
                Clipboard.SetDataObject(dataObj);
        }

        private void releaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                obj = null;
                MessageBox.Show("Exception Occurred while releasing object " + ex.ToString());
            }
            finally
            {
                GC.Collect();
            }
        }
        #endregion

        private void ExportTransactions_Click(object sender, EventArgs e)
        {
            ExportToExcel(dgvCashbookEntries, "Transactions");
        }

        private void ExportBranchFigures_Click(object sender, EventArgs e)
        {
            ExportToExcel(dgvBranchBalances, "Branch Figures");            
        }

        private void ExportTransactonsByPBranch_Click(object sender, EventArgs e)
        {
            ExportToExcel(dataGridViewTransactionByPBranch, "Transaction Totals by Paired Branch"); 
        }

        private void ExportTransactionsByPUser_Click(object sender, EventArgs e)
        {
            ExportToExcel(dataGridViewTransactionByPUser, "Transaction Totals by Paired User"); 
        }

        




    }
}