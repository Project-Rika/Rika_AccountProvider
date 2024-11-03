using AccountProvider.Context;
using AccountProvider.Interfaces;
using AccountProvider.Entities;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;


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
}

