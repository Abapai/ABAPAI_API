using ABAPAI.Domain.Entities;
using ABAPAI.Domain.Interfaces.Repositories;
using ABAPAI.Infra.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace ABAPAI.Infra.Repositories
{
    public class StaffRepository : IStaffRepository
    {
        private readonly DataContext _dataContext;

        public StaffRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public void Create(Staff staff)
        {
            var id = _dataContext.Staff.Add(staff);
            _dataContext.SaveChanges();
        }

        public IEnumerable<string> ExistName_user(string name_user, string email, string cpf_cnpj)
        {
            var staff = _dataContext.Staff.AsNoTracking().FirstOrDefault(x => x.Name_user == name_user || x.CPF == cpf_cnpj || x.CNPJ == cpf_cnpj || x.Email == email);
            if (staff is not null)
            {
                var labels = new List<string>();
                if (staff.Name_user == name_user)
                {
                    labels.Add("name_user");
                }
                if (staff.Email == email)
                {
                    labels.Add("email");
                }
                if (staff.CPF == cpf_cnpj)
                {
                    labels.Add("CPF");
                }
                if (staff.CNPJ == cpf_cnpj)
                {
                    labels.Add("CNPJ");
                }

                return labels.AsEnumerable();
            }
            return null;

        }

        public bool ExistName_user(string name_user)
        {
            return _dataContext.Staff.Any(x => x.Name_user == name_user);
        }

        public bool ExistName_userById(string id, string name_user)
        {
            return _dataContext.Staff.Any(x => x.Id.ToString() != id && x.Name_user == name_user);
        }

        public Staff FindStaff(string email, string password)
        {
            return _dataContext.Staff.Where(x => x.Email == email && x.Password == password).FirstOrDefault();
        }

        public Staff GetById(string id)
        {
            return _dataContext
                .Staff.Include(x => x.Address)
                .FirstOrDefault(x => x.Id.ToString() == id);
        }

        public void Update(Staff staff)
        {

            _dataContext.Entry(staff).State = EntityState.Modified;
            _dataContext.SaveChanges();


        }
    }
}
