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
    
    public void LogAction(string username, string roles, string methodName, DateTime timestamp)
    {
        var message = $"User: {username}, Permissions: {roles}, Method: {methodName}, TimeStamp (UTC): {timestamp}";
        _logger.LogInformation(message);
    }
}