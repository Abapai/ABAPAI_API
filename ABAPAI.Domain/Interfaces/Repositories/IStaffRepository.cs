using ABAPAI.Domain.Entities;
using System.Collections.Generic;

namespace ABAPAI.Domain.Interfaces.Repositories
{
    public interface IStaffRepository
    {
        void Create(Staff staff);

        IEnumerable<string> ExistName_user(string name_user, string email, string cpf_cnpj);

        bool ExistName_user(string name_user);

        Staff FindStaff(string email, string password);

        void Update(Staff staff);

        Staff GetById(string id);

        bool ExistName_userById(string id, string name_user);
    }
}
