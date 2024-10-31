using AccountProvider.Context;
using AccountProvider.Entities;
using AccountProvider.Factories;
using AccountProvider.Interfaces;
using AccountProvider.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AccountProvider.Services;

public class UserService(DataContext context, IUserRepository userRepository) : IUserService
{
	private readonly DataContext _context = context;
	private readonly IUserRepository _userRepository = userRepository;

	public async Task<ActionResult<UpdateUserDto>> UpdateUserAsync(UpdateUserDto updateUserDto)
	{
		try
		{
			if (updateUserDto != null)
			{
				var existingUser = await _userRepository.GetUserAsync(updateUserDto.UserId);
				if (existingUser != null)
				{
					var mappedEntity = UpdateUserFactory.UpdateUserEntity(updateUserDto, existingUser);
					if (mappedEntity != null)
					{
						var result = _userRepository.UpdateUserAsync(mappedEntity);
						if (result != null)
						{
							var mappedDto = UpdateUserFactory.UpdateUserDto(existingUser);
							if (mappedDto != null)
							{
								return new OkObjectResult(mappedDto);
							}
						}
					}
				}
				else
				{
					return new NotFoundResult();
				}
			}
			else
			{
				return new BadRequestResult();
			}
		}
		catch (Exception ex)
		{
			Debug.WriteLine("ERROR :: " + ex.Message);
		}
		return new StatusCodeResult(500);
	}
}
