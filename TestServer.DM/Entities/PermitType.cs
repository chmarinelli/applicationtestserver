using System;
using TestServer.Core;

namespace TestServer.DM.Entities
{
    public class PermitType : IEntityAuditableBase
    {
        public int Id { get; set; }
        public string Description { get; set; }

        #region AuditFields
        /// <summary>
        /// Bool property represent if the cut was deleted by user
        /// </summary>
        public bool IsDeleted { get; set; }

        /// <summary>
        /// Date property representing the date on which the entity was created
        /// </summary>
        public DateTimeOffset CreatedAt { get; set; }

        /// <summary>
        /// Date property representing the date on which the entity was edited
        /// </summary>
        public DateTimeOffset? ModifiedAt{ get; set; }

        #endregion
    }
}
