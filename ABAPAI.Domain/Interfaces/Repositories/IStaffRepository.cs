using ABAPAI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ABAPAI.Domain.Interfaces.Repositories
{
    public interface IStaffRepository
    {
        void Create(Staff staff);

        bool ExistName_user(string name_user);

        Staff FindStaff(string email, string password);
    }
}
