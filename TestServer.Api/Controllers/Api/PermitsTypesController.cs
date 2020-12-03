using AutoMapper;
using TestServer.BL.Dtos;
using TestServer.BL.UnitOfWork;
using TestServer.DM.Entities;

namespace TestServer.Api.Controllers.Api
{
    public class PermitsTypesController : ApplicationBaseApiController<PermitType, PermitTypeDto>
    {
        public PermitsTypesController(UnitOfWork unitOfWork, IMapper mapper)
            : base(unitOfWork, mapper)
        {

        }
    }
}
