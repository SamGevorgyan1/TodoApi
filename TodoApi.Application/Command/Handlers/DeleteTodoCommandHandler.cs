using MediatR;
using TodoApi.Domain.Repository;

namespace TodoApi.Application.Command.Handlers;

public class DeleteTodoCommandHandler : IRequestHandler<DeleteTodo, int>
{
    private readonly ITodoRepository _todoRepository;

    public DeleteTodoCommandHandler(ITodoRepository todoRepository)
    {
        _todoRepository = todoRepository;
    }

    public async Task<int> Handle(DeleteTodo request, CancellationToken cancellationToken)
    {
        return await _todoRepository.DeleteAsync(request.Id);
    }
}