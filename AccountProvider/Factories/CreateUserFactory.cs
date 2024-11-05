using AccountProvider.Entities;
using AccountProvider.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountProvider.Factories;

public class CreateUserFactory
{
    public static UserEntity CreateUserEntity(CreateUserDto createUserDto, string passwordHash)
    {
        try
        {
            return new UserEntity
            {
                Id = Guid.NewGuid().ToString(),
                FirstName = createUserDto.FirstName,
                LastName = createUserDto.LastName,
                Email = createUserDto.Email,
                Password = passwordHash,
                Role = "User",
                IsEmailConfirmed = false,
                PhoneNumber = createUserDto.PhoneNumber,
                ProfileImageUrl = createUserDto.ProfileImageUrl,
                Gender = createUserDto.Gender,
                Age = createUserDto.Age
            };
        }
        catch (Exception ex)
        {
            Debug.WriteLine("ERROR :: " + ex.Message);
        }
        return null!;
    }
}
