namespace WritersWalk.Application.Models;

public class Assignment
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }

    public List<AssignmentSurrounding>? AssignmentSurroundings { get; set; }
    public List<AssignmentTopic>? AssignmentTopics { get; set; }
    public List<AssignmentUser>? AssignmentUsers { get; set; }

    public Assignment(int id, string title, string description)
    {
        Id = id;
        Title = title;
        Description = description;
    }

}