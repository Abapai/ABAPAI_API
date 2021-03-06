using ABAPAI.Domain.Commands;
using ABAPAI.Domain.Commands.Staff;
using ABAPAI.Domain.Entities;
using ABAPAI.Domain.Enums;
using ABAPAI.Domain.Handlers;
using ABAPAI.Tests.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ABAPAI.Tests.HandlerTests
{
    [TestClass]
    public class AuthenticationStaff_HandlerTests
    {
        private readonly StaffHandler _staffHandler = new StaffHandler(new FakeStaffRepository(), new FakeFileUploadRepository());
        private readonly Staff staff_valid = new Staff("abner_math", "name", "abnerm80@gmail.com", "abner123", Roles.STAFF, "09025325864", null, null, false);
        private readonly Staff staff_invalid = new Staff("abner_matheus", "name", "abnerm80@gmail.com", "errado", Roles.STAFF, "09025325864", null, null, false);



        [TestMethod]
        public void Dado_um_email_e_senha_de_um_staff_valido_retornar_token_valido()
        {
            var result = (GenericCommandResult)_staffHandler.Handle(new AuthenticationStaffCommand(staff_valid.Email, staff_valid.Password)).Result;
            Assert.AreEqual(true, result.Success);
            /*var response_body = JsonConvert.DeserializeObject<User>(result.Data.ToString());
            var jwt = new JwtSecurityTokenHandler().ReadJwtToken(response_body.id);
            Assert.AreEqual(Roles.STAFF.ToString(), jwt.Claims.Where(x => x.Type == "role").Select(x => x.Value).FirstOrDefault());*/
        }


        [TestMethod]
        public void Dado_um_email_e_senha_de_um_staff_invalido_retornar_false()
        {
            var result = (GenericCommandResult)_staffHandler.Handle(new AuthenticationStaffCommand(staff_invalid.Email, staff_invalid.Password)).Result;
            Assert.AreEqual(false, result.Success);

        }
    }
}
