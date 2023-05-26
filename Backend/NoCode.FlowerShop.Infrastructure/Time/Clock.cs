using NoCode.FlowerShop.Application.Common.Interfaces.Clock;

namespace NoCode.FlowerShop.Infrastructure.Time;

public class Clock : IClock
{
    public DateTime UtcNow => DateTime.UtcNow;
}
