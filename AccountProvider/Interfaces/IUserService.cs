using AccountProvider.Dtos;
using AccountProvider.Entities;

namespace AccountProvider.Interfaces;

public interface IUserService
{
    Task<GetUserDto> GetUserAsync(string userId);

    
}
