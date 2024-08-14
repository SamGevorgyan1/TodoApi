using MediatR;
using TodoApi.Application.DTO;

namespace TodoApi.Application.Command;

public record UpdateTodo(int Id, string Name, bool IsComplete) : IRequest<TodoDto>;