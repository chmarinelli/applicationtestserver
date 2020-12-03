using FluentValidation;
using TestServer.BL.Abstract;
using TestServer.DM.Context;
using TestServer.DM.Entities;

namespace TestServer.BL.UnitOfWork.Repositories
{
    public class PermitTypeRepository : EntityBaseRepository<PermitType>, IPermitTypeRepository
    {
        public PermitTypeRepository(TestServerContext context, IValidator<PermitType> validator)
        : base(context, validator)
        {

        }
    }
}
