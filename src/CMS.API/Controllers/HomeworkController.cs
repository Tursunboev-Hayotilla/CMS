using CMS.Application.UseCases.HomeWorkCases.Commands;
using CMS.Application.UseCases.HomeWorkCases.Queries;
using CMS.Domain.Entities;
using CMS.Domain.Entities.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CMS.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class HomeworkController : ControllerBase
    {
        private readonly IMediator _mediatr;
        public HomeworkController(IMediator mediator)
        {
            _mediatr = mediator;
        }
        [HttpGet]
        public async Task<IEnumerable<Homework>> GetAllHomeworks(Guid id)
        {
            return await _mediatr.Send(new GetAllHomeworksByClassId() { ClassId = id });
        }
        [HttpGet]
        public async Task<Homework> GetHomeworkByLessonId(Guid id)
        {
            return await _mediatr.Send(new GetHomeworkByLesson() { LessonId = id });
        }
        [HttpPost]
        public async Task<ResponseModel> CreateHomework(CreateHomeworkCommand command)
        {
            return await _mediatr.Send(command);
        }
        [HttpPut]
        public async Task<ResponseModel> UpdateHomework(UpdateHomeworkCommand command)
        {
            return await _mediatr.Send(command);
        }
        [HttpDelete]
        public async Task<ResponseModel> DeleteHomework(Guid id)
        {
            return await _mediatr.Send(new DeleteHomework() { HomeworkId = id });
        }
    }
}
