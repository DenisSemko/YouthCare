using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YouthCareServer.Domain;
using YouthCareServer.Models;

namespace YouthCareServer.Services.Abstract
{
    public interface IUserService
    {
        Task<AuthenticationResult> RegisterAsync(RegisterModel user);
        Task<AuthenticationResult> LoginAsync(LoginModel user);
    }
}
