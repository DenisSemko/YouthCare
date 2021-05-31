using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.Domain;
using CIL.Models;

namespace BLL.Services.Abstract
{
    public interface IUserService
    {
        Task<AuthenticationResult> RegisterAsync(RegisterModel user);
        Task<AuthenticationResult> LoginAsync(LoginModel user);
    }
}
