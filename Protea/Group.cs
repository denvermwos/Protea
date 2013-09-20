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
    public class Group
    {
        public int GroupID;
        public string GroupName;
        public Dictionary<string, GroupAccessItem> GroupsAccessDict;
        public bool groupIsNew = false;
        
        public Group(string groupname)
        {
            GroupName = groupname;
            groupIsNew = true;
            GroupsAccessDict = GroupAccessItem.GetGroupLessAccessItems();
            
        }
        public Group(int groupid, string groupname)
        {
            GroupID = groupid;
            GroupName = groupname;
            GroupsAccessDict = GroupAccessItem.GetGroupsAccessItems(GroupID);
        }
        public void Save()
        {
            if (groupIsNew)
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

                    var cmd = "uspNewGroupInsert";
                    using (var insertCommand = new SqlCommand(cmd, con))
                    {
                        insertCommand.CommandType = CommandType.StoredProcedure;
                        insertCommand.Parameters.AddWithValue("@GroupName", GroupName);

                        con.Open();
                        GroupID=(int)insertCommand.ExecuteScalar();
                        groupIsNew = false;

                    }
                }
                GroupAccessItem.SaveDictionary(GroupsAccessDict,GroupID);
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

                    var cmd = "UPDATE Groups SET GroupName=@GroupName WHERE GroupID=@GroupID";
                    using (var insertCommand = new SqlCommand(cmd, con))
                    {
                        insertCommand.Parameters.AddWithValue("@GroupName", GroupName);
                        insertCommand.Parameters.AddWithValue("@GroupID", GroupID);
                        con.Open();
                        insertCommand.ExecuteNonQuery();

                    }
                }
                GroupAccessItem.SaveDictionary(GroupsAccessDict, GroupID);
            }
            catch (Exception ex)
            {

                ExceptionLogger.LogMessage(ex);
            }
        }

        public static Group GetGroupByID(int ID)
        {
            Group result = null;
            SqlConnection GetGroupByIDConn = ConnFactory.GetConnection();

            try
            {
                GetGroupByIDConn.Open();
            }
            catch (Exception ex)
            {
                ExceptionLogger.LogMessage(ex);
            }



            SqlCommand myCommand = new SqlCommand("SELECT * FROM Groups WHERE GroupID = @GroupID", GetGroupByIDConn);
            myCommand.Parameters.AddWithValue("@GroupID", ID);

            try
            {
                SqlDataReader myReader = null;
                myReader = myCommand.ExecuteReader();

                if (myReader.Read())
                {
                    int groupid = Convert.ToInt32(myReader["GroupID"]);
                    string groupname = myReader["GroupName"].ToString();

                    result = new Group(groupid, groupname);



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
                GetGroupByIDConn.Close();
            }
            catch (Exception ex)
            {
                ExceptionLogger.LogMessage(ex);
            }


            return result;

        }
        public static List<Group> GetGroups()
        {
            List<Group> result = new List<Group>();
            SqlConnection GetGroupsConn = ConnFactory.GetConnection();

            try
            {
                GetGroupsConn.Open();
            }
            catch (Exception ex)
            {
                ExceptionLogger.LogMessage(ex);
            }



            SqlCommand myCommand = new SqlCommand("SELECT * FROM Groups", GetGroupsConn);


            try
            {
                SqlDataReader myReader = null;
                myReader = myCommand.ExecuteReader();

                while (myReader.Read())
                {
                    int groupid = Convert.ToInt32(myReader["GroupID"]);
                    string groupname = myReader["GroupName"].ToString();

                    result.Add(new Group(groupid, groupname));



                }

            }
            catch (Exception ex)
            {
                ExceptionLogger.LogMessage(ex);
            }
            try
            {
                GetGroupsConn.Close();
            }
            catch (Exception ex)
            {
                ExceptionLogger.LogMessage(ex);
            }


            return result;

        }
        public static bool GroupNameAvailable(Group group)
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



            SqlCommand myCommand = new SqlCommand("SELECT * FROM Groups WHERE GroupName = @GroupName", UsernameExistsConn);
            if (!group.groupIsNew)
            {
                myCommand.CommandText = "SELECT * FROM Groups WHERE GroupName = @GroupName AND GroupID != @GroupID";
                myCommand.Parameters.AddWithValue("@GroupID", group.GroupID);
            }

            myCommand.Parameters.AddWithValue("@GroupName", group.GroupName);

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
        public override string ToString()
        {
            return GroupName;
        }


    }
}
