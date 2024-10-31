using AccountProvider.Entities;
using AccountProvider.Models;

namespace AccountProvider.Interfaces;

public interface IUserService
{
	Task<IEnumerable<GetAllUserDto>> GetAllUserAsync();
}
