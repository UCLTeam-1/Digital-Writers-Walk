using System.ComponentModel.DataAnnotations.Schema;

namespace WritersWalk.Application.Models;

[Table("AssignmentTopics")]
public class AssignmentTopic
{
    public int Id { get; set; }
    public int AssignmentId { get; set; }
    public int TopicId { get; set; }

    [ForeignKey("AssignmentId")]
    public Assignment? Assignment { get; set; }
    [ForeignKey("TopicId")]
    public Topic? Topic { get; set; }
}