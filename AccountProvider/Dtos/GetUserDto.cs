namespace AccountProvider.Dtos;

public class GetUserDto
{
    public string? Id { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set;} = null!;

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string Gender { get; set; } = null!;

    public int Age { get; set; }

}
