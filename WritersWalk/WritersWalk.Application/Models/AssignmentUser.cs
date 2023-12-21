using System.ComponentModel.DataAnnotations.Schema;

namespace WritersWalk.Application.Models;

[Table("AssignmentUsers")]
public class AssignmentUser
{
    public int Id { get; set; }
    public string UserId { get; set; }
    public int AssignmentId { get; set; }

    public DateTime? StartTime { get; set; }
    public DateTime? EndTime { get; set; }

    public AssignmentStatus? Status { get; set; }

    [ForeignKey("UserId")]
    public User? User { get; set; }
    [ForeignKey("AssignmentId")]
    public Assignment? Assignment { get; set; }
}