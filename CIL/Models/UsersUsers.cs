using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CIL.Models
{
    public class UsersUsers
    {
        public Guid Id { get; set; }
        public User ParentId { get; set; }
        public User ChildId { get; set; }
    }
}
