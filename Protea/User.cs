using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Data.Sql;
using System.Windows.Forms;
namespace Protea
{
    public class User
    {
        public int UserID;
        public int StaffNo;
        public string FName;
        public string LName;
        public string Username;
        public string UserPassword;
        public Group UserGroup;
        public Branch UserBranch;
        public bool ChangePwd;
        private bool userIsNew;
        
        public User()
        {
        }
        public User(int userid, string fname, string lname)
        {
            UserID = userid;
            FName = fname;
            LName = lname;
            
        }
        public User(int userid, string fname, string lname, bool changepwd)
        {
            UserID = userid;
            FName = fname;
            LName = lname;
            ChangePwd = changepwd;
        }
        public User(int userid, int staffno, string fname, string lname, string username, string userpassword, Group usergroup , Branch userbranch, bool changepwd)
        {
            userIsNew = false;

            UserID = userid;
            StaffNo = staffno;
            FName = fname;
            LName = lname;
            Username = username;
            UserPassword = userpassword;
            UserGroup = usergroup;
            UserBranch = userbranch;
            ChangePwd = changepwd;
        }
        public User(int staffno, string fname, string lname, string username, string userpassword, Group usergroup, Branch userbranch, bool changepwd)
        {
            userIsNew = true;

            StaffNo = staffno;
            FName = fname;
            LName = lname;
            Username = username;
            UserPassword = userpassword;
            UserGroup = usergroup;
            UserBranch = userbranch;
            ChangePwd = changepwd;
        }
        public override string ToString()
        {
            return FName + " " + LName;
        }
        public void ChangePassword(string newpwd)
        {
            using (var con = ConnFactory.GetConnection())
            {

                var cmd = "UPDATE Users SET UserPassword=@UserPassword,ChangePwd='False' WHERE UserID=@UserID";
                using (var updateCommand = new SqlCommand(cmd, con))
                {
                    updateCommand.Parameters.AddWithValue("@UserPassword", newpwd);
                    updateCommand.Parameters.AddWithValue("@UserID", UserID);
                    con.Open();
                    updateCommand.ExecuteNonQuery();

                }
            }
        }
        public void Save()
        {
            if (userIsNew)
            {
                Insert();
            }
            else
            {
                Update();
            }
        }
        public void Insert()
        {
            try
            {
                using (var con = ConnFactory.GetConnection())
                {

                    var cmd = "INSERT INTO Users (StaffNo,FName,LName,Username,UserPassword,GroupID,BranchID,ChangePwd) VALUES (@StaffNo,@FName,@LName,@Username,@UserPassword,@GroupID,@BranchID,@ChangePwd);SELECT CAST(scope_identity() AS int)";
                   //var cmd = "INSERT INTO Users (StaffNo,FName,LName,Username,UserPassword,GroupID,BranchID,ChangePwd) VALUES (@StaffNo,@FName,@LName,@Username,@UserPassword,@GroupID,@BranchID,@ChangePwd);SELECT CAST(scope_identity() AS int)";
                    using (var insertCommand = new SqlCommand(cmd, con))
                    {
                        insertCommand.Parameters.AddWithValue("@StaffNo", StaffNo);
                        insertCommand.Parameters.AddWithValue("@FName", FName);
                        insertCommand.Parameters.AddWithValue("@LName", LName);
                        insertCommand.Parameters.AddWithValue("@Username", Username);
                        insertCommand.Parameters.AddWithValue("@UserPassword", UserPassword);
                        insertCommand.Parameters.AddWithValue("@GroupID", UserGroup.GroupID);
                        insertCommand.Parameters.AddWithValue("@BranchID", UserBranch.BranchID);
                        insertCommand.Parameters.AddWithValue("@ChangePwd", ChangePwd);
                        con.Open();
                        UserID = Convert.ToInt32(insertCommand.ExecuteScalar());
                        userIsNew = false;
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
            using (var con = ConnFactory.GetConnection())
            {

                var cmd = "UPDATE Users SET FName=@FName,LName=@LName,Username=@Username,UserPassword=@UserPassword,StaffNo=@StaffNo,GroupID=@GroupID,BranchID=@BranchID,ChangePwd=@ChangePwd WHERE UserID=@UserID";
                using (var insertCommand = new SqlCommand(cmd, con))
                {
                    insertCommand.Parameters.AddWithValue("@UserID", UserID);
                    insertCommand.Parameters.AddWithValue("@FName", FName);
                    insertCommand.Parameters.AddWithValue("@LName", LName);
                    insertCommand.Parameters.AddWithValue("@Username", Username);
                    insertCommand.Parameters.AddWithValue("@UserPassword", UserPassword);
                    insertCommand.Parameters.AddWithValue("@StaffNo", StaffNo);
                    insertCommand.Parameters.AddWithValue("@GroupID", UserGroup.GroupID);
                    insertCommand.Parameters.AddWithValue("@BranchID", UserBranch.BranchID);
                    insertCommand.Parameters.AddWithValue("@ChangePwd", ChangePwd);
                    con.Open();
                    insertCommand.ExecuteNonQuery();

                }
            }
            
        }
        public static List<User> GetUsers()
        {
            List<User> users = new List<User>();

            SqlConnection GetUsersConn = ConnFactory.GetConnection();

            try
            {
                GetUsersConn.Open();
            }
            catch (Exception ex)
            {
                ExceptionLogger.LogMessage(ex);
            }



            SqlCommand myCommand = new SqlCommand("SELECT * FROM Users ORDER BY StaffNo ASC", GetUsersConn);
            

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

                    User tempuser = new User(userid, staffno, fname, lname, username, userpassword, Group.GetGroupByID(groupid), Branch.GetBranchByID(userbranch), changepwd);

                    users.Add(tempuser);


                }
                
            }
            catch (Exception ex)
            {
                ExceptionLogger.LogMessage(ex);
            }
            try
            {
                GetUsersConn.Close();
            }
            catch (Exception ex)
            {
                ExceptionLogger.LogMessage(ex);
            }
            
            return users;
        }
        public static List<User> GetUsersExcept(User user)
        {
            List<User> users = new List<User>();

            SqlConnection GetUsersConn = ConnFactory.GetConnection();

            try
            {
                GetUsersConn.Open();
            }
            catch (Exception ex)
            {
                ExceptionLogger.LogMessage(ex);
            }



            SqlCommand myCommand = new SqlCommand("SELECT * FROM Users ORDER BY FName,LName ASC", GetUsersConn);
            myCommand.Parameters.AddWithValue("@UserID", user.UserID);


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

                    User tempuser = new User(userid, staffno, fname, lname, username, userpassword, Group.GetGroupByID(groupid), Branch.GetBranchByID(userbranch), changepwd);

                    users.Add(tempuser);


                }

            }
            catch (Exception ex)
            {
                ExceptionLogger.LogMessage(ex);
            }
            try
            {
                GetUsersConn.Close();
            }
            catch (Exception ex)
            {
                ExceptionLogger.LogMessage(ex);
            }

            return users;
        }
        public static List<User> GetUsersFromBranch(User user, bool includeCBUser)
        {
            List<User> users = new List<User>();

            SqlConnection GetUsersConn = ConnFactory.GetConnection();

            try
            {
                GetUsersConn.Open();
            }
            catch (Exception ex)
            {
                ExceptionLogger.LogMessage(ex);
            }


            string cmd = "SELECT * FROM Users WHERE BranchID = @BranchID ";
            if (!includeCBUser)
            {
                cmd += "AND UserID != @UserID ";
            }
            cmd += "ORDER BY StaffNo ASC";
            SqlCommand myCommand = new SqlCommand(cmd, GetUsersConn);
            myCommand.Parameters.AddWithValue("@BranchID", user.UserBranch.BranchID);
            myCommand.Parameters.AddWithValue("@UserID", user.UserID);

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

                    User tempuser = new User(userid, staffno, fname, lname, username, userpassword, Group.GetGroupByID(groupid), Branch.GetBranchByID(userbranch), changepwd);

                    users.Add(tempuser);


                }

            }
            catch (Exception ex)
            {
                ExceptionLogger.LogMessage(ex);
            }
            try
            {
                GetUsersConn.Close();
            }
            catch (Exception ex)
            {
                ExceptionLogger.LogMessage(ex);
            }

            return users;
        }
        public static User GetUserByID(int ID)
        {
            User result = null;

            

            SqlConnection GetUserByIDConn = ConnFactory.GetConnection();

            try
            {
                GetUserByIDConn.Open();
            }
            catch (Exception ex)
            {
                ExceptionLogger.LogMessage(ex);
            }


            
            SqlCommand myCommand = new SqlCommand("SELECT * FROM Users WHERE UserID = @UserID", GetUserByIDConn);
            myCommand.Parameters.AddWithValue("@UserID", ID);

            try
            {
                SqlDataReader myReader = null;
                myReader = myCommand.ExecuteReader();

                if (myReader.Read())
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

                    result = new User(userid,staffno, fname,lname,username,userpassword,Group.GetGroupByID(groupid),Branch.GetBranchByID(userbranch),changepwd);

                    

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
                GetUserByIDConn.Close();
            }
            catch (Exception ex)
            {
                ExceptionLogger.LogMessage(ex);
            }


            return result;
        }
        public static bool UsernameAvailable(User user)
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



            SqlCommand myCommand = new SqlCommand("SELECT * FROM Users WHERE Username = @Username", UsernameExistsConn);
            if (!user.userIsNew)
            {
                myCommand.CommandText = "SELECT * FROM Users WHERE Username = @Username AND UserID != @UserID";
                myCommand.Parameters.AddWithValue("@UserID", user.UserID);
            }
            
            myCommand.Parameters.AddWithValue("@Username", user.Username);

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
        }
}
