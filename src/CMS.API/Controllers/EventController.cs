using CMS.Application.UseCases.EventCases.Commands;
using CMS.Application.UseCases.EventCases.Queries;
using CMS.Domain.Entities;
using CMS.Domain.Entities.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CMS.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private readonly IMediator _mediator;
        public EventController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IEnumerable<Event>> GetAllEvents()
        {
            return await _mediator.Send(new GetAllEventQuery() { } );
        }
        [HttpGet]
        public async Task<Event> GetEventById(Guid id)
        {
            return await _mediator.Send(new GetByIdEventQuery() { Id = id });
        }
        [HttpGet]
        public async Task<Event> GetEventByDate(int day,int month)
        {
            return await _mediator.Send(new GetEventByDateQuery() { Day = day, Month = month });
        }

        [HttpPost]
        public async Task<ResponseModel> CreateEvent(CreateEventCommand command)
        {
            return await _mediator.Send(command);
        }
        [HttpPut]
        public async Task<ResponseModel> UpdateEvent(UpdateEventCommand command)
        {
            return await _mediator.Send(command);
        }
        [HttpDelete]
        public async Task<ResponseModel> DeleteEvent(Guid id)
        {
            return await _mediator.Send(new DeleteEventCommand() { EventId = id });
        }
    }
}
