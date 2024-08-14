using FluentValidation;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace TodoApi.Application.Exceptions;

public class ValidationExceptionMiddleware
{
    private readonly RequestDelegate _next;

    public ValidationExceptionMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (ValidationException ex)
        {
            context.Response.StatusCode = StatusCodes.Status400BadRequest;
            context.Response.ContentType = "application/json";

            var errors = ex.Errors.Select(e => new
            {
                e.PropertyName, e.ErrorMessage
            });

            var result = new
            {
                StatusCode = 400,
                Message = "Validation failed.",
                Errors = errors
            };

            await context.Response.WriteAsync(JsonConvert.SerializeObject(result));
        }
    }
}