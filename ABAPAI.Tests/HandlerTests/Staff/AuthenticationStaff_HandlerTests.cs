using ABAPAI.Domain.Entities;
using ABAPAI.Domain.Enums;
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
    public class AuthenticationStaff_HandlerTests
    {
        private readonly StaffHandler _staffHandler = new StaffHandler(new FakeStaffRepository());
        private readonly Staff staff = new Staff("abner_math", "name", "abnerm80@gmail.com", "abner123", Roles.STAFF, "09025325864", null, null, false);

        [TestMethod]
        public void Dado_um_email_e_senha_de_um_usuario_valido_retornar_token()
        {
            var staff = new Staff("abner_math", "name", "abnerm80@gmail.com", "abner123", Roles.STAFF, "09025325864", null, null, false);
        }
    }
}
