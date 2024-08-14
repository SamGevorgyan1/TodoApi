using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using FluentValidation;
using MediatR;
using TodoApi.Application.Behavior;

namespace TodoApi.Application;

public static class Extensions
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        services.AddMediatR(ctg =>
        {
            ctg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly());
            ctg.AddBehavior(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
        });
        return services;
    }
}