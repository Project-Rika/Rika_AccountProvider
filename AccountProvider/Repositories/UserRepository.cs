using AccountProvider.Context;
using AccountProvider.Interfaces;
using AccountProvider.Entities;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Linq.Expressions;



namespace AccountProvider.Repositories;

public class UserRepository(DataContext context) : IUserRepository
{
    private readonly DataContext _context = context;


    public async Task<UserEntity?> GetByEmailAsync(string email)
    {
        return await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
    }

    public async Task CreateUserAsync(UserEntity userEntity)
    {
        try
        {
            await _context.Users.AddAsync(userEntity);
            await _context.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"An error occurred: {ex.Message}");
        }

    }

    public async Task<UserEntity> GetUserAsync(Expression<Func<UserEntity, bool>> predciate)
    {
        try
        {
            var result = await _context.Users.FirstOrDefaultAsync(predciate);
            return result;
        }
        catch (Exception ex)
        {
            return null;
        }
    }

}