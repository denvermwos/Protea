using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Data.Sql;

namespace Protea
{
    public class PBranchAudit
    {
        public Branch PBranch;
        public decimal PBranchesCBTotalAmount;
        public decimal BranchesCBTotalAmount;
        public decimal Variance;

        public PBranchAudit(Branch pBranch, decimal pBranchesCBTotalAmount, decimal branchesCBTotalAmount, decimal variance)
        {
            PBranch = pBranch;
            PBranchesCBTotalAmount = pBranchesCBTotalAmount;
            BranchesCBTotalAmount = branchesCBTotalAmount;
            Variance = variance;

        }
        public static List<PBranchAudit> DoPBranchAudit(Branch branchToAudit, TransType transactionToAudit, DateTime startDate, DateTime endDate)
        {
            List<PBranchAudit> result = new List<PBranchAudit>();
            SqlConnection DoPBranchAuditConn = ConnFactory.GetConnection();

            try
            {
                DoPBranchAuditConn.Open();
            }
            catch (Exception ex)
            {
                ExceptionLogger.LogMessage(ex);
            }

            SqlParameter StartDateParam = new SqlParameter("@StartDate", SqlDbType.DateTime);
            StartDateParam.Value = startDate.Date;
            SqlParameter EndDateParam = new SqlParameter("@EndDate", SqlDbType.DateTime);
            EndDateParam.Value = endDate.Date.AddDays(1);
            SqlParameter BranchIDParam = new SqlParameter("@BranchID", SqlDbType.Int);
            BranchIDParam.Value = branchToAudit.BranchID;
            SqlParameter TransTypeIDParam = new SqlParameter("@TransTypeID", SqlDbType.Int);
            TransTypeIDParam.Value = transactionToAudit.TransTypeID;

            SqlCommand myCommand = new SqlCommand("uspGetTransactionTotalByPBranch", DoPBranchAuditConn);
            myCommand.CommandType = CommandType.StoredProcedure;
            myCommand.Parameters.Add(StartDateParam);
            myCommand.Parameters.Add(EndDateParam);
            myCommand.Parameters.Add(BranchIDParam);
            myCommand.Parameters.Add(TransTypeIDParam);

            try
            {
                SqlDataReader myReader = null;
                myReader = myCommand.ExecuteReader();

                while (myReader.Read())
                {
                    Branch pBranch = new Branch(Convert.ToInt16(myReader["PBranchID"]), myReader["PBranchName"].ToString(), Convert.ToDecimal(myReader["PBranchCBBalance"]), Convert.ToDecimal(myReader["PBranchDropBalance"]));
                    
                    decimal PBranchesCBTotalAmount = Convert.ToDecimal(myReader["PBranchesCBTotalAmount"]);
                    decimal BranchesCBTotalAmount = Convert.ToDecimal(myReader["BranchesCBTotalAmount"]);
                    decimal Variance = Convert.ToDecimal(myReader["Variance"]);

                    PBranchAudit cbe = new PBranchAudit(pBranch, PBranchesCBTotalAmount, BranchesCBTotalAmount, Variance);
                    result.Add(cbe);
                    
                }

            }
            catch (Exception ex)
            {
                ExceptionLogger.LogMessage(ex);
            }
            try
            {
                DoPBranchAuditConn.Close();
            }
            catch (Exception ex)
            {
                ExceptionLogger.LogMessage(ex);
            }


            return result;
        }

    }
}
/*

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
go







ALTER PROCEDURE [dbo].[uspGetTransactionTotalByPBranch]
	(
	@BranchID int,
	@TransTypeID int,
	@StartDate datetime,
	@EndDate datetime
	
	)
AS
	SELECT PBranchID,BranchName As PBranchName,PBranchCBBalance,PBranchDropBalance, ISNULL(PBranchesCBTotalAmount,0) AS PBranchesCBTotalAmount,ISNULL(BranchesCBTotalAmount,0) AS BranchesCBTotalAmount, ISNULL(BranchesCBTotalAmount,0) + ISNULL(PBranchesCBTotalAmount,0) AS Variance
			 FROM	(
						--All other Branches	
						SELECT BranchID AS PBranchID,BranchName,CBBalance AS PBranchCBBalance,DropBalance AS PBranchDropBalance FROM Branches WHERE BranchID != @BranchID
					)

		AS OtherBranches
		
		LEFT JOIN	(
						--Sum amount from my cashbook for each branch that we had an entry for
						SELECT ISNULL(PBranchID,0) AS BranchID, SUM(Amount) AS BranchesCBTotalAmount FROM Cashbook
						WHERE BranchID = @BranchID AND EntryDate > @StartDate AND EntryDate < @EndDate AND TypeID = @TransTypeID
						GROUP BY PBranchID
					)
		AS BranchesCBTotalAmount ON OtherBranches.PBranchID = BranchesCBTotalAmount.BranchID

		LEFT JOIN	(
						--Sum amount from other branches of entries for my branch
						SELECT BranchID, SUM(Amount) AS PBranchesCBTotalAmount  FROM Cashbook
						WHERE PBranchID = @BranchID AND EntryDate > @StartDate AND EntryDate < @EndDate AND TypeID = @TransTypeID
						GROUP BY BranchID
					)
		
		AS PBranchesCBTotalTable ON OtherBranches.PBranchID = PBranchesCBTotalTable.BranchID


	

	RETURN

*/