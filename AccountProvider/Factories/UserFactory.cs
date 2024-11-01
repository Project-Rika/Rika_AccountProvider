using AccountProvider.Dtos;
using AccountProvider.Interfaces;
using Microsoft.Identity.Client;
using Xunit;


namespace AccountProvider.Factories
{
	public class UserFactory
	{
		private readonly IUserRepository _userRepository;

		public UserFactory(IUserRepository userRepository)
		{
			_userRepository = userRepository;
		}

		public async Task<GetUserDto> GetUserAsync(string userId)
		{
			var user = await _userRepository.GetUserAsync(userId);
			if (user == null)
			{
				throw new KeyNotFoundException($"User with ID {userId} not found");
			}
			return user;
		}

		
	}

}

