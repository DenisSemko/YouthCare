using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace YouthCareServer.Models
{
    public class User : IdentityUser<Guid>
    {
        //By default: Id, Email, PasswordHash, PhoneNumber, UserName
        [Required]
        public string Name { get; set; }

        public string MiddleName { get; set; }

        [Required]
        public string Surname { get; set; }

        public DateTime BirthDate { get; set; }
        public string Gender { get; set; }

        public string Address { get; set; }
        public string ProfilePicture { get; set; }

        [Required]
        public string UserType { get; set; }
        public bool ParentsAgreement { get; set; }

        [IgnoreDataMember]
        public ICollection<Treatment> TreatmentSportsman { get; set; }

        [IgnoreDataMember]
        public ICollection<Treatment> TreatmentDoctor { get; set; }

        [IgnoreDataMember]
        public ICollection<ObservationNote> ObservationNotes { get; set; }

        public Section BelongSection { get; set; }

        [IgnoreDataMember]
        public ICollection<SportsmanNote> SportsmanNotes { get; set; }

        [IgnoreDataMember]
        public ICollection<Analysis> SportsmanAnalyses { get; set; }

        [IgnoreDataMember]
        public ICollection<Analysis> DoctorAnalyses { get; set; }

        [IgnoreDataMember]
        public ICollection<Message> MessageSender { get; set; }

        [IgnoreDataMember]
        public ICollection<Message> MessageRecepient { get; set; }

        [IgnoreDataMember]
        public ICollection<UsersUsers> UserParentId { get; set; }

        [IgnoreDataMember]
        public ICollection<UsersUsers> UserChildId { get; set; }

    }
}
