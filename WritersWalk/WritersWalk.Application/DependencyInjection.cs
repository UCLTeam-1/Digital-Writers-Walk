using Microsoft.Extensions.DependencyInjection;
using WritersWalk.Application.Controllers;
using WritersWalk.Application.Database;
using WritersWalk.Application.Repositories;
using WritersWalk.Application.Repositories.Interfaces;

namespace WritersWalk.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddDbContext<SqliteDbContext>();
        services.AddScoped<TopicController>();
        services.AddScoped<ITopicRepository, TopicRepository>();
        services.AddScoped<SurroundingController>();
        services.AddScoped<ISurroundingRepository, SurroundingRepository>();
        services.AddScoped<AssignmentController>();
        services.AddScoped<IAssignmentRepository, AssignmentRepository>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IAssignmentUserRepository, AssignmentUserRepository>();
        return services;
    }

}