﻿using AccountProvider.Entities;
using AccountProvider.Models;
using System.Diagnostics;

namespace AccountProvider.Factories;

public class UpdateUserFactory
{
	public static UserEntity UpdateUserEntity(UpdateUserDto updateUserDto, UserEntity userEntity)
	{
		try
		{
			if (updateUserDto != null && userEntity != null)
			{
				userEntity.FirstName = updateUserDto.FirstName;
				userEntity.LastName = updateUserDto.LastName;
				userEntity.Email = updateUserDto.Email;
				userEntity.Password = updateUserDto.Password!;
				userEntity.PhoneNumber = updateUserDto.PhoneNumber;
				userEntity.ProfileImageUrl = updateUserDto.ProfileImageUrl;
				userEntity.Age = updateUserDto.Age;
				userEntity.Gender = updateUserDto.Gender;

				return userEntity;
			}
		}
		catch (Exception ex)
		{
			Debug.WriteLine("ERROR :: " + ex.Message);
		}
		return null!;
	}

	public static UpdateUserDto UpdateUserDto(UserEntity userEntity)
	{
		try
		{
			if (userEntity != null)
			{
				return new UpdateUserDto
				{
					FirstName = userEntity.FirstName,
					LastName = userEntity.LastName,
					Email = userEntity.Email,
					Password = userEntity.Password!,
					PhoneNumber = userEntity.PhoneNumber,
					ProfileImageUrl = userEntity.ProfileImageUrl,
					Age = userEntity.Age,
					Gender = userEntity.Gender
				};
			}
		}
		catch (Exception ex)
		{
			Debug.WriteLine("ERROR :: " + ex.Message);
		}
		return null!;
	}
}
