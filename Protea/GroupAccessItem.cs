using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;


namespace Protea
{
    public class GroupAccessItem
    {
        public int GroupID;
        public int AccessItemID;
        public bool HasAccess;
        public GroupAccessItem(int groupid, int accessitemid, bool hasaccess)
        {
            GroupID = groupid;
            AccessItemID = accessitemid;
            HasAccess = hasaccess;
        }
        public GroupAccessItem(int groupid, int accessitemid)
        {
            GroupID = groupid;
            AccessItemID = accessitemid;
            HasAccess = false;
        }

        public void Update()
        {
            try
            {
                using (var con = ConnFactory.GetConnection())
                {

                    var cmd = "UPDATE GroupsAccessItems SET HasAccess=@HasAccess WHERE GroupID=@GroupID AND AccessItemID = @AccessItemID";
                    using (var insertCommand = new SqlCommand(cmd, con))
                    {
                        
                        insertCommand.Parameters.AddWithValue("@GroupID", GroupID);
                        insertCommand.Parameters.AddWithValue("@AccessItemID", AccessItemID);
                        insertCommand.Parameters.AddWithValue("@HasAccess", HasAccess);
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
        
        /// <summary>
        /// For use with new group, will allow user to set items access without having a groupid first
        /// </summary>
        /// <param name="dict"></param>
        /// <param name="group"></param>
        public static void SaveDictionary(Dictionary<string, GroupAccessItem> dict,int groupid)
        {
            foreach (KeyValuePair<string, GroupAccessItem> pair in dict)
            {
                pair.Value.GroupID = groupid;
                pair.Value.Update();
            }
        }
        public static Dictionary<string, GroupAccessItem> GetGroupsAccessItems(int groupid)
        {
            Dictionary<string,GroupAccessItem> result = new Dictionary<string,GroupAccessItem>();
            SqlConnection GetGroupsAccessItemsConn = ConnFactory.GetConnection();

            try
            {
                GetGroupsAccessItemsConn.Open();
            }
            catch (Exception ex)
            {
                ExceptionLogger.LogMessage(ex);
            }



            SqlCommand myCommand = new SqlCommand("SELECT * FROM GroupsAccessItems LEFT JOIN AccessItems ON GroupsAccessItems.AccessItemID = AccessItems.AccessItemID WHERE GroupsAccessItems.GroupID = @GroupID", GetGroupsAccessItemsConn);


            try
            {
                SqlDataReader myReader = null;
                myCommand.Parameters.AddWithValue("@GroupID", groupid);
                myReader = myCommand.ExecuteReader();
                
                while (myReader.Read())
                {
                    GroupAccessItem tempGroupAccessItem = new GroupAccessItem(Convert.ToInt32(myReader["GroupID"]),Convert.ToInt32(myReader["AccessItemID"]),Convert.ToBoolean(myReader["HasAccess"]));
                    

                    result.Add(myReader["AccessName"].ToString(),tempGroupAccessItem);



                }

            }
            catch (Exception ex)
            {
                ExceptionLogger.LogMessage(ex);
            }
            try
            {
                GetGroupsAccessItemsConn.Close();
            }
            catch (Exception ex)
            {
                ExceptionLogger.LogMessage(ex);
            }


            return result;

        }
        public static Dictionary<string, GroupAccessItem> GetGroupLessAccessItems()
        {
            Dictionary<string, GroupAccessItem> result = new Dictionary<string, GroupAccessItem>();
            SqlConnection GetGroupsAccessItemsConn = ConnFactory.GetConnection();

            try
            {
                GetGroupsAccessItemsConn.Open();
            }
            catch (Exception ex)
            {
                ExceptionLogger.LogMessage(ex);
            }



            SqlCommand myCommand = new SqlCommand("SELECT * FROM AccessItems", GetGroupsAccessItemsConn);


            try
            {
                SqlDataReader myReader = null;
                
                myReader = myCommand.ExecuteReader();

                while (myReader.Read())
                {
                    GroupAccessItem tempGroupAccessItem = new GroupAccessItem(0, Convert.ToInt32(myReader["AccessItemID"]), false);


                    result.Add(myReader["AccessName"].ToString(), tempGroupAccessItem);



                }

            }
            catch (Exception ex)
            {
                ExceptionLogger.LogMessage(ex);
            }
            try
            {
                GetGroupsAccessItemsConn.Close();
            }
            catch (Exception ex)
            {
                ExceptionLogger.LogMessage(ex);
            }


            return result;

        }
        
    }
}
