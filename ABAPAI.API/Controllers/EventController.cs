using ABAPAI.Domain.Commands;
using ABAPAI.Domain.Commands.Event;
using ABAPAI.Domain.DTO;
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
        [Route("listAdmin")]
        [Authorize]
        public  ActionResult<List<DTOEventListSimple>> ListAdminEvent([FromServices] IEventRepository eventRepository)
        {
            var id_staff = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;

            var eventList = eventRepository.GetAllEvents(id_staff).OrderBy(x=>x.DateTimeStart).ToList();
            var list = new List<DTOEventListSimple>();
            eventList.ForEach(x =>
            {
                list.Add(new DTOEventListSimple(x.Id,x.Image, x.Title));
            });

            return Ok(list);         
        }
        #endregion

        [Route("")]
        [HttpPut]
        public GenericCommandResult Update(
            [FromBody] UpdateEventCommand command,
            [FromServices] Event_Handler handler
        )
        {
            command.User = "testeUser";
            return (GenericCommandResult)handler.Handle(command);
        }

    }
}
