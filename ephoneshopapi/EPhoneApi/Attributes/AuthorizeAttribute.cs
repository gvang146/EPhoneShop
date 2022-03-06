using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace EPhoneApi.Attributes;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
public class AuthorizeAttribute : Attribute, IAuthorizationFilter
{
    public void OnAuthorization(AuthorizationFilterContext context)
    {
        var userId = context.HttpContext.Items["UserId"];
        if (userId == null)
        {
            // not logged in
            context.Result = new JsonResult(new { Message = "Unauthorized access" }) { StatusCode = StatusCodes.Status401Unauthorized };
        }
    }
}