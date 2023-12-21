using WritersWalk.Application.Models;

namespace WritersWalk.Application.Repositories;

public interface ISurroundingRepository : IGenericRepository<Surrounding>
{
    Task<Surrounding> GetSurroundingByIdWithAssignmentsAsync(int id);
}