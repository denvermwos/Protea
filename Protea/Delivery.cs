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
        public string DeliveryDescription;
        public User UserReturnedBy;

        public Delivery()
        {
        }

        public Delivery(DateTime deliveryDate, Branch branch, bool deliveryReturned, string deliveryDescription, User userReturnedBy)
        {
            DeliveryDate = deliveryDate;
            Branch = branch;
            DeliveryReturned = deliveryReturned;
            DeliveryDescription = deliveryDescription;
            UserReturnedBy = userReturnedBy;
            
        }
        public Delivery(int deliveryID, DateTime deliveryDate, Branch branch, bool deliveryReturned, string deliveryDescription, User userReturnedBy)
        {
            DeliveryID = deliveryID;
            DeliveryDate = deliveryDate;
            Branch = branch;
            DeliveryReturned = deliveryReturned;
            DeliveryDescription = deliveryDescription;
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
                    string deliveryDescription = returnedDeliveriesReader["DeliveryDescription"].ToString();

                    int userid = Convert.ToInt32(returnedDeliveriesReader["RetUserID"]);
                    string fname = returnedDeliveriesReader["RetFName"].ToString();
                    string lname = returnedDeliveriesReader["RetLName"].ToString();

                    User userReturnedBy = new User(userid, fname, lname);
                    
                    Delivery tempDelivery = new Delivery(deliveryID,deliveryDate,branch,deliveryReturned,deliveryDescription, userReturnedBy);//(publicationSaleDate, publicationDeliveryDate, publication, userPublicationSoldBy, branchPublicationSoldIn, description, quantity, totalPrice);

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
                    bool deliveryReturned = Convert.ToBoolean(unreturnedDeliveriesReader["DeliveryReturned"]);
                    string deliveryDescription = unreturnedDeliveriesReader["DeliveryDescription"].ToString();



                    int userid = Convert.ToInt32(unreturnedDeliveriesReader["RetUserID"]);
                    string fname = unreturnedDeliveriesReader["RetFName"].ToString();
                    string lname = unreturnedDeliveriesReader["RetLName"].ToString();
                    
                    User userReturnedBy = new User(userid,fname, lname);

                    Delivery tempDelivery = new Delivery(deliveryID, deliveryDate, branch, deliveryReturned, deliveryDescription, userReturnedBy);//, userUnreturnedBy);//(publicationSaleDate, publicationDeliveryDate, publication, userPublicationSoldBy, branchPublicationSoldIn, description, quantity, totalPrice);

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
        public Boolean Save()
        {
            Boolean result = false;
            if (DeliveryID == null)
            {
                result = Insert();
            }
            else
            {
                result = Update();
            }
            return result;
        }
        public Boolean Update()
        {

            Boolean result = false;

            SqlConnection updateDeliveryConn = ConnFactory.GetConnection();

            try
            {
                updateDeliveryConn.Open();
            }
            catch (Exception ex)
            {
                ExceptionLogger.LogMessage(ex);
            }

            SqlCommand updateDeliveryCommand = new SqlCommand("uspUpdateDelivery", updateDeliveryConn);
            updateDeliveryCommand.CommandType = CommandType.StoredProcedure;
            updateDeliveryCommand.Parameters.AddWithValue("@DeliveryID", DeliveryID);
            updateDeliveryCommand.Parameters.AddWithValue("@DeliveryDate", DeliveryDate.Date);
            updateDeliveryCommand.Parameters.AddWithValue("@BranchID", Branch.BranchID);
            updateDeliveryCommand.Parameters.AddWithValue("@DeliveryReturned", DeliveryReturned);
            updateDeliveryCommand.Parameters.AddWithValue("@DeliveryDescription", DeliveryDescription);
            updateDeliveryCommand.Parameters.AddWithValue("@CanEditReturnedDeliveries", frmMain.cbUser.UserGroup.GroupsAccessDict["Can Edit Saved Deliveries"].HasAccess);
            updateDeliveryCommand.Parameters.AddWithValue("@UserReturnedBy", UserReturnedBy.UserID);                            
            

            //@DeliveryID int,
            //@DeliveryDate datetime,
            //@BranchID int,
            //@DeliveryReturned bit,
            //@UserReturnedBy int,
            //@CanEditReturnedDeliveries bit


            SqlParameter returnValue = new SqlParameter();
            returnValue.Direction = ParameterDirection.ReturnValue;
            updateDeliveryCommand.Parameters.Add(returnValue);

            try
            {
                updateDeliveryCommand.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                ExceptionLogger.LogMessage(ex);
            }
            try
            {
                updateDeliveryConn.Close();
            }
            catch (Exception ex)
            {
                ExceptionLogger.LogMessage(ex);
            }

            try
            {
                int errorCode = (int)returnValue.Value;
                if (errorCode == 0)
                {
                    //Successfully Updated
                    result = true;
                }
                else if (errorCode == 1)
                {
                    //Delivery doesnt exist
                    result = false;
                }
                else if (errorCode == 2)
                {
                    //Delivery returned and user has no permission to overwrite
                    result = false;
                }
            }
            catch
            {
            }


            //result will be true only if this update procedure was successful
            return result;
            
        }
        public Boolean Insert()
        {
            Boolean result = false;

            SqlConnection insertDeliveryConn = ConnFactory.GetConnection();

            try
            {
                insertDeliveryConn.Open();
            }
            catch (Exception ex)
            {
                ExceptionLogger.LogMessage(ex);
            }

            SqlCommand insertDeliveryCommand = new SqlCommand("uspInsertDelivery", insertDeliveryConn);
            insertDeliveryCommand.CommandType = CommandType.StoredProcedure;
            insertDeliveryCommand.Parameters.AddWithValue("@DeliveryDate", DeliveryDate.Date);
            insertDeliveryCommand.Parameters.AddWithValue("@BranchID", Branch.BranchID);
            


            //@DeliveryID int,
            //@DeliveryDate datetime,
            //@BranchID int,
            //@DeliveryReturned bit,
            //@UserReturnedBy int,
            //@CanEditReturnedDeliveries bit


            SqlParameter returnValue = new SqlParameter();
            returnValue.Direction = ParameterDirection.ReturnValue;
            insertDeliveryCommand.Parameters.Add(returnValue);

            try
            {
                insertDeliveryCommand.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                ExceptionLogger.LogMessage(ex);
            }
            try
            {
                insertDeliveryConn.Close();
            }
            catch (Exception ex)
            {
                ExceptionLogger.LogMessage(ex);
            }

            try
            {
                int errorCode = (int)returnValue.Value;
                if (errorCode == 0)
                {
                    //Successfully Inserted
                    result = true;
                }
                else if (errorCode == 1)
                {
                    //Delivery already exist
                    result = false;
                }
                
            }
            catch
            {
            }


            //result will be true only if this insert procedure was successful
            return result;
        }
    }
}
