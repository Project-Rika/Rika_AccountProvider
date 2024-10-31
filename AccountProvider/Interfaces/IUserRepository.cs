using AccountProvider.Dtos;
namespace AccountProvider.Interfaces;

public interface IUserRepository
{

    Task<GetUserDto> GetUserAsync(string userId);
}