using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace CIL.Models
{
    public class Treatment
    {
        [Required]
        public Guid Id { get; set; }
        public User SportsmanUserId { get; set; }
        public User DoctorUserId { get; set; }
        public string Description { get; set; }
        public DateTime DateBegin { get; set; }
        public DateTime DateEnd { get; set; }

        [IgnoreDataMember]
        public ICollection<ObservationNote> ObservationNotes { get; set; }
    }
}
