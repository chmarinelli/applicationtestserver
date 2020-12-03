using FluentValidation;
using TestServer.BL.Abstract;
using TestServer.DM.Context;
using TestServer.DM.Entities;

namespace TestServer.BL.UnitOfWork.Repositories
{
    public class PermitRepository : EntityBaseRepository<Permit>, IPermitRepository
    {
        public PermitRepository(TestServerContext context, IValidator<Permit> validator)
        : base(context, validator)
        {

        }
    }
}
