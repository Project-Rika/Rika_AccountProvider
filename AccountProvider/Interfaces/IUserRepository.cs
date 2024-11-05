using AccountProvider.Entities;

namespace AccountProvider.Interfaces;

public interface IUserRepository
{
    Task<UserEntity?> GetByEmailAsync(string email);
    Task CreateUserAsync(UserEntity user);
}