using CompanyName.ProjectName.Domain.Common;
using System.Collections.Generic;

namespace CompanyName.ProjectName.Domain.Entities.Sample
{
    public class Todo : BaseEntity
    {
        public string Name { set; get; }        
        public virtual ICollection<TodoItem> TodoItems { get; set; }
    }
}
