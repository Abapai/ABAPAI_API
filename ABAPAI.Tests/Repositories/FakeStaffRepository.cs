using ABAPAI.Domain.Entities;
using ABAPAI.Domain.Enums;
using ABAPAI.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ABAPAI.Tests.Repositories
{
    public class FakeStaffRepository : IStaffRepository
    {

        public void Create(Staff staff)
        {
            
        }

        public bool ExistName_user(string name_user, string email, string cpf_cnpj)
        {
            return false;
        }

        public bool ExistName_user(string name_user)
        {
            return false;
        }

        public Staff FindStaff(string email, string password)
        {
            return new Staff("abner_math", "name", "abnerm80@gmail.com", "abner123", Roles.STAFF, "09025325864", null, null, false);
        }
    }
}
