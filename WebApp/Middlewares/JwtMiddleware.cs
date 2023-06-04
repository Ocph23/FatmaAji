

using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WebApp.Data;
using WebApp.Models;
using WebApp.Services;

namespace WebApp
{
    public class JwtMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly AppSettings _appSettings;

        public JwtMiddleware(RequestDelegate next, IOptions<AppSettings> appSettings)
        {
            _next = next;
            _appSettings = appSettings.Value;
        }

        public async Task Invoke(HttpContext context, UserManager<ApplicationUser> userManager)
        {
            //if (!context.Request.Headers.ContainsKey("Authorization"))
            //{
            //    context.Response.StatusCode = 401;
            //    await context.Response.WriteAsync("Unauthorized");
            //    return;
            //}

            var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

            if (token != null)
            {
                await attachUserToContext(context, userManager, token);
            }

            await _next(context);
        }

        private async Task attachUserToContext(HttpContext context, UserManager<ApplicationUser> userManager, string token)
        {
            try
            {
                await Task.Delay(100);
                var tokenHandler = new JwtSecurityTokenHandler();
                SecurityToken validatedToken = null;
                var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
                tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidIssuer = _appSettings.Issuer,
                    ValidAudience = _appSettings.Audience,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                  
                }, out validatedToken);

                var jwtToken = (JwtSecurityToken)validatedToken;
                string id = jwtToken.Claims.First(x => x.Type == "id").Value;
                // string roles = jwtToken.Claims.First(x => x.Type == "roles").Value;
                var name = jwtToken.Claims.First(x => x.Type == "name").Value;
                var sub = jwtToken.Claims.First(x => x.Type == "sub").Value;
                var email = jwtToken.Claims.First(x => x.Type == "email").Value;
                var claims = new List<Claim>
                {
                               new Claim(ClaimTypes.NameIdentifier, id.ToString()),
                               new Claim(ClaimTypes.Name, name),
                               new Claim(ClaimTypes.Email, email),
                               new Claim(ClaimTypes.Role, "Admin"),
                };
                var user = await userManager.FindByEmailAsync(email);
                var roles = await userManager.GetRolesAsync(user);
                 foreach (var role in roles)
                {
                    claims.Add(new Claim(ClaimTypes.Role, role.ToString()));
                }


                var identity = new ClaimsIdentity(claims, "Bearer");
                context.User = new ClaimsPrincipal(identity);
                if (user != null)
                    context.Items["User"] = user;
            }
            catch (Exception ex)
            {
                context.Response.StatusCode = 401;
                //await context.Response.WriteAsync("Unauthorized");
            }
        }
    }
}