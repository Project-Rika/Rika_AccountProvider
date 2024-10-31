namespace AccountProvider.Models;

public class GetAllUserDto
{
	public string? Id { get; set; }
	public string FirstName { get; set; } = null!;
	public string LastName { get; set; } = null!;
	public string Email { get; set; } = null!;
	public string Gender { get; set; } = null!;
}
