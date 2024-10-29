using AccountProvider.Context;
using AccountProvider.Interfaces;

namespace AccountProvider.Repositories;

public class UserRepository(DataContext context) : IUserRepository
{
    private readonly DataContext _context = context;
}
