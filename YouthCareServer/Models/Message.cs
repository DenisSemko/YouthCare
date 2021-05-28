﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace YouthCareServer.Models
{
    public class Message
    {
        [Required]
        public Guid Id { get; set; }
        public User SenderId { get; set; }
        public string SenderUsername { get; set; }
        public User RecepientId { get; set; }
        public string RecepientUsername { get; set; }
        public string Content { get; set; }
        public DateTime MessageSent { get; set; }
    }
}
