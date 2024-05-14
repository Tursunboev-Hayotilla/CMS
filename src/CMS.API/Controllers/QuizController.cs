using CMS.Application.UseCases.QuizCases.Commands;
using CMS.Application.UseCases.QuizCases.Queries;
using CMS.Domain.Entities;
using CMS.Domain.Entities.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CMS.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class QuizController : ControllerBase
    {
        private readonly IMediator _mediator;
        public QuizController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IEnumerable<Quiz>> GetAllQuizes()
        {
            return await _mediator.Send(new GetAllQuizQuery());
        }
        [HttpGet]
        public async Task<Quiz> GetQUizById(Guid id)
        {
            return await _mediator.Send(new GetQuizByIdQuery { Id = id });
        }
        [HttpGet]
        public async Task<Quiz> GetQuizByLessonId(Guid id)
        {
            return await _mediator.Send(new GetQuizByLessonIdQuery() { LessonId = id });
        }
        [HttpPost]
        public async Task<ResponseModel> CreateQuiz([FromForm] CreateQuizCommand command)
        {
            return await _mediator.Send(command);
        }

        [HttpPut]
        public async Task<ResponseModel> UpdateQuiz([FromForm] UpdateQuizCommand command)
        {
            return await _mediator.Send(command);
        }
        [HttpDelete]
        public async Task<ResponseModel> DeleteQuiz(Guid id)
        {
            return await _mediator.Send(new DeleteQuizCommand() { Id = id });
        }
    }
}
