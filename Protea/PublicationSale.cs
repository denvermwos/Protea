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
        public Branch Branch { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public decimal TotalPrice { get; set; }


        public PublicationSale(DateTime publicationSaleDate, DateTime publicationDeliveryDate, Publication publication, User user, Branch branch, string description, int quantity, decimal totalPrice)
        {
            PublicationSaleDate = publicationSaleDate;
            PublicationDeliveryDate = publicationDeliveryDate;
            Publication = publication;
            User = user;
            Branch = branch;
            Description = description;
            Quantity = quantity;
            TotalPrice = totalPrice;
        }
        public string Sell()
        {
            string result = "No Sale";

            
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
            uspSellPublicationCommand.CommandType = CommandType.StoredProcedure;
            uspSellPublicationCommand.Parameters.AddWithValue("@PublicationSaleDate", PublicationSaleDate);
            uspSellPublicationCommand.Parameters.AddWithValue("@PublicationDeliveryDate",PublicationDeliveryDate);
            uspSellPublicationCommand.Parameters.AddWithValue("@BranchID", User.UserBranch.BranchID);
            uspSellPublicationCommand.Parameters.AddWithValue("@Description", Description);
            uspSellPublicationCommand.Parameters.AddWithValue("@PublicationID", Publication.PublicationID);
            uspSellPublicationCommand.Parameters.AddWithValue("@PublicationName", Publication.PublicationName);
            uspSellPublicationCommand.Parameters.AddWithValue("@Quantity", Quantity);
            uspSellPublicationCommand.Parameters.AddWithValue("@UserID", User.UserID);

            SqlParameter returnValue = new SqlParameter();
            returnValue.Direction = ParameterDirection.ReturnValue;
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
                    result = "";
                }
                else if (errorCode == 1)
                {
                    result = "Selected delivery has already been returned";
                }
                else
                {
                    result = "An unknown error has occurred";
                }
            }
            catch
            {
            }



            return result;
        }
        public static List<PublicationSale> GetPublicationSales(DateTime startDate,Branch branchOfSale)
        {
            List<PublicationSale> publicationSales = new List<PublicationSale>();


            SqlConnection getPublicationSalesConn = ConnFactory.GetConnection();

            try
            {
                getPublicationSalesConn.Open();
            }
            catch (Exception ex)
            {
                ExceptionLogger.LogMessage(ex);
            }



            //SqlParameter StartDateParam = new SqlParameter("@StartDate", SqlDbType.DateTime);
            //StartDateParam.Value = startDate.Date;
            //SqlParameter EndDateParam = new SqlParameter("@EndDate", SqlDbType.DateTime);
            //EndDateParam.Value = endDate.Date.AddDays(1);
            //SqlParameter BranchIDParam = new SqlParameter("@BranchID", SqlDbType.Int);
            //BranchIDParam.Value = branchToAudit.BranchID;
            //SqlParameter TransTypeIDParam = new SqlParameter("@TransTypeID", SqlDbType.Int);
            //TransTypeIDParam.Value = transactionToAudit.TransTypeID;

            SqlCommand getPublicationSales = new SqlCommand("uspGetPublicationSales", getPublicationSalesConn);

            getPublicationSales.Parameters.AddWithValue("@PublicationSaleStartDate", startDate.Date);
            getPublicationSales.Parameters.AddWithValue("@PublicationSaleEndDate", startDate.Date.AddDays(1));
            getPublicationSales.Parameters.AddWithValue("@BranchID", branchOfSale.BranchID);
            getPublicationSales.CommandType = CommandType.StoredProcedure;
            //myCommand.Parameters.Add(StartDateParam);
            //myCommand.Parameters.Add(EndDateParam);
            //myCommand.Parameters.Add(BranchIDParam);
            //myCommand.Parameters.Add(TransTypeIDParam);

            try
            {
                SqlDataReader myReader = null;
                myReader = getPublicationSales.ExecuteReader();

                while (myReader.Read())
                {
                    int publicationSaleID = Convert.ToInt16(myReader["PublicationSaleID"]);
                    DateTime publicationSaleDate = Convert.ToDateTime(myReader["PublicationSaleDate"]);
                    DateTime publicationDeliveryDate = Convert.ToDateTime(myReader["PublicationDeliveryDate"]);
                    string description = myReader["Description"].ToString();
                    int quantity = Convert.ToInt16(myReader["Quantity"]);
                    decimal totalPrice = Convert.ToDecimal(myReader["TotalPrice"]);
                    Branch branchPublicationSoldIn = new Branch(Convert.ToInt16(myReader["BranchID"]), myReader["BranchName"].ToString(), Convert.ToDecimal(myReader["CBBalance"]), Convert.ToDecimal(myReader["DropBalance"]));
                    User userPublicationSoldBy = new User(Convert.ToInt16(myReader["UserID"]), myReader["FName"].ToString(), myReader["LName"].ToString());
                    Publication publication = new Publication(Convert.ToInt32(myReader["PublicationID"]), myReader["PublicationName"].ToString(), Convert.ToDecimal(myReader["PublicationPrice"]));

                    PublicationSale tempPublicationSale = new PublicationSale(publicationSaleDate, publicationDeliveryDate, publication, userPublicationSoldBy, branchPublicationSoldIn, description, quantity, totalPrice);

                    publicationSales.Add(tempPublicationSale);


                }

            }
            catch (Exception ex)
            {
                ExceptionLogger.LogMessage(ex);
            }
            try
            {
                getPublicationSalesConn.Close();
            }
            catch (Exception ex)
            {
                ExceptionLogger.LogMessage(ex);
            }


            return publicationSales;
        }
    }
}
