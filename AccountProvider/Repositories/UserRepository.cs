using AccountProvider.Context;
using AccountProvider.Entities;
using AccountProvider.Interfaces;

namespace AccountProvider.Repositories;

public class UserRepository(DataContext context) : IUserRepository
{
    private readonly DataContext _context = context;

    public Task<UserEntity> UpdateUserAsync(UserEntity userEntity)
    {
        throw new NotImplementedException();
    }
}
