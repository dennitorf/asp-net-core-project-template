using System;

namespace CompanyName.ProjectName.Domain.Common
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }

        public string CreatedBy { get; set; }

        public DateTime ModifiedDate { get; set; }

        public string LastModifiedBy { get; set; }
        public bool IsActive { set; get; }
    }
}
