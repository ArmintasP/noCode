namespace NoCode.FlowerShop.Application.Common.Interfaces.Interceptors;

public interface IActionLogService
{
    void LogAction(string username, string roles, string methodName, DateTime timestamp);
}