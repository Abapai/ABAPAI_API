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
    public class CreateStaff_CNPJ_HandlerTests 
    {

        private readonly StaffHandler _staffHandler = new StaffHandler(new FakeStaffRepository());
        private readonly CreateStaff_CNPJ_Command _createStaffCommand_invalid = new CreateStaff_CNPJ_Command(
            "abnerm80@gmail.com",
            "abner_math",
            "abner matheus",
            "senha",
            "senha",
            "104.239.797/0118-46",
            null,
            false
            );
        private readonly CreateStaff_CNPJ_Command _createStaffCommand_invalid2 = new CreateStaff_CNPJ_Command(
            "abnerm80@gmail.com",
            "abner_math",
            "abner matheus",
            "senha",
            "senha",
            "104.239.797/0118-46",
            111,
            true
            );
        private readonly CreateStaff_CNPJ_Command _createStaffCommand_valid = new CreateStaff_CNPJ_Command(
            "abnerm80@gmail.com",
            "abner_math",
            "abner matheus",
            "senha",
            "senha",
            "04.239.797/0118-46",
            null,
            true
            );
        private GenericCommandResult _result;

        [TestMethod]
        public void dado_um_staff_invalido_deve_interroper_execucao()
        {
            _result = (GenericCommandResult)_staffHandler.Handle(_createStaffCommand_invalid);
            Assert.AreEqual(_result.Success, false);
            _result = (GenericCommandResult)_staffHandler.Handle(_createStaffCommand_invalid2);
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
