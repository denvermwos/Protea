using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Protea
{
    public class Branch
    {
        public int BranchID;
        public string BranchName;
        public decimal CBBalance = 0;
        public decimal DropBalance = 0;
        public bool branchIsNew = false;
        public Branch()
        {
        }
        public Branch(int branchid, string branchname, decimal cbbalance, decimal dropbalance)
        {
            BranchID = branchid;
            BranchName = branchname;
            branchIsNew = false;
            CBBalance = cbbalance;
            DropBalance = dropbalance;
        }
        public Branch(string branchname)
        {
            BranchName = branchname;
            branchIsNew = true;
            CBBalance = 0;
            DropBalance = 0;
        }

        public bool ExistsInDBCheck()
        {

            return false;
        }
        public void Insert()
        {
            try
            {
                using (var con = ConnFactory.GetConnection())
                {

                    var cmd = "uspNewBranchInsert";
                    using (var insertCommand = new SqlCommand(cmd, con))
                    {
                        insertCommand.CommandType = CommandType.StoredProcedure;
                        insertCommand.Parameters.AddWithValue("@BranchName", BranchName);
                        insertCommand.Parameters.AddWithValue("@CBBalance", CBBalance);
                        insertCommand.Parameters.AddWithValue("@DropBalance", DropBalance);

                        con.Open();
                        BranchID = (int)insertCommand.ExecuteScalar();
                        branchIsNew = false;

                    }
                }
            }
            catch (Exception ex)
            {

                ExceptionLogger.LogMessage(ex);
            }
        }
        public void Update()
        {
            try
            {
                using (var con = ConnFactory.GetConnection())
                {

                    var cmd = "UPDATE Branches SET BranchName=@BranchName WHERE BranchID=@BranchID";
                    using (var insertCommand = new SqlCommand(cmd, con))
                    {
                        insertCommand.Parameters.AddWithValue("@BranchName", BranchName);
                        insertCommand.Parameters.AddWithValue("@BranchID", BranchID);
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
        public void Save()
        {
            if (branchIsNew)
            {
                Insert();
            }
            else
            {
                Update();
            }
        }
        public static Branch GetBranchByID(int ID)
        {
            Branch result = null;
            SqlConnection GetBranchByIDConn = ConnFactory.GetConnection();

            try
            {
                GetBranchByIDConn.Open();
            }
            catch (Exception ex)
            {
                ExceptionLogger.LogMessage(ex);
            }


            
            SqlCommand myCommand = new SqlCommand("SELECT * FROM Branches WHERE BranchID = @BranchID", GetBranchByIDConn);
            myCommand.Parameters.AddWithValue("@BranchID", ID);

            try
            {
                SqlDataReader myReader = null;
                myReader = myCommand.ExecuteReader();

                if (myReader.Read())
                {
                    int branchid = Convert.ToInt32(myReader["BranchID"]);
                    string branchname = myReader["BranchName"].ToString();
                    decimal cbbalance = Convert.ToDecimal(myReader["CBBalance"]);
                    decimal dropbalance = Convert.ToDecimal(myReader["DropBalance"]);
                    result = new Branch(branchid,branchname,cbbalance,dropbalance);

                    

                }
                else
                {
                    

                }
            }
            catch (Exception ex)
            {
                ExceptionLogger.LogMessage(ex);
            }
            try
            {
                GetBranchByIDConn.Close();
            }
            catch (Exception ex)
            {
                ExceptionLogger.LogMessage(ex);
            }

            
            return result;
            
        }

        public static bool BranchNameAvailable(Branch branch)
        {
            bool result = true;



            SqlConnection UsernameExistsConn = ConnFactory.GetConnection();

            try
            {
                UsernameExistsConn.Open();
            }
            catch (Exception ex)
            {
                ExceptionLogger.LogMessage(ex);
            }



            SqlCommand myCommand = new SqlCommand("SELECT * FROM Branches WHERE BranchName = @BranchName", UsernameExistsConn);
            if (!branch.branchIsNew)
            {
                myCommand.CommandText = "SELECT * FROM Branches WHERE BranchName = @BranchName AND BranchID != @BranchID";
                myCommand.Parameters.AddWithValue("@BranchID", branch.BranchID);
            }

            myCommand.Parameters.AddWithValue("@BranchName", branch.BranchName);

            try
            {
                SqlDataReader myReader = null;
                myReader = myCommand.ExecuteReader();

                if (myReader.Read())
                {
                    result = false;

                }
                else
                {
                    result = true;
                }
            }
            catch (Exception ex)
            {
                ExceptionLogger.LogMessage(ex);
            }
            try
            {
                UsernameExistsConn.Close();
            }
            catch (Exception ex)
            {
                ExceptionLogger.LogMessage(ex);
            }


            return result;
        }
        public static List<Branch> GetBranches()
        {
            List<Branch> result = new List<Branch>();
            SqlConnection GetBranchesConn = ConnFactory.GetConnection();

            try
            {
                GetBranchesConn.Open();
            }
            catch (Exception ex)
            {
                ExceptionLogger.LogMessage(ex);
            }



            SqlCommand myCommand = new SqlCommand("SELECT * FROM Branches", GetBranchesConn);
            

            try
            {
                SqlDataReader myReader = null;
                myReader = myCommand.ExecuteReader();

                while (myReader.Read())
                {
                    int branchid = Convert.ToInt32(myReader["BranchID"]);
                    string branchname = myReader["BranchName"].ToString();
                    decimal cbbalance = Convert.ToDecimal(myReader["CBBalance"]);
                    decimal dropbalance = Convert.ToDecimal(myReader["DropBalance"]);
                    result.Add(new Branch(branchid, branchname, cbbalance, dropbalance));



                }
                
            }
            catch (Exception ex)
            {
                ExceptionLogger.LogMessage(ex);
            }
            try
            {
                GetBranchesConn.Close();
            }
            catch (Exception ex)
            {
                ExceptionLogger.LogMessage(ex);
            }


            return result;

        }
        public static List<Branch> GetPBranches(Branch usersBranch)
        {
            List<Branch> result = new List<Branch>();
            SqlConnection GetBranchesConn = ConnFactory.GetConnection();

            try
            {
                GetBranchesConn.Open();
            }
            catch (Exception ex)
            {
                ExceptionLogger.LogMessage(ex);
            }



            SqlCommand myCommand = new SqlCommand("SELECT * FROM Branches WHERE BranchID != @BranchID", GetBranchesConn);
            myCommand.Parameters.AddWithValue("@BranchID", usersBranch.BranchID);

            try
            {
                SqlDataReader myReader = null;
                myReader = myCommand.ExecuteReader();

                while (myReader.Read())
                {
                    int branchid = Convert.ToInt32(myReader["BranchID"]);
                    string branchname = myReader["BranchName"].ToString();
                    decimal cbbalance = Convert.ToDecimal(myReader["CBBalance"]);
                    decimal dropbalance = Convert.ToDecimal(myReader["DropBalance"]);
                    result.Add(new Branch(branchid, branchname, cbbalance, dropbalance));



                }

            }
            catch (Exception ex)
            {
                ExceptionLogger.LogMessage(ex);
            }
            try
            {
                GetBranchesConn.Close();
            }
            catch (Exception ex)
            {
                ExceptionLogger.LogMessage(ex);
            }


            return result;

        }
        public override string ToString()
        {
            return BranchName;
        }
        
    }
}
