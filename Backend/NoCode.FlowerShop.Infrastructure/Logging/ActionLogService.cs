using Microsoft.Extensions.Logging;
using NoCode.FlowerShop.Application.Common.Interfaces.Interceptors;

namespace NoCode.FlowerShop.Infrastructure.Logging;

public class ActionLogService : IActionLogService
{
    private readonly ILogger<ActionLogService> _logger;
    
    public ActionLogService(ILogger<ActionLogService> logger)
    {
        _logger = logger;
    }
    
    public void LogAction(string username, string roles, string methodName, string parameters, DateTime timestamp)
    {
        var message = $"User: {username}, Permissions: {roles}, Method: {methodName}, Parameters: {parameters}, TimeStamp (UTC): {timestamp}";
        _logger.LogInformation(message);
    }
}