using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ChocoLync.Filters
{
    public class RoleAuthorizeAttribute : ActionFilterAttribute
    {
        private readonly string[] _roles;

        public RoleAuthorizeAttribute(string roles)
        {
            _roles = roles.Split(',', StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);
        }

        public override void OnActionExecuting(
            ActionExecutingContext context)
        {
            var role =
                context.HttpContext.Session
                .GetString("Role");

            if (!_roles.Contains(role))
            {
                context.Result =
                    new RedirectToActionResult(
                        "AccessDenied",
                        "Account",
                        null);
            }
        }
    }
}