using AccountProvider.Entities;
using AccountProvider.Models;
using Microsoft.AspNetCore.Mvc;
namespace AccountProvider.Interfaces;

public interface IUserService
{
    Task<UserEntity?> GetUserByEmailAsync(string email);
    Task<IActionResult> CreateUserAsync(CreateUserDto createUserDto);
    Task<IActionResult> DeleteUserAsync(int userId);
}
