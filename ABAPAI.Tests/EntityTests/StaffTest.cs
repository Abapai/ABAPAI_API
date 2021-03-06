using ABAPAI.Domain.Entities;
using ABAPAI.Domain.Enums;
using ABAPAI.Domain.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ABAPAI.Tests.EntityTests
{
    [TestClass]
    public class StaffTest
    {

        private readonly Staff staff = new Staff("abner_math", "name", "abnerm80@gmail.com", "abner123", Roles.STAFF, "09025325864", null, null, false);

        [TestMethod]
        public void Ao_gerar_um_staff_valido_quando_executar_metodo_hashPassword_deve_gerar_um_hash()
        {
            var password = staff.Password;
            staff.hashPassword();
            Assert.AreEqual(password.GetHash(), staff.Password);

        }
    }
}
