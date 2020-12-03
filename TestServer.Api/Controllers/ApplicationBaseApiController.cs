using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TestServer.BL.Abstract;
using TestServer.BL.UnitOfWork;
using TestServer.Core;
using TestServer.Core.Extensions;

namespace TestServer.Api.Controllers
{
    [Route("Api/[controller]")]
    public abstract class ApplicationBaseApiController<T, TD> : ControllerBase
                 where T : class, IEntityBase, new()
                 where TD : class, IEntityBaseDto, new()
    {
        protected readonly UnitOfWork _unitOfWork;
        protected readonly IEntityBaseRepository<T> _repository;
        protected readonly IMapper _mapper;

        public ApplicationBaseApiController(UnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _repository = _unitOfWork.Get<T>();
            _mapper = mapper;
        }

        [HttpGet]
        public virtual IActionResult Get()
        {
            return Ok(_mapper.Map<List<TD>>(_repository.GetAll()));
        }

        [HttpGet("{key}")]
        public virtual async Task<IActionResult> Get(int key)
        {
            T result = await _repository.FindAsync(key);
            return Ok(_mapper.Map<TD>(result));
        }

        [HttpPost]
        public virtual async Task<IActionResult> Post([FromBody] TD dto)
        {
            if (dto == null) throw new ArgumentNullException(typeof(TD).GetCleanNameFromDto());

            var model = _mapper.Map<T>(dto);

            await _repository.AddAsync(model);
            await _unitOfWork.SaveAsync();

            return Ok(_mapper.Map(model, dto));
        }


        [HttpPut("{key}")]
        public virtual async Task<IActionResult> Put([FromRoute] int key, [FromBody] TD dto)
        {
            if (dto == null) throw new ArgumentNullException(typeof(TD).GetCleanNameFromDto());

            var model = await _repository.FindAsync(key);

            model = _mapper.Map(dto, model);

            _repository.Update(model);
            await _unitOfWork.SaveAsync();

            return Ok(_mapper.Map(model, dto));
        }

        [HttpDelete("{key}")]
        public virtual async Task<IActionResult> Delete([FromRoute] int key)
        {
            await _repository.SoftDeleteAsync(key);
            await _unitOfWork.SaveAsync();

            return Ok();
        }
    }
}
