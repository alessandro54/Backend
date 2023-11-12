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

        // i want to the role admin too
        if (user!.Role is not (UserRole.Coach or UserRole.Admin))
            context.Result = new JsonResult(new { message = "You Need to be a Coach" })
            {
                StatusCode = StatusCodes.Status401Unauthorized
            };
    }
}
