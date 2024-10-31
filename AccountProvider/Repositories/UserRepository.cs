using AccountProvider.Context;
using AccountProvider.Dtos;
using AccountProvider.Entities;
using AccountProvider.Interfaces;
using Microsoft.EntityFrameworkCore;
using static Microsoft.ApplicationInsights.MetricDimensionNames.TelemetryContext;

namespace AccountProvider.Repositories;

public class UserRepository(DataContext context) : IUserRepository
{
    private readonly DataContext _context = context;

    public Task<GetUserDto> GetUserAsync(string userId)
    {
        throw new NotImplementedException();
    }
}
