using FluentValidation;

namespace CompanyName.ProjectName.Application.Features.TodoItems.Commands.CreateTodoItem
{
    public class CreateTodoItemCommandValidator : AbstractValidator<CreateTodoItemCommand>
    {
        public CreateTodoItemCommandValidator()
        {
            RuleFor(c => c.Name)
                .NotEmpty()
                .NotNull()
                .NotEqual("")
                .WithMessage("Name is required");

            RuleFor(c => c.TodoId)
                .NotEmpty()
                .NotNull()
                .NotEqual(0)
                .WithMessage("Name is required");
        }
    }
}
