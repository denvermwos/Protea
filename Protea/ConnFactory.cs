using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Protea
{
    class ConnFactory
    {
        public static SqlConnection GetConnection()
        {
            //SqlConnection conn = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Protea\Protea\Protea.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True");
            SqlConnection conn = new SqlConnection(@"Data Source=tcp:192.168.0.85,1433;Database=Protea;User Id=sa;Password=shift1234;");
            return conn;
            
        }
    }
}
