using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SerienbriefMailer
{
    public class Email
    {  
        public MailAttachments ma = new MailAttachments();

        public Email(string pRecipient, string subject, string body, MailAttachment mailAttachment)
        {
            Recipient = pRecipient;
            this.Subject = subject;
            this.Body = body;
            ma.Add(mailAttachment);
        }

        public int Id { get; set; }

        public string Recipient { get; set; }
        
        public string Subject { get; set; }
        
        public string  Body { get; set; }

        public string Success { get; set; }

        public List<MailAttachment> mailAttachment { get; set; }

        public MailAttachment MailAttachment { get; set; }
    }
}
