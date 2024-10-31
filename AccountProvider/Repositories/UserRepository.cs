using AccountProvider.Context;
using AccountProvider.Entities;
using AccountProvider.Interfaces;
using System.Diagnostics;

namespace AccountProvider.Repositories;

public class UserRepository(DataContext context) : IUserRepository
{
    private readonly DataContext _context = context;

    public async Task<UserEntity?> UpdateUserAsync(UserEntity userEntity)
    {
        try
        {
            if (userEntity != null)
            {
                _context.Users.Update(userEntity);
                var result = await _context.SaveChangesAsync();

                if (result > 0)
                {
                    return userEntity;
                }
            }
        }
        catch (Exception ex)
        {
           Debug.WriteLine("ERROR :: " + ex.Message);
        }

        return null;
    }
}
