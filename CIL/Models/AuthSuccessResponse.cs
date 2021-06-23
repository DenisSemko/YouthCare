using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CIL.Models
{
    public class AuthSuccessResponse
    {
        public string AccessToken { get; set; }
        public string Username { get; set; }
        public string UserType { get; set; }
    }
}
