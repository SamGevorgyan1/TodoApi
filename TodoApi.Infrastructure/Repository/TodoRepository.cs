using Microsoft.EntityFrameworkCore;
using TodoApi.Domain.Entity;
using TodoApi.Domain.Repository;
using TodoApi.Infrastructure.Data;

namespace TodoApi.Infrastructure.Repository;

public class TodoRepository : ITodoRepository
{
    private readonly TodoDbContext _dbContext;

    public TodoRepository(TodoDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Todo> CreateAsync(Todo todo)
    {
        await _dbContext.Todos.AddAsync(todo);
        await _dbContext.SaveChangesAsync();
        return todo;
    }

    public async Task<List<Todo>> GetAllAsync()
    {
        return await _dbContext.Todos.ToListAsync();
    }

    public async Task<Todo> GetByIdAsync(int id)
    {
        var todo = await _dbContext.Todos
            .AsNoTracking()
            .FirstOrDefaultAsync(t => t.Id == id);

        return todo;
    }

    public async Task<int> DeleteAsync(int id)
    {
        return await _dbContext.Todos
            .Where(t => t.Id == id)
            .ExecuteDeleteAsync();
    }

    public async Task<Todo> UpdateAsync(int id, Todo todo)
    {
        var todoEntity = await _dbContext.Todos.FirstOrDefaultAsync(t => t.Id == id);
        todoEntity.Name = todo.Name;
        todoEntity.IsComplete = todo.IsComplete;
        await _dbContext.SaveChangesAsync();
        return todoEntity;
    }
}