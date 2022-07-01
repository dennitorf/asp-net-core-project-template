﻿using CompanyName.ProjectName.Domain.Common;

namespace CompanyName.ProjectName.Domain.Entities.Sample
{
    public class TodoItem : BaseEntity
    {
        public string Name { set; get; }
        public bool IsCompleted { set; get; }
    }
}