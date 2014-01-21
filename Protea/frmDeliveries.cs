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
    public partial class frmDeliveries : Form
    {
        public frmDeliveries()
        {
            InitializeComponent();
            PopulateUnreturnedDeliveries();
            PopulateReturnedDeliveries();
        }

        public void PopulateUnreturnedDeliveries()
        {
            dataGridViewUnreturnedDeliveries.Rows.Clear();
            List<Delivery> unreturnedDeliveries = Delivery.GetUnreturnedDeliveries(frmMain.cbUser.UserBranch);
            for (int i = 0; i < unreturnedDeliveries.Count(); i++)
            {
                DataGridViewRow unreturnedDeliveryRow = new DataGridViewRow();
                unreturnedDeliveryRow.CreateCells(dataGridViewUnreturnedDeliveries);
                unreturnedDeliveryRow.Cells[ColumnUnreturnedDeliveryDate.Index].Value = unreturnedDeliveries[i].DeliveryDate.ToString("dd MMM");
                unreturnedDeliveryRow.Cells[ColumnUnreturnedDeliveryBranch.Index].Value = unreturnedDeliveries[i].Branch;
                unreturnedDeliveryRow.Tag = unreturnedDeliveries[i];
                dataGridViewUnreturnedDeliveries.Rows.Add(unreturnedDeliveryRow);
            }
        }
        public void PopulateReturnedDeliveries()
        {
            dataGridViewReturnedDeliveries.Rows.Clear();
            List<Delivery> returnedDeliveries = Delivery.GetReturnedDeliveries(dateTimeReturnedDeliveryStartDate.Value.Date,frmMain.cbUser.UserBranch);
            for (int i = 0; i < returnedDeliveries.Count(); i++)
            {
                DataGridViewRow returnedDeliveryRow = new DataGridViewRow();
                returnedDeliveryRow.CreateCells(dataGridViewReturnedDeliveries);
                returnedDeliveryRow.Cells[ColumnReturnedDeliveryDate.Index].Value = returnedDeliveries[i].DeliveryDate.ToString("dd MMM");
                returnedDeliveryRow.Cells[ColumnReturnedDeliveryBranch.Index].Value = returnedDeliveries[i].Branch;
                returnedDeliveryRow.Tag = returnedDeliveries[i];
                dataGridViewReturnedDeliveries.Rows.Add(returnedDeliveryRow);
            }
        }

        private void dataGridViewUnreturnedDeliveries_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Delivery selectedDelivery = ((Delivery)dataGridViewUnreturnedDeliveries.SelectedRows[0].Tag);
            frmDelivery frmDelivery = new frmDelivery(selectedDelivery);
            frmDelivery.Show();
        }

        private void dataGridViewReturnedDeliveries_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Delivery selectedDelivery = ((Delivery)dataGridViewReturnedDeliveries.SelectedRows[0].Tag);
            frmDelivery frmDelivery = new frmDelivery(selectedDelivery);
            frmDelivery.Show();
        }

        private void dateTimeReturnedDeliveryStartDate_ValueChanged(object sender, EventArgs e)
        {
            PopulateReturnedDeliveries();
            PopulateUnreturnedDeliveries();
        }
    }
}
