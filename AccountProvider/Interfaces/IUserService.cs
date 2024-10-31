using AccountProvider.Entities;
using AccountProvider.Models;
using Microsoft.AspNetCore.Mvc;

namespace AccountProvider.Interfaces;

public interface IUserService
{
	Task<ActionResult<UpdateUserDto>> UpdateUserAsync(UpdateUserDto updateUserDto);
}
