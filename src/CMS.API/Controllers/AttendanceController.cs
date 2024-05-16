using CMS.Application.UseCases.AttendaceCases.Commands;
using CMS.Application.UseCases.AttendaceCases.Queries;
using CMS.Domain.Entities;
using CMS.Domain.Entities.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CMS.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AttendanceController : ControllerBase
    {
        private readonly IMediator _mediatr;
        public AttendanceController(IMediator mediator)
        {
            _mediatr = mediator;
        }
        [HttpGet]
        public async Task<IEnumerable<Attendance>> GetAllAttendance(Guid id)
        {
            return await _mediatr.Send(new GetAllAttandeceByLesson() { lessonId = id });
        }
        [HttpPost]
        public async Task<ResponseModel> CreateAttendace(CreateAttendanceCommand command)
        {
            return await _mediatr.Send(command);
        }
    }
}
