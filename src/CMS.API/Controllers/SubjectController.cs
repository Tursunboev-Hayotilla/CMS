using CMS.Application.UseCases.SubjectCases.Commands;
using CMS.Application.UseCases.SubjectCases.Queries;
using CMS.Domain.Entities;
using CMS.Domain.Entities.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CMS.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class SubjectController : ControllerBase
    {
        private readonly IMediator _mediatr;
        public SubjectController(IMediator mediator)
        {
            _mediatr = mediator;
        }

        [HttpGet]
        public async Task<IEnumerable<Subject>> GetAllSubjects()
        {
            return await _mediatr.Send(new GetAllSubjectsQuery() { });
        }
        [HttpGet]
        public async Task<Subject> GetSubjectById(Guid id)
        {
            return await _mediatr.Send(new GetSubjectById() { Id = id });
        }
        [HttpPost]
        public async Task<ResponseModel> CreateSubject(CreateSubjectCommand command)
        {
            return await _mediatr.Send(command);
        }
        [HttpPut]
        public async Task<ResponseModel> UpdateSubject(UpdateSUbjectCommand command)
        {
            return await _mediatr.Send(command);
        }
        [HttpDelete]
        public async Task<ResponseModel> DeleteSubject(Guid id)
        {
            return await _mediatr.Send(new DeleteSubjectCommand() { Id = id }); 
        }
    }
}
