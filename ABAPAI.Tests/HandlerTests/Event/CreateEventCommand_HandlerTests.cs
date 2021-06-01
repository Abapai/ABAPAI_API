using ABAPAI.Domain.Commands;
using ABAPAI.Domain.Commands.Event;
using ABAPAI.Domain.Handlers;
using ABAPAI.Domain.Utils;
using ABAPAI.Tests.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ABAPAI.Tests.HandlerTests.Event
{
    [TestClass]
    public class CreateEventCommand_HandlerTests
    {
        private Event_Handler _event_Handler = new Event_Handler(new FakeFileUploadRepository(), new FakeEventRepository());
        private readonly CreateEventCommand _createEventCommand_valid
            = new CreateEventCommand("data:image/jpeg;base64,/9j/4AAQSkZJRgABAgAAAQABAAD/7QB8UGhvdG9zaG9wIDMuMAA4QklNBAQAAAAAAF8cAigAWkZCT", "title", "descrição minha", DateTime.Now.AddDays(3), DateTime.Now.AddDays(6), 1, 1, true, 100,10, 41, "991238262", "instagram", "www.");


        private readonly CreateEventCommand _createEventCommand_invalid
           = new CreateEventCommand("data:image/jpeg;base64,/9j/4AAQSkZJRgABAgAAAQABAAD/7QB8UGhvdG9zaG9wIDMuMAA4QklNBAQAAAAAAF8cAigAWkZCT", "title", "descrição minha", DateTime.Now.AddDays(3), DateTime.Now.AddDays(6), 1, 1, true, 0,10, 41, "991238262", "instagram", "www.");

        private readonly FakeStaffRepository _fakeStaffRepository = new FakeStaffRepository();
        const string email = "abnerm80@gmail.com";
        string password = "abner123".GetHash();


        [TestMethod]
        public void Dado_um_evento_valido_entao_criar_evento()
        {
            var fakeStaff = _fakeStaffRepository.FindStaff(email, password);
            _createEventCommand_valid.UpdateId(fakeStaff.Id.ToString());
            var result = (GenericCommandResult)_event_Handler.Handle(_createEventCommand_valid).Result;
            Assert.AreEqual(true, result.Success);
        }


        [TestMethod]
        public void Dado_um_evento_invalido_entao_nao_criar_evento()
        {
            var fakeStaff = _fakeStaffRepository.FindStaff(email, password);
            _createEventCommand_invalid.UpdateId(fakeStaff.Id.ToString());
            var result = (GenericCommandResult)_event_Handler.Handle(_createEventCommand_invalid).Result;
            Assert.AreEqual(false, result.Success);
        }

    }
}
