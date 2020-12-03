using System;
using TestServer.BL.Abstract;

namespace TestServer.BL.Dtos
{
    public class PermitDto : IEntityBaseDto
    {
        public int Id { get; set; }
        public string EmployeeName { get; set; }
        public string EmployeeLastName { get; set; }
        public int PermitTypeId { get; set; }
        public virtual PermitTypeDto PermitType { get; set; }
        public DateTime PermitDate { get; set; }

        public DateTimeOffset? CreatedAt { get; set; }
    }
}
