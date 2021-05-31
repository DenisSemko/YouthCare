using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CIL.Models
{
    public class SportsmanNote
    {
        [Required]
        public Guid Id { get; set; }

        [Required]
        public User SportsmanUserId { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
    }
}
