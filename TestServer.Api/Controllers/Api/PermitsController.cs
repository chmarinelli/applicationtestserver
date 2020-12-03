using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using TestServer.BL.Dtos;
using TestServer.BL.UnitOfWork;
using TestServer.DM.Entities;

namespace TestServer.Api.Controllers.Api
{
    public class PermitsController : ApplicationBaseApiController<Permit, PermitDto>
    {
        public PermitsController(UnitOfWork unitOfWork, IMapper mapper)
            : base(unitOfWork, mapper)
        {

        }

        [HttpGet]
        public override IActionResult Get() => Ok(_mapper.Map<List<PermitDto>>(_repository.GetAll(p => p.PermitType)));

    }
}
