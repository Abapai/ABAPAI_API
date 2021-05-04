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
    public class UpdateStaff_HandlerTests
    {
        private readonly UpdateStaffCommand _validCommand = new UpdateStaffCommand("abner", "abner_math", "usuario de teste", "41", "999999999", "abner@gmail.com", "senhadoabner");
        private readonly UpdateStaffCommand _invalidCommand = new UpdateStaffCommand("abner", "abner_math", "usuario de teste", "41", "999999999", "abner@gmail.com", "senhadoabner");
        private readonly StaffHandler _staffHandler = new StaffHandler(new FakeStaffRepository());
        private GenericCommandResult _result = new GenericCommandResult();
        private readonly AuthenticationStaffCommand _userValid = new AuthenticationStaffCommand("abnerm80@gmail.com", "abner123");

        [TestMethod]
        public void Dado_um_id_invalido_parar_a_execucao()
        {
            var _fakeRepository = new FakeStaffRepository();
            var fakeStaff = _fakeRepository.FindStaff("abnerm80@gmail.com", "abner123");
            //var fakeStaffTest = _fakeRepository.FindStaff("jhonatan_med@gmail.com", "jhonatan123");
            fakeStaff.UpdateStaff(fakeStaff.);
            //_result = (GenericCommandResult)_staffHandler.Handle(fakeStaff);
            Assert.AreEqual(_result.Success, false);
        }

        [TestMethod]
        public void Dado_um_id_valido_deve_atualizar_o_staff()
        {
            _result = (GenericCommandResult)_staffHandler.Handle(_validCommand);
            Assert.AreEqual(_result.Success, true);
        }

    }
}
