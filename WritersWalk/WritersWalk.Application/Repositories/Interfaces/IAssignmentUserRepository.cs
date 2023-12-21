using WritersWalk.Application.Models;

namespace WritersWalk.Application.Repositories.Interfaces;

public interface IAssignmentUserRepository : IGenericRepository<AssignmentUser>
{
    Task<AssignmentUser> GetByAssignmentAndUserId(int assignmentId, string userId);
}