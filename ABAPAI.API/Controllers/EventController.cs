using ABAPAI.Domain.Commands;
using ABAPAI.Domain.Commands.Event;
using ABAPAI.Domain.Handlers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ABAPAI.API.Controllers
{

    [Route("v1/event")]
    [ApiController]
    public class EventController : ControllerBase
    {
        [HttpPost]
        [AllowAnonymous]
        [Authorize]
        public async Task<ActionResult<GenericCommandResult>> CreateEvent([FromBody] CreateEventCommand command, [FromServices] Event_Handler eventHandler)
        {

            var result = (GenericCommandResult)await eventHandler.Handle(command);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
    }
}
