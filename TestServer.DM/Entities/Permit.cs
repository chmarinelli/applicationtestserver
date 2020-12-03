using System;
using TestServer.Core;

namespace TestServer.DM.Entities
{
    public class Permit : IEntityAuditableBase
    {
        public int Id { get; set; }
        public string EmployeeName { get; set; }
        public string EmployeeLastName { get; set; }
        public int PermitTypeId { get; set; }
        public virtual PermitType PermitType { get; set; }
        public DateTime PermitDate { get; set; }

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
        public DateTimeOffset? ModifiedAt { get; set; }

        #endregion
    }
}
