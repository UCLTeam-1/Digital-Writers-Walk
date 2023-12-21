using Microsoft.EntityFrameworkCore;
using WritersWalk.Application.Controllers;
using WritersWalk.Application.Database;
using WritersWalk.Application.Models;
using WritersWalk.Application.Repositories;

namespace WritersWalk.Test;

public class AssignmentControllerTest
{
    private readonly SqliteDbContext _context;
    private AssignmentController _assignmentController;

    public AssignmentControllerTest()
    {
        var dbOptions = new DbContextOptionsBuilder<SqliteDbContext>()
.UseInMemoryDatabase(Guid.NewGuid().ToString());
        _context = new SqliteDbContext(dbOptions.Options);
    }

    [Fact]
    public void GetAssignmentAsync_ShouldReturnAssignment()
    {

        seedDate();
        List<int> assignments = new List<int>();
        assignments.Add(1);
        assignments.Add(2);
        assignments.Add(3);

        var topicId = 1;
        var userId = "1";

        var assignmentRepository = new AssignmentRepository(_context);
        var topicRepository = new TopicRepository(_context);
        var surroundingRepository = new SurroundingRepository(_context);
        var userRepository = new UserRepository(_context);
        var assignmentUser = new AssignmentUserRepository(_context);

        _assignmentController = new AssignmentController(assignmentRepository,
            topicRepository, surroundingRepository, userRepository, assignmentUser);
        //Act

        var result = _assignmentController.GetAssignmentAsync(topicId, assignments, userId).Result;
        //Assert
        Assert.NotNull(result);
    }


    public void seedDate()
    {
        List<Assignment> assignments = new List<Assignment>();


        //Arrange
        var assignment1 = new Assignment(1, "Title 1", "description 1");
        var assignment2 = new Assignment(2, "Title 2", "description 2");
        var assignment3 = new Assignment(3, "Title 3", "description 3");
        var assignment4 = new Assignment(4, "Title 4", "description 4");
        var assignment5 = new Assignment(5, "Title 5", "description 5");

        assignments.Add(assignment1);
        assignments.Add(assignment2);
        assignments.Add(assignment3);
        assignments.Add(assignment4);
        assignments.Add(assignment5);

        _context.Assignments.AddRange(assignments);

        List<Topic> topics = new List<Topic>();
        var topic1 = new Topic(1, "TEST_TOPIC 1");
        var topic2 = new Topic(2, "TEST_TOPIC 2");
        var topic3 = new Topic(3, "TEST_TOPIC 3");

        topics.Add(topic1);
        topics.Add(topic2);
        topics.Add(topic3);

        _context.Topics.AddRange(topics);

        List<Surrounding> surroundings = new List<Surrounding>();

        var surrounding1 = new Surrounding(1, "TEST_SURROUNDING 1");
        var surrounding2 = new Surrounding(2, "TEST_SURROUNDING 2");
        var surrounding3 = new Surrounding(3, "TEST_SURROUNDING 3");
        var surrounding4 = new Surrounding(4, "TEST_SURROUNDING 4");
        var surrounding5 = new Surrounding(5, "TEST_SURROUNDING 5");

        surroundings.Add(surrounding1);
        surroundings.Add(surrounding2);
        surroundings.Add(surrounding3);
        surroundings.Add(surrounding4);
        surroundings.Add(surrounding5);

        _context.Surroundings.AddRange(surroundings);

        List<User> users = new List<User>();
        var user1 = new User("1", "user1@mail.com", "password123");
        var user2 = new User("2", "user2@mail.com", "password123");
        var user3 = new User("3", "user3@mail.com", "password123");

        _context.AssignmentSurroundings.Add(new AssignmentSurrounding { AssignmentId = 1, SurroundingsId = 1 });
        _context.AssignmentSurroundings.Add(new AssignmentSurrounding { AssignmentId = 1, SurroundingsId = 2 });
        _context.AssignmentSurroundings.Add(new AssignmentSurrounding { AssignmentId = 1, SurroundingsId = 3 });
        _context.AssignmentSurroundings.Add(new AssignmentSurrounding { AssignmentId = 2, SurroundingsId = 1 });
        _context.AssignmentSurroundings.Add(new AssignmentSurrounding { AssignmentId = 2, SurroundingsId = 2 });
        _context.AssignmentSurroundings.Add(new AssignmentSurrounding { AssignmentId = 2, SurroundingsId = 4 });
        _context.AssignmentSurroundings.Add(new AssignmentSurrounding { AssignmentId = 3, SurroundingsId = 5 });


        _context.AssignmentTopics.Add(new AssignmentTopic { AssignmentId = 1, TopicId = 1 });
        _context.AssignmentTopics.Add(new AssignmentTopic { AssignmentId = 1, TopicId = 2 });
        _context.AssignmentTopics.Add(new AssignmentTopic { AssignmentId = 1, TopicId = 3 });
        _context.AssignmentTopics.Add(new AssignmentTopic { AssignmentId = 2, TopicId = 1 });
        _context.AssignmentTopics.Add(new AssignmentTopic { AssignmentId = 2, TopicId = 2 });
        _context.AssignmentTopics.Add(new AssignmentTopic { AssignmentId = 2, TopicId = 3 });


        _context.AssignmentUsers.Add(new AssignmentUser { AssignmentId = 1, UserId = "1" });
        _context.AssignmentUsers.Add(new AssignmentUser { AssignmentId = 1, UserId = "2" });
        _context.AssignmentUsers.Add(new AssignmentUser { AssignmentId = 1, UserId = "3" });


        users.Add(user1);
        users.Add(user2);
        users.Add(user3);
        _context.Users.AddRange(users);
        _context.SaveChanges();
    }


}