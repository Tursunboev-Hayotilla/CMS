using CMS.Application.UseCases.LessonCases.Commands;
using CMS.Application.UseCases.LessonCases.Queries;
using CMS.Domain.Entities;
using CMS.Domain.Entities.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CMS.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class LessonController : ControllerBase
    {
        private readonly IMediator _mediatr;
        public LessonController(IMediator mediator)
        {
            _mediatr = mediator;
        }

        [HttpGet]
        public async Task<IEnumerable<Lesson>> GetAllLessons()
        {
            return await _mediatr.Send(new GetAllLessonQuery());
        }
        [HttpGet]
        public async Task<IEnumerable<Lesson>> GetAllLessonsByClassId(Guid Id)
        {
            return await _mediatr.Send(new GetAllLessonByClassId() { classId = Id });
        }
        [HttpGet]

        public async Task<IEnumerable<Lesson>> GetAllTeachers(string id)
        {
            return await _mediatr.Send(new GetAllLessonsByTeacherId() { teacherId = id });
        }
        [HttpGet]
        public async Task<Lesson> GetLessonById(Guid id)
        {
            return await _mediatr.Send(new GetLessonByIdQuery() { Id = id });
        }
        [HttpPost]
        public async Task<ResponseModel> CreateLesson(CreateLessonCommand command)
        {
            return await _mediatr.Send(command);
        }
        [HttpPut]
        public async Task<ResponseModel> UpdateLesson(UpdateLessonCommand command)
        {
            return await _mediatr.Send(command);
        }
        [HttpDelete]
        public async Task<ResponseModel> DelereLesson(Guid id)
        {
            return await _mediatr.Send(new DeleteLessonCommand() { lessonId = id });
        }
    }
}
