using System.Security.Claims;
using Microsoft.AspNetCore.Mvc.Filters;
using NoCode.FlowerShop.Application.Common.Interfaces.Interceptors;

namespace NoCode.FlowerShop.Infrastructure.ActionFilters;

public class LogActionFilter : IActionFilter
{
    private readonly IActionLogService _logService;

    public LogActionFilter(IActionLogService logService)
    {
        _logService = logService;
    }

    public void OnActionExecuting(ActionExecutingContext context)
    {

        var controllerName = context.Controller.GetType().Name;
        var actionName = context.ActionDescriptor.RouteValues["action"];

        var nameIdentifier = context.HttpContext.User.Claims
            .FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
        var userId = nameIdentifier ?? "Anonymous user";
        
        var userRoles = context.HttpContext.User.Claims
            .Where(c => c.Type == ClaimTypes.Role) 
            .Select(c => c.Value)
            .ToList();
        string roles = string.Join(",", userRoles); 

        _logService.LogAction(userId, roles, $"{controllerName}.{actionName}", DateTime.UtcNow);
    }

    public void OnActionExecuted(ActionExecutedContext context)
    {
        
    }
}
