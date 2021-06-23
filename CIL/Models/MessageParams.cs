using System;
using System.Collections.Generic;
using System.Text;

namespace CIL.Models
{
    public class MessageParams : PaginationParams
    {
        public string Container { get; set; } = "Unread";
    }
}
