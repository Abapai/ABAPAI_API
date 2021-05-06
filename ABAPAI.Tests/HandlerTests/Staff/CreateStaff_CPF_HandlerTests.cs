using ABAPAI.Domain.Commands;
using ABAPAI.Domain.Commands.Staff;
using ABAPAI.Domain.Handlers;
using ABAPAI.Tests.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ABAPAI.Tests.HandlerTests
{

    [TestClass]
    public class CreateStaff_CPF_HandlerTests
    {
        private readonly StaffHandler _staffHandler = new StaffHandler(new FakeStaffRepository(), new FakeFileUploadRepository());
        private readonly CreateStaff_CPF_Command _createStaffCommand_invalid = new CreateStaff_CPF_Command("abnerm80@gmail.com", "abner_math", "abner matheus", "senha", "senhasenha", "09025225663");
        private readonly CreateStaff_CPF_Command _createStaffCommand_valid = new CreateStaff_CPF_Command("abnerm80@gmail.com", "abner_math", "abner matheus", "senha", "senha", "090.253.256-63");
        private GenericCommandResult _result;

        [TestMethod]
        public void dado_um_staff_invalido_deve_interroper_execucao()
        {
            _result = (GenericCommandResult) _staffHandler.Handle(_createStaffCommand_invalid).Result;
            Assert.AreEqual(_result.Success, false);
        }

        [TestMethod]
        public void dado_um_staff_valido_deve_cadastrar()
        {
            _result = (GenericCommandResult) _staffHandler.Handle(_createStaffCommand_valid).Result;
            Assert.AreEqual(_result.Success, true);
        }
    }
}
