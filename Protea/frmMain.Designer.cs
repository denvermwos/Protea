namespace Protea
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.btnUsers = new System.Windows.Forms.Button();
            this.btnBranches = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cboxBranch = new System.Windows.Forms.ComboBox();
            this.btnTransactions = new System.Windows.Forms.Button();
            this.tpRecon = new System.Windows.Forms.TabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.gbPendingTransfers = new System.Windows.Forms.GroupBox();
            this.dgvReconPending = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gbCompletedTransfers = new System.Windows.Forms.GroupBox();
            this.dgvReconCompleted = new System.Windows.Forms.DataGridView();
            this.ReconDescCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ReconAmountCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ReconCapturerCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cboxReconUserBeingViewed = new System.Windows.Forms.ComboBox();
            this.dtpReconViewerDateTime = new System.Windows.Forms.DateTimePicker();
            this.gbTransfer = new System.Windows.Forms.GroupBox();
            this.btnCancelTransfer = new System.Windows.Forms.Button();
            this.btnProcessTransfer = new System.Windows.Forms.Button();
            this.txtTransferAmount = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cboxTransferPartner = new System.Windows.Forms.ComboBox();
            this.rbRecieveCashFrom = new System.Windows.Forms.RadioButton();
            this.rbGiveCashTo = new System.Windows.Forms.RadioButton();
            this.tpBranchCashbookAndDropFigures = new System.Windows.Forms.TabPage();
            this.ExportBranchFigures = new System.Windows.Forms.Button();
            this.dgvBranchBalances = new System.Windows.Forms.DataGridView();
            this.CompanysBranch = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CBBalance = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DropSafe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnDropRefresh = new System.Windows.Forms.Button();
            this.tpCashbook = new System.Windows.Forms.TabPage();
            this.ExportTransactions = new System.Windows.Forms.Button();
            this.btnPrintTransactions = new System.Windows.Forms.Button();
            this.chkboxShowTransactions = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpStartDate = new System.Windows.Forms.DateTimePicker();
            this.btnSearch = new System.Windows.Forms.Button();
            this.dtpEndDate = new System.Windows.Forms.DateTimePicker();
            this.cboxTransTypeFilter = new System.Windows.Forms.ComboBox();
            this.dgvCashbookEntries = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DateandTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BranchCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PBranchCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnTransactionListPUser = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EntryType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Total = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ScannedFile = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CapturedBy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtCBAmount = new System.Windows.Forms.TextBox();
            this.txtCBDescription = new System.Windows.Forms.TextBox();
            this.btnSubmitTransaction = new System.Windows.Forms.Button();
            this.cboxDorC = new System.Windows.Forms.ComboBox();
            this.cboxTransType = new System.Windows.Forms.ComboBox();
            this.comboBoxPBranchForCashbookEntryCapture = new System.Windows.Forms.ComboBox();
            this.labelPBranch = new System.Windows.Forms.Label();
            this.labelPUser = new System.Windows.Forms.Label();
            this.comboBoxPUsersForCashbookEntryCapture = new System.Windows.Forms.ComboBox();
            this.tcProtea = new System.Windows.Forms.TabControl();
            this.tabPageTransactionTotalByPBranch = new System.Windows.Forms.TabPage();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.ExportTransactonsByPBranch = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.dateTimePickerPBranchAuditStart = new System.Windows.Forms.DateTimePicker();
            this.buttonDoPBranchAudit = new System.Windows.Forms.Button();
            this.dateTimePickerPBranchAuditEnd = new System.Windows.Forms.DateTimePicker();
            this.comboBoxTransactionTotalByPBranchFilter = new System.Windows.Forms.ComboBox();
            this.dataGridViewTransactionByPBranch = new System.Windows.Forms.DataGridView();
            this.ColumnPBranch = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnTotalFromPBranchsCashbook = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnTotalFromCashbook = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnNetOfBranchAndPBranch = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPageTransactionTotalByPUser = new System.Windows.Forms.TabPage();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.ExportTransactionsByPUser = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.dateTimePickerPUserAuditStart = new System.Windows.Forms.DateTimePicker();
            this.buttonDoPUserAudit = new System.Windows.Forms.Button();
            this.dateTimePickerPUserAuditEnd = new System.Windows.Forms.DateTimePicker();
            this.comboBoxTransactionTotalByPUserFilter = new System.Windows.Forms.ComboBox();
            this.dataGridViewTransactionByPUser = new System.Windows.Forms.DataGridView();
            this.ColumnPUserStaffNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnPUserName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnPUserTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPageRaceCards = new System.Windows.Forms.TabPage();
            this.buttonDeliveries = new System.Windows.Forms.Button();
            this.groupBoxPublicationSale = new System.Windows.Forms.GroupBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.ColumnPublicationSaleDeliveryDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateTimePickerPublicationSalesHistory = new System.Windows.Forms.DateTimePicker();
            this.textBoxTotalPriceOfPublicationSale = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.textBoxPublicationDescription = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.numericUpDownItemsInSale = new System.Windows.Forms.NumericUpDown();
            this.label11 = new System.Windows.Forms.Label();
            this.dataGridViewPublicationSalesHistory = new System.Windows.Forms.DataGridView();
            this.ColumnSalesHistoryDeliveryDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnSalesHistoryPublicationName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnSalesHistoryQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnSalesHistoryTotalPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label10 = new System.Windows.Forms.Label();
            this.comboBoxPublications = new System.Windows.Forms.ComboBox();
            this.buttonPurchasePublications = new System.Windows.Forms.Button();
            this.btnGroups = new System.Windows.Forms.Button();
            this.gbEditEntities = new System.Windows.Forms.GroupBox();
            this.gbBranch = new System.Windows.Forms.GroupBox();
            this.textBoxDropSafe = new System.Windows.Forms.TextBox();
            this.labelDropSafe = new System.Windows.Forms.Label();
            this.labelCashbookBalance = new System.Windows.Forms.Label();
            this.textBoxCashbookBalance = new System.Windows.Forms.TextBox();
            this.timer30sec = new System.Windows.Forms.Timer(this.components);
            this.prntdocTransactions = new System.Drawing.Printing.PrintDocument();
            this.gbEditUsers = new System.Windows.Forms.GroupBox();
            this.tpRecon.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.gbPendingTransfers.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReconPending)).BeginInit();
            this.gbCompletedTransfers.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReconCompleted)).BeginInit();
            this.gbTransfer.SuspendLayout();
            this.tpBranchCashbookAndDropFigures.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBranchBalances)).BeginInit();
            this.tpCashbook.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCashbookEntries)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.tcProtea.SuspendLayout();
            this.tabPageTransactionTotalByPBranch.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTransactionByPBranch)).BeginInit();
            this.tabPageTransactionTotalByPUser.SuspendLayout();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTransactionByPUser)).BeginInit();
            this.tabPageRaceCards.SuspendLayout();
            this.groupBoxPublicationSale.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownItemsInSale)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPublicationSalesHistory)).BeginInit();
            this.gbEditEntities.SuspendLayout();
            this.gbBranch.SuspendLayout();
            this.gbEditUsers.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnUsers
            // 
            this.btnUsers.Location = new System.Drawing.Point(6, 19);
            this.btnUsers.Name = "btnUsers";
            this.btnUsers.Size = new System.Drawing.Size(68, 23);
            this.btnUsers.TabIndex = 1;
            this.btnUsers.Text = "Users";
            this.btnUsers.UseVisualStyleBackColor = true;
            this.btnUsers.Click += new System.EventHandler(this.btnUsers_Click);
            // 
            // btnBranches
            // 
            this.btnBranches.Location = new System.Drawing.Point(6, 19);
            this.btnBranches.Name = "btnBranches";
            this.btnBranches.Size = new System.Drawing.Size(68, 23);
            this.btnBranches.TabIndex = 2;
            this.btnBranches.Text = "Branches";
            this.btnBranches.UseVisualStyleBackColor = true;
            this.btnBranches.Click += new System.EventHandler(this.btnBranches_Click);
            // 
            // button4
            // 
            this.button4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button4.Location = new System.Drawing.Point(1153, 21);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(50, 23);
            this.button4.TabIndex = 5;
            this.button4.Text = "Exit";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Branch";
            // 
            // cboxBranch
            // 
            this.cboxBranch.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboxBranch.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboxBranch.FormattingEnabled = true;
            this.cboxBranch.Location = new System.Drawing.Point(58, 24);
            this.cboxBranch.Name = "cboxBranch";
            this.cboxBranch.Size = new System.Drawing.Size(121, 21);
            this.cboxBranch.TabIndex = 4;
            this.cboxBranch.SelectedIndexChanged += new System.EventHandler(this.cboxBranch_SelectedIndexChanged);
            this.cboxBranch.DropDownClosed += new System.EventHandler(this.cboxBranch_DropDownClosed);
            this.cboxBranch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CloseComboxBoxDropDownIfUserTyped);
            this.cboxBranch.Leave += new System.EventHandler(this.cboxBranch_Leave);
            this.cboxBranch.Validating += new System.ComponentModel.CancelEventHandler(this.cboxBranch_Validating);
            // 
            // btnTransactions
            // 
            this.btnTransactions.Location = new System.Drawing.Point(80, 19);
            this.btnTransactions.Name = "btnTransactions";
            this.btnTransactions.Size = new System.Drawing.Size(76, 23);
            this.btnTransactions.TabIndex = 3;
            this.btnTransactions.Text = "Transactions";
            this.btnTransactions.UseVisualStyleBackColor = true;
            this.btnTransactions.Click += new System.EventHandler(this.btnTransactions_Click);
            // 
            // tpRecon
            // 
            this.tpRecon.Controls.Add(this.groupBox3);
            this.tpRecon.Controls.Add(this.gbTransfer);
            this.tpRecon.Location = new System.Drawing.Point(4, 22);
            this.tpRecon.Name = "tpRecon";
            this.tpRecon.Padding = new System.Windows.Forms.Padding(3);
            this.tpRecon.Size = new System.Drawing.Size(1190, 362);
            this.tpRecon.TabIndex = 2;
            this.tpRecon.Text = "Recon";
            this.tpRecon.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox3.Controls.Add(this.gbPendingTransfers);
            this.groupBox3.Controls.Add(this.gbCompletedTransfers);
            this.groupBox3.Controls.Add(this.cboxReconUserBeingViewed);
            this.groupBox3.Controls.Add(this.dtpReconViewerDateTime);
            this.groupBox3.Location = new System.Drawing.Point(6, 6);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(944, 294);
            this.groupBox3.TabIndex = 7;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Recon Viewer";
            // 
            // gbPendingTransfers
            // 
            this.gbPendingTransfers.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.gbPendingTransfers.Controls.Add(this.dgvReconPending);
            this.gbPendingTransfers.Location = new System.Drawing.Point(488, 47);
            this.gbPendingTransfers.Name = "gbPendingTransfers";
            this.gbPendingTransfers.Size = new System.Drawing.Size(450, 241);
            this.gbPendingTransfers.TabIndex = 10;
            this.gbPendingTransfers.TabStop = false;
            this.gbPendingTransfers.Text = "Pending Transfers";
            // 
            // dgvReconPending
            // 
            this.dgvReconPending.AllowUserToAddRows = false;
            this.dgvReconPending.AllowUserToDeleteRows = false;
            this.dgvReconPending.AllowUserToResizeColumns = false;
            this.dgvReconPending.AllowUserToResizeRows = false;
            this.dgvReconPending.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvReconPending.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvReconPending.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvReconPending.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvReconPending.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvReconPending.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvReconPending.Location = new System.Drawing.Point(6, 19);
            this.dgvReconPending.Name = "dgvReconPending";
            this.dgvReconPending.ReadOnly = true;
            this.dgvReconPending.RowHeadersVisible = false;
            this.dgvReconPending.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvReconPending.Size = new System.Drawing.Size(438, 216);
            this.dgvReconPending.TabIndex = 7;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "Description";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 85;
            // 
            // dataGridViewTextBoxColumn2
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.dataGridViewTextBoxColumn2.DefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewTextBoxColumn2.HeaderText = "Amount";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 68;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "Captured By";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Width = 90;
            // 
            // gbCompletedTransfers
            // 
            this.gbCompletedTransfers.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.gbCompletedTransfers.Controls.Add(this.dgvReconCompleted);
            this.gbCompletedTransfers.Location = new System.Drawing.Point(11, 47);
            this.gbCompletedTransfers.Name = "gbCompletedTransfers";
            this.gbCompletedTransfers.Size = new System.Drawing.Size(459, 241);
            this.gbCompletedTransfers.TabIndex = 9;
            this.gbCompletedTransfers.TabStop = false;
            this.gbCompletedTransfers.Text = "Completed Transfers";
            // 
            // dgvReconCompleted
            // 
            this.dgvReconCompleted.AllowUserToAddRows = false;
            this.dgvReconCompleted.AllowUserToDeleteRows = false;
            this.dgvReconCompleted.AllowUserToResizeColumns = false;
            this.dgvReconCompleted.AllowUserToResizeRows = false;
            this.dgvReconCompleted.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvReconCompleted.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvReconCompleted.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvReconCompleted.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ReconDescCol,
            this.ReconAmountCol,
            this.ReconCapturerCol});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvReconCompleted.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgvReconCompleted.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvReconCompleted.Location = new System.Drawing.Point(9, 19);
            this.dgvReconCompleted.Name = "dgvReconCompleted";
            this.dgvReconCompleted.ReadOnly = true;
            this.dgvReconCompleted.RowHeadersVisible = false;
            this.dgvReconCompleted.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvReconCompleted.Size = new System.Drawing.Size(444, 216);
            this.dgvReconCompleted.TabIndex = 0;
            // 
            // ReconDescCol
            // 
            this.ReconDescCol.HeaderText = "Description";
            this.ReconDescCol.Name = "ReconDescCol";
            this.ReconDescCol.ReadOnly = true;
            this.ReconDescCol.Width = 85;
            // 
            // ReconAmountCol
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.ReconAmountCol.DefaultCellStyle = dataGridViewCellStyle3;
            this.ReconAmountCol.HeaderText = "Amount";
            this.ReconAmountCol.Name = "ReconAmountCol";
            this.ReconAmountCol.ReadOnly = true;
            this.ReconAmountCol.Width = 68;
            // 
            // ReconCapturerCol
            // 
            this.ReconCapturerCol.HeaderText = "Captured By";
            this.ReconCapturerCol.Name = "ReconCapturerCol";
            this.ReconCapturerCol.ReadOnly = true;
            this.ReconCapturerCol.Width = 90;
            // 
            // cboxReconUserBeingViewed
            // 
            this.cboxReconUserBeingViewed.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxReconUserBeingViewed.FormattingEnabled = true;
            this.cboxReconUserBeingViewed.Location = new System.Drawing.Point(11, 18);
            this.cboxReconUserBeingViewed.Name = "cboxReconUserBeingViewed";
            this.cboxReconUserBeingViewed.Size = new System.Drawing.Size(159, 21);
            this.cboxReconUserBeingViewed.TabIndex = 5;
            this.cboxReconUserBeingViewed.SelectedIndexChanged += new System.EventHandler(this.cbReconUserBeingViewed_SelectedIndexChanged);
            this.cboxReconUserBeingViewed.DropDownClosed += new System.EventHandler(this.cbReconUserBeingViewed_DropDownClosed);
            // 
            // dtpReconViewerDateTime
            // 
            this.dtpReconViewerDateTime.Location = new System.Drawing.Point(176, 19);
            this.dtpReconViewerDateTime.Name = "dtpReconViewerDateTime";
            this.dtpReconViewerDateTime.Size = new System.Drawing.Size(148, 20);
            this.dtpReconViewerDateTime.TabIndex = 6;
            this.dtpReconViewerDateTime.ValueChanged += new System.EventHandler(this.dtpReconViewerDateTime_ValueChanged);
            // 
            // gbTransfer
            // 
            this.gbTransfer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.gbTransfer.Controls.Add(this.btnCancelTransfer);
            this.gbTransfer.Controls.Add(this.btnProcessTransfer);
            this.gbTransfer.Controls.Add(this.txtTransferAmount);
            this.gbTransfer.Controls.Add(this.label5);
            this.gbTransfer.Controls.Add(this.cboxTransferPartner);
            this.gbTransfer.Controls.Add(this.rbRecieveCashFrom);
            this.gbTransfer.Controls.Add(this.rbGiveCashTo);
            this.gbTransfer.Location = new System.Drawing.Point(6, 306);
            this.gbTransfer.Name = "gbTransfer";
            this.gbTransfer.Size = new System.Drawing.Size(944, 66);
            this.gbTransfer.TabIndex = 3;
            this.gbTransfer.TabStop = false;
            this.gbTransfer.Text = "Transfer";
            // 
            // btnCancelTransfer
            // 
            this.btnCancelTransfer.Location = new System.Drawing.Point(853, 27);
            this.btnCancelTransfer.Name = "btnCancelTransfer";
            this.btnCancelTransfer.Size = new System.Drawing.Size(75, 23);
            this.btnCancelTransfer.TabIndex = 6;
            this.btnCancelTransfer.Text = "Cancel";
            this.btnCancelTransfer.UseVisualStyleBackColor = true;
            this.btnCancelTransfer.Click += new System.EventHandler(this.btnCancelTransfer_Click);
            // 
            // btnProcessTransfer
            // 
            this.btnProcessTransfer.Location = new System.Drawing.Point(772, 27);
            this.btnProcessTransfer.Name = "btnProcessTransfer";
            this.btnProcessTransfer.Size = new System.Drawing.Size(75, 23);
            this.btnProcessTransfer.TabIndex = 5;
            this.btnProcessTransfer.Text = "Process";
            this.btnProcessTransfer.UseVisualStyleBackColor = true;
            this.btnProcessTransfer.Click += new System.EventHandler(this.btnProcessTransfer_Click);
            // 
            // txtTransferAmount
            // 
            this.txtTransferAmount.Location = new System.Drawing.Point(573, 29);
            this.txtTransferAmount.Name = "txtTransferAmount";
            this.txtTransferAmount.Size = new System.Drawing.Size(193, 20);
            this.txtTransferAmount.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(524, 32);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 13);
            this.label5.TabIndex = 3;
            this.label5.Text = "Amount";
            // 
            // cboxTransferPartner
            // 
            this.cboxTransferPartner.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxTransferPartner.FormattingEnabled = true;
            this.cboxTransferPartner.Location = new System.Drawing.Point(145, 29);
            this.cboxTransferPartner.Name = "cboxTransferPartner";
            this.cboxTransferPartner.Size = new System.Drawing.Size(287, 21);
            this.cboxTransferPartner.TabIndex = 2;
            // 
            // rbRecieveCashFrom
            // 
            this.rbRecieveCashFrom.AutoSize = true;
            this.rbRecieveCashFrom.Checked = true;
            this.rbRecieveCashFrom.Location = new System.Drawing.Point(11, 19);
            this.rbRecieveCashFrom.Name = "rbRecieveCashFrom";
            this.rbRecieveCashFrom.Size = new System.Drawing.Size(124, 17);
            this.rbRecieveCashFrom.TabIndex = 1;
            this.rbRecieveCashFrom.TabStop = true;
            this.rbRecieveCashFrom.Text = "Recieve Cash from...";
            this.rbRecieveCashFrom.UseVisualStyleBackColor = true;
            // 
            // rbGiveCashTo
            // 
            this.rbGiveCashTo.AutoSize = true;
            this.rbGiveCashTo.Location = new System.Drawing.Point(11, 42);
            this.rbGiveCashTo.Name = "rbGiveCashTo";
            this.rbGiveCashTo.Size = new System.Drawing.Size(95, 17);
            this.rbGiveCashTo.TabIndex = 0;
            this.rbGiveCashTo.Text = "Give Cash to...";
            this.rbGiveCashTo.UseVisualStyleBackColor = true;
            // 
            // tpBranchCashbookAndDropFigures
            // 
            this.tpBranchCashbookAndDropFigures.Controls.Add(this.ExportBranchFigures);
            this.tpBranchCashbookAndDropFigures.Controls.Add(this.dgvBranchBalances);
            this.tpBranchCashbookAndDropFigures.Controls.Add(this.btnDropRefresh);
            this.tpBranchCashbookAndDropFigures.Location = new System.Drawing.Point(4, 22);
            this.tpBranchCashbookAndDropFigures.Name = "tpBranchCashbookAndDropFigures";
            this.tpBranchCashbookAndDropFigures.Padding = new System.Windows.Forms.Padding(3);
            this.tpBranchCashbookAndDropFigures.Size = new System.Drawing.Size(1190, 362);
            this.tpBranchCashbookAndDropFigures.TabIndex = 1;
            this.tpBranchCashbookAndDropFigures.Text = "Branch Figures";
            this.tpBranchCashbookAndDropFigures.UseVisualStyleBackColor = true;
            this.tpBranchCashbookAndDropFigures.Enter += new System.EventHandler(this.BranchFigures_Enter);
            // 
            // ExportBranchFigures
            // 
            this.ExportBranchFigures.Location = new System.Drawing.Point(89, 7);
            this.ExportBranchFigures.Name = "ExportBranchFigures";
            this.ExportBranchFigures.Size = new System.Drawing.Size(75, 23);
            this.ExportBranchFigures.TabIndex = 2;
            this.ExportBranchFigures.Text = "Export";
            this.ExportBranchFigures.UseVisualStyleBackColor = true;
            this.ExportBranchFigures.Click += new System.EventHandler(this.ExportBranchFigures_Click);
            // 
            // dgvBranchBalances
            // 
            this.dgvBranchBalances.AllowUserToAddRows = false;
            this.dgvBranchBalances.AllowUserToDeleteRows = false;
            this.dgvBranchBalances.AllowUserToResizeColumns = false;
            this.dgvBranchBalances.AllowUserToResizeRows = false;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.LightSkyBlue;
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Transparent;
            this.dgvBranchBalances.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvBranchBalances.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvBranchBalances.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBranchBalances.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CompanysBranch,
            this.CBBalance,
            this.DropSafe});
            this.dgvBranchBalances.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvBranchBalances.Location = new System.Drawing.Point(3, 36);
            this.dgvBranchBalances.Name = "dgvBranchBalances";
            this.dgvBranchBalances.ReadOnly = true;
            this.dgvBranchBalances.RowHeadersVisible = false;
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.Black;
            this.dgvBranchBalances.RowsDefaultCellStyle = dataGridViewCellStyle8;
            this.dgvBranchBalances.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvBranchBalances.Size = new System.Drawing.Size(947, 350);
            this.dgvBranchBalances.TabIndex = 1;
            // 
            // CompanysBranch
            // 
            this.CompanysBranch.HeaderText = "Branch";
            this.CompanysBranch.Name = "CompanysBranch";
            this.CompanysBranch.ReadOnly = true;
            // 
            // CBBalance
            // 
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.CBBalance.DefaultCellStyle = dataGridViewCellStyle6;
            this.CBBalance.HeaderText = "Cashbook";
            this.CBBalance.Name = "CBBalance";
            this.CBBalance.ReadOnly = true;
            // 
            // DropSafe
            // 
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.DropSafe.DefaultCellStyle = dataGridViewCellStyle7;
            this.DropSafe.HeaderText = "Drop Balance";
            this.DropSafe.Name = "DropSafe";
            this.DropSafe.ReadOnly = true;
            // 
            // btnDropRefresh
            // 
            this.btnDropRefresh.Location = new System.Drawing.Point(7, 7);
            this.btnDropRefresh.Name = "btnDropRefresh";
            this.btnDropRefresh.Size = new System.Drawing.Size(75, 23);
            this.btnDropRefresh.TabIndex = 0;
            this.btnDropRefresh.Text = "Update";
            this.btnDropRefresh.UseVisualStyleBackColor = true;
            this.btnDropRefresh.Click += new System.EventHandler(this.btnDropRefresh_Click);
            // 
            // tpCashbook
            // 
            this.tpCashbook.Controls.Add(this.ExportTransactions);
            this.tpCashbook.Controls.Add(this.btnPrintTransactions);
            this.tpCashbook.Controls.Add(this.chkboxShowTransactions);
            this.tpCashbook.Controls.Add(this.groupBox2);
            this.tpCashbook.Controls.Add(this.dgvCashbookEntries);
            this.tpCashbook.Controls.Add(this.dateTimePicker1);
            this.tpCashbook.Controls.Add(this.groupBox1);
            this.tpCashbook.Location = new System.Drawing.Point(4, 22);
            this.tpCashbook.Name = "tpCashbook";
            this.tpCashbook.Padding = new System.Windows.Forms.Padding(3);
            this.tpCashbook.Size = new System.Drawing.Size(1190, 362);
            this.tpCashbook.TabIndex = 0;
            this.tpCashbook.Text = "Cashbook Transactions";
            this.tpCashbook.UseVisualStyleBackColor = true;
            // 
            // ExportTransactions
            // 
            this.ExportTransactions.Location = new System.Drawing.Point(221, 83);
            this.ExportTransactions.Name = "ExportTransactions";
            this.ExportTransactions.Size = new System.Drawing.Size(75, 23);
            this.ExportTransactions.TabIndex = 19;
            this.ExportTransactions.Text = "Export";
            this.ExportTransactions.UseVisualStyleBackColor = true;
            this.ExportTransactions.Click += new System.EventHandler(this.ExportTransactions_Click);
            // 
            // btnPrintTransactions
            // 
            this.btnPrintTransactions.Location = new System.Drawing.Point(139, 83);
            this.btnPrintTransactions.Name = "btnPrintTransactions";
            this.btnPrintTransactions.Size = new System.Drawing.Size(75, 23);
            this.btnPrintTransactions.TabIndex = 18;
            this.btnPrintTransactions.Text = "Print";
            this.btnPrintTransactions.UseVisualStyleBackColor = true;
            this.btnPrintTransactions.Click += new System.EventHandler(this.btnPrintTransactions_Click);
            // 
            // chkboxShowTransactions
            // 
            this.chkboxShowTransactions.AutoSize = true;
            this.chkboxShowTransactions.Checked = true;
            this.chkboxShowTransactions.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkboxShowTransactions.Location = new System.Drawing.Point(15, 89);
            this.chkboxShowTransactions.Name = "chkboxShowTransactions";
            this.chkboxShowTransactions.Size = new System.Drawing.Size(117, 17);
            this.chkboxShowTransactions.TabIndex = 17;
            this.chkboxShowTransactions.Text = "Show Transactions";
            this.chkboxShowTransactions.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.dtpStartDate);
            this.groupBox2.Controls.Add(this.btnSearch);
            this.groupBox2.Controls.Add(this.dtpEndDate);
            this.groupBox2.Controls.Add(this.cboxTransTypeFilter);
            this.groupBox2.Location = new System.Drawing.Point(9, 37);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1175, 45);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Filter";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(558, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "End Date";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(270, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Start Date";
            // 
            // dtpStartDate
            // 
            this.dtpStartDate.Location = new System.Drawing.Point(331, 18);
            this.dtpStartDate.Name = "dtpStartDate";
            this.dtpStartDate.Size = new System.Drawing.Size(200, 20);
            this.dtpStartDate.TabIndex = 8;
            this.dtpStartDate.ValueChanged += new System.EventHandler(this.dtpStartDate_ValueChanged);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(832, 15);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(90, 23);
            this.btnSearch.TabIndex = 10;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // dtpEndDate
            // 
            this.dtpEndDate.Location = new System.Drawing.Point(616, 18);
            this.dtpEndDate.Name = "dtpEndDate";
            this.dtpEndDate.Size = new System.Drawing.Size(200, 20);
            this.dtpEndDate.TabIndex = 9;
            this.dtpEndDate.ValueChanged += new System.EventHandler(this.dtpEndDate_ValueChanged);
            // 
            // cboxTransTypeFilter
            // 
            this.cboxTransTypeFilter.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboxTransTypeFilter.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboxTransTypeFilter.FormattingEnabled = true;
            this.cboxTransTypeFilter.Location = new System.Drawing.Point(6, 17);
            this.cboxTransTypeFilter.Name = "cboxTransTypeFilter";
            this.cboxTransTypeFilter.Size = new System.Drawing.Size(248, 21);
            this.cboxTransTypeFilter.TabIndex = 7;
            this.cboxTransTypeFilter.SelectedIndexChanged += new System.EventHandler(this.cboxTransTypeFilter_SelectedIndexChanged);
            this.cboxTransTypeFilter.Validating += new System.ComponentModel.CancelEventHandler(this.cboxTransTypeFilter_Validating);
            // 
            // dgvCashbookEntries
            // 
            this.dgvCashbookEntries.AllowUserToAddRows = false;
            this.dgvCashbookEntries.AllowUserToDeleteRows = false;
            this.dgvCashbookEntries.AllowUserToResizeColumns = false;
            this.dgvCashbookEntries.AllowUserToResizeRows = false;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.LightSkyBlue;
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.Color.White;
            this.dgvCashbookEntries.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle9;
            this.dgvCashbookEntries.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvCashbookEntries.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvCashbookEntries.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCashbookEntries.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.DateandTime,
            this.BranchCol,
            this.PBranchCol,
            this.ColumnTransactionListPUser,
            this.EntryType,
            this.Description,
            this.Amount,
            this.Total,
            this.ScannedFile,
            this.CapturedBy});
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle13.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle13.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle13.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle13.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvCashbookEntries.DefaultCellStyle = dataGridViewCellStyle13;
            this.dgvCashbookEntries.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvCashbookEntries.Location = new System.Drawing.Point(-4, 112);
            this.dgvCashbookEntries.Name = "dgvCashbookEntries";
            this.dgvCashbookEntries.ReadOnly = true;
            this.dgvCashbookEntries.RowHeadersVisible = false;
            this.dgvCashbookEntries.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCashbookEntries.Size = new System.Drawing.Size(1188, 190);
            this.dgvCashbookEntries.StandardTab = true;
            this.dgvCashbookEntries.TabIndex = 16;
            // 
            // id
            // 
            this.id.Frozen = true;
            this.id.HeaderText = "Transaction ID";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.id.Width = 102;
            // 
            // DateandTime
            // 
            this.DateandTime.Frozen = true;
            this.DateandTime.HeaderText = "Date and Time";
            this.DateandTime.Name = "DateandTime";
            this.DateandTime.ReadOnly = true;
            this.DateandTime.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.DateandTime.Width = 83;
            // 
            // BranchCol
            // 
            this.BranchCol.Frozen = true;
            this.BranchCol.HeaderText = "Branch";
            this.BranchCol.Name = "BranchCol";
            this.BranchCol.ReadOnly = true;
            this.BranchCol.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.BranchCol.Width = 47;
            // 
            // PBranchCol
            // 
            this.PBranchCol.Frozen = true;
            this.PBranchCol.HeaderText = "#Branch";
            this.PBranchCol.Name = "PBranchCol";
            this.PBranchCol.ReadOnly = true;
            this.PBranchCol.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.PBranchCol.Width = 54;
            // 
            // ColumnTransactionListPUser
            // 
            this.ColumnTransactionListPUser.HeaderText = "#User";
            this.ColumnTransactionListPUser.Name = "ColumnTransactionListPUser";
            this.ColumnTransactionListPUser.ReadOnly = true;
            this.ColumnTransactionListPUser.Width = 61;
            // 
            // EntryType
            // 
            this.EntryType.HeaderText = "Type";
            this.EntryType.Name = "EntryType";
            this.EntryType.ReadOnly = true;
            this.EntryType.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.EntryType.Width = 37;
            // 
            // Description
            // 
            this.Description.HeaderText = "Description";
            this.Description.Name = "Description";
            this.Description.ReadOnly = true;
            this.Description.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Description.Width = 66;
            // 
            // Amount
            // 
            this.Amount.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Amount.DefaultCellStyle = dataGridViewCellStyle10;
            this.Amount.HeaderText = "Amount";
            this.Amount.Name = "Amount";
            this.Amount.ReadOnly = true;
            this.Amount.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Amount.Width = 49;
            // 
            // Total
            // 
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Total.DefaultCellStyle = dataGridViewCellStyle11;
            this.Total.HeaderText = "Total";
            this.Total.Name = "Total";
            this.Total.ReadOnly = true;
            this.Total.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Total.Width = 37;
            // 
            // ScannedFile
            // 
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.ScannedFile.DefaultCellStyle = dataGridViewCellStyle12;
            this.ScannedFile.HeaderText = "Scanned File";
            this.ScannedFile.Name = "ScannedFile";
            this.ScannedFile.ReadOnly = true;
            this.ScannedFile.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ScannedFile.Width = 75;
            // 
            // CapturedBy
            // 
            this.CapturedBy.HeaderText = "Captured By";
            this.CapturedBy.Name = "CapturedBy";
            this.CapturedBy.ReadOnly = true;
            this.CapturedBy.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.CapturedBy.Width = 71;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(385, 206);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker1.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtCBAmount);
            this.groupBox1.Controls.Add(this.txtCBDescription);
            this.groupBox1.Controls.Add(this.btnSubmitTransaction);
            this.groupBox1.Controls.Add(this.cboxDorC);
            this.groupBox1.Controls.Add(this.cboxTransType);
            this.groupBox1.Controls.Add(this.comboBoxPBranchForCashbookEntryCapture);
            this.groupBox1.Controls.Add(this.labelPBranch);
            this.groupBox1.Controls.Add(this.labelPUser);
            this.groupBox1.Controls.Add(this.comboBoxPUsersForCashbookEntryCapture);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox1.Location = new System.Drawing.Point(3, 308);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1184, 51);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(454, 22);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(31, 13);
            this.label6.TabIndex = 15;
            this.label6.Text = "Type";
            // 
            // txtCBAmount
            // 
            this.txtCBAmount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCBAmount.Location = new System.Drawing.Point(973, 19);
            this.txtCBAmount.Name = "txtCBAmount";
            this.txtCBAmount.Size = new System.Drawing.Size(108, 20);
            this.txtCBAmount.TabIndex = 15;
            this.txtCBAmount.KeyDown += new System.Windows.Forms.KeyEventHandler(this.EnterToNextControlHandler);
            // 
            // txtCBDescription
            // 
            this.txtCBDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCBDescription.Location = new System.Drawing.Point(3, 19);
            this.txtCBDescription.Name = "txtCBDescription";
            this.txtCBDescription.Size = new System.Drawing.Size(445, 20);
            this.txtCBDescription.TabIndex = 10;
            this.txtCBDescription.KeyDown += new System.Windows.Forms.KeyEventHandler(this.EnterToNextControlHandler);
            // 
            // btnSubmitTransaction
            // 
            this.btnSubmitTransaction.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSubmitTransaction.Location = new System.Drawing.Point(1087, 17);
            this.btnSubmitTransaction.Name = "btnSubmitTransaction";
            this.btnSubmitTransaction.Size = new System.Drawing.Size(75, 23);
            this.btnSubmitTransaction.TabIndex = 16;
            this.btnSubmitTransaction.Text = "Submit";
            this.btnSubmitTransaction.UseVisualStyleBackColor = true;
            this.btnSubmitTransaction.Click += new System.EventHandler(this.btnSubmitTransaction_Click);
            // 
            // cboxDorC
            // 
            this.cboxDorC.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cboxDorC.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxDorC.FormattingEnabled = true;
            this.cboxDorC.Location = new System.Drawing.Point(863, 19);
            this.cboxDorC.Name = "cboxDorC";
            this.cboxDorC.Size = new System.Drawing.Size(104, 21);
            this.cboxDorC.TabIndex = 14;
            this.cboxDorC.SelectedIndexChanged += new System.EventHandler(this.cboxDorC_SelectedIndexChanged);
            this.cboxDorC.KeyDown += new System.Windows.Forms.KeyEventHandler(this.EnterToNextControlHandler);
            // 
            // cboxTransType
            // 
            this.cboxTransType.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.cboxTransType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboxTransType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboxTransType.FormattingEnabled = true;
            this.cboxTransType.Location = new System.Drawing.Point(491, 19);
            this.cboxTransType.Name = "cboxTransType";
            this.cboxTransType.Size = new System.Drawing.Size(187, 21);
            this.cboxTransType.TabIndex = 11;
            this.cboxTransType.SelectedIndexChanged += new System.EventHandler(this.cboxTransType_SelectedIndexChanged);
            this.cboxTransType.KeyDown += new System.Windows.Forms.KeyEventHandler(this.EnterToNextControlHandler);
            this.cboxTransType.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CloseComboxBoxDropDownIfUserTyped);
            this.cboxTransType.Validating += new System.ComponentModel.CancelEventHandler(this.cboxTransType_Validating);
            // 
            // comboBoxPBranchForCashbookEntryCapture
            // 
            this.comboBoxPBranchForCashbookEntryCapture.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.comboBoxPBranchForCashbookEntryCapture.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboBoxPBranchForCashbookEntryCapture.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBoxPBranchForCashbookEntryCapture.FormattingEnabled = true;
            this.comboBoxPBranchForCashbookEntryCapture.Location = new System.Drawing.Point(736, 19);
            this.comboBoxPBranchForCashbookEntryCapture.Name = "comboBoxPBranchForCashbookEntryCapture";
            this.comboBoxPBranchForCashbookEntryCapture.Size = new System.Drawing.Size(121, 21);
            this.comboBoxPBranchForCashbookEntryCapture.TabIndex = 12;
            this.comboBoxPBranchForCashbookEntryCapture.KeyDown += new System.Windows.Forms.KeyEventHandler(this.EnterToNextControlHandler);
            this.comboBoxPBranchForCashbookEntryCapture.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CloseComboxBoxDropDownIfUserTyped);
            this.comboBoxPBranchForCashbookEntryCapture.Validating += new System.ComponentModel.CancelEventHandler(this.cboxPBranch_Validating);
            // 
            // labelPBranch
            // 
            this.labelPBranch.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.labelPBranch.AutoSize = true;
            this.labelPBranch.Location = new System.Drawing.Point(682, 22);
            this.labelPBranch.Name = "labelPBranch";
            this.labelPBranch.Size = new System.Drawing.Size(48, 13);
            this.labelPBranch.TabIndex = 12;
            this.labelPBranch.Text = "#Branch";
            // 
            // labelPUser
            // 
            this.labelPUser.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.labelPUser.AutoSize = true;
            this.labelPUser.Location = new System.Drawing.Point(682, 22);
            this.labelPUser.Name = "labelPUser";
            this.labelPUser.Size = new System.Drawing.Size(36, 13);
            this.labelPUser.TabIndex = 16;
            this.labelPUser.Text = "#User";
            this.labelPUser.Visible = false;
            // 
            // comboBoxPUsersForCashbookEntryCapture
            // 
            this.comboBoxPUsersForCashbookEntryCapture.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.comboBoxPUsersForCashbookEntryCapture.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboBoxPUsersForCashbookEntryCapture.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBoxPUsersForCashbookEntryCapture.FormattingEnabled = true;
            this.comboBoxPUsersForCashbookEntryCapture.Location = new System.Drawing.Point(736, 19);
            this.comboBoxPUsersForCashbookEntryCapture.Name = "comboBoxPUsersForCashbookEntryCapture";
            this.comboBoxPUsersForCashbookEntryCapture.Size = new System.Drawing.Size(121, 21);
            this.comboBoxPUsersForCashbookEntryCapture.TabIndex = 13;
            this.comboBoxPUsersForCashbookEntryCapture.Visible = false;
            this.comboBoxPUsersForCashbookEntryCapture.KeyDown += new System.Windows.Forms.KeyEventHandler(this.EnterToNextControlHandler);
            this.comboBoxPUsersForCashbookEntryCapture.Validating += new System.ComponentModel.CancelEventHandler(this.comboBoxPUsersForCashbookEntryCapture_Validating);
            // 
            // tcProtea
            // 
            this.tcProtea.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tcProtea.Controls.Add(this.tpCashbook);
            this.tcProtea.Controls.Add(this.tpRecon);
            this.tcProtea.Controls.Add(this.tpBranchCashbookAndDropFigures);
            this.tcProtea.Controls.Add(this.tabPageTransactionTotalByPBranch);
            this.tcProtea.Controls.Add(this.tabPageTransactionTotalByPUser);
            this.tcProtea.Controls.Add(this.tabPageRaceCards);
            this.tcProtea.Location = new System.Drawing.Point(12, 71);
            this.tcProtea.Name = "tcProtea";
            this.tcProtea.SelectedIndex = 0;
            this.tcProtea.Size = new System.Drawing.Size(1198, 388);
            this.tcProtea.TabIndex = 6;
            // 
            // tabPageTransactionTotalByPBranch
            // 
            this.tabPageTransactionTotalByPBranch.Controls.Add(this.groupBox4);
            this.tabPageTransactionTotalByPBranch.Controls.Add(this.dataGridViewTransactionByPBranch);
            this.tabPageTransactionTotalByPBranch.Location = new System.Drawing.Point(4, 22);
            this.tabPageTransactionTotalByPBranch.Name = "tabPageTransactionTotalByPBranch";
            this.tabPageTransactionTotalByPBranch.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageTransactionTotalByPBranch.Size = new System.Drawing.Size(1190, 362);
            this.tabPageTransactionTotalByPBranch.TabIndex = 3;
            this.tabPageTransactionTotalByPBranch.Text = "Transaction Total By #Branch";
            this.tabPageTransactionTotalByPBranch.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox4.Controls.Add(this.ExportTransactonsByPBranch);
            this.groupBox4.Controls.Add(this.label4);
            this.groupBox4.Controls.Add(this.label7);
            this.groupBox4.Controls.Add(this.dateTimePickerPBranchAuditStart);
            this.groupBox4.Controls.Add(this.buttonDoPBranchAudit);
            this.groupBox4.Controls.Add(this.dateTimePickerPBranchAuditEnd);
            this.groupBox4.Controls.Add(this.comboBoxTransactionTotalByPBranchFilter);
            this.groupBox4.Location = new System.Drawing.Point(6, 6);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(1175, 45);
            this.groupBox4.TabIndex = 6;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Filter";
            // 
            // ExportTransactonsByPBranch
            // 
            this.ExportTransactonsByPBranch.Location = new System.Drawing.Point(929, 15);
            this.ExportTransactonsByPBranch.Name = "ExportTransactonsByPBranch";
            this.ExportTransactonsByPBranch.Size = new System.Drawing.Size(75, 23);
            this.ExportTransactonsByPBranch.TabIndex = 13;
            this.ExportTransactonsByPBranch.Text = "Export";
            this.ExportTransactonsByPBranch.UseVisualStyleBackColor = true;
            this.ExportTransactonsByPBranch.Click += new System.EventHandler(this.ExportTransactonsByPBranch_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(558, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "End Date";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(270, 22);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(55, 13);
            this.label7.TabIndex = 11;
            this.label7.Text = "Start Date";
            // 
            // dateTimePickerPBranchAuditStart
            // 
            this.dateTimePickerPBranchAuditStart.Location = new System.Drawing.Point(331, 18);
            this.dateTimePickerPBranchAuditStart.Name = "dateTimePickerPBranchAuditStart";
            this.dateTimePickerPBranchAuditStart.Size = new System.Drawing.Size(200, 20);
            this.dateTimePickerPBranchAuditStart.TabIndex = 8;
            // 
            // buttonDoPBranchAudit
            // 
            this.buttonDoPBranchAudit.Location = new System.Drawing.Point(832, 15);
            this.buttonDoPBranchAudit.Name = "buttonDoPBranchAudit";
            this.buttonDoPBranchAudit.Size = new System.Drawing.Size(90, 23);
            this.buttonDoPBranchAudit.TabIndex = 10;
            this.buttonDoPBranchAudit.Text = "Search";
            this.buttonDoPBranchAudit.UseVisualStyleBackColor = true;
            this.buttonDoPBranchAudit.Click += new System.EventHandler(this.buttonDoPBranchAudit_Click);
            // 
            // dateTimePickerPBranchAuditEnd
            // 
            this.dateTimePickerPBranchAuditEnd.Location = new System.Drawing.Point(616, 18);
            this.dateTimePickerPBranchAuditEnd.Name = "dateTimePickerPBranchAuditEnd";
            this.dateTimePickerPBranchAuditEnd.Size = new System.Drawing.Size(200, 20);
            this.dateTimePickerPBranchAuditEnd.TabIndex = 9;
            // 
            // comboBoxTransactionTotalByPBranchFilter
            // 
            this.comboBoxTransactionTotalByPBranchFilter.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboBoxTransactionTotalByPBranchFilter.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBoxTransactionTotalByPBranchFilter.FormattingEnabled = true;
            this.comboBoxTransactionTotalByPBranchFilter.Location = new System.Drawing.Point(6, 17);
            this.comboBoxTransactionTotalByPBranchFilter.Name = "comboBoxTransactionTotalByPBranchFilter";
            this.comboBoxTransactionTotalByPBranchFilter.Size = new System.Drawing.Size(248, 21);
            this.comboBoxTransactionTotalByPBranchFilter.TabIndex = 7;
            this.comboBoxTransactionTotalByPBranchFilter.Validating += new System.ComponentModel.CancelEventHandler(this.comboBoxTransactionTotalByPBranchFilter_Validating);
            // 
            // dataGridViewTransactionByPBranch
            // 
            this.dataGridViewTransactionByPBranch.AllowUserToAddRows = false;
            this.dataGridViewTransactionByPBranch.AllowUserToDeleteRows = false;
            this.dataGridViewTransactionByPBranch.AllowUserToResizeColumns = false;
            this.dataGridViewTransactionByPBranch.AllowUserToResizeRows = false;
            this.dataGridViewTransactionByPBranch.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewTransactionByPBranch.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridViewTransactionByPBranch.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridViewTransactionByPBranch.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnPBranch,
            this.ColumnTotalFromPBranchsCashbook,
            this.ColumnTotalFromCashbook,
            this.ColumnNetOfBranchAndPBranch});
            this.dataGridViewTransactionByPBranch.Location = new System.Drawing.Point(6, 57);
            this.dataGridViewTransactionByPBranch.Name = "dataGridViewTransactionByPBranch";
            this.dataGridViewTransactionByPBranch.RowHeadersVisible = false;
            this.dataGridViewTransactionByPBranch.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewTransactionByPBranch.Size = new System.Drawing.Size(1178, 312);
            this.dataGridViewTransactionByPBranch.TabIndex = 0;
            // 
            // ColumnPBranch
            // 
            this.ColumnPBranch.HeaderText = "#Branch";
            this.ColumnPBranch.Name = "ColumnPBranch";
            this.ColumnPBranch.Width = 73;
            // 
            // ColumnTotalFromPBranchsCashbook
            // 
            this.ColumnTotalFromPBranchsCashbook.HeaderText = "Total From #Branch\'s Cashbook";
            this.ColumnTotalFromPBranchsCashbook.Name = "ColumnTotalFromPBranchsCashbook";
            this.ColumnTotalFromPBranchsCashbook.Width = 184;
            // 
            // ColumnTotalFromCashbook
            // 
            this.ColumnTotalFromCashbook.HeaderText = "Total From Cashbook";
            this.ColumnTotalFromCashbook.Name = "ColumnTotalFromCashbook";
            this.ColumnTotalFromCashbook.Width = 133;
            // 
            // ColumnNetOfBranchAndPBranch
            // 
            this.ColumnNetOfBranchAndPBranch.HeaderText = "Net";
            this.ColumnNetOfBranchAndPBranch.Name = "ColumnNetOfBranchAndPBranch";
            this.ColumnNetOfBranchAndPBranch.Width = 49;
            // 
            // tabPageTransactionTotalByPUser
            // 
            this.tabPageTransactionTotalByPUser.Controls.Add(this.groupBox5);
            this.tabPageTransactionTotalByPUser.Controls.Add(this.dataGridViewTransactionByPUser);
            this.tabPageTransactionTotalByPUser.Location = new System.Drawing.Point(4, 22);
            this.tabPageTransactionTotalByPUser.Name = "tabPageTransactionTotalByPUser";
            this.tabPageTransactionTotalByPUser.Size = new System.Drawing.Size(1190, 362);
            this.tabPageTransactionTotalByPUser.TabIndex = 4;
            this.tabPageTransactionTotalByPUser.Text = "Transaction Total By #User";
            this.tabPageTransactionTotalByPUser.UseVisualStyleBackColor = true;
            // 
            // groupBox5
            // 
            this.groupBox5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox5.Controls.Add(this.ExportTransactionsByPUser);
            this.groupBox5.Controls.Add(this.label8);
            this.groupBox5.Controls.Add(this.label9);
            this.groupBox5.Controls.Add(this.dateTimePickerPUserAuditStart);
            this.groupBox5.Controls.Add(this.buttonDoPUserAudit);
            this.groupBox5.Controls.Add(this.dateTimePickerPUserAuditEnd);
            this.groupBox5.Controls.Add(this.comboBoxTransactionTotalByPUserFilter);
            this.groupBox5.Location = new System.Drawing.Point(8, 3);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(1179, 45);
            this.groupBox5.TabIndex = 7;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Filter";
            // 
            // ExportTransactionsByPUser
            // 
            this.ExportTransactionsByPUser.Location = new System.Drawing.Point(904, 16);
            this.ExportTransactionsByPUser.Name = "ExportTransactionsByPUser";
            this.ExportTransactionsByPUser.Size = new System.Drawing.Size(75, 22);
            this.ExportTransactionsByPUser.TabIndex = 13;
            this.ExportTransactionsByPUser.Text = "Export";
            this.ExportTransactionsByPUser.UseVisualStyleBackColor = true;
            this.ExportTransactionsByPUser.Click += new System.EventHandler(this.ExportTransactionsByPUser_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(558, 22);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(52, 13);
            this.label8.TabIndex = 12;
            this.label8.Text = "End Date";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(270, 22);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(55, 13);
            this.label9.TabIndex = 11;
            this.label9.Text = "Start Date";
            // 
            // dateTimePickerPUserAuditStart
            // 
            this.dateTimePickerPUserAuditStart.Location = new System.Drawing.Point(331, 18);
            this.dateTimePickerPUserAuditStart.Name = "dateTimePickerPUserAuditStart";
            this.dateTimePickerPUserAuditStart.Size = new System.Drawing.Size(200, 20);
            this.dateTimePickerPUserAuditStart.TabIndex = 8;
            // 
            // buttonDoPUserAudit
            // 
            this.buttonDoPUserAudit.Location = new System.Drawing.Point(832, 15);
            this.buttonDoPUserAudit.Name = "buttonDoPUserAudit";
            this.buttonDoPUserAudit.Size = new System.Drawing.Size(66, 23);
            this.buttonDoPUserAudit.TabIndex = 10;
            this.buttonDoPUserAudit.Text = "Search";
            this.buttonDoPUserAudit.UseVisualStyleBackColor = true;
            this.buttonDoPUserAudit.Click += new System.EventHandler(this.buttonDoPUserAudit_Click);
            // 
            // dateTimePickerPUserAuditEnd
            // 
            this.dateTimePickerPUserAuditEnd.Location = new System.Drawing.Point(616, 18);
            this.dateTimePickerPUserAuditEnd.Name = "dateTimePickerPUserAuditEnd";
            this.dateTimePickerPUserAuditEnd.Size = new System.Drawing.Size(200, 20);
            this.dateTimePickerPUserAuditEnd.TabIndex = 9;
            // 
            // comboBoxTransactionTotalByPUserFilter
            // 
            this.comboBoxTransactionTotalByPUserFilter.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboBoxTransactionTotalByPUserFilter.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBoxTransactionTotalByPUserFilter.FormattingEnabled = true;
            this.comboBoxTransactionTotalByPUserFilter.Location = new System.Drawing.Point(6, 17);
            this.comboBoxTransactionTotalByPUserFilter.Name = "comboBoxTransactionTotalByPUserFilter";
            this.comboBoxTransactionTotalByPUserFilter.Size = new System.Drawing.Size(248, 21);
            this.comboBoxTransactionTotalByPUserFilter.TabIndex = 7;
            this.comboBoxTransactionTotalByPUserFilter.Validating += new System.ComponentModel.CancelEventHandler(this.comboBoxTransactionTotalByPUserFilter_Validating);
            // 
            // dataGridViewTransactionByPUser
            // 
            this.dataGridViewTransactionByPUser.AllowUserToAddRows = false;
            this.dataGridViewTransactionByPUser.AllowUserToDeleteRows = false;
            this.dataGridViewTransactionByPUser.AllowUserToResizeColumns = false;
            this.dataGridViewTransactionByPUser.AllowUserToResizeRows = false;
            this.dataGridViewTransactionByPUser.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewTransactionByPUser.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridViewTransactionByPUser.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewTransactionByPUser.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnPUserStaffNo,
            this.ColumnPUserName,
            this.ColumnPUserTotal});
            this.dataGridViewTransactionByPUser.Location = new System.Drawing.Point(8, 54);
            this.dataGridViewTransactionByPUser.Name = "dataGridViewTransactionByPUser";
            this.dataGridViewTransactionByPUser.RowHeadersVisible = false;
            this.dataGridViewTransactionByPUser.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewTransactionByPUser.Size = new System.Drawing.Size(1179, 305);
            this.dataGridViewTransactionByPUser.TabIndex = 0;
            // 
            // ColumnPUserStaffNo
            // 
            this.ColumnPUserStaffNo.HeaderText = "Staff No";
            this.ColumnPUserStaffNo.Name = "ColumnPUserStaffNo";
            this.ColumnPUserStaffNo.Width = 71;
            // 
            // ColumnPUserName
            // 
            this.ColumnPUserName.HeaderText = "Name";
            this.ColumnPUserName.Name = "ColumnPUserName";
            this.ColumnPUserName.Width = 60;
            // 
            // ColumnPUserTotal
            // 
            this.ColumnPUserTotal.HeaderText = "Total";
            this.ColumnPUserTotal.Name = "ColumnPUserTotal";
            this.ColumnPUserTotal.Width = 56;
            // 
            // tabPageRaceCards
            // 
            this.tabPageRaceCards.Controls.Add(this.buttonDeliveries);
            this.tabPageRaceCards.Controls.Add(this.groupBoxPublicationSale);
            this.tabPageRaceCards.Location = new System.Drawing.Point(4, 22);
            this.tabPageRaceCards.Name = "tabPageRaceCards";
            this.tabPageRaceCards.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageRaceCards.Size = new System.Drawing.Size(1190, 362);
            this.tabPageRaceCards.TabIndex = 5;
            this.tabPageRaceCards.Text = "RaceCards";
            this.tabPageRaceCards.UseVisualStyleBackColor = true;
            this.tabPageRaceCards.Click += new System.EventHandler(this.tabPageRaceCards_Click);
            // 
            // buttonDeliveries
            // 
            this.buttonDeliveries.Location = new System.Drawing.Point(666, 7);
            this.buttonDeliveries.Name = "buttonDeliveries";
            this.buttonDeliveries.Size = new System.Drawing.Size(75, 23);
            this.buttonDeliveries.TabIndex = 2;
            this.buttonDeliveries.Text = "Deliveries";
            this.buttonDeliveries.UseVisualStyleBackColor = true;
            this.buttonDeliveries.Click += new System.EventHandler(this.buttonDeliveries_Click);
            // 
            // groupBoxPublicationSale
            // 
            this.groupBoxPublicationSale.Controls.Add(this.textBox1);
            this.groupBoxPublicationSale.Controls.Add(this.dataGridView2);
            this.groupBoxPublicationSale.Controls.Add(this.dateTimePickerPublicationSalesHistory);
            this.groupBoxPublicationSale.Controls.Add(this.textBoxTotalPriceOfPublicationSale);
            this.groupBoxPublicationSale.Controls.Add(this.label17);
            this.groupBoxPublicationSale.Controls.Add(this.textBoxPublicationDescription);
            this.groupBoxPublicationSale.Controls.Add(this.label14);
            this.groupBoxPublicationSale.Controls.Add(this.label13);
            this.groupBoxPublicationSale.Controls.Add(this.label12);
            this.groupBoxPublicationSale.Controls.Add(this.numericUpDownItemsInSale);
            this.groupBoxPublicationSale.Controls.Add(this.label11);
            this.groupBoxPublicationSale.Controls.Add(this.dataGridViewPublicationSalesHistory);
            this.groupBoxPublicationSale.Controls.Add(this.label10);
            this.groupBoxPublicationSale.Controls.Add(this.comboBoxPublications);
            this.groupBoxPublicationSale.Controls.Add(this.buttonPurchasePublications);
            this.groupBoxPublicationSale.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBoxPublicationSale.Location = new System.Drawing.Point(8, 7);
            this.groupBoxPublicationSale.Name = "groupBoxPublicationSale";
            this.groupBoxPublicationSale.Size = new System.Drawing.Size(651, 349);
            this.groupBoxPublicationSale.TabIndex = 0;
            this.groupBoxPublicationSale.TabStop = false;
            this.groupBoxPublicationSale.Text = "Publication Sale";
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.SystemColors.Window;
            this.textBox1.Location = new System.Drawing.Point(135, 44);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(217, 169);
            this.textBox1.TabIndex = 17;
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.AllowUserToDeleteRows = false;
            this.dataGridView2.AllowUserToResizeColumns = false;
            this.dataGridView2.AllowUserToResizeRows = false;
            this.dataGridView2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.ColumnHeadersVisible = false;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnPublicationSaleDeliveryDate});
            this.dataGridView2.Location = new System.Drawing.Point(10, 44);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowHeadersVisible = false;
            this.dataGridView2.Size = new System.Drawing.Size(119, 169);
            this.dataGridView2.TabIndex = 16;
            // 
            // ColumnPublicationSaleDeliveryDate
            // 
            this.ColumnPublicationSaleDeliveryDate.HeaderText = "Delivery Date";
            this.ColumnPublicationSaleDeliveryDate.Name = "ColumnPublicationSaleDeliveryDate";
            // 
            // dateTimePickerPublicationSalesHistory
            // 
            this.dateTimePickerPublicationSalesHistory.Location = new System.Drawing.Point(450, 52);
            this.dateTimePickerPublicationSalesHistory.Name = "dateTimePickerPublicationSalesHistory";
            this.dateTimePickerPublicationSalesHistory.Size = new System.Drawing.Size(190, 20);
            this.dateTimePickerPublicationSalesHistory.TabIndex = 15;
            this.dateTimePickerPublicationSalesHistory.ValueChanged += new System.EventHandler(this.dateTimePickerPublicationSalesHistory_ValueChanged);
            // 
            // textBoxTotalPriceOfPublicationSale
            // 
            this.textBoxTotalPriceOfPublicationSale.Enabled = false;
            this.textBoxTotalPriceOfPublicationSale.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxTotalPriceOfPublicationSale.Location = new System.Drawing.Point(71, 308);
            this.textBoxTotalPriceOfPublicationSale.Name = "textBoxTotalPriceOfPublicationSale";
            this.textBoxTotalPriceOfPublicationSale.Size = new System.Drawing.Size(164, 31);
            this.textBoxTotalPriceOfPublicationSale.TabIndex = 14;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(7, 321);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(58, 13);
            this.label17.TabIndex = 13;
            this.label17.Text = "Total Price";
            // 
            // textBoxPublicationDescription
            // 
            this.textBoxPublicationDescription.Location = new System.Drawing.Point(6, 242);
            this.textBoxPublicationDescription.Name = "textBoxPublicationDescription";
            this.textBoxPublicationDescription.Size = new System.Drawing.Size(235, 20);
            this.textBoxPublicationDescription.TabIndex = 12;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(6, 225);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(60, 13);
            this.label14.TabIndex = 11;
            this.label14.Text = "Description";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(3, 265);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(59, 13);
            this.label13.TabIndex = 10;
            this.label13.Text = "Publication";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(6, 28);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(220, 13);
            this.label12.TabIndex = 9;
            this.label12.Text = "Select Delivery from which Card is being Sold";
            // 
            // numericUpDownItemsInSale
            // 
            this.numericUpDownItemsInSale.Location = new System.Drawing.Point(205, 282);
            this.numericUpDownItemsInSale.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDownItemsInSale.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownItemsInSale.Name = "numericUpDownItemsInSale";
            this.numericUpDownItemsInSale.Size = new System.Drawing.Size(36, 20);
            this.numericUpDownItemsInSale.TabIndex = 5;
            this.numericUpDownItemsInSale.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericUpDownItemsInSale.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(355, 54);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(89, 13);
            this.label11.TabIndex = 5;
            this.label11.Text = "Sales History for :";
            this.label11.Click += new System.EventHandler(this.label11_Click);
            // 
            // dataGridViewPublicationSalesHistory
            // 
            this.dataGridViewPublicationSalesHistory.AllowUserToAddRows = false;
            this.dataGridViewPublicationSalesHistory.AllowUserToDeleteRows = false;
            this.dataGridViewPublicationSalesHistory.AllowUserToResizeColumns = false;
            this.dataGridViewPublicationSalesHistory.AllowUserToResizeRows = false;
            this.dataGridViewPublicationSalesHistory.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            this.dataGridViewPublicationSalesHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewPublicationSalesHistory.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnSalesHistoryDeliveryDate,
            this.ColumnSalesHistoryPublicationName,
            this.ColumnSalesHistoryQuantity,
            this.ColumnSalesHistoryTotalPrice});
            this.dataGridViewPublicationSalesHistory.Location = new System.Drawing.Point(358, 82);
            this.dataGridViewPublicationSalesHistory.Name = "dataGridViewPublicationSalesHistory";
            this.dataGridViewPublicationSalesHistory.RowHeadersVisible = false;
            this.dataGridViewPublicationSalesHistory.Size = new System.Drawing.Size(282, 262);
            this.dataGridViewPublicationSalesHistory.TabIndex = 4;
            this.dataGridViewPublicationSalesHistory.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView2_CellContentClick);
            // 
            // ColumnSalesHistoryDeliveryDate
            // 
            this.ColumnSalesHistoryDeliveryDate.HeaderText = "Delivered";
            this.ColumnSalesHistoryDeliveryDate.Name = "ColumnSalesHistoryDeliveryDate";
            this.ColumnSalesHistoryDeliveryDate.Width = 77;
            // 
            // ColumnSalesHistoryPublicationName
            // 
            this.ColumnSalesHistoryPublicationName.HeaderText = "Publication";
            this.ColumnSalesHistoryPublicationName.Name = "ColumnSalesHistoryPublicationName";
            this.ColumnSalesHistoryPublicationName.Width = 84;
            // 
            // ColumnSalesHistoryQuantity
            // 
            this.ColumnSalesHistoryQuantity.HeaderText = "Qty";
            this.ColumnSalesHistoryQuantity.Name = "ColumnSalesHistoryQuantity";
            this.ColumnSalesHistoryQuantity.Width = 48;
            // 
            // ColumnSalesHistoryTotalPrice
            // 
            this.ColumnSalesHistoryTotalPrice.HeaderText = "Total";
            this.ColumnSalesHistoryTotalPrice.Name = "ColumnSalesHistoryTotalPrice";
            this.ColumnSalesHistoryTotalPrice.Width = 56;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(176, 284);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(23, 13);
            this.label10.TabIndex = 4;
            this.label10.Text = "Qty";
            // 
            // comboBoxPublications
            // 
            this.comboBoxPublications.FormattingEnabled = true;
            this.comboBoxPublications.Location = new System.Drawing.Point(6, 281);
            this.comboBoxPublications.Name = "comboBoxPublications";
            this.comboBoxPublications.Size = new System.Drawing.Size(155, 21);
            this.comboBoxPublications.TabIndex = 3;
            // 
            // buttonPurchasePublications
            // 
            this.buttonPurchasePublications.AccessibleDescription = "";
            this.buttonPurchasePublications.Location = new System.Drawing.Point(251, 321);
            this.buttonPurchasePublications.Name = "buttonPurchasePublications";
            this.buttonPurchasePublications.Size = new System.Drawing.Size(87, 23);
            this.buttonPurchasePublications.TabIndex = 2;
            this.buttonPurchasePublications.Text = "Purchase";
            this.buttonPurchasePublications.UseVisualStyleBackColor = true;
            this.buttonPurchasePublications.Click += new System.EventHandler(this.buttonPurchasePublications_Click);
            // 
            // btnGroups
            // 
            this.btnGroups.Location = new System.Drawing.Point(162, 19);
            this.btnGroups.Name = "btnGroups";
            this.btnGroups.Size = new System.Drawing.Size(68, 23);
            this.btnGroups.TabIndex = 7;
            this.btnGroups.Text = "Groups";
            this.btnGroups.UseVisualStyleBackColor = true;
            this.btnGroups.Click += new System.EventHandler(this.btnGroups_Click);
            // 
            // gbEditEntities
            // 
            this.gbEditEntities.Controls.Add(this.btnGroups);
            this.gbEditEntities.Controls.Add(this.btnBranches);
            this.gbEditEntities.Controls.Add(this.btnTransactions);
            this.gbEditEntities.Location = new System.Drawing.Point(126, 12);
            this.gbEditEntities.Name = "gbEditEntities";
            this.gbEditEntities.Size = new System.Drawing.Size(236, 53);
            this.gbEditEntities.TabIndex = 8;
            this.gbEditEntities.TabStop = false;
            // 
            // gbBranch
            // 
            this.gbBranch.Controls.Add(this.textBoxDropSafe);
            this.gbBranch.Controls.Add(this.labelDropSafe);
            this.gbBranch.Controls.Add(this.labelCashbookBalance);
            this.gbBranch.Controls.Add(this.textBoxCashbookBalance);
            this.gbBranch.Controls.Add(this.label1);
            this.gbBranch.Controls.Add(this.cboxBranch);
            this.gbBranch.Location = new System.Drawing.Point(368, 12);
            this.gbBranch.Name = "gbBranch";
            this.gbBranch.Size = new System.Drawing.Size(545, 53);
            this.gbBranch.TabIndex = 9;
            this.gbBranch.TabStop = false;
            // 
            // textBoxDropSafe
            // 
            this.textBoxDropSafe.BackColor = System.Drawing.SystemColors.Window;
            this.textBoxDropSafe.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxDropSafe.Location = new System.Drawing.Point(457, 19);
            this.textBoxDropSafe.Name = "textBoxDropSafe";
            this.textBoxDropSafe.ReadOnly = true;
            this.textBoxDropSafe.Size = new System.Drawing.Size(84, 26);
            this.textBoxDropSafe.TabIndex = 10;
            // 
            // labelDropSafe
            // 
            this.labelDropSafe.AutoSize = true;
            this.labelDropSafe.Location = new System.Drawing.Point(396, 27);
            this.labelDropSafe.Name = "labelDropSafe";
            this.labelDropSafe.Size = new System.Drawing.Size(55, 13);
            this.labelDropSafe.TabIndex = 9;
            this.labelDropSafe.Text = "Drop Safe";
            // 
            // labelCashbookBalance
            // 
            this.labelCashbookBalance.AutoSize = true;
            this.labelCashbookBalance.Location = new System.Drawing.Point(185, 27);
            this.labelCashbookBalance.Name = "labelCashbookBalance";
            this.labelCashbookBalance.Size = new System.Drawing.Size(98, 13);
            this.labelCashbookBalance.TabIndex = 8;
            this.labelCashbookBalance.Text = "CashBook Balance";
            // 
            // textBoxCashbookBalance
            // 
            this.textBoxCashbookBalance.BackColor = System.Drawing.SystemColors.Window;
            this.textBoxCashbookBalance.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxCashbookBalance.Location = new System.Drawing.Point(289, 19);
            this.textBoxCashbookBalance.Name = "textBoxCashbookBalance";
            this.textBoxCashbookBalance.ReadOnly = true;
            this.textBoxCashbookBalance.Size = new System.Drawing.Size(84, 26);
            this.textBoxCashbookBalance.TabIndex = 7;
            // 
            // timer30sec
            // 
            this.timer30sec.Enabled = true;
            this.timer30sec.Interval = 30000;
            this.timer30sec.Tick += new System.EventHandler(this.timer30sec_Tick);
            // 
            // prntdocTransactions
            // 
            this.prntdocTransactions.BeginPrint += new System.Drawing.Printing.PrintEventHandler(this.prntdocTransactions_BeginPrint);
            this.prntdocTransactions.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.prntdocTransactions_PrintPage);
            // 
            // gbEditUsers
            // 
            this.gbEditUsers.Controls.Add(this.btnUsers);
            this.gbEditUsers.Location = new System.Drawing.Point(31, 12);
            this.gbEditUsers.Name = "gbEditUsers";
            this.gbEditUsers.Size = new System.Drawing.Size(89, 53);
            this.gbEditUsers.TabIndex = 10;
            this.gbEditUsers.TabStop = false;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1222, 471);
            this.Controls.Add(this.gbEditUsers);
            this.Controls.Add(this.gbBranch);
            this.Controls.Add(this.gbEditEntities);
            this.Controls.Add(this.tcProtea);
            this.Controls.Add(this.button4);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmMain";
            this.Text = "Protea ::";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.tpRecon.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.gbPendingTransfers.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvReconPending)).EndInit();
            this.gbCompletedTransfers.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvReconCompleted)).EndInit();
            this.gbTransfer.ResumeLayout(false);
            this.gbTransfer.PerformLayout();
            this.tpBranchCashbookAndDropFigures.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBranchBalances)).EndInit();
            this.tpCashbook.ResumeLayout(false);
            this.tpCashbook.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCashbookEntries)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tcProtea.ResumeLayout(false);
            this.tabPageTransactionTotalByPBranch.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTransactionByPBranch)).EndInit();
            this.tabPageTransactionTotalByPUser.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTransactionByPUser)).EndInit();
            this.tabPageRaceCards.ResumeLayout(false);
            this.groupBoxPublicationSale.ResumeLayout(false);
            this.groupBoxPublicationSale.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownItemsInSale)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPublicationSalesHistory)).EndInit();
            this.gbEditEntities.ResumeLayout(false);
            this.gbBranch.ResumeLayout(false);
            this.gbBranch.PerformLayout();
            this.gbEditUsers.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnUsers;
        private System.Windows.Forms.Button btnBranches;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboxBranch;
        private System.Windows.Forms.Button btnTransactions;
        private System.Windows.Forms.TabPage tpRecon;
        private System.Windows.Forms.GroupBox gbTransfer;
        private System.Windows.Forms.Button btnCancelTransfer;
        private System.Windows.Forms.Button btnProcessTransfer;
        private System.Windows.Forms.TextBox txtTransferAmount;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cboxTransferPartner;
        private System.Windows.Forms.RadioButton rbRecieveCashFrom;
        private System.Windows.Forms.RadioButton rbGiveCashTo;
        private System.Windows.Forms.TabPage tpBranchCashbookAndDropFigures;
        private System.Windows.Forms.DataGridView dgvBranchBalances;
        private System.Windows.Forms.DataGridViewTextBoxColumn CompanysBranch;
        private System.Windows.Forms.DataGridViewTextBoxColumn CBBalance;
        private System.Windows.Forms.DataGridViewTextBoxColumn DropSafe;
        private System.Windows.Forms.Button btnDropRefresh;
        private System.Windows.Forms.TabPage tpCashbook;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpStartDate;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.DateTimePicker dtpEndDate;
        private System.Windows.Forms.ComboBox cboxTransTypeFilter;
        private System.Windows.Forms.DataGridView dgvCashbookEntries;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtCBAmount;
        private System.Windows.Forms.TextBox txtCBDescription;
        private System.Windows.Forms.Button btnSubmitTransaction;
        private System.Windows.Forms.ComboBox cboxDorC;
        private System.Windows.Forms.ComboBox cboxTransType;
        private System.Windows.Forms.TabControl tcProtea;
        private System.Windows.Forms.ComboBox cboxReconUserBeingViewed;
        private System.Windows.Forms.DateTimePicker dtpReconViewerDateTime;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView dgvReconPending;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.CheckBox chkboxShowTransactions;
        private System.Windows.Forms.Button btnGroups;
        private System.Windows.Forms.GroupBox gbEditEntities;
        private System.Windows.Forms.GroupBox gbBranch;
        private System.Windows.Forms.GroupBox gbPendingTransfers;
        private System.Windows.Forms.GroupBox gbCompletedTransfers;
        private System.Windows.Forms.DataGridView dgvReconCompleted;
        private System.Windows.Forms.DataGridViewTextBoxColumn ReconDescCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn ReconAmountCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn ReconCapturerCol;
        private System.Windows.Forms.TextBox textBoxDropSafe;
        private System.Windows.Forms.Label labelDropSafe;
        private System.Windows.Forms.Label labelCashbookBalance;
        private System.Windows.Forms.TextBox textBoxCashbookBalance;
        private System.Windows.Forms.Timer timer30sec;
        private System.Windows.Forms.Label labelPBranch;
        private System.Windows.Forms.ComboBox comboBoxPBranchForCashbookEntryCapture;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TabPage tabPageTransactionTotalByPBranch;
        private System.Windows.Forms.DataGridView dataGridViewTransactionByPBranch;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DateTimePicker dateTimePickerPBranchAuditStart;
        private System.Windows.Forms.Button buttonDoPBranchAudit;
        private System.Windows.Forms.DateTimePicker dateTimePickerPBranchAuditEnd;
        private System.Windows.Forms.ComboBox comboBoxTransactionTotalByPBranchFilter;
        private System.Windows.Forms.ComboBox comboBoxPUsersForCashbookEntryCapture;
        private System.Windows.Forms.Label labelPUser;
        private System.Windows.Forms.TabPage tabPageTransactionTotalByPUser;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DateTimePicker dateTimePickerPUserAuditStart;
        private System.Windows.Forms.Button buttonDoPUserAudit;
        private System.Windows.Forms.DateTimePicker dateTimePickerPUserAuditEnd;
        private System.Windows.Forms.ComboBox comboBoxTransactionTotalByPUserFilter;
        private System.Windows.Forms.DataGridView dataGridViewTransactionByPUser;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPUserStaffNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPUserName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPUserTotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPBranch;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnTotalFromPBranchsCashbook;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnTotalFromCashbook;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnNetOfBranchAndPBranch;
        private System.Windows.Forms.TabPage tabPageRaceCards;
        private System.Windows.Forms.GroupBox groupBoxPublicationSale;
        private System.Windows.Forms.Button buttonPurchasePublications;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.DataGridView dataGridViewPublicationSalesHistory;
        private System.Windows.Forms.ComboBox comboBoxPublications;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.NumericUpDown numericUpDownItemsInSale;
        private System.Windows.Forms.TextBox textBoxPublicationDescription;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox textBoxTotalPriceOfPublicationSale;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnSalesHistoryDeliveryDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnSalesHistoryPublicationName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnSalesHistoryQuantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnSalesHistoryTotalPrice;
        private System.Windows.Forms.DateTimePicker dateTimePickerPublicationSalesHistory;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPublicationSaleDeliveryDate;
        private System.Windows.Forms.Button buttonDeliveries;
        private System.Windows.Forms.Button btnPrintTransactions;
        private System.Drawing.Printing.PrintDocument prntdocTransactions;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn DateandTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn BranchCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn PBranchCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnTransactionListPUser;
        private System.Windows.Forms.DataGridViewTextBoxColumn EntryType;
        private System.Windows.Forms.DataGridViewTextBoxColumn Description;
        private System.Windows.Forms.DataGridViewTextBoxColumn Amount;
        private System.Windows.Forms.DataGridViewTextBoxColumn Total;
        private System.Windows.Forms.DataGridViewTextBoxColumn ScannedFile;
        private System.Windows.Forms.DataGridViewTextBoxColumn CapturedBy;
        private System.Windows.Forms.GroupBox gbEditUsers;
        private System.Windows.Forms.Button ExportTransactions;
        private System.Windows.Forms.Button ExportBranchFigures;
        private System.Windows.Forms.Button ExportTransactonsByPBranch;
        private System.Windows.Forms.Button ExportTransactionsByPUser;
    }
}

