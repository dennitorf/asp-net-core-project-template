using CompanyName.ProjectName.Application.Features.TodoItems.Commands.CreateTodoItem;
using CompanyName.ProjectName.Application.Features.TodoItems.Commands.DeleteTodoItem;
using CompanyName.ProjectName.Application.Features.TodoItems.Commands.UpdateTodoItem;
using CompanyName.ProjectName.Application.Features.TodoItems.Queries.GetAllTodoItems;
using CompanyName.ProjectName.Application.Features.TodoItems.Queries.GetTodoItem;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CompanyName.ProjectName.WebApi.Controllers
{
    [Route("api/todos/{todoId}/[controller]")]
    [ApiController]
    public class TodoItems : BaseController
    {
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<TodoItemDto>))]
        public async Task<IActionResult> GetAll([FromRoute]int todoId)
        {
            return Ok(await Mediator.Send(new GetAllTodoItemsQuery() { Id = todoId }));
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(TodoItemDto))]
        public async Task<IActionResult> Get([FromRoute] int todoId, [FromRoute] int id)
        {
            return Ok(await Mediator.Send(new GetTodoItemQuery() { Id = id }));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(TodoItemDto))]
        public async Task<IActionResult> Post([FromRoute] int todoId, CreateTodoItemCommand command)
        {
            command.TodoId = todoId;

            return Ok(await Mediator.Send(command));
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(TodoItemDto))]
        public async Task<IActionResult> Put([FromRoute] int todoId, [FromRoute] int id, [FromBody] UpdateTodoItemCommand command)
        {            
            return Ok(await Mediator.Send(command));
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Delete([FromRoute] int todoId,[FromRoute] int id)
        {
            await Mediator.Send(new DeleteTodoItemCommand() { Id = id });
            return NoContent();

        }
    }
}
