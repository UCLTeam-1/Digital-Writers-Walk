using Microsoft.EntityFrameworkCore;
using WritersWalk.Application.Database;
using WritersWalk.Application.Models;

namespace WritersWalk.Application.Repositories;

public class UserRepository : GenericRepository<User>, IUserRepository
{
    public UserRepository(SqliteDbContext context) : base(context)
    {
    }

    /// <summary>
    /// Retrieves a user by its ID from the database, including its related AssignmentUsers and Assignments.
    /// </summary>
    /// <param name="id">The ID of the user</param>
    /// <returns>
    /// The user with the specified ID and its associated AssignmentUsers and Assignments,
    /// or null if no user is found with the given ID
    /// </returns>
    public async Task<User> GetUserByIdWithAssignmentsAsync(string id)
    {
        return await _context.Users
            .Include(x => x.AssignmentUsers)
            .ThenInclude(x => x.Assignment)
            .FirstOrDefaultAsync(x => x.Id.Equals(id));
    }
}