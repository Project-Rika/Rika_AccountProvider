using AccountProvider.Dtos;
﻿using AccountProvider.Entities;
using System.Linq.Expressions;


namespace AccountProvider.Interfaces;

public interface IUserRepository
{

    Task<UserEntity> GetUserAsync(Expression<Func<UserEntity, bool>> predicate);
    Task<UserEntity?>GetByEmailAsync(string email);
    Task CreateUserAsync(UserEntity user);

}