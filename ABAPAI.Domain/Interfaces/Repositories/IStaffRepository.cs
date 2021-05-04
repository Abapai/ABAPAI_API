using ABAPAI.Domain.Entities;

namespace ABAPAI.Domain.Interfaces.Repositories
{
    public interface IStaffRepository
    {
        void Create(Staff staff);

        bool ExistName_user(string name_user, string email, string cpf_cnpj);

        bool ExistName_user(string name_user);

        Staff FindStaff(string email, string password);

        void Update(Staff staff);

        Staff GetById(string id);

        bool ExistName_userById(string id, string name_user);
    }
}
