using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CIL.Models;

namespace CIL.DTOs
{
    public class AnalysisDto
    {
        public Guid Id { get; set; }
        public Guid SportsmanUserId { get; set; }
        public Guid DoctorUserId { get; set; }
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
