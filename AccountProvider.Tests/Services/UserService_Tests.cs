using AccountProvider.Dtos;
using AccountProvider.Entities;
using AccountProvider.Interfaces;
using Moq;

namespace AccountProvider.Tests.Services;

public class UserService_Tests
{
    private Mock<IUserService> _mockUserService;

    public UserService_Tests()
    {
        _mockUserService = new Mock<IUserService>();
    }



    [Fact]
    public async Task GetUserAsync_ThenReturnUserById()
    {
        // Arrange
        var userId = "2";
        var userDto = new GetUserDto
        {
            Id = userId
        };

        _mockUserService.Setup(x => x.GetUserAsync(userId))
            .ReturnsAsync(userDto);


        // Act
        var result = await _mockUserService.Object.GetUserAsync(userId);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(userId, result.Id);
    }

    
    [Fact]
    public async Task GetUserAsync_WhileNotExistingReturnNotFound ()
    {
        // Arrange
        var userId = "999";
        var userDto = new GetUserDto
        {
            Id = userId
        };

        _mockUserService.Setup(x => x.GetUserAsync(userId))
            .ReturnsAsync((GetUserDto?)null);

        // Act
        var result = await _mockUserService.Object.GetUserAsync(userId);

        // Assert
        Assert.Null(result);
        
    }
    /*

    
    Testfall 2: Användaren hämtas inte från databasen
    Förutsättningar: Användaren som ska hämtas finns inte i databasen.
    Steg 1: Sök efter ett UserId eller email som inte finns i databasen.
    Steg 2: Returnera relevant statuskod.
    Förväntat resultat: Ingen användare hämtas och relevant statuskod returneras.


    */

}







