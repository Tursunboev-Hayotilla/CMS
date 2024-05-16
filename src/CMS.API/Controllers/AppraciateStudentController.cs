using CMS.Application.UseCases.StundentAppraciateCases.Commands;
using CMS.Domain.Entities.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CMS.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AppraciateStudentController : ControllerBase
    {
        private readonly IMediator _mediatr;
        public AppraciateStudentController(IMediator mediator)
        {
            _mediatr = mediator;
        }
        [HttpPost]
        public async Task<ResponseModel> AppraciateStudent(AppraciateStudentCommand command)
        {
            return await _mediatr.Send(command);
        }
        [HttpPut]
        public async Task<ResponseModel> UpdateApprasiation(UpdateStudentAppraciateCommand command)
        {
            return await _mediatr.Send(command);
        }
    }
}
