using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using WebApp.Data;

namespace WebApp
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class ApiAuthorizeAttribute : Attribute, IAuthorizationFilter
    {
        private readonly UserManager<ApplicationUser> userManager;

     

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (context.HttpContext.Response.StatusCode== 401)
            {
                context.Result = new JsonResult(new { message = "Unauthorized" }) { StatusCode = StatusCodes.Status401Unauthorized };
            }
            else
            {
                var user = (ApplicationUser)context.HttpContext.Items["User"];

                if (!string.IsNullOrEmpty(Roles))
                {
                    var splite = Roles.Split(",");
                    var found = false;
                    foreach (var item in splite)
                    {
                        var role = item.Trim();
                        if (context.HttpContext.User.IsInRole(role))
                        {
                            found = true;
                            break;
                        }
                    }

                    if (!found)
                    {
                        context.Result = new JsonResult(new { message = "Unauthorized" }) { StatusCode = StatusCodes.Status401Unauthorized };
                    }
                }
            }

            
            
        }

        public string Roles { get; set; }
       
    }


    //public static class UserExtention
    //{
    //    public static bool UserInRole(this ApplicationUser user, string roleName)
    //    {
    //       try
    //       {
    //            if(user==null)
    //                return false;

    //            if(user.Roles.Where(x=>x.Role.Name.ToLower()==roleName.ToLower()).Count()>0)
    //                return true;
    //            return false;
    //       }
    //       catch 
    //       {
    //            return false;
    //       }
    //   }



    //    public static int? UserId(this ClaimsPrincipal principal)
    //    {
    //        try
    //        {
    //            var cl = principal.Claims.Where(x => x.Type == ClaimTypes.NameIdentifier).FirstOrDefault();
    //            if (cl != null && !string.IsNullOrEmpty(cl.Value))
    //            {
    //                var result = Convert.ToInt32(cl.Value);
    //                if (result > 0)
    //                    return result;
    //            }

    //            return null;
    //        }
    //        catch 
    //        {
    //            return null;
    //        }
    //    }

    //    public static bool InRole(this ClaimsPrincipal principal, string roleName)
    //    {
    //        try
    //        {
    //            var cl = principal.Claims.Where(x => x.Type == ClaimTypes.Role).FirstOrDefault();

    //            if (cl != null && !string.IsNullOrEmpty(cl.Value))
    //            {
    //                var roles = cl.Value.Split(',').ToList();
    //                if(roles.Where(x=>x.ToLower() == roleName.ToLower()).Count()>0)
    //                    return true;
    //            }
    //            return false;
    //        }
    //        catch
    //        {
    //            return false;
    //        }
    //    }
    //}
}