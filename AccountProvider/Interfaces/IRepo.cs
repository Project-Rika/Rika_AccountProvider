using AccountProvider.Entities;
using System.Linq.Expressions;

namespace AccountProvider.Interfaces;

public interface IRepo<TEntity> where TEntity : class
{
    Task<TEntity> GetOneUserAsync(Expression<Func<TEntity, bool>> expression);
    
}
