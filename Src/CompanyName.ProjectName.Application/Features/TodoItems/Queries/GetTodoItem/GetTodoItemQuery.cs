using CompanyName.ProjectName.Application.Features.TodoItems.Queries.GetAllTodoItems;
using MediatR;

namespace CompanyName.ProjectName.Application.Features.TodoItems.Queries.GetTodoItem
{
    public class GetTodoItemQuery : IRequest<TodoItemDto>
    {
        public int Id { set; get; }
    }
}
