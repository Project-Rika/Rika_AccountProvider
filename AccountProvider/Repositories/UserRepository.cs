using AccountProvider.Context;
using AccountProvider.Dtos;
using AccountProvider.Interfaces;

namespace AccountProvider.Repositories;

public class UserRepository(DataContext context) : IUserRepository
{
    private readonly DataContext _context = context;

	public Task<GetUserDto> GetUserAsync(string userId)
	{
		throw new NotImplementedException();
	}
}
