namespace WritersWalk.Application.Models;

public class Surrounding
{
    public int Id { get; set; }
    public string Title { get; set; }

    public List<AssignmentSurrounding>? AssignmentSurroundings { get; set; }

    public Surrounding(int id, string title)
    {
        Id = id;
        Title = title;
    }
    public Surrounding()
    {
    }
}