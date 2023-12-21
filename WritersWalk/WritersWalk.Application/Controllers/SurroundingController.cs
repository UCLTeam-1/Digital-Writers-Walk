using WritersWalk.Application.Models;
using WritersWalk.Application.Repositories;

namespace WritersWalk.Application.Controllers;

public class SurroundingController
{
    private readonly ISurroundingRepository _surroundingRepository;

    public SurroundingController(ISurroundingRepository surroundingRepository)
    {
        _surroundingRepository = surroundingRepository;
    }

    /// <summary>
    /// Retrieves all surroundings asynchronously from the repository.
    /// </summary>
    /// <returns>A list of surroundings</returns>
    public Task<List<Surrounding>> GetAllAsync()
    {
        return _surroundingRepository.GetAllAsync();
    }

    /// <summary>
    /// Creates a new surrounding asynchronously and adds it to the repository.
    /// </summary>
    /// <param name="title">The title of the surrounding</param>
    /// <returns>The newly created surrounding</returns>
    public async Task<Surrounding> CreateAsync(string title)
    {
        var newSurrounding = new Surrounding { Title = title };
        await _surroundingRepository.AddAsync(newSurrounding);
        return newSurrounding;
    }

    /// <summary>
    /// Deletes a surrounding asynchronously based on the given ID.
    /// </summary>
    /// <param name="surroundingId">The ID of the surrounding to delete</param>
    public async Task DeleteAsync(int surroundingId)
    {
        var surroundingToDelete = await _surroundingRepository.GetByIdAsync(surroundingId);

        if (surroundingToDelete != null)
        {
            await _surroundingRepository.DeleteAsync(surroundingToDelete);
        }
    }
}