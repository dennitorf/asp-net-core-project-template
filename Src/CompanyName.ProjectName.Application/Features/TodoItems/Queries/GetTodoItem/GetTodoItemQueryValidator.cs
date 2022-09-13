using FluentValidation;

namespace CompanyName.ProjectName.Application.Features.TodoItems.Queries.GetTodoItem
{
    public class GetTodoItemQueryValidator : AbstractValidator<GetTodoItemQuery>
    {
        public GetTodoItemQueryValidator()
        {
            RuleFor(c => c.Id)
                .NotEmpty()
                .NotNull()
                .NotEqual(0)
                .WithMessage("Id is required");
        }
    }
}
