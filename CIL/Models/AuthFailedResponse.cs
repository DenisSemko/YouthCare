using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CIL.Models
{
    public class AuthFailedResponse
    {
        public IEnumerable<string> Errors { get; set; }
    }
}
