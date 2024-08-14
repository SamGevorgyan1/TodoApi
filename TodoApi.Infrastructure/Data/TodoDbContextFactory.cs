using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace TodoApi.Infrastructure.Data;

public class TodoDbContextFactory : IDesignTimeDbContextFactory<TodoDbContext>
{
    public TodoDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<TodoDbContext>();
        optionsBuilder.UseNpgsql("Host=localhost;Database=todo;Username=user;Password=user");
        return new TodoDbContext(optionsBuilder.Options);
    }
}