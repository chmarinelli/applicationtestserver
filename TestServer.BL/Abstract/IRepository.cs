using TestServer.Core;
using TestServer.DM.Entities;

namespace TestServer.BL.Abstract
{
    public interface IPermitTypeRepository : IEntityBaseRepository<PermitType> { }
    public interface IPermitRepository : IEntityBaseRepository<Permit> { }
}
