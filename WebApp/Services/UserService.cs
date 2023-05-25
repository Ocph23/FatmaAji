using Microsoft.Extensions.Options;
using System;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using System.Data;
using WebApp.Data;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using WebApp.Models;
using ShareModel;

namespace WebApp.Services
{

    public interface IUserAuthentification
    {
        Task<AuthenticateResponse> Authenticate(LoginRequest model);
        Task<object> Profile();
    }
    public interface IUserService : IUserAuthentification
    {
        Task<ApplicationUser> FindUserById(string id);
        Task<string> AuthenticateUSerProvider(ApplicationUser user);
        Task<string> GenerateToken(ApplicationUser user);
        Task<AuthenticateResponse> Register(RegisterRequest requst);
        Task AddUserRole(string v, ApplicationUser user);
        Task<ApplicationUser> FindUserByUserName(string userName);
        Task<ApplicationUser> FindUserByEmail(string email);
        Task<IEnumerable<ApplicationUser>> GetUsers();
    }


    public class UserService : IUserService
    {
        private readonly ApplicationDbContext _context;

        private readonly AppSettings _appSettings;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;

        public ApplicationDbContext ApplicationDbContext { get; }

        public UserService(IOptions<AppSettings> appSettings, ApplicationDbContext dbcontext, IHttpContextAccessor httpContextAccessor, UserManager<ApplicationUser> _userManager, SignInManager<ApplicationUser> _signInManager)
        {
            _context = dbcontext;
            _appSettings = appSettings.Value;
            _httpContextAccessor = httpContextAccessor;
            userManager = _userManager;
            signInManager = _signInManager;
        }

        public async Task<AuthenticateResponse> Authenticate(LoginRequest model)
        {
            try
            {
                var result = await signInManager.PasswordSignInAsync(model.UserName.ToUpper(), model.Password, false, lockoutOnFailure: false);
                if (result.Succeeded)
                {
                    var user = await userManager.FindByEmailAsync(model.UserName);
                    var token = await GenerateJwtToken(user!);
                    return new AuthenticateResponse(user.UserName, user.Email, token);

                }
                throw new SystemException($"Your Account {model.UserName} Not Have Access !");
            }
            catch (System.Exception ex)
            {
                throw new SystemException(ex.Message);
            }
        }

        public async Task<string> AuthenticateUSerProvider(ApplicationUser user)
        {
            try
            {
                var token = await GenerateJwtToken(user);
                if (string.IsNullOrEmpty(token))
                    throw new SystemException("You Not Have Access");
                return token;

            }
            catch (System.Exception ex)
            {
                throw new SystemException(ex.Message);
            }
        }

        private Task<string> GenerateJwtToken(ApplicationUser user)
        {
            var issuer = _appSettings.Issuer;
            var audience = _appSettings.Audience;
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                new Claim("id", user.Id),
                new Claim(JwtRegisteredClaimNames.Name, user.Name),
                new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim(JwtRegisteredClaimNames.Jti,
                Guid.NewGuid().ToString())
             }),
                Expires = DateTime.UtcNow.AddDays(7),
                Issuer = issuer,
                Audience = audience,
                SigningCredentials = new SigningCredentials
                (new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha512Signature)
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return Task.FromResult(tokenHandler.WriteToken(token));
        }

        public async Task<string> GenerateToken(ApplicationUser user)
        {
            return await GenerateJwtToken(user);
        }

        public async Task<AuthenticateResponse> Register(RegisterRequest model)
        {
            try
            {
                ApplicationUser user = new ApplicationUser { Name = model.Name, Email = model.UserName, UserName = model.UserName, EmailConfirmed=true};
                var userCreated = await userManager.CreateAsync(user, model.Password);
                if (userCreated.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, "Pendaftar");
                    var token = await GenerateJwtToken(user);
                    return new AuthenticateResponse(user.UserName, user.Email, token);
                }

                string errorMessage=string.Empty;
                if (userCreated.Errors.Count() > 0)
                {
                   errorMessage= userCreated.Errors.FirstOrDefault().Description;
                }

                throw new SystemException(errorMessage);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private static string GeneratePasswordHash(string password)
        {
            if (string.IsNullOrEmpty(password))
                throw new SystemException("Password Requeired !");

            MD5 md5 = new MD5CryptoServiceProvider();

            //compute hash from the bytes of text  
            md5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(password));

            //get hash result after compute it  
            byte[] result = md5.Hash;

            StringBuilder strBuilder = new StringBuilder();
            for (int i = 0; i < result.Length; i++)
            {
                //change it into 2 hexadecimal digits  
                //for each byte  
                strBuilder.Append(result[i].ToString("x2"));
            }
            return strBuilder.ToString();
        }

        public async Task<ApplicationUser> FindUserById(string id)
        {
            var user = await userManager.FindByIdAsync(id);
            return user;
        }

        public Task AddUserRole(string v, ApplicationUser user)
        {
            throw new NotImplementedException();
        }

        public Task<ApplicationUser> FindUserByUserName(string userName)
        {
            throw new NotImplementedException();
        }

        public Task<ApplicationUser> FindUserByEmail(string email)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ApplicationUser>> GetUsers()
        {
            throw new NotImplementedException();
        }

        public Task<object> Profile()
        {
            throw new NotImplementedException();
        }
    }

}