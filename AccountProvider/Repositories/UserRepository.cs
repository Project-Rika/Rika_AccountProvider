using AccountProvider.Context;
using AccountProvider.Entities;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Linq.Expressions;


namespace AccountProvider.Repositories;

public class UserRepository(DataContext context) : Repo<UserEntity>
{
    private readonly DataContext _context = context;
   

    public override async Task<UserEntity> GetOneUserAsync(Expression<Func<UserEntity, bool>> predciate)
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
