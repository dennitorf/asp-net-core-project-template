using CompanyName.ProjectName.Application.Features.Todos.Queries.GetAllTodos;
using MediatR;

namespace CompanyName.ProjectName.Application.Features.Todos.Commands.CreateTodo
{
    public class CreateTodoCommand : IRequest<TodoDto>
    {
        public string Name { set; get; }
    }
}
