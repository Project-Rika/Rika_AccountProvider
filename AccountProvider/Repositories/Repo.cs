using AccountProvider.Context;
using AccountProvider.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq.Expressions;

namespace AccountProvider.Repositories;

public class Repo<TEntity> : IRepo<TEntity> where TEntity : class
{

    private readonly DataContext _context;

    
    public virtual Task<TEntity> GetOneUserAsync(Expression<Func<TEntity, bool>> predciate)
    {
        try
        {
            var result = _context.Set<TEntity>().FirstOrDefaultAsync(predciate)!;
            return result!;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
}
