using WritersWalk.Application.Models;

namespace WritersWalk.Application.Repositories;

public interface ITopicRepository : IGenericRepository<Topic>
{
    Task<Topic> GetTopicByIdWithAssignmentsAsync(int id);
}