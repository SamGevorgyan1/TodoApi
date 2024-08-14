using AutoMapper;
using MediatR;
using TodoApi.Application.DTO;
using TodoApi.Domain.Entity;
using TodoApi.Domain.Repository;

namespace TodoApi.Application.Command.Handlers;

public class CreateTodoCommandHandler : IRequestHandler<CreateTodo, TodoDto>
{
    private readonly ITodoRepository _todoRepository;
    private readonly IMapper _mapper;

    public CreateTodoCommandHandler(ITodoRepository todoRepository, IMapper mapper)
    {
        _todoRepository = todoRepository;
        _mapper = mapper;
    }

    public async Task<TodoDto> Handle(CreateTodo request, CancellationToken cancellationToken)
    {
        var createdTodo = await _todoRepository.CreateAsync(_mapper.Map<Todo>(request));
        return _mapper.Map<TodoDto>(createdTodo);
    }
}