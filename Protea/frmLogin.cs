using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Protea
{
    public partial class frmLogin : Form
    {
        public static string uname;
        public static int userid;
        public static bool isadmin;
        public static User user;

        public frmLogin()
        {
            InitializeComponent();
            

        }
        private void AuthenticateUser()
        {
            SqlConnection loginConn = ConnFactory.GetConnection();

            try
            {
                loginConn.Open();
            }
            catch (Exception ex)
            {
                ExceptionLogger.LogMessage(ex);
            }


            SqlParameter userName = new SqlParameter("@userName", SqlDbType.VarChar, 50);
            userName.Value = txtUsername.Text;
            SqlParameter userPassword = new SqlParameter("@userPassword", SqlDbType.VarChar, 50);
            userPassword.Value = txtPassword.Text;
            SqlCommand myCommand = new SqlCommand("SELECT * FROM Users WHERE Username = @userName AND UserPassword = @userPassword", loginConn);
            myCommand.Parameters.Add(userName);
            myCommand.Parameters.Add(userPassword);

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

                    user = new User(userid, staffno, fname, lname, username, userpassword, Group.GetGroupByID(groupid), Branch.GetBranchByID(userbranch), changepwd);

                    //There was a valid entry in the db, this means that the username and password were correct
                    //            this.DialogResult = DialogResult.Yes;
                    if (cboxChangePwd.Checked == true)
                    {
                        user.ChangePwd = true;
                    }
                    this.DialogResult = DialogResult.OK;

                }
                else
                {
                    //no vaid entry, this was an unsuccessful attemp to login
                    MessageBox.Show("Incorrect username or password.");

                }
            }
            catch (Exception ex)
            {
                ExceptionLogger.LogMessage(ex);
            }
            try
            {
                loginConn.Close();
            }
            catch (Exception ex)
            {
                ExceptionLogger.LogMessage(ex);
            }
        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            AuthenticateUser();

        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            
        }
    }
}
