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
    public partial class frmTransactions : Form
    {
        public frmTransactions()
        {
            InitializeComponent();
            PopulateTransactionList();
        }

        private void PopulateTransactionList()
        {
            dgvTransactions.Rows.Clear();
            List<TransType> branches = TransType.GetTransTypes();

            for (int i = 0; i < branches.Count(); i++)
            {
                TransType temptransaction = branches.ToList()[i];
                DataGridViewRow transtyperow = new DataGridViewRow();
                transtyperow.CreateCells(dgvTransactions);

                transtyperow.Cells[dgvTransactions.Columns["TransDescription"].Index].Value = temptransaction.TransDescription;
                transtyperow.Cells[dgvTransactions.Columns["DropSafe"].Index].Value = temptransaction.DropSafe;
                transtyperow.Cells[dgvTransactions.Columns["Recon"].Index].Value = temptransaction.Recon;
                transtyperow.Tag = temptransaction;

                dgvTransactions.Rows.Add(transtyperow);
            }
        }
        private void btnAddTransaction_Click(object sender, EventArgs e)
        {
            frmTransaction FormTransaction = new frmTransaction();
            FormTransaction.ShowDialog();
            PopulateTransactionList();
        }

        private void dgvTransactions_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvTransactions_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            frmTransaction FormTransaction = new frmTransaction((TransType)(dgvTransactions.SelectedRows[0].Tag));
            FormTransaction.ShowDialog();
            PopulateTransactionList();
        }
    }
}
