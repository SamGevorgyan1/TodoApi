using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TodoApi.Domain.Repository;
using TodoApi.Infrastructure.Data;
using TodoApi.Infrastructure.Repository;

namespace TodoApi.Infrastructure;

public static class ConfigureService
{
    public static IServiceCollection AddInfrastructureServices
        (this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<TodoDbContext>(options =>
            options.UseNpgsql(configuration.GetConnectionString("TodoDbContext")));
        services.AddTransient<ITodoRepository, TodoRepository>();
        return services;
    }
}