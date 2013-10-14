using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Sql;
using System.Data.SqlClient;

namespace Protea
{
    public class TransType
    {
        public int TransTypeID;
        public string TransDescription;
        public bool Recon;
        public bool DropSafe;
        public bool NeedsPBranch;
        public bool NeedsPUser;
        public bool transTypeIsNew = true;
        public TransType()
        {
        }
        public TransType(int typeid, string typedesc, bool recon,bool dropsafe,bool needspbranch,bool needspuser)
        {
            transTypeIsNew = false;
            TransTypeID = typeid;
            TransDescription = typedesc;
            Recon = recon;
            DropSafe = dropsafe;
            NeedsPBranch = needspbranch;
            NeedsPUser = needspuser;
        }
        public TransType(string typedesc, bool recon, bool dropsafe)
        {
            transTypeIsNew = true;
            TransDescription = typedesc;
            Recon = recon;
            DropSafe = dropsafe;
        }
        public void Insert()
        {
            try
            {
                using (var con = ConnFactory.GetConnection())
                {

                    var cmd = "BEGIN TRAN DECLARE @TID int; INSERT INTO TransTypes (TransDescription, Recon, DropSafe,NeedsPBranch,NeedsPUser) VALUES (@TransDescription, 'False', 'False', @NeedsPBranch,@NeedsPUser); SET @TID = scope_identity(); INSERT INTO BranchTransTypeBalance (BranchID, TransTypeID, BranchTransTypeBalanceAmount) SELECT BranchID, @TID AS TransTypeID, 0 AS BranchTransTypeBalanceAmount FROM Branches; SELECT @TID; COMMIT TRAN";
                    using (var insertCommand = new SqlCommand(cmd, con))
                    {
                        insertCommand.Parameters.AddWithValue("@TransDescription", TransDescription);
                        insertCommand.Parameters.AddWithValue("@Recon", Recon);
                        insertCommand.Parameters.AddWithValue("@DropSafe", DropSafe);
                        insertCommand.Parameters.AddWithValue("@NeedsPBranch", NeedsPBranch);
                        insertCommand.Parameters.AddWithValue("@NeedsPUser", NeedsPUser);
                        con.Open();
                        TransTypeID = (int)insertCommand.ExecuteScalar();
                        transTypeIsNew = false;

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

                    var cmd = "UPDATE TransTypes SET TransDescription=@TransDescription, Recon=@Recon, DropSafe=@DropSafe WHERE TransTypeID=@TransTypeID";
                    using (var insertCommand = new SqlCommand(cmd, con))
                    {
                        insertCommand.Parameters.AddWithValue("@TransTypeID", TransTypeID);
                        insertCommand.Parameters.AddWithValue("@TransDescription", TransDescription);
                        insertCommand.Parameters.AddWithValue("@Recon", Recon);
                        insertCommand.Parameters.AddWithValue("@DropSafe", DropSafe);
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
            if (transTypeIsNew)
            {
                Insert();
            }
            else
            {
                Update();
            }
        }

        public static List<TransType> GetTransTypes()
        {
            List<TransType> result = new List<TransType>();
            SqlConnection GetTransTypesConn = ConnFactory.GetConnection();

            try
            {
                GetTransTypesConn.Open();
            }
            catch (Exception ex)
            {
                ExceptionLogger.LogMessage(ex);
            }



            SqlCommand myCommand = new SqlCommand("SELECT * FROM TransTypes ORDER BY cast(TransDescription as varchar(500))", GetTransTypesConn);


            try
            {
                SqlDataReader myReader = null;
                myReader = myCommand.ExecuteReader();

                while (myReader.Read())
                {
                    int transtypeid = Convert.ToInt32(myReader["TransTypeID"]);
                    string transdescription = myReader["TransDescription"].ToString();
                    bool recon = Convert.ToBoolean(myReader["Recon"]);
                    bool dropsafe = Convert.ToBoolean(myReader["DropSafe"]);
                    bool needspbranch = Convert.ToBoolean(myReader["NeedsPBranch"]);
                    bool needspuser = Convert.ToBoolean(myReader["NeedsPUser"]);
                    result.Add(new TransType(transtypeid, transdescription, recon, dropsafe,needspbranch,needspuser));



                }

            }
            catch (Exception ex)
            {
                ExceptionLogger.LogMessage(ex);
            }
            try
            {
                GetTransTypesConn.Close();
            }
            catch (Exception ex)
            {
                ExceptionLogger.LogMessage(ex);
            }


            return result;

        }
        public static List<TransType> GetTransTypesWithPBranch()
        {
            List<TransType> result = new List<TransType>();
            SqlConnection GetTransTypesConn = ConnFactory.GetConnection();

            try
            {
                GetTransTypesConn.Open();
            }
            catch (Exception ex)
            {
                ExceptionLogger.LogMessage(ex);
            }



            SqlCommand myCommand = new SqlCommand("SELECT * FROM TransTypes  WHERE NeedsPBranch = 'true' ORDER BY cast(TransDescription as varchar(500))", GetTransTypesConn);


            try
            {
                SqlDataReader myReader = null;
                myReader = myCommand.ExecuteReader();

                while (myReader.Read())
                {
                    int transtypeid = Convert.ToInt32(myReader["TransTypeID"]);
                    string transdescription = myReader["TransDescription"].ToString();
                    bool recon = Convert.ToBoolean(myReader["Recon"]);
                    bool dropsafe = Convert.ToBoolean(myReader["DropSafe"]);
                    bool needspbranch = Convert.ToBoolean(myReader["NeedsPBranch"]);
                    bool needspuser = Convert.ToBoolean(myReader["NeedsPUser"]);
                    result.Add(new TransType(transtypeid, transdescription, recon, dropsafe, needspbranch,needspuser));



                }

            }
            catch (Exception ex)
            {
                ExceptionLogger.LogMessage(ex);
            }
            try
            {
                GetTransTypesConn.Close();
            }
            catch (Exception ex)
            {
                ExceptionLogger.LogMessage(ex);
            }


            return result;

        }

        public static List<TransType> GetTransTypesWithPUser()
        {
            List<TransType> result = new List<TransType>();
            SqlConnection GetTransTypesConn = ConnFactory.GetConnection();

            try
            {
                GetTransTypesConn.Open();
            }
            catch (Exception ex)
            {
                ExceptionLogger.LogMessage(ex);
            }



            SqlCommand myCommand = new SqlCommand("SELECT * FROM TransTypes  WHERE NeedsPUser = 'true' ORDER BY cast(TransDescription as varchar(500))", GetTransTypesConn);


            try
            {
                SqlDataReader myReader = null;
                myReader = myCommand.ExecuteReader();

                while (myReader.Read())
                {
                    int transtypeid = Convert.ToInt32(myReader["TransTypeID"]);
                    string transdescription = myReader["TransDescription"].ToString();
                    bool recon = Convert.ToBoolean(myReader["Recon"]);
                    bool dropsafe = Convert.ToBoolean(myReader["DropSafe"]);
                    bool needspbranch = Convert.ToBoolean(myReader["NeedsPBranch"]);
                    bool needspuser = Convert.ToBoolean(myReader["NeedsPUser"]);
                    result.Add(new TransType(transtypeid, transdescription, recon, dropsafe, needspbranch, needspuser));



                }

            }
            catch (Exception ex)
            {
                ExceptionLogger.LogMessage(ex);
            }
            try
            {
                GetTransTypesConn.Close();
            }
            catch (Exception ex)
            {
                ExceptionLogger.LogMessage(ex);
            }


            return result;

        }

        public override string ToString()
        {
            return TransDescription;
        }
    }
}