using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Protea
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {   
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            frmLogin login = new frmLogin();
            if (login.ShowDialog() == DialogResult.OK)
            {
                
                if (frmLogin.user.ChangePwd)
                {
                    frmChangePwd chngpwd = new frmChangePwd(frmLogin.user);
                    if (chngpwd.ShowDialog() == DialogResult.OK)
                    {

                        Application.Run(new frmMain(User.GetUserByID(frmLogin.user.UserID)));
                    }

                }
                else
                {
                    
                    Application.Run(new frmMain(frmLogin.user));
                    
                }
            }
        }
    }
}
//      151326-420402-902004-753893-587412-457022-048575-