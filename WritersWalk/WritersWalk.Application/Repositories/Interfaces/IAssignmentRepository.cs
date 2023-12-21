using WritersWalk.Application.Models;

namespace WritersWalk.Application.Repositories;

public interface IAssignmentRepository : IGenericRepository<Assignment>
{
    Task<Assignment> GetAssignmentByIdWithTopicsSurroundingsUsersAsync(int id);


}