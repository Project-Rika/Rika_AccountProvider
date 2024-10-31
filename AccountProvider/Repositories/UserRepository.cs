using AccountProvider.Context;
using AccountProvider.Entities;
using AccountProvider.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Drawing.Text;

namespace AccountProvider.Repositories;

public class UserRepository(DataContext context) : IUserRepository
{
    private readonly DataContext _context = context;

	public async Task<IEnumerable<UserEntity>> GetAllUserAsync()
	{
		return await _context.Users.ToListAsync();
	}
}
