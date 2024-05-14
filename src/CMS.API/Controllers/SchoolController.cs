using CMS.Application.UseCases.SchoolCases.Handlers.QueryHandlers;
using CMS.Application.UseCases.SchoolCases.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CMS.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class SchoolController : ControllerBase
    {
        private readonly IMediator _mediator;
        public SchoolController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<int> GetAllStudents()
        {
            return await _mediator.Send(new GetAllSchoolsStudentsQuery() { });
        }
        [HttpGet]
        public async Task<int> GetAllStuff()
        {
            return await _mediator.Send(new GetAllSchoolEmployees() { });
        }
    }
}
