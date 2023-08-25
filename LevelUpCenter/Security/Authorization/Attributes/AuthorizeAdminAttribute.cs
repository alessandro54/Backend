using LevelUpCenter.Security.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace LevelUpCenter.Security.Authorization.Attributes;

public class AuthorizeAdminAttribute: Attribute, IAuthorizationFilter
{
    public void OnAuthorization(AuthorizationFilterContext context)
    {
        // Authorization process
        var user = (User?)context.HttpContext.Items["User"];

        if (user is not { Role: UserRole.Admin })
            context.Result = new JsonResult(new { message = "You Need to be an Admin" })
            {
                StatusCode = StatusCodes.Status401Unauthorized
            };
    }
}
