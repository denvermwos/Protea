using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Threading;
using Xealcom.Security;
using Microsoft.VisualBasic.FileIO;



namespace Protea
{
    class FileMover
    {
        public DateTime date;
        
        //public bool upload;
        public int userID;
        public int branchID;
        public int EntryID;
        public string branch;
        private bool doneCopying = false;
        
        
        private string ServerRoot = @"\\PROTEASERVER\ProteaReceipts";//or maybe @"\\192.168.0.79\CashBooks
        private string BackupDir = @"\\PROTEASERVER\ProteaReceiptsBAK";

        //private string ServerRoot = @"c:\ProteaReceipts";//or maybe @"\\192.168.0.79\CashBooks
        //private string BackupDir = @"c:\ProteaReceiptsBAK";
        
        
        
        
        private string extension = ".pdf";
        private string extensionType = "PDF Files";
        private CashbookEntry cashBookEntry;
        //"c:\CashBooks" Directory
        // "c:\CashBooks\template\template.xls" template file to serve up when none exists
        //"c:\CashBooksBAK" which is goin to be a backup directory for the cashbooks, allowing a technician to perform one UNDO
        public FileMover()
        {
        }
        public FileMover(DateTime Date, int BranchID, int Shift, string BranchName,int UserID)
        {
            date = Date;
            branchID = BranchID;
            EntryID = Shift;
            branch = BranchName;
            userID = UserID;
        }
        public FileMover(CashbookEntry cbEntry)
        {
            date = cbEntry.EntryDate;
            branchID = cbEntry.CBEBranch.BranchID;
            userID = cbEntry.Capturer.UserID;
            EntryID = cbEntry.EntryID;
            branch = cbEntry.CBEBranch.BranchName;
            cashBookEntry = cbEntry;
        }

        private string GetUploadedFileDirectory()
        {
            return ServerRoot + @"\"; //+ date.Year.ToString() + @"\" + IntToMonth(date.Month) + @"\" + date.Day.ToString() ;//+ @"\";
        }
        private string GetBackupDirectory()
        {
            return BackupDir + @"\" + date.Year.ToString() + @"\" + IntToMonth(date.Month) + @"\" + date.Day.ToString();//+ @"\";
        }
        public DialogResult Up()
        {
            
            
            

            
            DialogResult result;
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = extensionType + "|*" + extension + "|All Files|*.*";
            ofd.Title = "UPLOAD YOUR PDF to the Server";
            
            result = ofd.ShowDialog();
            //Application.DoEvents();



            MessageBox.Show(">" + ofd.FileName + "<");
            if (ofd.FileName != "")
            {

                string filetocopy = ofd.FileName;
                //MessageBox.Show("ln 90");
                
                
                Thread copyThread = new Thread(new ThreadStart(() => MoveFileUp(filetocopy)));
                copyThread.Start();
                //MoveFileUp(filetocopy);
                
                while (!doneCopying)
                {
                    Thread.Sleep(1000);
                    //MessageBox.Show("not finished!");
                }
                
            }
            
            //MessageBox.Show("finished");
            
            
            
            
            return result;
            
        }
        private void MoveFileUp(string filetocopy)
        {

            ImpersonateUser iU = new ImpersonateUser();

            iU.Impersonate("mwos", "administrator", "WyaY1t1972");

            string UploadedFileDirectory = GetUploadedFileDirectory();
            string BackupDIR = GetBackupDirectory();

            try
            {
                //File.Copy(filetocopy, UploadedFileDirectory + @"\" + FileName(), true);
                
                
                doneCopying = false;
                CopyFile(filetocopy, UploadedFileDirectory + @"\" + FileName());
                File.Delete(filetocopy);//delete file from folder it was selected from, myscans in the case of protea
               
                cashBookEntry.ScannedFile = "Yes";
                cashBookEntry.Update();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            iU.Undo();
            
        }
        private void MoveFileDown(string filetocopyto)
        {
            ImpersonateUser iU = new ImpersonateUser();

            iU.Impersonate("mwos", "administrator", "WyaY1t1972");

            string UploadedFileDirectory = GetUploadedFileDirectory();
            string BackupDIR = GetBackupDirectory();

            try
            {
                //File.Copy(filetocopy, UploadedFileDirectory + @"\" + FileName(), true);


                doneCopying = false;
                CopyFile(UploadedFileDirectory + @"\" + FileName(),filetocopyto);
                

                cashBookEntry.ScannedFile = "Yes";
                cashBookEntry.Update();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            iU.Undo();

        }
        public DialogResult Down()
        {
            
            string UploadedFileDirectory = GetUploadedFileDirectory();
            string BackupDIR = GetBackupDirectory();
            DialogResult result = DialogResult.Cancel;
            if (!File.Exists(UploadedFileDirectory + @"\" +FileName()))
            {
                MessageBox.Show("Requested receipt does not exist in directory!");
            }
            else
            {
                
                SaveFileDialog sfd = new SaveFileDialog();

                sfd.Filter = extensionType + "|*" + extension + "|All Files|*.*";
                sfd.OverwritePrompt = false;//overwriting is fine
                sfd.Title = "DOWNLOAD a PDF from Server";
                sfd.FileName = FileName();
                result = sfd.ShowDialog();
                
                if (sfd.FileName != "")
                {
                    
                    //Application.DoEvents();
                    
                    string filecopyto = sfd.FileName;
                    

                    try
                    {

                        Thread copyThread = new Thread(new ThreadStart(() => MoveFileDown(filecopyto)));
                        copyThread.Start();
                        

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                    
                    
                    while (!doneCopying)
                    {
                        Thread.Sleep(1000);
                        //MessageBox.Show("not finished!");
                    }
                    
                }
            }
            //iU.Undo();
            return result;
        }
        public void getTemplate()
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = extensionType + "|*" + extension + "|All Files|*.*";
            sfd.Title = "DOWNLOAD a Cashbook from Server";
            sfd.ShowDialog();
            if (sfd.FileName != "")
            {
                string filecopyto = sfd.FileName;


                try
                {
                    if (!File.Exists(ServerRoot + @"\template\template" + extension))
                    {
                        MessageBox.Show("Template file does not exist--" + ServerRoot + @"\template\template" + extension);
                    }
                    else
                    {
                        File.Copy(ServerRoot + @"\template\template" + extension, filecopyto, true);
                    }
                    

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            
        }
        private string IntToMonth(int monthAsInt)
        {
            switch (monthAsInt)
            {
                case 1: return "January";
                case 2: return "February";
                case 3: return "March";
                case 4: return "April";
                case 5: return "May";
                case 6: return "June";
                case 7: return "July";
                case 8: return "August";
                case 9: return "September";
                case 10: return "October";
                case 11: return "November";
                case 12: return "December";
                default: return "unknownmonth";
            }
            

        }
        private string FileName()
        {
            string filename;
            filename = branch + date.Day.ToString() + IntToMonth(date.Month) + date.Year.ToString() + "-" + EntryID.ToString("0000000000") + extension;
            return filename;
        }


        //xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
        public void CopyFile(string source, string dest)
        {
            
            doneCopying = false;
            //MessageBox.Show("hello");
            
            //using (FileStream sourceStream = new FileStream(source, FileMode.Open))
            //{
            //    byte[] buffer = new byte[64 * 1024]; // Change to suitable size after testing performance
            //    using (FileStream destStream = new FileStream(dest, FileMode.Create))
            //    {
            //        int i;
            //        while ((i = sourceStream.Read(buffer, 0, buffer.Length)) > 0)
            //        {
            //            destStream.Write(buffer, 0, i);
            //            //OnProgress(sourceStream.Position, sourceStream.Length);
            //        }
            //    }
            //}
            File.Copy(source, dest,true);
            doneCopying = true;
        }
    }
}
