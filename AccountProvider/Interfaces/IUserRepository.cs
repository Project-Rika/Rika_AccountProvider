using AccountProvider.Dtos;
using AccountProvider.Entities;
using static Microsoft.ApplicationInsights.MetricDimensionNames.TelemetryContext;

namespace AccountProvider.Interfaces;

public interface IUserRepository
{
    Task<GetUserDto> GetUserAsync(string userId);
}