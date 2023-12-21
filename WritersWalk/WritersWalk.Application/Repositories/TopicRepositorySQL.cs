using Microsoft.EntityFrameworkCore;
using WritersWalk.Application.Database;
using WritersWalk.Application.Models;

namespace WritersWalk.Application.Repositories;

public class TopicRepositorySQL
{
    private readonly SqliteDbContext _context;

    public TopicRepositorySQL(SqliteDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(Topic entity)
    {
        FormattableString query = $"INSERT INTO Topics (Title) VALUES (\"{entity.Title}\") ";
        await _context.Database.ExecuteSqlInterpolatedAsync(query);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Topic entity)
    {
        FormattableString query = $"DELETE FROM Topics WHERE Id = {entity.Id}";
        await _context.Database.ExecuteSqlInterpolatedAsync(query);
    }

    public async Task<List<Topic>> GetAllAsync()
    {
        FormattableString query = $"SELECT * FROM Topics";
        return await _context.Topics.FromSqlInterpolated(query).ToListAsync();
    }

    public async Task<Topic?> GetByIdAsync(int id)
    {
        FormattableString query = $"SELECT * FROM Topics WHERE Id = {id}";
        return await _context.Topics.FromSql(query).FirstOrDefaultAsync();
    }

    public async Task UpdateAsync(Topic entity)
    {
        FormattableString query = $"UPDATE Topics SET Title = {entity.Title} WHERE Id = {entity.Id}";
        await _context.Database.ExecuteSqlInterpolatedAsync(query);
    }
}
