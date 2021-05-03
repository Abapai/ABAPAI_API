using ABAPAI.Domain.Commands;
using ABAPAI.Domain.Commands.Staff;
using ABAPAI.Domain.Enums;
using ABAPAI.Domain.Handlers;
using ABAPAI.Domain.Interfaces.Repositories;
using ABAPAI.Domain.Utils;
using Microsoft.AspNetCore.Authorization;
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
        
        #region GET
        [Route("name_user/{name_user}")]
        
        public ActionResult<bool> ExistName_user(string name_user,[FromServices] IStaffRepository staffRepository)
        {            
            return Ok(!staffRepository.ExistName_user(name_user));
        }

        #endregion

        #region POST

        [HttpPost]
        [Route("login")]
        public ActionResult<GenericCommandResult> Authentication(
            [FromBody] AuthenticationStaffCommand command,
            [FromServices] StaffHandler staffHandler)
        {
            var result = (GenericCommandResult)staffHandler.Handle(command);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost]
        [Route("cpf")]
        public ActionResult<GenericCommandResult> Create_staff_CPF(
            [FromBody]CreateStaff_CPF_Command command,
            [FromServices] StaffHandler staffHandler)
        {
            var result = (GenericCommandResult) staffHandler.Handle(command);
            if (result.Success)
            {
                return Created("",result);
            }

            return BadRequest(result);
        }

        [HttpPost]
        [Route("cnpj")]
        public ActionResult<GenericCommandResult> Create_staff_CNPJ(
            [FromBody] CreateStaff_CNPJ_Command command,
            [FromServices] StaffHandler staffHandler)
        {
            var result = (GenericCommandResult) staffHandler.Handle(command);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
           
        }

        #endregion


        [Route("online")]
        [Authorize(Policy = "JWT_STAFF", Roles = "STAFF")]
        public string  Get()          
        {
            return "Here";
        }
    }
}
