using WritersWalk.Application.Models;
using WritersWalk.Application.Repositories;

namespace WritersWalk.Application.Controllers;

public class TopicController
{
    private readonly ITopicRepository _topicRepository;

    public TopicController(ITopicRepository topicRepository)
    {
        _topicRepository = topicRepository;
    }

    /// <summary>
    /// Retrieves all topics asynchronously from the repository.
    /// </summary>
    /// <returns>A list of topics</returns>
    public Task<List<Topic>> GetAllAsync()
    {
        return _topicRepository.GetAllAsync();
    }

    /// <summary>
    /// Retrieves a topic asynchronously based on the given ID.
    /// </summary>
    /// <param name="id">The ID of the topic</param>
    /// <returns>The topic with the given ID</returns>
    public Task<Topic> GetByIdAsync(int id)
    {
        return _topicRepository.GetByIdAsync(id);
    }

    /// <summary>
    /// Creates a new topic asynchronously and adds it to the repository.
    /// </summary>
    /// <param name="title">The title of the topic</param>
    /// <returns>The newly created topic</returns>
    public async Task<Topic> CreateTopicAsync(string title)
    {
        var newTopic = new Topic { Title = title };
        await _topicRepository.AddAsync(newTopic);
        return newTopic;
    }

    /// <summary>
    /// Updates an existing topic asynchronously in the repository.
    /// </summary>
    /// <param name="topic">The updated topic</param>
    /// <returns>The updated topic</returns>
    public async Task<Topic> UpdateTopicAsync(Topic topic)
    {
        await _topicRepository.UpdateAsync(topic);
        return topic;
    }

    /// <summary>
    /// Deletes a topic asynchronously based on the given ID.
    /// </summary>
    /// <param name="topicId">The ID of the topic to delete</param>
    public async Task DeleteTopicAsync(int topicId)
    {
        var topicToDelete = await _topicRepository.GetByIdAsync(topicId);

        if (topicToDelete != null)
        {
            await _topicRepository.DeleteAsync(topicToDelete);
        }
    }
}