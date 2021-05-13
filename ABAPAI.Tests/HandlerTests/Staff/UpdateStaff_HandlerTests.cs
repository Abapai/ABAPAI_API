using ABAPAI.Domain.Commands;
using ABAPAI.Domain.Commands.Staff;
using ABAPAI.Domain.Handlers;
using ABAPAI.Domain.Utils;
using ABAPAI.Tests.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace ABAPAI.Tests.HandlerTests
{
    [TestClass]
    public class UpdateStaff_HandlerTests
    {
        public static FakeStaffRepository _fakeStaffRepository = new FakeStaffRepository();        
        private readonly StaffHandler _staffHandler = new StaffHandler(_fakeStaffRepository, new FakeFileUploadRepository());
        private GenericCommandResult _result = new GenericCommandResult();
        private readonly AuthenticationStaffCommand _userValid = new AuthenticationStaffCommand("abnerm80@gmail.com", "abner123");

        [TestMethod]
        public void Dado_um_name_user_invalido_parar_a_execucao()
        {
            
            var fakeStaff = _fakeStaffRepository.FindStaff("abnerm80@gmail.com", "abner123".GetHash());           
            
            UpdateStaffCommand updateStaffCommand = new UpdateStaffCommand(
               fakeStaff.Name,
               "jhonatan_med",
               fakeStaff.Description,
               fakeStaff.DDD,
               fakeStaff.Phone,
               fakeStaff.Address.Address,
               fakeStaff.Address.City,
               fakeStaff.Address.Postal_code,
               fakeStaff.Address.State,
               fakeStaff.Address.Number
                );
            updateStaffCommand.UpdateId(fakeStaff.Id.ToString());

            _result = (GenericCommandResult) _staffHandler.Handle(updateStaffCommand).Result;
            
            Assert.AreEqual(_result.Success, false);
        }

        [TestMethod]
        public void Dado_um_valido_deve_atualizar_o_staff()
        {
            const string email = "abnerm80@gmail.com";
            string password = "abner123".GetHash();
            var fakeStaff = _fakeStaffRepository.FindStaff(email,password);

            UpdateStaffCommand updateStaffCommand = new UpdateStaffCommand(
               fakeStaff.Name,
               "abner_math2021",
               fakeStaff.Description,
               "41",
               "991238262",
               fakeStaff.Address.Address,
               fakeStaff.Address.City,
               fakeStaff.Address.Postal_code,
               fakeStaff.Address.State,
               fakeStaff.Address.Number
                );

            updateStaffCommand.UpdateId(fakeStaff.Id.ToString());

            _result = (GenericCommandResult) _staffHandler.Handle(updateStaffCommand).Result;

            var fakeStaffUpdated = _fakeStaffRepository.FindStaff(email, password);
            Assert.AreEqual(_result.Success, true);
            Assert.AreEqual(fakeStaffUpdated.Phone, updateStaffCommand.Phone);
            Assert.AreEqual(fakeStaffUpdated.DDD, updateStaffCommand.DDD);
        }

    }
}
