using System.Security.Claims;
using Microsoft.AspNetCore.Mvc.Filters;
using NoCode.FlowerShop.Application.Common.Interfaces.Clock;
using NoCode.FlowerShop.Application.Common.Interfaces.Interceptors;

namespace NoCode.FlowerShop.Infrastructure.ActionFilters;

public class LogActionFilter : IActionFilter
{
    private readonly IActionLogService _logService;
    private readonly IClock _clock;

    public LogActionFilter(IActionLogService logService, IClock clock)
    {
        _logService = logService;
        _clock = clock;
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
        string permissions = string.Join(",", userRoles);
        
        var parameters = context.ActionArguments
            .ToDictionary(arg => arg.Key, arg => arg.Value ?? "NULL");
        string serializedParameters = System.Text.Json.JsonSerializer.Serialize(parameters);

        _logService.LogAction(userId, permissions, $"{controllerName}.{actionName}", serializedParameters, _clock.UtcNow);
    }

    public void OnActionExecuted(ActionExecutedContext context)
    {
        
    }
}
