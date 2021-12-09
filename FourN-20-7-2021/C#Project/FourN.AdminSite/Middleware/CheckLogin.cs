using FourN.AdminSite.Helper;
using FourN.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static FourN.Data.SystemEnum;

namespace FourN.AdminSite.Middleware
{
    public class CheckLogin
    {
        private readonly RequestDelegate _next;

        public CheckLogin(RequestDelegate next)
        {
            _next = next;
        }

        public Task Invoke(HttpContext httpContext)
        {
            //before
            var path = httpContext.Request.Path;
            var user = httpContext.Session.GetCurrentAuthentication();
            //if(user == null)
            //{
            //    httpContext.Response.Redirect("/Authentication/Login");
            //}
            //if(path.HasValue && (!path.Value.StartsWith("/Authentication/Login")))
            //{
            //    if (user == null)
            //    {
            //        httpContext.Response.Redirect("/Authentication/Login");
            //    }
            //}
            if (path.HasValue && path.Value.StartsWith("/Group"))
            {
                if (user == null || user.department == (int)SystemEnum.RoleNumber.Partner || user.department == (int)SystemEnum.RoleNumber.Developer)
                {
                    httpContext.Response.Redirect("/Authentication/NotAllow");
                }
            }
            if (path.HasValue && path.Value.StartsWith("/ProjectManagement"))
            {
                if (user == null || user.department == (int)SystemEnum.RoleNumber.Partner)
                {
                    httpContext.Response.Redirect("/Authentication/NotAllow");
                }
            }
            if (path.HasValue && path.Value.StartsWith("/Module4"))
            {
                if (user == null)
                {
                    httpContext.Response.Redirect("/Authentication/NotAllow");
                }
            }
            if (path.HasValue && path.Value.StartsWith("/User"))
            {
                if (user == null || user.department == (int)SystemEnum.RoleNumber.Developer || user.department == (int)SystemEnum.RoleNumber.Partner)
                {
                    httpContext.Response.Redirect("/Authentication/NotAllow");
                }
            }
            if (path.HasValue && path.Value.StartsWith("/KOPC/Costsalary"))
            {
                if (user == null || (user.department != (int)SystemEnum.RoleNumber.PM && user.department != (int)SystemEnum.RoleNumber.Leader))
                {
                    httpContext.Response.Redirect("/Authentication/NotAllow");
                }
            }
            if (path.HasValue && path.Value.StartsWith("/KOPC/Requestpm"))
            {
                if (user == null || user.department == (int)SystemEnum.RoleNumber.Developer || user.department == (int)SystemEnum.RoleNumber.Partner)
                {
                    httpContext.Response.Redirect("/Authentication/NotAllow");
                }
            }
            if (path.HasValue && path.Value.StartsWith("Backup"))
            {
                if (user == null || user.department == (int)SystemEnum.RoleNumber.Developer || user.department == (int)SystemEnum.RoleNumber.Partner)
                {
                    httpContext.Response.Redirect("/Authentication/NotAllow");
                }
            }
            //end before
            return _next(httpContext);
            //will excute when next finished
        }
        // Extension method used to add the middleware to the HTTP request pipeline.
    }
    public static class CheckLoginMiddlewareExtensions
    {
        public static IApplicationBuilder UseCheckLoginMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<CheckLogin>();
        }
    }
}
