using CMS.Application.UseCases.ClassCases.Commands;
using CMS.Application.UseCases.ClassCases.Queries;
using CMS.Domain.Entities;
using CMS.Domain.Entities.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CMS.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ClassController : ControllerBase
    {
        private readonly IMediator _mediatr;
        public ClassController(IMediator mediator)
        {
            _mediatr =  mediator;
        }
        [HttpGet]
        public async Task<IEnumerable<Class>> GetAllClasses()
        {
            return await _mediatr.Send(new GetAllClassesQuery());
        }
        [HttpGet]
        public async Task<Class> GetClassById(Guid id)
        {
           return await _mediatr.Send(new GetClassByIdQuery() { Id = id });
        }
        [HttpPost]
        public async Task<ResponseModel> CreateClass([FromForm] CreateClassCommand command)
        {
            return await _mediatr.Send(command);
        }
        [HttpPost]
        public async Task<ResponseModel> AddSubjects(AddSubjectsToClass command)
        {
            return await _mediatr.Send(command);
        }
        [HttpPut]
        public async Task<ResponseModel> UpdateClass([FromForm] UpdateClassCommand command)
        {
            return await _mediatr.Send(command);
        }
        [HttpDelete]
        public async Task<ResponseModel> DeleteClass(Guid id)
        {
            return await _mediatr.Send(new DeleteClassCommand() { Id = id });
        }
    }
}
