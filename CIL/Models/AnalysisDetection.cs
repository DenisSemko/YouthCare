using System;
using System.Collections.Generic;
using System.Text;

namespace CIL.Models
{
    public class AnalysisDetection
    {
        public Guid Id { get; set; }
        public Guid SportsmanId { get; set; }
        public Guid DoctorId { get; set; }
        public string AnalysisType { get; set; }
    }
}
