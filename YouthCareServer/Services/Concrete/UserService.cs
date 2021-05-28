using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using YouthCareServer.Domain;
using YouthCareServer.Models;
using YouthCareServer.Services.Abstract;

namespace YouthCareServer.Services.Concrete
{
    public class UserService : IUserService
    {
        private readonly UserManager<User> _userManager;
        private readonly IConfiguration _configuration;
        private readonly ApplicationContext myDbContext;
        private readonly IWebHostEnvironment webHostEnvironment;

        public UserService(UserManager<User> userManager, IConfiguration configuration, ApplicationContext myDbContext, IWebHostEnvironment hostEnvironment)
        {
            this._userManager = userManager;
            this._configuration = configuration;
            this.myDbContext = myDbContext;
            this.webHostEnvironment = hostEnvironment;
        }

        public async Task<AuthenticationResult> RegisterAsync(RegisterModel registerModel)
        {
            var existingUser = await _userManager.FindByNameAsync(registerModel.Username);

            if (existingUser != null)
            {
                return new AuthenticationResult
                {
                    Errors = new[] { "User with such username already exists" }
                };
            }
            var selectedSection = await myDbContext.Section.Where(c => c.Id == registerModel.BelongSection).FirstOrDefaultAsync();
            var uniqueFileName = UploadedFile(registerModel);
            var newUser = new User
            {
                Name = registerModel.Name,
                Surname = registerModel.Surname,
                BirthDate = registerModel.BirthDate,
                Gender = registerModel.Gender,
                UserName = registerModel.Username,
                Email = registerModel.Email,
                PasswordHash = registerModel.PasswordHash,
                BelongSection = selectedSection,
                ProfilePicture = uniqueFileName,
                UserType = registerModel.UserType
            };

            var createdUser = await _userManager.CreateAsync(newUser, registerModel.PasswordHash);
            

            if (!createdUser.Succeeded)
            {
                return new AuthenticationResult
                {
                    Errors = createdUser.Errors.Select(x => x.Description)
                };
            }

            return GenerateAuthenticationResultForUser(newUser);
        }

        public async Task<AuthenticationResult> LoginAsync(LoginModel loginModel)
        {
            var user = await _userManager.FindByNameAsync(loginModel.Username);
            
            if (user == null)
            {
                return new AuthenticationResult
                {
                    Errors = new[] { "User does not exist" }
                };
            }
            var userHasValidPassword = await _userManager.CheckPasswordAsync(user, loginModel.Password);

            if (!userHasValidPassword)
            {
                return new AuthenticationResult
                {
                    Errors = new[] { "User credentials are wrong" }
                };
            }


            return GenerateAuthenticationResultForUser(user);
        }
        
        private AuthenticationResult GenerateAuthenticationResultForUser(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration["JWT:Secret"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim("id", user.Id.ToString())
                }),
                Expires = DateTime.UtcNow.AddHours(3),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
                Issuer = _configuration["JWT:ValidIssuer"],
                Audience = _configuration["JWT:ValidAudience"]
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return new AuthenticationResult
            {
                Success = true,
                AccessToken = tokenHandler.WriteToken(token)
            };
        }
        private string UploadedFile(RegisterModel model)
        {
            string uniqueFileName = null;

            if (model.ProfileImage != null)
            {
                string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, "images");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + model.ProfileImage.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    model.ProfileImage.CopyTo(fileStream);
                }
            }
            return uniqueFileName;
        }
    }
}
