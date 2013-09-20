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
    public partial class frmReceipt : Form
    {
        private FileMover fm;
        private bool FileExists;
        private bool hasAccessToUpload;
        public frmReceipt()
        {
            InitializeComponent();
        }
        public frmReceipt(CashbookEntry cashbookentry,bool fileexists,bool hasaccesstoupload)
        {
            InitializeComponent();
            fm = new FileMover(cashbookentry);
            
            FileExists = fileexists;
            hasAccessToUpload = hasaccesstoupload;
            
            if (!FileExists)
            {
                btnDownload.Visible = false;
            }
            
        }
        private void Wait()
        {
            
            btnCancelReceipt.Visible = false;
            btnDownload.Visible = false;
            btnUpload.Visible = false;
            lblWait.Visible = true;
            
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {

            if (hasAccessToUpload)
            {
                Wait();
                DialogResult = fm.Up();
            }
            else
            {
                MessageBox.Show("Only the user who made this entry can attach a receipt to it");
            }
            
            this.DialogResult = DialogResult.Cancel;
        }

        private void btnDownload_Click(object sender, EventArgs e)
        {
            Wait();
            this.DialogResult = fm.Down();

        }
    }
}
