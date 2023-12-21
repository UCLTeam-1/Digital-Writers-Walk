namespace WritersWalk.Application.Models;

public class User
{
    public string Id { get; set; }
    public string? FirstName { get; set; } = String.Empty;
    public string? LastName { get; set; } = String.Empty;
    public string Email { get; set; } = String.Empty;
    public string Password { get; set; } = String.Empty;


    public List<AssignmentUser>? AssignmentUsers { get; set; }

    public User(string id, string email, string password)
    {
        Id = id;
        Email = email;
        Password = password;
    }

    public User()
    {

    }

}