using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
namespace Protea
{
    class ReconEntry
    {
        public int ReconID;
        public int PReconID;
        public DateTime ReconTransferDateTime;
        public string ReconDescription;
        public decimal TransferAmount;
        public User ReconOwner;
        public User CapturerUser;
        public Branch ReconBranch;
        public bool TransferFinal;


        public  ReconEntry()
        {
        }
        
        public ReconEntry(int reconid,int preconid,DateTime recontransferdatetime,string recondescription,decimal transferamount,User reconowner,User captureruser, Branch reconbranch,bool transferfinal)
        {
            ReconID = reconid;
            PReconID = preconid;
            ReconTransferDateTime = recontransferdatetime;
            ReconDescription = recondescription;
            TransferAmount = transferamount;
            ReconOwner = reconowner;
            CapturerUser = captureruser;
            ReconBranch = reconbranch;
            TransferFinal = transferfinal;
        }
        public static List<ReconEntry> GetReconEntries(Branch branch, User user, DateTime dateTime, bool viewFinalTransfers)
        {
            DateTime startOfDay = dateTime.Date;
            DateTime endOfDay = dateTime.AddDays(1).Date;

            List<ReconEntry> result = new List<ReconEntry>();
            SqlConnection GetReconEntriesConn = ConnFactory.GetConnection();

            try
            {
                GetReconEntriesConn.Open();
            }
            catch (Exception ex)
            {
                ExceptionLogger.LogMessage(ex);
            }



            SqlCommand myCommand = new SqlCommand("uspGetReconEntries", GetReconEntriesConn);
            myCommand.CommandType = CommandType.StoredProcedure;
            myCommand.Parameters.AddWithValue("@startDate", startOfDay);
            myCommand.Parameters.AddWithValue("@endDate", endOfDay);
            myCommand.Parameters.AddWithValue("@ReconOwnerID", user.UserID);
            myCommand.Parameters.AddWithValue("@BranchID", branch.BranchID);
            myCommand.Parameters.AddWithValue("@TransferFinal", viewFinalTransfers);
            try
            {
                SqlDataReader myReader = null;
                myReader = myCommand.ExecuteReader();

                while (myReader.Read())
                {

                    int reconid = Convert.ToInt32(myReader["ReconID"]);
                    int preconid = Convert.ToInt32(myReader["PReconID"]); ;
                    DateTime recontransferdatetime = Convert.ToDateTime(myReader["ReconTransferDateTime"]);
                    string recondescription = myReader["ReconDescription"].ToString();
                    decimal transferamount = Convert.ToDecimal(myReader["TransferAmount"]);
                    User reconowner = User.GetUserByID(Convert.ToInt32(myReader["ReconOwnerID"]));
                    User captureruser = User.GetUserByID(Convert.ToInt32(myReader["CapturerUserID"]));
                    Branch reconbranch = Branch.GetBranchByID(Convert.ToInt32(myReader["BranchID"]));
                    bool transferfinal = Convert.ToBoolean(myReader["TransferFinal"]);


                    result.Add(new ReconEntry(reconid, preconid, recontransferdatetime, recondescription, transferamount, reconowner, captureruser, reconbranch, transferfinal));
                    



                }

            }
            catch (Exception ex)
            {
                ExceptionLogger.LogMessage(ex);
            }
            try
            {
                GetReconEntriesConn.Close();
            }
            catch (Exception ex)
            {
                ExceptionLogger.LogMessage(ex);
            }


            return result;

        }
        public static decimal GetReconEntriesTotal(Branch branch, User user, DateTime dateTime, bool viewFinalTransfers)
        {
            DateTime startOfDay = dateTime.Date;
            DateTime endOfDay = dateTime.AddDays(1).Date;

            
            decimal resulttotal = 0;
            SqlConnection GetReconEntriesConn = ConnFactory.GetConnection();

            try
            {
                GetReconEntriesConn.Open();
            }
            catch (Exception ex)
            {
                ExceptionLogger.LogMessage(ex);
            }



            SqlCommand myCommand = new SqlCommand("DECLARE @Total decimal(18,2); SELECT @Total = Sum(TransferAmount) FROM Recon WHERE ReconTransferDateTime >= @startDate AND ReconTransferDateTime <= @endDate AND BranchID = @BranchID AND ReconOwnerID = @ReconOwnerID AND TransferFinal = @TransferFinal; SELECT ISNULL(@Total,0.00);", GetReconEntriesConn);
            myCommand.Parameters.AddWithValue("@startDate", startOfDay);
            myCommand.Parameters.AddWithValue("@endDate", endOfDay);
            myCommand.Parameters.AddWithValue("@ReconOwnerID", user.UserID);
            myCommand.Parameters.AddWithValue("@BranchID", branch.BranchID);
            myCommand.Parameters.AddWithValue("@TransferFinal", viewFinalTransfers);
            try
            {
                
                resulttotal = Convert.ToDecimal(myCommand.ExecuteScalar());

               

            }
            catch (Exception ex)
            {
                ExceptionLogger.LogMessage(ex);
            }
            try
            {
                GetReconEntriesConn.Close();
            }
            catch (Exception ex)
            {
                ExceptionLogger.LogMessage(ex);
            }


            return resulttotal;

        }
        public void UpdateReconEntry()
        {
            //using (var con = ConnFactory.GetConnection())
            //{

            //    var cmd = "UPDATE Cashbook SET ReconTransferDateTime=@ReconTransferDateTime,ReconDescription=@ReconDescription,TransferAmount=@TransferAmount,ReconTransferPartner=@ReconTransferPartner,UserID=@UserID,BranchID=@BranchID,TransferFinal=@TransferFinal WHERE ReconID=@ReconID";
            //    using (var updateCommand = new SqlCommand(cmd, con))
            //    {
            //        updateCommand.Parameters.AddWithValue("@ReconID", ReconID);
            //        updateCommand.Parameters.AddWithValue("@ReconTransferDateTime", ReconTransferDateTime);
            //        updateCommand.Parameters.AddWithValue("@ReconDescription", ReconDescription);
            //        updateCommand.Parameters.AddWithValue("@TransferAmount", TransferAmount);
            //        updateCommand.Parameters.AddWithValue("@ReconTransferPartner", ReconTransferPartner);
            //        updateCommand.Parameters.AddWithValue("@UserID", CapturerUser.UserID);
            //        updateCommand.Parameters.AddWithValue("@BranchID", ReconBranch.BranchID);
            //        updateCommand.Parameters.AddWithValue("@TransferFinal", TransferFinal);
            //        con.Open();
            //        updateCommand.ExecuteNonQuery();

            //    }
            //}
        }
        public int InsertReconEntry()
        {
            int newID = 0;
            //using (var con = ConnFactory.GetConnection())
            //{

            //    var cmd = "INSERT INTO Recon (ReconTransferDateTime,ReconDescription,TransferAmount,ReconTransferPartner,UserID,BranchID,TransferFinal) VALUES (@ReconTransferDateTime,@ReconDescription,@TransferAmount,@ReconTransferPartner,@UserID,@BranchID,@TransferFinal);SELECT CAST(scope_identity() AS int)";
            //    using (var insertCommand = new SqlCommand(cmd, con))
            //    {
            //        insertCommand.Parameters.AddWithValue("@ReconTransferDateTime", ReconTransferDateTime);
            //        insertCommand.Parameters.AddWithValue("@ReconDescription", ReconDescription);
            //        insertCommand.Parameters.AddWithValue("@TransferAmount", TransferAmount);
            //        insertCommand.Parameters.AddWithValue("@ReconTransferPartner", ReconTransferPartner);
            //        insertCommand.Parameters.AddWithValue("@UserID", CapturerUser.UserID);
            //        insertCommand.Parameters.AddWithValue("@BranchID", ReconBranch.BranchID);
            //        insertCommand.Parameters.AddWithValue("@TransferFinal", TransferFinal);

            //        con.Open();
            //        int i = (int)insertCommand.ExecuteScalar();
            //        newID = i;
            //        ReconID = newID;
            //        existsInDB = true;
            //    }
            //}
            return newID;
        }

        public static void TransferCash(decimal TransferAmount, User Initiator, User Acceptor, Branch BranchofTransfer, DateTime dateTime)
        {
            try
            {
                using (var con = ConnFactory.GetConnection())
                {

                    
                    using (var insertCommand = new SqlCommand("uspTransferCash", con))
                    {
                        insertCommand.CommandType = CommandType.StoredProcedure;
                        insertCommand.Parameters.AddWithValue("@EntryDate", dateTime);
                        insertCommand.Parameters.AddWithValue("@RecDescription", "Cash Recieved from " + Initiator.FName + " " + Initiator.LName);
                        insertCommand.Parameters.AddWithValue("@Amount", TransferAmount);
                        insertCommand.Parameters.AddWithValue("@AcceptorID", Acceptor.UserID);
                        insertCommand.Parameters.AddWithValue("@CapturerUserID", Initiator.UserID);
                        insertCommand.Parameters.AddWithValue("@BranchID", BranchofTransfer.BranchID);
                        insertCommand.Parameters.AddWithValue("@TransDescription", "Cash Transferred to " + Acceptor.FName + " " + Acceptor.LName);
                        //insertCommand.Parameters.AddWithValue("@GroupID", GroupID);
                        con.Open();
                        insertCommand.ExecuteNonQuery();

                    }
                }
            }

            catch (Exception ex)
            {

                ExceptionLogger.LogMessage(ex);
            }
        }
        public static int AcceptCash(decimal TransferAmount, User Initiator, User Acceptor, Branch BranchofTransfer, DateTime dateTime)
        {
            int result = 1;
            DateTime startOfDay = dateTime.Date;
            DateTime endOfDay = dateTime.AddDays(1).Date;
            try
            {
                using (var con = ConnFactory.GetConnection())
                {
                    using (var insertCommand = new SqlCommand("uspAcceptCash", con))
                    {
                        insertCommand.CommandType = CommandType.StoredProcedure;
                        insertCommand.Parameters.AddWithValue("@StartDate", startOfDay);
                        insertCommand.Parameters.AddWithValue("@EndDate", endOfDay);

                        insertCommand.Parameters.AddWithValue("@Amount", TransferAmount);
                        insertCommand.Parameters.AddWithValue("@AcceptorID", Acceptor.UserID);
                        insertCommand.Parameters.AddWithValue("@CapturerUserID", Initiator.UserID);
                        insertCommand.Parameters.AddWithValue("@BranchID", BranchofTransfer.BranchID);

                        //insertCommand.Parameters.AddWithValue("@GroupID", GroupID);
                        con.Open();
                        result = (int)insertCommand.ExecuteScalar();

                    }
                }
            }

            catch (Exception ex)
            {

                ExceptionLogger.LogMessage(ex);
            }
            return result;
        }

    }
}
