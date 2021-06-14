using ABAPAI.Domain.Commands;
using ABAPAI.Domain.Commands.Event;
using ABAPAI.Domain.DTO;
using ABAPAI.Domain.Enums;
using ABAPAI.Domain.Handlers;
using ABAPAI.Domain.Interfaces.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ABAPAI.API.Controllers
{

    [Route("v1/event")]
    [ApiController]
    public class EventController : ControllerBase
    {

        #region POST
        [HttpPost]        
        [Authorize(Policy = "JWT_STAFF", Roles = "STAFF")]
        public async Task<ActionResult<GenericCommandResult>> CreateEvent([FromBody] CreateEventCommand command, [FromServices] Event_Handler eventHandler)
        {
            var id_staff = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;
            command.UpdateId(id_staff);
            var result = (GenericCommandResult)await eventHandler.Handle(command);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
        #endregion

        #region GET
        [HttpGet]
        [Route("listAdmin/{page}/{limit}")]
        [Authorize]
        public  ActionResult<List<DTOPaginationEventListAdmin>> ListAdminEvent([FromServices] IEventRepository eventRepository,int page,int limit,int? category)
        {
            var id_staff = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;
            var count = eventRepository.CountByEvent(id_staff,category);
            var eventList = eventRepository.GetAllEvents(id_staff).OrderBy(x=>x.DateTimeStart).Where(x => x.EventCategory == (category.HasValue?(EventCategory)category:x.EventCategory) ).Skip((page - 1) * limit).Take(limit).ToList();
            var list = new List<DTOEventListSimple>();
            eventList.ForEach(x =>
            {
                list.Add(new DTOEventListSimple(x.Id,x.Image, x.Title,x.EventCategory,x.DateTimeStart,x.ValueEvent,x.PublicLimit,x.Quantity.GetValueOrDefault(),10));
            });

            var obj = new DTOPaginationEventListAdmin(count,limit,list);

            return Ok(obj);         
        }
        #endregion

    }
}
