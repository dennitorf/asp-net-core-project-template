using FluentValidation;

namespace CompanyName.ProjectName.Application.Features.TodoItems.Commands.DeleteTodoItem
{
    public class DeleteTodoItemCommandValidator : AbstractValidator<DeleteTodoItemCommand>
    {
        public DeleteTodoItemCommandValidator()
        {
            RuleFor(c => c.Id)
                .NotEmpty()
                .NotNull()
                .NotEqual(0)
                .WithMessage("Id is required");
        }
    }
}
