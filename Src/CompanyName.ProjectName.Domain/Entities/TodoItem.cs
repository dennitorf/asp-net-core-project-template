using CompanyName.ProjectName.Domain.Common;

namespace CompanyName.ProjectName.Domain.Entities
{
    public class TodoItem : BaseEntity
    {
        public string Name { set; get; }
        public bool IsCompleted { set; get; }
    }
}
