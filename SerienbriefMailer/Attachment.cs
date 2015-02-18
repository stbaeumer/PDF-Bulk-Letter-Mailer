using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SerienbriefMailer
{
    public class MailAttachment
    {
        public MailAttachment(string pRecipient, int pFileNumber, int pPage)
        {            
            Recipient = pRecipient;
            FileNumber = pFileNumber;
            PageNumber = pPage;
        }
        public string Recipient { get; set; }
        public int FileNumber { get; set; }
        public int PageNumber { get; set; }
        public Email Email { get; set; }
    }
}
