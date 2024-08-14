using MediatR;
using TodoApi.Application.DTO;

namespace TodoApi.Application.Queries;

public record GetTodoByIdQuery(int TodoId) : IRequest<TodoDto>;
