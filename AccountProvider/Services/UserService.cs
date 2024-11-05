using System.Security.Cryptography;
using AccountProvider.Context;
using AccountProvider.Entities;
using AccountProvider.Interfaces;
using System.Text;
using AccountProvider.Models;
using AccountProvider.Factories;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace AccountProvider.Services;

public class UserService(DataContext context, IUserRepository userRepository) : IUserService
{
    private readonly DataContext _context = context;
    private readonly IUserRepository _userRepository = userRepository;

    public async Task<UserEntity?> GetUserByEmailAsync(string email)
    {
        return await _userRepository.GetByEmailAsync(email);
    }


    public async Task<IActionResult> CreateUserAsync(CreateUserDto createUserDto)
    {
        try
        {
            if (string.IsNullOrEmpty(createUserDto.FirstName) ||
                string.IsNullOrEmpty(createUserDto.LastName) ||
                string.IsNullOrEmpty(createUserDto.Email) ||
                string.IsNullOrEmpty(createUserDto.Password))
            {
                return new BadRequestObjectResult("Invalid input data. Please ensure all fields are filled in.");
            }


            var existingUser = await _userRepository.GetByEmailAsync(createUserDto.Email);
            if (existingUser != null)
            {
                return new ConflictObjectResult($"The email address is already registered. {existingUser}");
            }
            else
            {
                var passwordHash = HashPassword(createUserDto.Password);

                var user = CreateUserFactory.CreateUserEntity(createUserDto, passwordHash);

                await _userRepository.CreateUserAsync(user);

                return new CreatedResult(string.Empty, "User created successfully!");

            }


        }
        catch (Exception ex)
        {
            Debug.WriteLine($"An error occurred: {ex.Message}");
            return new StatusCodeResult(500);
        }

    }


    private static string HashPassword(string password)
    {
        var hashedBytes = SHA256.HashData(Encoding.UTF8.GetBytes(password));
        return BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
    }

}
