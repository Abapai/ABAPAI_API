using ABAPAI.Domain.Entities;
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

        public bool ExistName_user(string name_user)
        {
            return false;
        }

        public Staff FindStaff(string email, string password)
        {
            
        }
    }
}
