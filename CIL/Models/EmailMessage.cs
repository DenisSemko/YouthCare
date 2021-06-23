using System;
using System.Collections.Generic;
using System.Text;

namespace CIL.Models
{
    public class EmailMessage
    {
        public string EmailTo { get; set; }
        public string Subject { get; set; }
        public string Content { get; set; }

        public EmailMessage()
        {

        }
        public EmailMessage(string to, string subject, string content)
        {
            EmailTo = to;
            Subject = subject;
            Content = content;
        }
    }
}
