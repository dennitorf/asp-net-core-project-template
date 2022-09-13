using MediatR;
using System.Collections.Generic;

namespace CompanyName.ProjectName.Application.Features.Todos.Queries.GetAllTodos
{
    public class GetAllTodosQuery : IRequest<IEnumerable<TodoDto>>
    {
        public int Id { set; get; }

        public string Name { set; get; }
    }
}
