using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace CIL.Models
{
    public class EmailMessageAttachment : EmailMessage
    {
        public IFormFileCollection EmailAttachments { get; set; }
        public EmailMessageAttachment() { }
        public EmailMessageAttachment(string to, string subject, string content) : base(to, subject, content) { }

    }
}
