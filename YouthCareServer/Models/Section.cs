using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace YouthCareServer.Models
{
    public class Section
    {
        [Required]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string CoachName { get; set; }
        public string SportComplexTitle { get; set; }
        [IgnoreDataMember]
        public ICollection<User> UsersList { get; set; }
    }
}
