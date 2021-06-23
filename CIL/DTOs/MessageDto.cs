using System;
using System.Collections.Generic;
using System.Text;

namespace CIL.DTOs
{
    public class MessageDto
    {
        public Guid Id { get; set; }
        public Guid SenderId { get; set; }
        public string SenderUsername { get; set; }
        public Guid RecepientId { get; set; }
        public string RecepientUsername { get; set; }
        public string Content { get; set; }
        public DateTime? MessageRead { get; set; }
        public DateTime MessageSent { get; set; }

    }
}
