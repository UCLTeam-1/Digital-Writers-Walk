using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using WritersWalk.Application.Database;
using WritersWalk.Application.Models;
using WritersWalk.Application.Repositories;

namespace WritersWalk.Test;

public class TopicRepositorySQLTest
{
    private readonly SqliteDbContext _context;

    public TopicRepositorySQLTest()
    {
        var connection = new SqliteConnection("DataSource=:memory:");
        connection.Open();
        var dbOptions = new DbContextOptionsBuilder<SqliteDbContext>()
            .UseSqlite(connection);
        _context = new SqliteDbContext(dbOptions.Options);
        _context.Database.EnsureCreated();
    }


    [Fact]
    public void AddTopic_ShouldIncreaseTopicsCount()
    {
        var topic = new Topic()
        {
            Title = "TEST_TOPIC"
        };

        var repo = new TopicRepositorySQL(_context);
        repo.AddAsync(topic).Wait();

        var result = _context.Topics.Count();

        Assert.Equal(4, result);
    }

    [Fact]
    public void FindTopicById_ShouldReturnCorrectTitle()
    {
        var repo = new TopicRepositorySQL(_context);
        var result = repo.GetByIdAsync(1).Result;
        Assert.Equal("Skriv dig til klarhed", result.Title);
    }

    [Fact]
    public void UpdateTopic_ShouldUpdateTopicTitle()
    {
        var topic = new Topic()
        {
            Id = 1,
            Title = "TEST_TOPIC"
        };
        var repo = new TopicRepositorySQL(_context);
        repo.UpdateAsync(topic).Wait();

        var result = _context.Topics.Find(1);

        Assert.Equal("TEST_TOPIC", result.Title);
    }

    [Fact]
    public void GetAllTopics_ShouldReturnAllTopics()
    {
        var topic = new Topic()
        {
            Title = "TEST_TOPIC"
        };
        _context.Topics.Add(topic);
        _context.SaveChanges();

        var repo = new TopicRepositorySQL(_context);
        var result = repo.GetAllAsync().Result;

        Assert.Equal(4, result.Count());
    }

    [Fact]

    public void DeleteTopic_ShouldDecreaseTopicsCount()
    {
        var topic = new Topic()
        {
            Title = "TEST_TOPIC"
        };
        _context.Topics.Add(topic);
        _context.SaveChanges();

        var repo = new TopicRepositorySQL(_context);
        repo.DeleteAsync(topic).Wait();

        var result = _context.Topics.Count();

        Assert.Equal(3, result);
    }
}
