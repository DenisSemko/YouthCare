using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace YouthCareServer.Models
{
    public class Analysis
    {
        [Required]
        public Guid Id { get; set; }
        public User SportsmanUserId { get; set; }
        public User DoctorUserId { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public string Type { get; set; }
        public double Weight { get; set; }
        public double Height { get; set; }
        public double Measure { get; set; }
        public string Description { get; set; }
        public bool? Result { get; set; }
    }
}
