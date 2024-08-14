using MediatR;
using Microsoft.AspNetCore.Mvc;
using TodoApi.Application.Command;
using TodoApi.Application.Queries;

namespace TodoApi.Api.Controller;

[Route("api/todoitems")]
[ApiController]
public class TodoController : ControllerBase
{
    private readonly IMediator _mediator;

    public TodoController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateTodo command)
    {
        var createdTodo = await _mediator.Send(command);
        return CreatedAtAction(nameof(Get), new { id = createdTodo.Id }, createdTodo);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var todos = await _mediator.Send(new GetTodoQuery());
        return Ok(todos);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> Get(int id)
    {
        var todo = await _mediator.Send(new GetTodoByIdQuery(id));
        if (todo == null)
        {
            return NotFound();
        }
        return Ok(todo);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, [FromBody] UpdateTodo todo)
    {
        if (id != todo.Id)
        {
            return BadRequest("Todo ID mismatch");
        }

        var updatedTodo = await _mediator.Send(todo);
        return Ok(updatedTodo);
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _mediator.Send(new DeleteTodo(id));
        return NoContent();
    }
}