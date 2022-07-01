using AutoMapper;
using CompanyName.ProjectName.Application.Common.Exceptions;
using CompanyName.ProjectName.Application.Features.TodoItems.Queries.GetAllTodoItems;
using CompanyName.ProjectName.Domain.Entities.Sample;
using CompanyName.ProjectName.Persistence.Contexts;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CompanyName.ProjectName.Application.Features.TodoItems.Commands.UpdateTodoItem
{
    public class UpdateTodoItemCommandHandler : IRequestHandler<UpdateTodoItemCommand, TodoItemDto>
    {
        private ILogger logger;
        private AppDbContext db;
        private IMapper mapper;

        public UpdateTodoItemCommandHandler(ILogger<UpdateTodoItemCommandHandler> logger, AppDbContext db, IMapper mapper)
        {
            this.logger = logger;
            this.db = db;
            this.mapper = mapper;
        }

        public async Task<TodoItemDto> Handle(UpdateTodoItemCommand request, CancellationToken cancellationToken)
        {
            var ent = await db.TodoItems.FindAsync(request.Id);

            if (ent == null)
                throw new NotFoundException(nameof(TodoItem), request.Id);

            ent.Name = request.Name;
            ent.ModifiedDate = DateTime.UtcNow;
            ent.LastModifiedBy = "system";
            db.TodoItems.Update(ent);

            await db.SaveChangesAsync(cancellationToken);

            return mapper.Map<TodoItemDto>(ent);
        }
    }
}
