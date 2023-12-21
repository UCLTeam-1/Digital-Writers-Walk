using WritersWalk.Application.Database;
using WritersWalk.Application.Models;
using WritersWalk.Application.Repositories.Interfaces;

namespace WritersWalk.Application.Repositories;

public class AssignmentUserRepository : GenericRepository<AssignmentUser>, IAssignmentUserRepository
{
    public AssignmentUserRepository(SqliteDbContext context) : base(context)
    {
    }

    /// <summary>
    /// Retrieves an AssignmentUser by the assignment ID and user ID.
    /// </summary>
    /// <param name="assignmentId">The ID of the assignment</param>
    /// <param name="userId">The ID of the user</param>
    /// <returns>The AssignmentUser matching the assignment and user IDs, if found; otherwise, null</returns>
    public Task<AssignmentUser?> GetByAssignmentAndUserId(int assignmentId, string userId)
    {
        var assignmentUser = _context.AssignmentUsers.FirstOrDefault(x => x.AssignmentId == assignmentId && x.UserId == userId);
        return Task.FromResult(assignmentUser);
    }
}
