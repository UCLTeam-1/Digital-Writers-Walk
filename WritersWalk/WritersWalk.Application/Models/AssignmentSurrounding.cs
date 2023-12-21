using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WritersWalk.Application.Models;

[Table("AssignmentSurroundings")]
public class AssignmentSurrounding
{
    [Key]
    public int Id { get; set; }

    public int AssignmentId { get; set; }
    public int SurroundingsId { get; set; }

    [ForeignKey("AssignmentId")]
    public Assignment? Assignment { get; set; }

    [ForeignKey("SurroundingsId")]
    public Surrounding? Surroundings { get; set; }
}