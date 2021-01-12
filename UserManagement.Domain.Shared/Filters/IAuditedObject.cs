using System;
using System.Collections.Generic;
using System.Text;

namespace UserManagement.Filters
{
    public interface IAuditedObject
    {
        DateTime CreationTime { get; }
        //Guid CreatorId { get; }
        DateTime LastModificationTime { get; }
        //Guid LastModifierId { get; }
    }
}
