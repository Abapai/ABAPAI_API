using ABAPAI.Domain.Commands;
using ABAPAI.Domain.Commands.Staff;
using ABAPAI.Domain.Handlers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ABAPAI.API.Controllers
{
    [Route("v1/staff")]
    [ApiController]
    public class StaffController : ControllerBase
    {
        
        [HttpPost]
        public async Task<ActionResult<GenericCommandResult>> Create_staff_CPF(
            [FromBody]CreateStaff_CPF_Command command,
            [FromServices] StaffHandler staffHandler)
        {
            var result = (GenericCommandResult) staffHandler.Handle(command);
            return Ok(result);
        }

        public string  Get()
          
        {
            return "Here";
        }
    }
}
