using TodoApi.Domain.Entity;

namespace TodoApi.Domain.Repository;

public interface ITodoRepository
{
    Task<Todo> CreateAsync(Todo todo);
    Task<List<Todo>> GetAllAsync();
    Task<Todo> GetByIdAsync(int id);
    Task<Todo> UpdateAsync(int id, Todo todo);
    Task<int> DeleteAsync(int id);
}