using AutoMapper;
using MediatR;
using TodoApi.Application.DTO;
using TodoApi.Domain.Repository;

namespace TodoApi.Application.Queries.Handlers;

public class GetTodoByIdQueryHandler : IRequestHandler<GetTodoByIdQuery, TodoDto>
{
    private readonly ITodoRepository _todoRepository;
    private readonly IMapper _mapper;

    public GetTodoByIdQueryHandler(ITodoRepository todoRepository, IMapper mapper)
    {
        _todoRepository = todoRepository;
        _mapper = mapper;
    }

    public async Task<TodoDto> Handle(GetTodoByIdQuery request, CancellationToken cancellationToken) {
        var todo = await _todoRepository.GetByIdAsync(request.TodoId);
        return _mapper.Map<TodoDto>(todo);
    }
}