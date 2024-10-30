using AccountProvider.Context;
using AccountProvider.Dtos;
using AccountProvider.Interfaces;

namespace AccountProvider.Services;

public class UserService(DataContext context) : IUserService
{
    private readonly DataContext _context = context;

  
    public Task<GetUserDto> GetUserAsync(string userId)
    {
        throw new NotImplementedException();
    }
}

