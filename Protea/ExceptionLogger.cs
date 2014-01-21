using System;
using System.Windows.Forms;

namespace Protea
{
    class ExceptionLogger
    {
        //public static User user;
        public ExceptionLogger()
        {
        }
        public static void LogMessage(Exception ex)
        {
            //ExceptionEntry exceptionEntry = new ExceptionEntry(DateTime.Now, ex.ToString(), frmLogin.user);
            //exceptionEntry.Save();
            MessageBox.Show(ex.ToString(),"Protea");//"An error has occured and has been logged. Application must be closed");
            Application.Exit();
        }
    }
}
