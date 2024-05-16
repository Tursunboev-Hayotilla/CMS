using CMS.Application.UseCases.ExamAppraciate.Commands;
using CMS.Application.UseCases.ExamAppraciate.Queries;
using CMS.Application.UseCases.ExamCases.Queries;
using CMS.Application.UseCases.StundentAppraciateCases.Commands;
using CMS.Domain.Entities.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CMS.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ExamAppriciateController : ControllerBase
    {
        private readonly IMediator _mediatr;
        public ExamAppriciateController(IMediator mediator)
        {
            _mediatr = mediator;
        }
        [HttpGet]
        public async Task<List<ExamAppraciateStudent>> GetResult(Guid classId)
        {
            return await _mediatr.Send(new GetAllExamResultsByClassId() { ClassId = classId });
        }
        [HttpGet]
        public async Task<ExamAppraciateStudent> GetById(Guid ExamId)
        {
            return await _mediatr.Send(new GetResultById() { ExamId = ExamId });
        }
        [HttpPost]
        public async Task<ResponseModel> Appriciate(AppraciateStudentCommand command)
        {
            return await _mediatr.Send(command);
        }
        [HttpPut]
        public async Task<ResponseModel> Update(Update command)
        {
            return await _mediatr.Send(command);
        }
    }
}
