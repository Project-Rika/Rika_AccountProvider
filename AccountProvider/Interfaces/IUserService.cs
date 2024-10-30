using AccountProvider.Entities;
using AccountProvider.Models;

namespace AccountProvider.Interfaces;

public interface IUserService
{
    Task<UpdateUserDto> UpdateUserAsync(UpdateUserDto updateUserDto);
}
