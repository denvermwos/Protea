using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Globalization;

namespace Protea
{
    public partial class frmMain : Form
    {
        public string UserName;
        public int UserID;
        public bool IsAdmin;
        public bool cboxTransTypeDoneLoading = false;
        public User cbUser;
        public bool CurrentCBLocked = true;
        //private Dictionary<string, int> branchesDict = new Dictionary<string, int>();
        private bool cboxBranchesDoneLoading = false;

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
                tcProtea.TabPages.Remove(tcProtea.TabPages["tpBranchCashbookAndDropFigures"]);

            }
            if (!cbUser.UserGroup.GroupsAccessDict["Cashbook"].HasAccess)
            {
                tcProtea.TabPages.Remove(tcProtea.TabPages["tpCashbook"]);

            }
            if (!cbUser.UserGroup.GroupsAccessDict["Recon"].HasAccess)
            {
                tcProtea.TabPages.Remove(tcProtea.TabPages["tpRecon"]);

            }
            if (!cbUser.UserGroup.GroupsAccessDict["Edit Users Branches Transactions Groups"].HasAccess)
            {
                gbEditEntities.Visible = false;

            }
            if (!cbUser.UserGroup.GroupsAccessDict["Change Own Branch"].HasAccess)
            {
                gbBranch.Visible = false;
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
            
            dataGridViewTransactionByPBranch.Rows.Clear();
            cboxTransTypeDoneLoading = false;
            PopulateTransactionsCombobox(cboxTransType, false);
            cboxTransTypeDoneLoading = true;

            PopulateTransactionsCombobox(cboxTransTypeFilter, true);

            PopulateComboboxTransactionTotalByPBranchFilter();
            PopulateComboboxTransactionTotalByPUserFilter();
            cboxTransTypeFilter.SelectedIndex = 0;

            PopulateDorCCombobox();


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

            cboxDCItem debit = new cboxDCItem("Debit", -1);
            cboxDCItem credit = new cboxDCItem("Credit", +1);

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
                Branch tempuser = branches.ToList()[i];
                cboxBranch.Items.Add(tempuser);
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
                result += "\nA Valid PUser needs to be selected";
            }

            if ((comboBoxPBranchForCashbookEntryCapture.SelectedIndex == -1) && ((TransType)cboxTransType.SelectedItem).NeedsPBranch)
            {
                result += "\nA Valid PBranch needs to be selected";
            }

            if (!decimal.TryParse(txtCBAmount.Text, out d) && (txtCBAmount.Text != ""))
            {
                result += "\nAmount must be a decimal";
            }
            if ((txtCBAmount.Text == "") || (txtCBDescription.Text == ""))
            {
                result += "\nYou are required to fill in all fields";
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
            if (comboBoxPBranchForCashbookEntryCapture.SelectedItem == null)
            {
                
                comboBoxPBranchForCashbookEntryCapture.SelectedIndex = 0;
                
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            
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
            if (comboBoxPUsersForCashbookEntryCapture.SelectedItem == null)
            {
                comboBoxPUsersForCashbookEntryCapture.SelectedIndex = 0;
            }
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
        



        
    }
}