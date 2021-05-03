using ABAPAI.Domain.Entities;
using ABAPAI.Domain.Enums;
using ABAPAI.Domain.Interfaces.Repositories;
using ABAPAI.Domain.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABAPAI.Tests.Repositories
{
    public class FakeStaffRepository : IStaffRepository
    {


        private List<Staff> _staffs;

        public FakeStaffRepository()
        {
            _staffs = new List<Staff>();
            _staffs.Add(new Staff("abner_math", "name", "abnerm80@gmail.com", "abner123".GetHash(), Roles.STAFF, "09025325864", null, null, false));
            _staffs.Add(new Staff("abner_matheus", "name2", "abnerm10@gmail.com", "abner123".GetHash(), Roles.STAFF, "09025725861", null, null, false));
            _staffs.Add(new Staff("jhonatan_med", "name", "jhonatan_med@gmail.com", "jhonatan123".GetHash(), Roles.STAFF, "09022325164", null, null, false));
            _staffs.Add(new Staff("jhonatan_medeiros", "name", "jhonatan_medeiros@gmail.com", "abner123".GetHash(), Roles.STAFF, "09021325861", null, null, false));
        }

        public void Create(Staff staff)
        {
            
        }

        public bool ExistName_user(string name_user, string email, string cpf_cnpj)
        {
            return false;
        }

        public bool ExistName_user(string name_user)
        {
            return _staffs.Any(x => x.Name_user == name_user);
        }

        public Staff FindStaff(string email, string password)
        {
            return _staffs.Where(x => x.Email == email && x.Password == password).FirstOrDefault();            
        }
    }
}
