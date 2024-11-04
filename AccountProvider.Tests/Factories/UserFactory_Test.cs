using AccountProvider.Dtos;
using AccountProvider.Factories;
using AccountProvider.Interfaces;
using Moq;

namespace AccountProvider.Tests.Factories;

public class UserFactory_Test
{
	[Fact]
	public async Task GetUserAsync_DoesExist()
	{
		var userId = "1";

		var mockUserRepository = new Mock<IUserRepository>();
		mockUserRepository.Setup(repo => repo.GetUserAsync(userId))
			.ReturnsAsync(new GetUserDto
			{
				Id = userId,
				FirstName = "Gustav",
				LastName = "klaesson",
				Email = "gustav@domain.com",
				Gender = "Male"
			});

		var userFactory = new UserFactory(mockUserRepository.Object);

		var result = await userFactory.GetUserAsync(userId);

		Assert.NotNull(result);
		Assert.Equal(userId, result.Id);
	}


	[Fact]
	public async Task GetUserAsync_DoesNotExist()
	{
		var userId = "none";

		var mockUserRepository = new Mock<IUserRepository>();
		mockUserRepository.Setup(repo => repo.GetUserAsync(userId))
			.ReturnsAsync((GetUserDto?)null);

		var userFactory = new UserFactory(mockUserRepository.Object);

		await Assert.ThrowsAsync<KeyNotFoundException>(() => userFactory.GetUserAsync(userId));
	}
}