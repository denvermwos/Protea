using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Protea
{
    public class Delivery
    {
        public int DeliveryID;
        public DateTime DeliveryDate;
        public Branch Branch;
        public bool DeliveryReturned;
        public User UserReturnedBy;

        public Delivery()
        {
        }

        public Delivery(DateTime deliveryDate, Branch branch, bool deliveryReturned, User userReturnedBy)
        {
            DeliveryDate = deliveryDate;
            Branch = branch;
            DeliveryReturned = deliveryReturned;
            UserReturnedBy = userReturnedBy;
        }
        public Delivery(int deliveryID, DateTime deliveryDate, Branch branch, bool deliveryReturned, User userReturnedBy)
        {
            DeliveryID = deliveryID;
            DeliveryDate = deliveryDate;
            Branch = branch;
            DeliveryReturned = deliveryReturned;
            UserReturnedBy = userReturnedBy;
        }

        public static List<Delivery> GetReturnedDeliveries(DateTime StartDate, Branch Branch)
        {
            List<Delivery> returnedDeliveries = new List<Delivery>();

            SqlConnection GetReturnedDeliveriesConn = ConnFactory.GetConnection();

            try
            {
                GetReturnedDeliveriesConn.Open();
            }
            catch (Exception ex)
            {
                ExceptionLogger.LogMessage(ex);
            }

            SqlCommand uspGetReturnedDeliveriesCommand = new SqlCommand("uspGetReturnedDeliveries", GetReturnedDeliveriesConn);
            uspGetReturnedDeliveriesCommand.CommandType = CommandType.StoredProcedure;
            uspGetReturnedDeliveriesCommand.Parameters.AddWithValue("@StartDate", StartDate);
            uspGetReturnedDeliveriesCommand.Parameters.AddWithValue("@BranchID", Branch.BranchID);
            

            //SqlParameter returnValue = new SqlParameter();
            //returnValue.Direction = ParameterDirection.ReturnValue;
            //uspGetReturnedDeliveriesCommand.Parameters.Add(returnValue);

            try
            {
                SqlDataReader returnedDeliveriesReader = null;
                returnedDeliveriesReader = uspGetReturnedDeliveriesCommand.ExecuteReader();

                while (returnedDeliveriesReader.Read())
                {
                    
                    //public int DeliveryID;
                    //public DateTime DeliveryDate;
                    //public Branch Branch;
                    //public bool DeliveryReturned;
                    //public User UserReturnedBy;



                    int deliveryID = Convert.ToInt16(returnedDeliveriesReader["DeliveryID"]);
                    DateTime deliveryDate = Convert.ToDateTime(returnedDeliveriesReader["DeliveryDate"]);
                    Branch branch = new Branch(Convert.ToInt16(returnedDeliveriesReader["BranchID"]), returnedDeliveriesReader["BranchName"].ToString(), Convert.ToDecimal(returnedDeliveriesReader["CBBalance"]), Convert.ToDecimal(returnedDeliveriesReader["DropBalance"]));
                    bool deliveryReturned = Convert.ToBoolean(returnedDeliveriesReader["DeliveryReturned"]);
                    User userReturnedBy = new User(Convert.ToInt16(returnedDeliveriesReader["UserID"]), returnedDeliveriesReader["FName"].ToString(), returnedDeliveriesReader["LName"].ToString());

                    Delivery tempDelivery = new Delivery(deliveryID,deliveryDate,branch,deliveryReturned,userReturnedBy);//(publicationSaleDate, publicationDeliveryDate, publication, userPublicationSoldBy, branchPublicationSoldIn, description, quantity, totalPrice);

                    returnedDeliveries.Add(tempDelivery);


                }




            }
            catch (Exception ex)
            {
                ExceptionLogger.LogMessage(ex);
            }
            try
            {
                GetReturnedDeliveriesConn.Close();
            }
            catch (Exception ex)
            {
                ExceptionLogger.LogMessage(ex);
            }

            //try
            //{
            //    int errorCode = (int)returnValue.Value;
            //    if (errorCode == 0)
            //    {
            //        result = "";
            //    }
            //    else if (errorCode == 1)
            //    {
            //        result = "Selected delivery has already been returned";
            //    }
            //    else if (errorCode == 2)
            //    {
            //        result = "Delivery does not exist";
            //    }
            //}
            //catch
            //{
            //}



            //return result;

            return returnedDeliveries;
        }

        public static List<Delivery> GetUnreturnedDeliveries(Branch Branch)
        {
            List<Delivery> unreturnedDeliveries = new List<Delivery>();

            SqlConnection GetUnreturnedDeliveriesConn = ConnFactory.GetConnection();

            try
            {
                GetUnreturnedDeliveriesConn.Open();
            }
            catch (Exception ex)
            {
                ExceptionLogger.LogMessage(ex);
            }

            SqlCommand uspGetUnreturnedDeliveriesCommand = new SqlCommand("uspGetUnreturnedDeliveries", GetUnreturnedDeliveriesConn);
            uspGetUnreturnedDeliveriesCommand.CommandType = CommandType.StoredProcedure;


            uspGetUnreturnedDeliveriesCommand.Parameters.AddWithValue("@BranchID", Branch.BranchID);
            //SqlParameter returnValue = new SqlParameter();
            //returnValue.Direction = ParameterDirection.ReturnValue;
            //uspGetUnreturnedDeliveriesCommand.Parameters.Add(returnValue);

            try
            {
                SqlDataReader unreturnedDeliveriesReader = null;
                unreturnedDeliveriesReader = uspGetUnreturnedDeliveriesCommand.ExecuteReader();

                while (unreturnedDeliveriesReader.Read())
                {

                    
                    int deliveryID = Convert.ToInt16(unreturnedDeliveriesReader["DeliveryID"]);
                    DateTime deliveryDate = Convert.ToDateTime(unreturnedDeliveriesReader["DeliveryDate"]);
                    Branch branch = new Branch(Convert.ToInt16(unreturnedDeliveriesReader["BranchID"]), unreturnedDeliveriesReader["BranchName"].ToString(), Convert.ToDecimal(unreturnedDeliveriesReader["CBBalance"]), Convert.ToDecimal(unreturnedDeliveriesReader["DropBalance"]));
                    bool deliveryUnreturned = Convert.ToBoolean(unreturnedDeliveriesReader["DeliveryReturned"]);
                    User userUnreturnedBy = new User(Convert.ToInt16(unreturnedDeliveriesReader["UserID"]), unreturnedDeliveriesReader["FName"].ToString(), unreturnedDeliveriesReader["LName"].ToString());

                    Delivery tempDelivery = new Delivery(deliveryID, deliveryDate, branch, deliveryUnreturned, userUnreturnedBy);//(publicationSaleDate, publicationDeliveryDate, publication, userPublicationSoldBy, branchPublicationSoldIn, description, quantity, totalPrice);

                    unreturnedDeliveries.Add(tempDelivery);


                }




            }
            catch (Exception ex)
            {
                ExceptionLogger.LogMessage(ex);
            }
            try
            {
                GetUnreturnedDeliveriesConn.Close();
            }
            catch (Exception ex)
            {
                ExceptionLogger.LogMessage(ex);
            }

            

            return unreturnedDeliveries;
        }
        public string Update()
        {
            return "";
        }
        public string Insert()
        {
            return "";
        }
    }
}
