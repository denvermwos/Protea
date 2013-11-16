using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Protea
{
    public class Publication
    {
        public int PublicationID {get;set;}
        public string PublicationName { get; set; }
        public decimal PublicationPrice { get; set; }

        public Publication(int publicationID, string publicationName, decimal publicationPrice)
        {
            PublicationID = publicationID;
            PublicationName = publicationName;
            PublicationPrice = publicationPrice;
        }
        public override string ToString()
        {
            return PublicationName;
        }
        public static List<Publication> GetPublications()
        {
            List<Publication> publications =  new List<Publication>();
            SqlConnection GetPublicationsConn = ConnFactory.GetConnection();

            try
            {
                GetPublicationsConn.Open();
            }
            catch (Exception ex)
            {
                ExceptionLogger.LogMessage(ex);
            }



            SqlCommand myCommand = new SqlCommand("SELECT * FROM Publications", GetPublicationsConn);


            try
            {
                SqlDataReader myReader = null;
                myReader = myCommand.ExecuteReader();

                while (myReader.Read())
                {

                    Publication tempPublication = new Publication(Convert.ToInt32(myReader["PublicationID"]), myReader["PublicationName"].ToString(), Convert.ToDecimal(myReader["PublicationPrice"]));
                    publications.Add(tempPublication);

                }

            }
            catch (Exception ex)
            {
                ExceptionLogger.LogMessage(ex);
            }
            try
            {
                GetPublicationsConn.Close();
            }
            catch (Exception ex)
            {
                ExceptionLogger.LogMessage(ex);
            }

            return publications;
        }
    }
}
