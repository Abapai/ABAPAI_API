using ABAPAI.Domain.Commands;
using ABAPAI.Domain.Commands.Ticket;
using ABAPAI.Domain.Handlers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ABAPAI.API.Controllers
{

    [Route("v1/ticket")]
    [ApiController]
    public class TicketController :ControllerBase
    {
        #region POST 

        [HttpPost]
        [AllowAnonymous]
        [Route("{id_event}")]
        public async Task<ActionResult<GenericCommandResult>> CreateEvent([FromBody] CreateTicketCommand command, [FromServices] TicketHandler ticketHandler,string id_event)
        {
            
            command.updateIdEvent(id_event);
            var result = (GenericCommandResult)await ticketHandler.Handle(command);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
        #endregion
    }
}
