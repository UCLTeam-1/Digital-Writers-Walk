namespace WritersWalk.Application.Models;

public class Topic
{
    public int Id { get; set; }
    public string Title { get; set; }

    public List<AssignmentTopic>? AssignmentTopics { get; set; }

    public Topic(int id, string title)
    {
        Id = id;
        Title = title;
    }
    public Topic()
    {
    }

}