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
using BLL.Domain;
using CIL.Models;
using BLL.Services.Abstract;
using DAL;
using MimeKit;
using MailKit.Net.Smtp;

namespace BLL.Services.Concrete
{
    public class UserService : IUserService
    {
        private readonly UserManager<User> _userManager;
        private readonly IConfiguration _configuration;
        private readonly ApplicationContext myDbContext;
        private readonly EmailConfiguration emailConfig;
        private readonly IWebHostEnvironment webHostEnvironment;

        public UserService(UserManager<User> userManager, IConfiguration configuration, ApplicationContext myDbContext, IWebHostEnvironment hostEnvironment, EmailConfiguration emailConfig)
        {
            this._userManager = userManager;
            this._configuration = configuration;
            this.myDbContext = myDbContext;
            this.webHostEnvironment = hostEnvironment;
            this.emailConfig = emailConfig;
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

            var emailMessage = new MimeMessage();
            emailMessage.From.Add(new MailboxAddress(emailConfig.From));
            emailMessage.To.Add(new MailboxAddress(newUser.Email));
            emailMessage.Subject = "YouthCare - Welcome on Board!";

            string FilePath = Path.Combine(Directory.GetCurrentDirectory(), "welcome-email.html");
            string EmailTemplateText = File.ReadAllText(FilePath);
            BodyBuilder emailBodyBuilder = new BodyBuilder();
            emailBodyBuilder.HtmlBody = EmailTemplateText;
            emailMessage.Body = emailBodyBuilder.ToMessageBody();

            var client = new SmtpClient();
            await client.ConnectAsync(emailConfig.SmtpServer, emailConfig.Port, true);
            client.AuthenticationMechanisms.Remove("XOAUTH2");
            await client.AuthenticateAsync(emailConfig.UserName, emailConfig.Password);
            await client.SendAsync(emailMessage);
            await client.DisconnectAsync(true);
            client.Dispose();

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
                    new Claim(ClaimTypes.Role, user.UserType),
                    new Claim("id", user.Id.ToString())
                }),
                Expires = DateTime.UtcNow.AddHours(6),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
                Issuer = _configuration["JWT:ValidIssuer"],
                Audience = _configuration["JWT:ValidAudience"]
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return new AuthenticationResult
            {
                Success = true,
                AccessToken = tokenHandler.WriteToken(token),
                Username = user.UserName,
                UserType = user.UserType
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
