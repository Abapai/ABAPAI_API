using ABAPAI.Domain.Commands;
using ABAPAI.Domain.Commands.Staff;
using ABAPAI.Domain.Handlers;
using ABAPAI.Tests.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace ABAPAI.Tests.HandlerTests.Staff
{

    [TestClass]
    public class CreateStaffHandlerTests
    {
        private readonly StaffHandler _staffHandler = new StaffHandler(new FakeStaffRepository());
        private readonly CreateStaffCommand _createStaffCommand_invalid = new CreateStaffCommand("abnerm80@gmail.com", "abner_math", "abner matheus", "senha", "senhasenha", "09025225663");
        private readonly CreateStaffCommand _createStaffCommand_valid = new CreateStaffCommand("abnerm80@gmail.com", "abner_math", "abner matheus", "senha", "senha", "090.253.256-63");
        private GenericCommandResult _result;

        [TestMethod]
        public void dado_um_staff_invalido_deve_interroper_execucao()
        {
            _result = (GenericCommandResult)_staffHandler.Handle(_createStaffCommand_invalid);
            Assert.AreEqual(_result.Success, false);        
        }

        [TestMethod]
        public void dado_um_staff_valido_deve_cadastrar()
        {
            _result = (GenericCommandResult)_staffHandler.Handle(_createStaffCommand_valid);
            Assert.AreEqual(_result.Success, true);
        }
    }
}
