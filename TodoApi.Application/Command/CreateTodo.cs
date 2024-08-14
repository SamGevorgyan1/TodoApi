using MediatR;
using TodoApi.Application.DTO;

namespace TodoApi.Application.Command;

public record CreateTodo(string Name, bool IsComplete) : IRequest<TodoDto>;