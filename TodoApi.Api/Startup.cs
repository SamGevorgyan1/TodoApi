using TodoApi.Application;
using TodoApi.Application.Exceptions;
using TodoApi.Infrastructure;

namespace TodoApi.Api;

public class Startup
{
    private IConfiguration Configuration { get; }

    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

  
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddApplication();
        services.AddInfrastructureServices(Configuration);
        services.AddControllers();
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
        services.AddHttpContextAccessor();
    }

    
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "TodoApi v1"));
        }

        app.UseHttpsRedirection();

        app.UseMiddleware<ValidationExceptionMiddleware>();
        
        app.UseRouting();

        app.UseAuthorization();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
    }
}