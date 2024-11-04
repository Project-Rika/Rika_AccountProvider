using AccountProvider.Dtos;
using AccountProvider.Entities;
using AccountProvider.Models;
using Microsoft.AspNetCore.Mvc;

namespace AccountProvider.Interfaces;

public interface IUserService
{
    Task<GetUserDto> GetUserAsync(string userId);
    Task<UserEntity?> GetUserByEmailAsync(string email);
    Task<IActionResult> CreateUserAsync(CreateUserDto createUserDto);

}
