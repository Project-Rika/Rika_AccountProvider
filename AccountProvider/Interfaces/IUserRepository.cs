using AccountProvider.Entities;

namespace AccountProvider.Interfaces;

public interface IUserRepository
{

    Task<UserEntity?> UpdateUserAsync(UserEntity userEntity);
}