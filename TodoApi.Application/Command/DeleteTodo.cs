using MediatR;

namespace TodoApi.Application.Command;

public record DeleteTodo(int Id) : IRequest<int>;