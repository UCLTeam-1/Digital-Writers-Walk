using WritersWalk.Application.Database;
using WritersWalk.Application.Models;

namespace WritersWalk.Application.Repositories;

public class AssignmentRepository : GenericRepository<Assignment>, IAssignmentRepository
{
    public AssignmentRepository(SqliteDbContext context) : base(context)
    {
    }

    public async Task<Assignment> GetAssignmentByIdWithTopicsSurroundingsUsersAsync(int id)
    {
        throw new NotImplementedException();
    }
}
