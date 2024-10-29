using AccountProvider.Interfaces;
using Moq;

namespace AccountProvider.Tests.Repositories;

public class UserRepository_Tests
{
    private Mock<IUserRepository> _mockUserRepository;

    public UserRepository_Tests()
    {
        _mockUserRepository = new Mock<IUserRepository>();
    }
}
