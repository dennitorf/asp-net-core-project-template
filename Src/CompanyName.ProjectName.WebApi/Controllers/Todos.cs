using CompanyName.ProjectName.Application.Features.Todos.Commands.CreateTodo;
using CompanyName.ProjectName.Application.Features.Todos.Commands.DeleteTodo;
using CompanyName.ProjectName.Application.Features.Todos.Commands.UpdateTodo;
using CompanyName.ProjectName.Application.Features.Todos.Queries.GetAllTodos;
using CompanyName.ProjectName.Application.Features.Todos.Queries.GetTodo;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CompanyName.ProjectName.WebApi.Controllers
{
    [Route("ns-ms-name/api/[controller]")]
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

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(TodoDto))]
        public async Task<IActionResult> Post(CreateTodoCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(TodoDto))]
        public async Task<IActionResult> Put([FromRoute]int id, [FromBody]UpdateTodoCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            await Mediator.Send(new DeleteTodoCommand() { Id = id });
            return NoContent();
            
        }
    }
}
