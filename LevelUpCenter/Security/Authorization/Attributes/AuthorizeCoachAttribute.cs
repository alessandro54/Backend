using LevelUpCenter.Security.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace LevelUpCenter.Security.Authorization.Attributes;

public class AuthorizeCoachAttribute: Attribute, IAuthorizationFilter
{
    public void OnAuthorization(AuthorizationFilterContext context)
    {
        var allowAnonymous = context.ActionDescriptor.EndpointMetadata.OfType<AllowAnonymousAttribute>().Any();

        if (allowAnonymous)
        {
            return;
        }

        var user = (User?) context.HttpContext.Items["User"];

        if (user is not { Role: UserRole.Coach })
            context.Result = new JsonResult(new { message = "You Need to be an Admin" })
            {
                StatusCode = StatusCodes.Status401Unauthorized
            };
    }
}
