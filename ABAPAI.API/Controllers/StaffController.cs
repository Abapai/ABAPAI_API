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
            [FromBody] CreateStaff_CPF_Command command,
            [FromServices] StaffHandler staffHandler)
        {
            var result = (GenericCommandResult)staffHandler.Handle(command);
            if (result.Success)
            {
                return Created("", result);
            }

            return BadRequest(result);
        }

        [HttpPost]
        [Route("cnpj")]
        public ActionResult<GenericCommandResult> Create_staff_CNPJ(
            [FromBody] CreateStaff_CNPJ_Command command,
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
        [Route("upload")]
        public async Task<ActionResult<string>> Upload([FromBody] UploadImageCommand command, [FromServices] IFileUpload fileUpload)
        {
            var uploadService = await fileUpload.UploadBase64ImageAsync(command.Image);
            return uploadService;
        }


        [HttpDelete]
        [Route("upload")]
        public async Task<ActionResult<bool>> Delete([FromBody] UploadImageCommand command, [FromServices] IFileUpload fileUpload)
        {
            fileUpload.UpdateImageAsync(command.Image, "b8a52708-3a14-4a79-bace-267f015ca92a.jpg");
            return true;
        }




        #endregion


        [Route("online")]
        [Authorize(Policy = "JWT_STAFF", Roles = "STAFF")]
        public string Get()
        {
            return "Here";
        }
    }

    public class UploadImageCommand
    {
        public string Image { get; set; }
    }
}
