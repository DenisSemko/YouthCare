using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YouthCareServer.Models
{
    public class AuthFailedResponse
    {
        public IEnumerable<string> Errors { get; set; }
    }
}
