using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Protea
{
    public class CashbookEntry
    {
        public int EntryID;
        public DateTime EntryDate;
        //public int branchID;
        public Branch CBEBranch;
        public Branch BranchTag;
        public User Capturer;
        public int PUserID;
        public User UserTag;
        public TransType TransType;
        public string EntryDescription;
        public decimal Amount;
        public string ScannedFile;
        private bool ExistInDB;
        


        public CashbookEntry(Branch cbebranch, Branch pbranch, User captureruser, User puser, TransType type,string entrydescription,decimal amountparam,string scannedfile)
        {
            CBEBranch = cbebranch;
            BranchTag = pbranch;
            Capturer = captureruser;
            UserTag = puser;
            TransType = type;
            EntryDescription = entrydescription;
            EntryDate = DateTime.Now;
            Amount = amountparam;
            ScannedFile = scannedfile;
            ExistInDB = false;
            
        }

        public CashbookEntry(int entryid, DateTime entrydate, Branch cbebranch, Branch pbranch, User captureruser, User puser, TransType type, string entrydescription, decimal amountparam, string scannedfile)
        {
            //object created from existing entry in db
            EntryID = entryid;
            CBEBranch = cbebranch;
            BranchTag = pbranch;
            Capturer = captureruser;
            UserTag = puser;
            TransType = type;
            EntryDescription = entrydescription;
            EntryDate = entrydate;
            Amount = amountparam;
            ScannedFile = scannedfile;
            ExistInDB = true;

        }

        public CashbookEntry(int entryid)
        {
            EntryID = entryid;
            Read(EntryID);
            ExistInDB = true;
        }
        public void AddScannedFile(string fileLocation)
        {
            ScannedFile = fileLocation;
        }
        public void Save()
        {
            if (ExistInDB)
            {
                Update();
            }
            else
            {
                Create();
            }
        }
        public int Create()
        {
            int newID;
            using (var con = ConnFactory.GetConnection())
            {

                
                using (var insertCommand = new SqlCommand("uspCreateCashbookEntry2", con)) 
                {
                    insertCommand.CommandType = CommandType.StoredProcedure;
                    insertCommand.Parameters.AddWithValue("@EntryDate", EntryDate);
                    insertCommand.Parameters.AddWithValue("@BranchID", CBEBranch.BranchID);
                    if (TransType.NeedsPBranch)
                    {
                        insertCommand.Parameters.AddWithValue("@PBranchID",BranchTag.BranchID);
                    }
                    insertCommand.Parameters.AddWithValue("@CapturerUserID",Capturer.UserID);
                    if (TransType.NeedsPUser)
                    {
                        insertCommand.Parameters.AddWithValue("@PUserID", UserTag.UserID);
                    }
                    insertCommand.Parameters.AddWithValue("@TypeID",TransType.TransTypeID);
                    insertCommand.Parameters.AddWithValue("@Description",EntryDescription);
                    insertCommand.Parameters.AddWithValue("@Amount",Amount);
                    insertCommand.Parameters.AddWithValue("@ScannedFile", ScannedFile);
                    insertCommand.Parameters.AddWithValue("@DropSafe", TransType.DropSafe);
                    insertCommand.Parameters.AddWithValue("@Recon", TransType.Recon);
                    insertCommand.Parameters.AddWithValue("@TransDescription", TransType.TransDescription);
                    con.Open();
                    int i = (int)insertCommand.ExecuteScalar();
                    newID = i;
                    ExistInDB = true;
                    
                }               
            }
            return newID;
        }
        
        public void Update()
        {
            using (var con = ConnFactory.GetConnection())
            {

                try
                {
                    var cmd = "UPDATE Cashbook SET EntryDate=@EntryDate,BranchID=@BranchID,CapturerUserID=@CapturerUserID,PUserID=@PUserID,TypeID=@TypeID,Description=@Description,Amount=@Amount,ScannedFile=@ScannedFile WHERE EntryID=@EntryID";
                    using (var updateCommand = new SqlCommand(cmd, con))
                    {
                        updateCommand.Parameters.AddWithValue("@EntryID", EntryID);
                        updateCommand.Parameters.AddWithValue("@EntryDate", EntryDate);
                        updateCommand.Parameters.AddWithValue("@BranchID", CBEBranch.BranchID);
                        updateCommand.Parameters.AddWithValue("@CapturerUserID", Capturer.UserID);
                        updateCommand.Parameters.AddWithValue("@PUserID", UserTag.UserID);
                        updateCommand.Parameters.AddWithValue("@TypeID", TransType.TransTypeID);
                        updateCommand.Parameters.AddWithValue("@Description", EntryDescription);
                        updateCommand.Parameters.AddWithValue("@Amount", Amount);
                        updateCommand.Parameters.AddWithValue("@ScannedFile", ScannedFile);
                        con.Open();
                        updateCommand.ExecuteNonQuery();

                    }
                }
                catch (Exception ex)
                {

                    ExceptionLogger.LogMessage(ex);
                }
            }
            
        }
        public void Read(long entryid)
        {
            SqlConnection readConn = ConnFactory.GetConnection();

            try
            {
                readConn.Open();
            }
            catch (Exception ex)
            {
                ExceptionLogger.LogMessage(ex);
            }


            SqlParameter EntryIDParam = new SqlParameter("@EntryID", SqlDbType.BigInt, 50);
            EntryIDParam.Value = EntryID;
            
            SqlCommand myCommand = new SqlCommand("SELECT * FROM Cashbook INNER JOIN Branches ON Cashbook.BranchID = Branches.BranchID WHERE EntryID = @EntryID", readConn);
            myCommand.Parameters.Add(EntryIDParam);
            

            try
            {
                SqlDataReader myReader = null;
                myReader = myCommand.ExecuteReader();

                if (myReader.Read())
                {
                    EntryDate = Convert.ToDateTime(myReader["EntryDate"]);
                    CBEBranch = new Branch(Convert.ToInt16(myReader["Branches.BranchID"]), myReader["Branches.BranchName"].ToString(), Convert.ToDecimal(myReader["CBBalance"]), Convert.ToDecimal(myReader["DropBalance"]));

                    Capturer = new User(Convert.ToInt16(myReader["CapturerUserID"]), myReader["FName"].ToString(), myReader["LName"].ToString());
                    UserTag = new User(Convert.ToInt16(myReader["PUserID"]), myReader["PUserFName"].ToString(), myReader["PUserLName"].ToString());
                    TransType = new TransType(Convert.ToInt32(myReader["TypeID"]), myReader["TransDescription"].ToString(), Convert.ToBoolean(myReader["Recon"]), Convert.ToBoolean(myReader["DropSafe"]),false,false);
                    EntryDescription = myReader["Description"].ToString();
                    Amount = Convert.ToDecimal(myReader["Amount"]);
                    ScannedFile = myReader["ScannedFile"].ToString();
                }
                else
                {
                    //no vaid entry, this was an unsuccessful attemp to login
                    MessageBox.Show("Entry not found");

                }
            }
            catch (Exception ex)
            {
                ExceptionLogger.LogMessage(ex);
            }
            try
            {
                readConn.Close();
            }
            catch (Exception ex)
            {
                ExceptionLogger.LogMessage(ex);
            }
        }
        public static List<CashbookEntry> GetCashbookEntries(Branch branch, TransType transType, DateTime startDate, DateTime endDate)
        {
            
            List<CashbookEntry> result = new List<CashbookEntry>();
            SqlConnection GetCashbookEntriesConn = ConnFactory.GetConnection();

            try
            {
                GetCashbookEntriesConn.Open();
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
            BranchIDParam.Value = branch.BranchID;
            SqlParameter TransTypeIDParam = new SqlParameter("@TransTypeID", SqlDbType.Int);
            TransTypeIDParam.Value = transType.TransTypeID;

            SqlCommand myCommand = new SqlCommand("uspGetTransactions", GetCashbookEntriesConn);
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
                    int entryID = Convert.ToInt32(myReader["EntryID"]);
                    DateTime entryDate = Convert.ToDateTime(myReader["EntryDate"]);
                    Branch cbeBranch = new Branch(Convert.ToInt16(myReader["BranchID"]), myReader["BranchName"].ToString(), Convert.ToDecimal(myReader["CBBalance"]), Convert.ToDecimal(myReader["DropBalance"]));
                    Branch pBranch = new Branch(Convert.ToInt16(myReader["PBranchID"]), myReader["PBranchName"].ToString(), 0 , 0 );
                    User capturer = new User(Convert.ToInt16(myReader["CapturerUserID"]), myReader["FName"].ToString(), myReader["LName"].ToString());
                    User puser = new User(Convert.ToInt16(myReader["PUserID"]), myReader["PUserFName"].ToString(), myReader["PUserLName"].ToString());
                    TransType type = new TransType(Convert.ToInt32(myReader["TransTypeID"]), myReader["TransDescription"].ToString(), Convert.ToBoolean(myReader["Recon"]), Convert.ToBoolean(myReader["DropSafe"]),false,false);
                    string entryDescription = myReader["Description"].ToString();
                    decimal amount = Convert.ToDecimal(myReader["Amount"]);
                    string ScannedFile = myReader["ScannedFile"].ToString();
                    //Create new Cashbookentry object, this will be added as a tag to the row of the cashbook
                    CashbookEntry cbe = new CashbookEntry(entryID, entryDate, cbeBranch, pBranch, capturer, puser, type, entryDescription, amount, ScannedFile);
                    result.Add(cbe);

                }

            }
            catch (Exception ex)
            {
                ExceptionLogger.LogMessage(ex);
            }
            try
            {
                GetCashbookEntriesConn.Close();
            }
            catch (Exception ex)
            {
                ExceptionLogger.LogMessage(ex);
            }


            return result;

        }
        public static decimal[] GetBalanceBFwdandPageTotal(Branch branch, TransType transType, DateTime startDate, DateTime endDate)
        {
            decimal[] result = { 0, 0 };
            decimal BBFwd = 0;
            decimal PageTotal = 0;
            
            SqlConnection readConn = ConnFactory.GetConnection();

            try
            {
                readConn.Open();
            }
            catch (Exception ex)
            {
                ExceptionLogger.LogMessage(ex);
            }


            SqlParameter BranchIDParam = new SqlParameter("@BranchID", SqlDbType.Int);
            BranchIDParam.Value = branch.BranchID;
            SqlParameter TransTypeIDParam = new SqlParameter("@TransTypeID", SqlDbType.Int);
            TransTypeIDParam.Value = transType.TransTypeID;

            SqlParameter StartDateParam = new SqlParameter("@StartDate", SqlDbType.DateTime);
            StartDateParam.Value = startDate.Date;
            SqlParameter EndDateParam = new SqlParameter("@EndDate", SqlDbType.DateTime);
            EndDateParam.Value = endDate.Date.AddDays(1);
            



            SqlCommand myCommand = new SqlCommand("uspBBFwdAndPageTotal", readConn);
            myCommand.CommandType = CommandType.StoredProcedure;

            myCommand.Parameters.Add(StartDateParam);
            myCommand.Parameters.Add(EndDateParam);
            myCommand.Parameters.Add(BranchIDParam);
            myCommand.Parameters.Add(TransTypeIDParam);

            try
            {

                SqlDataReader myReader = null;
                myReader = myCommand.ExecuteReader();

                if (myReader.Read())
                {

                    BBFwd = Convert.ToDecimal(myReader["BBFwd"]);
                    PageTotal = Convert.ToDecimal(myReader["PageTotal"]);
                    
                }
                else
                {
                    //no vaid entry, this was an unsuccessful attemp to login
                    MessageBox.Show("Entry not found");

                }
                

            }
            catch (Exception ex)
            {
                ExceptionLogger.LogMessage(ex);
            }
            try
            {
                readConn.Close();
            }
            catch (Exception ex)
            {
                ExceptionLogger.LogMessage(ex);
            }


            result[0] = BBFwd;
            result[1] = PageTotal;
            return result;
        }

        public static decimal GetPageTotal(Branch branch, TransType transType, DateTime startDate,DateTime endDate)
        {
            decimal sum = 0;
            CashbookEntry bbfwd = new CashbookEntry(new Branch(),new Branch(), new User(), new User(), new TransType(), "Balance Brought Forward", 0, ""); ;
            SqlConnection readConn = ConnFactory.GetConnection();

            try
            {
                readConn.Open();
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
            BranchIDParam.Value = branch.BranchID;
            SqlParameter TransTypeIDParam = new SqlParameter("@TransTypeID", SqlDbType.Int);
            TransTypeIDParam.Value = transType.TransTypeID;




            SqlCommand myCommand = new SqlCommand(
                
                "DECLARE @BBFwd decimal(18,2);" +
                "DECLARE @Total decimal(18,2);" +
                "IF (@TransTypeID=0) " +
                    "BEGIN " +
                        
                        "SET @BBFwd = (SELECT SUM(Amount) FROM Cashbook INNER JOIN Branches ON Cashbook.BranchID = Branches.BranchID INNER JOIN Users ON Cashbook.CapturerUserID = Users.UserID INNER JOIN TransTypes ON Cashbook.TypeID = TransTypes.TransTypeID WHERE EntryDate >= @StartDate AND EntryDate <= @EndDate AND Cashbook.BranchID = @BranchID); " +
                    "END " +
                "ELSE " +
                    "BEGIN " +
                        
                        "SET @BBFwd = (SELECT SUM(Amount) FROM Cashbook INNER JOIN Branches ON Cashbook.BranchID = Branches.BranchID INNER JOIN Users ON Cashbook.CapturerUserID = Users.UserID INNER JOIN TransTypes ON Cashbook.TypeID = TransTypes.TransTypeID WHERE EntryDate >= @StartDate AND EntryDate <= @EndDate AND Cashbook.BranchID = @BranchID AND TransTypeID = @TransTypeID); " +
                    "END " +
                "SELECT ISNULL(@BBFwd,0.00); ", readConn);


            myCommand.Parameters.Add(StartDateParam);
            myCommand.Parameters.Add(EndDateParam);
            myCommand.Parameters.Add(BranchIDParam);
            myCommand.Parameters.Add(TransTypeIDParam);

            try
            {


                try
                {

                    object sumobject = myCommand.ExecuteScalar();
                    sum = sumobject == DBNull.Value ? 0 : Convert.ToDecimal(sumobject);
                    bbfwd = new CashbookEntry(new Branch(),new Branch(),new User(), new User(), new TransType(), "Balance Brought Forward", sum, "");
                }
                catch (Exception ex)
                {
                    ExceptionLogger.LogMessage(ex);
                }

            }
            catch (Exception ex)
            {
                ExceptionLogger.LogMessage(ex);
            }
            try
            {
                readConn.Close();
            }
            catch (Exception ex)
            {
                ExceptionLogger.LogMessage(ex);
            }



            return sum;
        }
        

    }
}
