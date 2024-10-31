using AccountProvider.Context;
using AccountProvider.Entities;
using AccountProvider.Interfaces;
using AccountProvider.Models;
using Microsoft.EntityFrameworkCore;

namespace AccountProvider.Services;

public class UserService(DataContext context) : IUserService
{
    private readonly DataContext _context = context;

	public Task<IEnumerable<GetAllUserDto>> GetAllUserAsync()
	{
		throw new NotImplementedException();
	}
}
