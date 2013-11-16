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

                    int publicationID = Convert.ToInt32(myReader["PublicationID"]);
                    string publicationName = myReader["PublicationName"].ToString();
                    decimal publicationPrice = Convert.ToDecimal(myReader["PublicationPrice"]);
                    Publication tempPublication = new Publication(publicationID, publicationName, publicationPrice);
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
