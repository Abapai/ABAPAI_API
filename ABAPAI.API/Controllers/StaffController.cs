using ABAPAI.Domain.Commands;
using ABAPAI.Domain.Commands.Staff;
using ABAPAI.Domain.DTO;
using ABAPAI.Domain.Handlers;
using ABAPAI.Domain.Interfaces.Repositories;
using ABAPAI.Domain.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ABAPAI.API.Controllers
{
    [Route("v1/staff")]
    [ApiController]
    public class StaffController : ControllerBase
    {

        #region GET
        
        [HttpGet]
        [Authorize(Policy = "JWT_STAFF", Roles = "STAFF")]
        public ActionResult<DTOStaff_Profile> GetStaff([FromServices] IStaffRepository staffRepository)
        {
            var id_staff= User.Claims.FirstOrDefault(x=> x.Type == ClaimTypes.NameIdentifier)?.Value;
            var staff = staffRepository.GetById(id_staff);
            return new DTOStaff_Profile
            {
                name = staff.Name,
                email = staff.Email,
                name_user = staff.Name_user,
                description = staff.Description,
                image = staff.Image.ConvertAddressImageToURLAzureBlob(),
                cpf = staff.CPF,
                cnpj = staff.CNPJ,
                stateRegistration = staff.StateRegistration,
                free = (bool)staff.Free,                
                ddd = staff.DDD,
                phone = staff.Phone,
                address = staff.Address?.Address,
                city = staff.Address?.City,
                state = staff.Address?.State,
                number = staff.Address?.Number,
                postal_code = staff.Address?.Postal_code
            };
            
        }

        [Route("name_user/{name_user}")]
        [AllowAnonymous]
        [Authorize]

        public ActionResult<bool> ExistName_user(string name_user, [FromServices] IStaffRepository staffRepository)
        {
            var idUser = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;
            if (idUser is null)
            {
                return Ok(!staffRepository.ExistName_user(name_user));
            }            
            return Ok(!staffRepository.ExistName_userById(idUser, name_user));
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

        #region PUT
        [HttpPut]
        [Authorize(Policy = "JWT_STAFF", Roles = "STAFF")]
        public async Task<ActionResult<GenericCommandResult>>PutStaff([FromBody]UpdateStaffCommand updateStaffCommand,[FromServices] StaffHandler staffHandler)
        {
            var id_staff = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;
            updateStaffCommand.UpdateId(id_staff);
            var result = (GenericCommandResult) await staffHandler.Handle(updateStaffCommand);
            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
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
