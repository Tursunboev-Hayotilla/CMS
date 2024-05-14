using CMS.Application.UseCases.StudentCases.Commands;
using CMS.Application.UseCases.StudentCases.Queries;
using CMS.Domain.Entities.Auth;
using CMS.Domain.Entities.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CMS.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IMediator _mediator;
        public StudentController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IEnumerable<Student>> GetAllSudents()
        {
            return await _mediator.Send(new GetAllStudentsQuery());
        }
        [HttpGet]
        public async Task<Student> GetStundetById(string Id)
        {
            return await _mediator.Send(new GetStudentByIdQuery() { Id = Id });
        }
        [HttpGet]
        public async Task<IEnumerable<Student>> GetStudentsByClassId(Guid id)
        {
            return await _mediator.Send(new GetStudentsByClassIdQuery() { Id = id });
        }

        [HttpPut]
        public async Task<ResponseModel> AddCoins(AddCoinsCommand command)
        {
            return await _mediator.Send(command);
        }
        [HttpPut]
        public async Task<ResponseModel> UpdateStudent(UpdateStudentCommand command)
        {
            return await _mediator.Send(command);
        }
        [HttpDelete]
        public async Task<ResponseModel> DeleteStudent(string id)
        {
            return await _mediator.Send(new DeleteStudentCommand() { Id = id });
        }

    }
}
