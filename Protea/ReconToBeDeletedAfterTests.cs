using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Transactions;


namespace Protea
{
    class Recon
    {
        public static void TransferCash(decimal TransferAmount, User Initiator, User Acceptor, Branch BranchofTransfer,DateTime dateTime)
        {
            try
            {
                using (var con = ConnFactory.GetConnection())
                {

                    var cmd =       "BEGIN TRAN " +
                                        "DECLARE @ReconIDA int; "+
                                        "DECLARE @ReconIDB int; " +
                                        //create recipients recon entry first
                                        "INSERT INTO Recon (PReconID,ReconTransferDateTime,ReconDescription,TransferAmount,ReconOwnerID,CapturerUserID,BranchID,TransferFinal) " +
                                        "VALUES     (0, @EntryDate, @RecDescription, @Amount, @AcceptorID, @CapturerUserID, @BranchID, 'false'); " +
                                        "SET @ReconIDA = scope_identity(); " +
                                        "INSERT INTO Recon (PReconID,ReconTransferDateTime,ReconDescription,TransferAmount,ReconOwnerID,CapturerUserID,BranchID,TransferFinal) " +
                                        "VALUES     (@ReconIDA, @EntryDate, @TransDescription, (-1)*@Amount, @CapturerUserID, @CapturerUserID, @BranchID, 'false'); " +
                                        "SET @ReconIDB = scope_identity(); " +
                                        "UPDATE Recon SET PReconID = @ReconIDB WHERE ReconID = @ReconIDA; " +
                                    "COMMIT TRAN";
                    using (var insertCommand = new SqlCommand(cmd, con))
                    {
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
        public static void AcceptCash(decimal TransferAmount, User Initiator, User Acceptor, Branch BranchofTransfer, DateTime dateTime)
        {
            DateTime startOfDay = dateTime.Date;
            DateTime endOfDay = dateTime.AddDays(1).Date;
            try
            {
                using (var con = ConnFactory.GetConnection())
                {

                    var cmd = "BEGIN TRAN " +
                                        "DECLARE @ReconIDA int; " +
                                        "DECLARE @ReconIDB int; " +//, PReconID, ReconTransferDateTime, ReconDescription, TransferAmount, ReconOwnerID, CapturerUserID, BranchID, TransferFinal
                                        "SELECT        @ReconIDA = ReconID,  @ReconIDB = PReconID FROM Recon "+
                                        "WHERE BranchID = @BranchID AND TransferAmount = @Amount AND ReconTransferDateTime >= @startDate AND ReconTransferDateTime <= @endDate AND CapturerUserID = @CapturerUserID AND ReconOwnerID = @AcceptorID; " +
                                        "UPDATE Recon SET TransferFinal = 'true' WHERE ReconID = @ReconIDA OR ReconID = @ReconIDB; " +
                                        
                                    "COMMIT TRAN";
                    using (var insertCommand = new SqlCommand(cmd, con))
                    {
                        insertCommand.Parameters.AddWithValue("@startDate", startOfDay);
                        insertCommand.Parameters.AddWithValue("@endDate", endOfDay);
                        
                        insertCommand.Parameters.AddWithValue("@Amount", TransferAmount);
                        insertCommand.Parameters.AddWithValue("@AcceptorID", Acceptor.UserID);
                        insertCommand.Parameters.AddWithValue("@CapturerUserID", Initiator.UserID);
                        insertCommand.Parameters.AddWithValue("@BranchID", BranchofTransfer.BranchID);
                        
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

    }
}
