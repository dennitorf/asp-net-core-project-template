using CompanyName.ProjectName.Application.Features.Todos.Queries.GetAllTodos;
using CompanyName.ProjectName.Application.Features.Todos.Queries.GetTodo;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CompanyName.ProjectName.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Todos : BaseController
    {
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<TodoDto>))]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await Mediator.Send(new GetAllTodosQuery() { }));
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(TodoDto))]
        public async Task<IActionResult> Get([FromRoute]int id)
        {
            return Ok(await Mediator.Send(new GetTodoQuery() { Id = id }));
        }
    }
}
