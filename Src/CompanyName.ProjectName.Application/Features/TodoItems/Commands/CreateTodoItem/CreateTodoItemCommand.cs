using CompanyName.ProjectName.Application.Features.TodoItems.Queries.GetAllTodoItems;
using MediatR;

namespace CompanyName.ProjectName.Application.Features.TodoItems.Commands.CreateTodoItem
{
    public class CreateTodoItemCommand : IRequest<TodoItemDto>
    {
        public string Name { set; get; }
        public int TodoId { set; get; }
    }
}
