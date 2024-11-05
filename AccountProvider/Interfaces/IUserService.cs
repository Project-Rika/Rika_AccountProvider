using AccountProvider.Entities;
using AccountProvider.Models;
using Microsoft.AspNetCore.Mvc;

namespace AccountProvider.Interfaces;

public interface IUserService
{
	Task<IActionResult> UpdateUserAsync(UpdateUserDto updateUserDto);
    Task<UserEntity?> GetUserByEmailAsync(string email);
    Task<IActionResult> CreateUserAsync(CreateUserDto createUserDto);
    Task<IActionResult> DeleteUserAsync(int userId);
}
