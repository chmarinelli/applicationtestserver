using System;

namespace TestServer.Core
{
    public interface IEntityAuditableBase : IEntityBase
    {
        DateTimeOffset CreatedAt { get; set; }
        DateTimeOffset? ModifiedAt { get; set; }
    }
}
