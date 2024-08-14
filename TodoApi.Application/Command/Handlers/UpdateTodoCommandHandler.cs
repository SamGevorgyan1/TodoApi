using AutoMapper;
using MediatR;
using TodoApi.Application.DTO;
using TodoApi.Domain.Entity;
using TodoApi.Domain.Repository;

namespace TodoApi.Application.Command.Handlers;

public class UpdateTodoCommandHandler : IRequestHandler<UpdateTodo, TodoDto>
{
    private readonly ITodoRepository _todoRepository;
    private readonly IMapper _mapper;

    public UpdateTodoCommandHandler(ITodoRepository todoRepository, IMapper mapper)
    {
        _todoRepository = todoRepository;
        _mapper = mapper;
    }

    public async Task<TodoDto> Handle(UpdateTodo request, CancellationToken cancellationToken)
    {
        var todoEntity = _mapper.Map<Todo>(request);
        var updateTodo = await _todoRepository.UpdateAsync(request.Id, todoEntity);
        return _mapper.Map<TodoDto>(updateTodo);;
    }
}