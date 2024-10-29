using AccountProvider.Context;
using AccountProvider.Interfaces;

namespace AccountProvider.Services;

public class UserService(DataContext context) : IUserService
{
    private readonly DataContext _context = context;

}
