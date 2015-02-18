using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerienbriefMailer
{
    public static class Global
    {
        public static string SmtpServer
        {
            get;
            set;
        }
        public static string SmtpUser
        {
            get;
            set;
        }
        public static string SmtpPort
        {
            get;
            set;
        }
        public static string SmtpPassword { get; set; }

        public static bool MailSettingsValid
        {
            get;
            set;
        }

        public static bool SubjectBodyValid { get; set; }

        public static bool CsvValid
        {
            get;
            set;
        }

        public static bool PdfValid
        {
            get;
            set;
        }
        public static string Subject
        {
            get;
            set;
        }
        public static string Body
        {
            get;
            set;
        }
        public static int NumberOfPages
        {
            get;
            set;
        }
        public static int NumberOfEmails
        {
            get;
            set;
        }
        public static System.Collections.ArrayList ListOfRecipients
        {
            get;
            set;
        }

    }
}
