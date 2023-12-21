using WritersWalk.Application.Models;
using WritersWalk.Application.Repositories;
using WritersWalk.Application.Repositories.Interfaces;

namespace WritersWalk.Application.Controllers;

public class AssignmentController
{
    private readonly IAssignmentRepository _assignmentRepository;
    private readonly ITopicRepository _topicRepository;
    private readonly ISurroundingRepository _surroundingRepository;
    private readonly IUserRepository _userRepository;
    private readonly IAssignmentUserRepository _assignmentUserRepository;

    public AssignmentController
    (
        IAssignmentRepository assignmentRepository,
        ITopicRepository topicRepository,
        ISurroundingRepository surroundingRepository,
        IUserRepository userRepository,
        IAssignmentUserRepository assignmentUserRepository
    )
    {
        _assignmentRepository = assignmentRepository;
        _topicRepository = topicRepository;
        _surroundingRepository = surroundingRepository;
        _userRepository = userRepository;
        _assignmentUserRepository = assignmentUserRepository;
    }

    /// <summary>
    /// Retrieves all assignments asynchronously from the repository.
    /// </summary>
    /// <returns>A list of assignments</returns>
    public async Task<List<Assignment>> GetAllAsync()
    {
        return await _assignmentRepository.GetAllAsync();
    }

    /// <summary>
    /// Creates an assignment asynchronously and adds it to the repository.
    /// </summary>
    /// <param name="assignment">The assignment to be created</param>
    /// <returns>The created assignment</returns>
    public async Task<Assignment> CreateAsync(Assignment assignment)
    {
        await _assignmentRepository.AddAsync(assignment);
        return assignment;
    }

    /// <summary>
    /// Retrieves an assignment asynchronously based on the given topic ID, surroundings, and user ID.
    /// </summary>
    /// <param name="topicId">The topic ID</param>
    /// <param name="surroundings">The list of surroundings IDs</param>
    /// <param name="userId">The user ID</param>
    /// <returns>An assignment</returns>
    public async Task<Assignment> GetAssignmentAsync(int topicId, List<int> surroundings, string userId)
    {
        // Get topic assignments by topicId
        var topicAssignments = await _topicRepository.GetTopicByIdWithAssignmentsAsync(topicId);
        // Get user assignments by userId
        var userAssignments = await _userRepository.GetUserByIdWithAssignmentsAsync(userId);

        // Create a list to store assignments
        var assignmentsList = new List<Assignment>();

        // Check if surroundings parameter is not null
        if (surroundings != null)
        {
            // Loop through each surrounding in surroundings list
            foreach (var surrounding in surroundings)
            {
                // Get surrounding assignments by surrounding Id
                var surroundingAssignments = await _surroundingRepository.GetSurroundingByIdWithAssignmentsAsync(surrounding);

                // Add all assignment objects to assignmentsList
                assignmentsList
                    .AddRange(surroundingAssignments.AssignmentSurroundings
                    .Select(assignmentSurrounding => assignmentSurrounding.Assignment)
                    .ToList());
            }
        }

        // Filter assignments in assignmentsList based on topicAssignments
        var filteredAssignments = assignmentsList
            .Where(assignment =>
                topicAssignments.AssignmentTopics.Any(assignmentTopic => assignmentTopic.AssignmentId == assignment.Id))
            .ToList();

        // Remove assignments that are already done by the user
        foreach (var userAssignment in userAssignments.AssignmentUsers)
        {
            filteredAssignments.RemoveAll(assignment => assignment.Id == userAssignment.AssignmentId);
        }

        // Return the first assignment from filteredAssignments
        return filteredAssignments.FirstOrDefault();
    }

    /// <summary>
    /// Retrieves a random assignment asynchronously from the repository.
    /// </summary>
    /// <returns>A random assignment</returns>
    public async Task<Assignment> GetRandomAssignmentAsync()
    {
        var assignments = await _assignmentRepository.GetAllAsync();
        var random = new Random();
        var randomAssignment = assignments[random.Next(assignments.Count)];
        return randomAssignment;
    }

    /// <summary>
    /// Creates a new AssignmentUser asynchronously and adds it to the repository.
    /// </summary>
    /// <param name="assignmentUser">The AssignmentUser to be created</param>
    /// <returns>A Task representing the asynchronous operation</returns>
    public async Task CreateAssignmentUser(AssignmentUser assignmentUser)
    {
        await _assignmentUserRepository.AddAsync(assignmentUser);
    }

    /// <summary>
    /// Updates an existing AssignmentUser asynchronously in the repository.
    /// </summary>
    /// <param name="assignmentUser">The AssignmentUser to be updated</param>
    /// <returns>A Task representing the asynchronous operation</returns>
    public async Task UpdateAssignmentUser(AssignmentUser assignmentUser)
    {
        await _assignmentUserRepository.UpdateAsync(assignmentUser);
    }

    /// <summary>
    /// Retrieves an AssignmentUser asynchronously by assignment ID and user ID.
    /// </summary>
    /// <param name="assignmentId">The assignment ID</param>
    /// <param name="userId">The user ID</param>
    /// <returns>The AssignmentUser matching the assignment ID and user ID</returns>
    public async Task<AssignmentUser> GetAssignmentUserByIdAsync(int assignmentId, string userId)
    {
        var assignmentUser = await _assignmentUserRepository.GetByAssignmentAndUserId(assignmentId, userId);
        return assignmentUser;
    }

    /// <summary>
    /// Retrieves the assignment in progress for a given user asynchronously.
    /// </summary>
    /// <param name="userId">The user ID</param>
    /// <returns>The assignment in progress, or null if not found</returns>
    public async Task<Assignment?> GetAssignmentInProgress(string userId)
    {
        try
        {
            var userAssignments = await _assignmentUserRepository.GetAllAsync();
            var Assignment = userAssignments.FirstOrDefault(x => x.UserId == userId && x.Status == AssignmentStatus.InProgress);
            var assignment = await _assignmentRepository.GetByIdAsync(Assignment.AssignmentId);
            return assignment;

        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return null;
        }
    }
}