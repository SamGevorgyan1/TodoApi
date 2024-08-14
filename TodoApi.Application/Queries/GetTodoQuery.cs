using MediatR;
using TodoApi.Application.DTO;

namespace TodoApi.Application.Queries;

public class GetTodoQuery : IRequest<List<TodoDto>>;