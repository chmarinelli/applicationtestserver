using FluentValidation;
using TestServer.DM.Entities;

namespace TestServer.BL.Validator
{
    public class PermitValidator : AbstractValidator<Permit>
    {
        public PermitValidator()
        {
            RuleFor(entity => entity.EmployeeName)
                .NotEmpty();

            RuleFor(entity => entity.EmployeeLastName)
                .NotEmpty();

            RuleFor(entity => entity.PermitTypeId)
                .NotEmpty();

            RuleFor(entity => entity.PermitDate)
                .NotEmpty();
        }
    }
}
