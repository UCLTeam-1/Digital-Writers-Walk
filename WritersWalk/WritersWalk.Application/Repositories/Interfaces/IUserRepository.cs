using WritersWalk.Application.Models;

namespace WritersWalk.Application.Repositories;

public interface IUserRepository : IGenericRepository<User>
{
    Task<User> GetUserByIdWithAssignmentsAsync(string id);
}