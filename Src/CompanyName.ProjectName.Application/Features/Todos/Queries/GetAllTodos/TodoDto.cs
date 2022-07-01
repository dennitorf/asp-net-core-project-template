using CompanyName.ProjectName.Application.Common.Interfaces.Mappings;
using CompanyName.ProjectName.Domain.Entities.Sample;
using System;

namespace CompanyName.ProjectName.Application.Features.Todos.Queries.GetAllTodos
{
    public class TodoDto : IMapFrom<Todo>
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string LastModifiedBy { get; set; }
        public bool IsActive { set; get; }
    }
}