using CMS.Application.UseCases.ExamCases.Commands;
using CMS.Application.UseCases.ExamCases.Queries;
using CMS.Domain.Entities;
using CMS.Domain.Entities.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CMS.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ExamController : ControllerBase
    {
        private readonly IMediator _mediatr;
        public ExamController(IMediator mediator)
        {
            _mediatr = mediator;
        }

        [HttpGet]
        public async Task<List<Examine>> GetAllExams()
        {
            return await _mediatr.Send(new GetAllExamsQuery ());
        }
        [HttpGet]
        public async Task<List<Examine>> GetAllExamsByClassId()
        {
            return await _mediatr.Send(new GetAllExamByClassIdQuery());
        }
        [HttpGet]
        public async Task<Examine> GetExamById(Guid id)
        {
            return await _mediatr.Send(new GetExamByIdQuery() { ExamId =  id });
        }
        [HttpPost]
        public async Task<ResponseModel> CreateExam([FromForm] CreateExamCommand command)
        {
            return await _mediatr.Send(command);
        }
        [HttpPut]
        public async Task<ResponseModel> UpdateExam(UpdateExamCommand command)
        {
            return await _mediatr.Send(command);
        }
        [HttpDelete]
        public async Task<ResponseModel> DeleteExam(Guid id)
        {
            return await _mediatr.Send(new DeleteExamCommand() { ExamId = id });
        }
    }
}
