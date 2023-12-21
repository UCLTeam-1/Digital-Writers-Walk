using Microsoft.EntityFrameworkCore;
using WritersWalk.Application.Controllers;
using WritersWalk.Application.Database;
using WritersWalk.Application.Models;
using WritersWalk.Application.Repositories;

namespace WritersWalk.Test;

public class TopicControllerTest
{
    private TopicController _topicController;
    private readonly SqliteDbContext _context;


    public TopicControllerTest()
    {
        var dbOptions = new DbContextOptionsBuilder<SqliteDbContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString());
        _context = new SqliteDbContext(dbOptions.Options);
    }
    [Fact]
    public void GetAllAsyncTest()
    {
        //Arrange
        var topic = new Topic(1, "TEST_TOPIC");

        _context.Topics.Add(topic);
        _context.SaveChanges();
        var _ = new TopicRepository(_context);
        _topicController = new TopicController(_);
        //Act
        var result = _topicController.GetAllAsync().Result;
        //Assert
        Assert.Single(result);
    }
}