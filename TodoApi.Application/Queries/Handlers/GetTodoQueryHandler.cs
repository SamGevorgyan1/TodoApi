using AutoMapper;
using MediatR;
using TodoApi.Application.DTO;
using TodoApi.Domain.Repository;

namespace TodoApi.Application.Queries.Handlers;

public class GetTodoQueryHandler : IRequestHandler<GetTodoQuery, List<TodoDto>>
{
    private readonly ITodoRepository _todoRepository;
    private readonly IMapper _mapper;

    public GetTodoQueryHandler(ITodoRepository todoRepository, IMapper mapper)
    {
        _todoRepository = todoRepository;
        _mapper = mapper;
    }

    public async Task<List<TodoDto>> Handle(GetTodoQuery request, CancellationToken cancellationToken)
    {
        var todos = await _todoRepository.GetAllAsync();
        var todosList = _mapper.Map<List<TodoDto>>(todos);
        return todosList;
    }
}