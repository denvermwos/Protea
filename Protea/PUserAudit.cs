using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Protea
{
    public class PUserAudit
    {
        public User User { get; set; }
        public decimal Total { get; set; }
        public PUserAudit(User user, decimal total)
        {
            User = user;
            Total = total;
        }
        public static List<PUserAudit> DoPUserAudit(Branch branchToAudit, TransType transactionToAudit, DateTime startDate, DateTime endDate)
        {
            List<PUserAudit> pUserAudits = new List<PUserAudit>();

            SqlConnection doPUserAuditConn = ConnFactory.GetConnection();

            try
            {
                doPUserAuditConn.Open();
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

            SqlCommand myCommand = new SqlCommand("uspGetTransactionTotalByPUser", doPUserAuditConn);
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

                    int userid = Convert.ToInt32(myReader["UserID"]);
                    int staffno = Convert.ToInt32(myReader["StaffNo"]);
                    string fname = myReader["FName"].ToString();
                    string lname = myReader["LName"].ToString();
                    string username = myReader["UserName"].ToString();
                    string userpassword = myReader["UserPassword"].ToString();
                    int groupid = Convert.ToInt32(myReader["GroupID"]);
                    int userbranch = Convert.ToInt32(myReader["BranchID"]);
                    bool changepwd = Convert.ToBoolean(myReader["ChangePwd"]);
                    decimal total = Convert.ToDecimal(myReader["SumAmount"]);
                    PUserAudit tempPUserAudit = new PUserAudit(new User(userid, staffno, fname, lname, username, userpassword, Group.GetGroupByID(groupid), Branch.GetBranchByID(userbranch), changepwd),total);

                    pUserAudits.Add(tempPUserAudit);


                }

            }
            catch (Exception ex)
            {
                ExceptionLogger.LogMessage(ex);
            }
            try
            {
                doPUserAuditConn.Close();
            }
            catch (Exception ex)
            {
                ExceptionLogger.LogMessage(ex);
            }

            return pUserAudits;
        }
    }
}
