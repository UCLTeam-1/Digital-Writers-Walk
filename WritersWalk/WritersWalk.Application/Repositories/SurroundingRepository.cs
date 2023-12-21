using Microsoft.EntityFrameworkCore;
using WritersWalk.Application.Database;
using WritersWalk.Application.Models;

namespace WritersWalk.Application.Repositories;

public class SurroundingRepository : GenericRepository<Surrounding>, ISurroundingRepository
{
    public SurroundingRepository(SqliteDbContext context) : base(context)
    {
    }

    /// <summary>
    /// Retrieves a surrounding by its ID from the database, including its related AssignmentSurroundings and Assignments.
    /// </summary>
    /// <param name="id">The ID of the surrounding</param>
    /// <returns>The surrounding with the specified ID and its associated AssignmentSurroundings and Assignments</returns>
    public async Task<Surrounding> GetSurroundingByIdWithAssignmentsAsync(int id)
    {
        return await _context.Surroundings
            .Include(x => x.AssignmentSurroundings)
            .ThenInclude(x => x.Assignment)
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == id);
    }
}