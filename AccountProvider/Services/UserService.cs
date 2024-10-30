using AccountProvider.Context;
using AccountProvider.Interfaces;
using AccountProvider.Models;

namespace AccountProvider.Services;

public class UserService(DataContext context) : IUserService
{
    private readonly DataContext _context = context;

    public Task<UpdateUserDto> UpdateUserAsync(UpdateUserDto updateUserDto)
    {
        throw new NotImplementedException();
    }
}
