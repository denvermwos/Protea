using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;


namespace Protea
{
    public class PublicationSale
    {
        public DateTime PublicationSaleDate { get; set; }
        public DateTime PublicationDeliveryDate { get; set; }
        public Publication Publication { get; set; }
        public User User { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public decimal TotalPrice { get; set; }
        
        public bool Sell()
        {
            bool result = false;

            
            SqlConnection SellPublicationConn = ConnFactory.GetConnection();

            try
            {
                SellPublicationConn.Open();
            }
            catch (Exception ex)
            {
                ExceptionLogger.LogMessage(ex);
            }

            SqlCommand uspSellPublicationCommand = new SqlCommand("uspSellPublication", SellPublicationConn);
            uspSellPublicationCommand.Parameters.AddWithValue("@PublicationSaleDate", PublicationSaleDate);
            uspSellPublicationCommand.Parameters.AddWithValue("@PublicationDeliveryDate",PublicationDeliveryDate);
            uspSellPublicationCommand.Parameters.AddWithValue("@BranchID", User.UserBranch.BranchID);
            uspSellPublicationCommand.Parameters.AddWithValue("@Description", Description);
            uspSellPublicationCommand.Parameters.AddWithValue("@PublicationID", Publication.PublicationID);
            uspSellPublicationCommand.Parameters.AddWithValue("@PublicationName", Publication.PublicationName);
            uspSellPublicationCommand.Parameters.AddWithValue("@Quantity", Quantity);
            uspSellPublicationCommand.Parameters.AddWithValue("@UserID", User.UserID);

            SqlParameter returnValue = new SqlParameter();
            uspSellPublicationCommand.Parameters.Add(returnValue);
            
            try
            {
                uspSellPublicationCommand.ExecuteNonQuery();
                               
            }
            catch (Exception ex)
            {
                ExceptionLogger.LogMessage(ex);
            }
            try
            {
                SellPublicationConn.Close();
            }
            catch (Exception ex)
            {
                ExceptionLogger.LogMessage(ex);
            }

            try
            {
                int errorCode = (int)returnValue.Value;
                if (errorCode != 0 )
                {
                    result = false;
                }
                else
                {
                    result = true;
                }
            }
            catch
            {
            }



            return result;
        }
    }
}
