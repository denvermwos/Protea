using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Sql;
using System.Data.SqlClient;

namespace Protea
{
    class ExceptionEntry
    {
        public DateTime ExceptionDate;
        public string ExceptionText;
        public User ExceptionUser;
        public ExceptionEntry(DateTime exceptiondate, string exceptiontext, User exceptionuser)
        {
            ExceptionDate = exceptiondate;
            ExceptionText = exceptiontext;
            ExceptionUser = exceptionuser;
        }
        public void Save()
        {
            using (var con = ConnFactory.GetConnection())
            {

                var cmd = "INSERT INTO ExceptionLog (ExceptionDate,ExceptionText,ExceptionUserID) VALUES (@ExceptionDate,@ExceptionText,@ExceptionUserID)";
                using (var insertCommand = new SqlCommand(cmd, con))
                {

                    insertCommand.Parameters.AddWithValue("@ExceptionDate", ExceptionDate);
                    insertCommand.Parameters.AddWithValue("@ExceptionText", ExceptionText);
                    insertCommand.Parameters.AddWithValue("@ExceptionUserID", ExceptionUser.UserID);

                    con.Open();
                    insertCommand.ExecuteNonQuery();

                }
            }
        }
    

    }
}
