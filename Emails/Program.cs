using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Outlook;


namespace Emails
{
    class Program
    {
        static void Main(string[] args)
        {
            Microsoft.Office.Interop.Outlook.Application app = null;
            Microsoft.Office.Interop.Outlook._NameSpace ns = null;
            Microsoft.Office.Interop.Outlook.PostItem item = null;
            Microsoft.Office.Interop.Outlook.MAPIFolder inboxFolder = null;
            Microsoft.Office.Interop.Outlook.MAPIFolder subFolder = null;

            try
            {
                app = new Microsoft.Office.Interop.Outlook.Application();
                ns = app.GetNamespace("MAPI");
                ns.Logon(null, null, false, false);

                inboxFolder = ns.GetDefaultFolder(Microsoft.Office.Interop.Outlook.OlDefaultFolders.olFolderInbox);
                subFolder = inboxFolder.Folders["MySubFolderName"]; //folder.Folders[1]; also works
                Console.WriteLine("Folder Name: {0}, EntryId: {1}", subFolder.Name, subFolder.EntryID);
                Console.WriteLine("Num Items: {0}", subFolder.Items.Count.ToString());

                for (int i = 1; i <= subFolder.Items.Count; i++)
                {
                    item = (Microsoft.Office.Interop.Outlook.PostItem)subFolder.Items[i];
                    Console.WriteLine("Item: {0}", i.ToString());
                    Console.WriteLine("Subject: {0}", item.Subject);
                    Console.WriteLine("Sent: {0} {1}", item.SentOn.ToLongDateString(), item.SentOn.ToLongTimeString());
                    Console.WriteLine("Categories: {0}", item.Categories);
                    Console.WriteLine("Body: {0}", item.Body);
                    Console.WriteLine("HTMLBody: {0}", item.HTMLBody);
                }
            }
            catch (System.Runtime.InteropServices.COMException ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                ns = null;
                app = null;
                inboxFolder = null;
            }
            //Application outlookApplication = new Application();
            //NameSpace outlookNamespace = outlookApplication.GetNamespace("MAPI");
            //MAPIFolder inboxFolder = outlookNamespace.GetDefaultFolder(OlDefaultFolders.olFolderInbox);
            //Items mailItems = inboxFolder.Items;

            //try
            //{
            //    //outlookApplication = new Application();
            //    //outlookNamespace = outlookApplication.GetNamespace("MAPI");
            //    //inboxFolder = outlookNamespace.GetDefaultFolder(OlDefaultFolders.olFolderInbox);
            //    //mailItems = inboxFolder.Items;

            //    foreach (MailItem item in mailItems)
            //    {
            //        var stringBuilder = new StringBuilder();
            //        stringBuilder.AppendLine("From: " + item.SenderEmailAddress);
            //        stringBuilder.AppendLine("To: " + item.To);
            //        stringBuilder.AppendLine("CC: " + item.CC);
            //        stringBuilder.AppendLine("");
            //        stringBuilder.AppendLine("Subject: " + item.Subject);
            //        stringBuilder.AppendLine(item.Body);

            //        Console.WriteLine(stringBuilder);
            //        Marshal.ReleaseComObject(item);
            //    }
            //}
            //catch { }
            //finally
            //{
            //    ReleaseComObject(mailItems);
            //    ReleaseComObject(inboxFolder);
            //    ReleaseComObject(outlookNamespace);
            //    ReleaseComObject(outlookApplication);
            //}
        }

        private static void ReleaseComObject(object obj)
        {
            if (obj != null)
            {
                Marshal.ReleaseComObject(obj);
                obj = null;
            }
        }
    }
}
