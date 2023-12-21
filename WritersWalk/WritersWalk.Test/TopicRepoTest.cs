using Microsoft.EntityFrameworkCore;
using WritersWalk.Application.Database;
using WritersWalk.Application.Models;
using WritersWalk.Application.Repositories;

namespace WritersWalk.Test;

public class TopicRepoTest
{
    private TopicRepository _topicRepository;
    private AssignmentRepository _assignmentRepository;
    private readonly SqliteDbContext _context;

    public TopicRepoTest()
    {
        var dbOptions = new DbContextOptionsBuilder<SqliteDbContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString());
        _context = new SqliteDbContext(dbOptions.Options);
        _topicRepository = new TopicRepository(_context);
        _assignmentRepository = new AssignmentRepository(_context);

    }

    [Fact]
    public async Task CreateTopic_ShouldCreate()
    {
        // arrange
        var topic = new Topic(1, "test");

        // act
        await _topicRepository.AddAsync(topic);

        // assert
        Assert.Equal("test", topic.Title);
    }

    [Fact]
    public async Task UpdateTopic_ShouldUpdate()
    {
        // arrange
        var topic = new Topic(1, "test");
        await _topicRepository.AddAsync(topic);

        // act
        topic.Title = "updated test";
        await _topicRepository.UpdateAsync(topic);

        // assert
        var updatedTopic = await _topicRepository.GetByIdAsync(topic.Id);
        Assert.Equal("updated test", updatedTopic?.Title);
    }

    [Fact]
    public async Task DeleteTopic_ShouldDelete()
    {
        // arrange
        var topic = new Topic(1, "test");
        await _topicRepository.AddAsync(topic);

        // act
        await _topicRepository.DeleteAsync(topic);

        // assert
        var deletedTopic = await _topicRepository.GetByIdAsync(topic.Id);
        Assert.Null(deletedTopic);
    }

    [Fact]
    public async Task GetAllTopics_ShouldReturnAllTopics()
    {
        // arrange
        await _topicRepository.AddAsync(new Topic(1, "Topic1"));
        await _topicRepository.AddAsync(new Topic(2, "Topic2"));

        // act
        var result = await _topicRepository.GetAllAsync();

        // assert
        Assert.NotNull(result);
        Assert.Equal(2, result.Count);
    }
    //[Fact]
    //public async Task GetTopicByIdWithAssignments_ShouldReturnTopicWithAssignments()
    //{
    //    arrange
    //   var topic = new Topic(1, "test");
    //    var assignment = new Assignment(1, "assignment title", "description");
    //    Create an AssignmentTopic linking the topic and assignment
    //    var assignmentTopic = new AssignmentTopic { AssignmentId = assignment.Id, TopicId = topic.Id };

    //    act
    //   await _topicRepository.AddAsync(topic);
    //    await _assignmentRepository.AddAsync(assignment);
    //    var result = await _topicRepository.GetTopicByIdWithAssignmentsAsync(topic.Id);

    //    assert
    //    Assert.NotNull(result);
    //    Assert.Equal("test", result.Title);
    //    Assert.NotEmpty(result.AssignmentTopics);

    //    Check if the AssignmentTopic in the result has the correct Assignment
    //    var assignmentTopicInResult = result.AssignmentTopics.FirstOrDefault();
    //    Assert.NotNull(assignmentTopicInResult);
    //    Assert.NotNull(assignmentTopicInResult.Assignment);
    //    Assert.Equal("assignment title", assignmentTopicInResult.Assignment.Title);
    //}

}
