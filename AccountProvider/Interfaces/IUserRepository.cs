using AccountProvider.Entities;

namespace AccountProvider.Interfaces;

public interface IUserRepository
{
	Task<IEnumerable<UserEntity>> GetAllUserAsync();
}