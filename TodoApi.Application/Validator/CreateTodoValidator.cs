using FluentValidation;
using TodoApi.Application.Command;

namespace TodoApi.Application.Validator;

public class CreateTodoValidator : AbstractValidator<CreateTodo>
{
    public CreateTodoValidator()
    {
        RuleFor(t => t.Name)
            .NotEmpty()
            .WithMessage("The name of todo can not be empty");
    }
}