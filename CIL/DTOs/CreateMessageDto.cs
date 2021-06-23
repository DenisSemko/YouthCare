using System;
using System.Collections.Generic;
using System.Text;

namespace CIL.DTOs
{
    public class CreateMessageDto
    {
        public string SenderUsername { get; set; }
        public string RecepientUsername { get; set; }
        public string Content { get; set; }
    }
}
