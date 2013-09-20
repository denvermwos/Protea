using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Sql;
using System.Data.SqlClient;

namespace Protea
{
    //Drop Safe Entry
    class DropSafeEntry
    {
        public long EntryID;
        public DateTime EntryDate;
        public int BranchID;
        public int CapturerUserID;
        public string Description;
        public decimal Amount;

        public DropSafeEntry(long entryid, DateTime entrydate, int branchid, int captureruserid, string description, decimal amount)
        {
            EntryID = entryid;
            EntryDate = entrydate;
            BranchID = branchid;
            CapturerUserID = captureruserid;
            Description = description;
            Amount = amount;
        }
        public void Save()
        {
            using (var con = ConnFactory.GetConnection())
            {

                var cmd = "INSERT INTO DropSafe (EntryID,EntryDate,BranchID,CapturerUserID,Description,Amount)VALUES (@EntryID,@EntryDate,@BranchID,@CapturerUserID,@Description,@Amount)";
                using (var insertCommand = new SqlCommand(cmd, con))
                {
                    insertCommand.Parameters.AddWithValue("@EntryID", EntryID);
                    insertCommand.Parameters.AddWithValue("@EntryDate", EntryDate);
                    insertCommand.Parameters.AddWithValue("@BranchID", BranchID);
                    insertCommand.Parameters.AddWithValue("@CapturerUserID", CapturerUserID);
                    insertCommand.Parameters.AddWithValue("@Description", Description);
                    insertCommand.Parameters.AddWithValue("@Amount", Amount);
                    con.Open();
                    insertCommand.ExecuteNonQuery();
                }
            }
        }

    }
}
