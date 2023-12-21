using Microsoft.EntityFrameworkCore;
using WritersWalk.Application.Database;
using WritersWalk.Application.Models;

namespace WritersWalk.Application.Repositories;

public class TopicRepository : GenericRepository<Topic>, ITopicRepository
{
    public TopicRepository(SqliteDbContext context) : base(context)
    {
    }

    /// <summary>
    /// Retrieves a topic by its ID from the database, including its related AssignmentTopics and Assignments.
    /// </summary>
    /// <param name="id">The ID of the topic</param>
    /// <returns>The topic with the specified ID and its associated AssignmentTopics and Assignments</returns>
    public async Task<Topic> GetTopicByIdWithAssignmentsAsync(int id)
    {
        return await _context.Topics
            .Include(x => x.AssignmentTopics)
            .ThenInclude(x => x.Assignment)
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == id);
    }
}