using ABAPAI.Domain.Commands;
using ABAPAI.Domain.Commands.Staff;
using ABAPAI.Domain.Handlers;
using ABAPAI.Domain.Interfaces.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ABAPAI.API.Controllers
{
    [Route("v1/staff")]
    [ApiController]
    public class StaffController : ControllerBase
    {

        #region GET
        [Route("name_user/{name_user}")]

        public ActionResult<bool> ExistName_user(string name_user, [FromServices] IStaffRepository staffRepository)
        {
            return Ok(!staffRepository.ExistName_user(name_user));
        }

        #endregion

        #region POST

        [HttpPost]
        [Route("login")]
        public async Task<ActionResult<GenericCommandResult>> Authentication(
            [FromBody] AuthenticationStaffCommand command,
            [FromServices] StaffHandler staffHandler)
        {
            var result = (GenericCommandResult) await staffHandler.Handle(command);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost]
        [Route("cpf")]
        public async Task<ActionResult<GenericCommandResult>> Create_staff_CPF(
            [FromBody] CreateStaff_CPF_Command command,
            [FromServices] StaffHandler staffHandler)
        {
            var result = (GenericCommandResult) await staffHandler.Handle(command);
            if (result.Success)
            {
                return Created("", result);
            }

            return BadRequest(result);
        }

        [HttpPost]
        [Route("cnpj")]
        public async Task<ActionResult<GenericCommandResult>> Create_staff_CNPJ(
            [FromBody] CreateStaff_CNPJ_Command command,
            [FromServices] StaffHandler staffHandler)
        {
            var result = (GenericCommandResult) await staffHandler.Handle(command);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);

        }

        #endregion


        [Route("online")]
        [Authorize(Policy = "JWT_STAFF", Roles = "STAFF")]
        public string Get()
        {
            return "Here";
        }
    }

}
