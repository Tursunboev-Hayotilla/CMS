using CMS.Application.UseCases.TeacherCases.Commands;
using CMS.Application.UseCases.TeacherCases.Queries;
using CMS.Domain.Entities.Auth;
using CMS.Domain.Entities.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CMS.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TeacherController : ControllerBase
    {
        private readonly IMediator _mediator;
        public TeacherController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IEnumerable<Teacher>> GetAllTeachers()
        {
            return await _mediator.Send(new GetAllTeacherQuery());  
        }
        [HttpGet]
        public async Task<IEnumerable<Teacher>> GetTeachersBySubject(Guid id)
        {
            return await _mediator.Send(new GetAllTeachersBySubjectQuery() {Id = id });
        }
        [HttpGet]
        public async Task<Teacher> GetTeacherById (string id)
        {
           return await _mediator.Send(new GetByIdTeacherQuery() { Id = id});
        }
        [HttpPut]
        public async Task<ResponseModel> UpdateTEacher(UpdateTeacherCommand command)
        {
            return await _mediator.Send(command);
        }
        [HttpDelete]
        public async Task<ResponseModel> DeleteTeacher(string id)
        {
            return await _mediator.Send(new DeleteTeacherCommand() { Id = id });
        }
    }
}
