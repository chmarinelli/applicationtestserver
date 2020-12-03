using FluentValidation;
using TestServer.DM.Entities;

namespace TestServer.BL.Validator
{
    public class PermitTypeValidator : AbstractValidator<PermitType>
    {
        public PermitTypeValidator()
        {
            RuleFor(entity => entity.Description)
                .NotEmpty();
        }
    }
}
