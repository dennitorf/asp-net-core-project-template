using AutoMapper;
using CompanyName.ProjectName.Persistence.Contexts;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CompanyName.ProjectName.Application.Features.TodoItems.Queries.GetAllTodoItems
{        
    public class GetAllTodoItemsQueryHandler : IRequestHandler<GetAllTodoItemsQuery, IEnumerable<TodoItemDto>>
    {
        private AppDbContext db;
        private ILogger logger;
        private IMapper mapper;

        public GetAllTodoItemsQueryHandler(AppDbContext db, ILogger<GetAllTodoItemsQueryHandler> logger, IMapper mapper)
        {
            this.db = db;
            this.logger = logger;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<TodoItemDto>> Handle(GetAllTodoItemsQuery request, CancellationToken cancellationToken)
        {
            return mapper.ProjectTo<TodoItemDto>(db.TodoItems.Where(c => c.TodoId == request.Id).AsNoTracking());
        }
    }
}
 