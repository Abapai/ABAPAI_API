using ABAPAI.Domain.Entities;
using ABAPAI.Domain.Interfaces.Repositories;
using ABAPAI.Infra.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ABAPAI.Infra.Repositories
{
    public class StaffRepository : IStaffRepository
    {
        private readonly DataContext _dataContext;

        public StaffRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async void Create(Staff staff)
        {
            var id = await _dataContext.Staff.AddAsync(staff);
            await _dataContext.SaveChangesAsync();            
        }

        public bool ExistName_user(string name_user,string email,string cpf_cnpj)
        {
            return _dataContext.Staff.Any(x => x.Name_user == name_user || x.Name == name_user || x.CPF == cpf_cnpj || x.CNPJ == cpf_cnpj);
        }

        public bool ExistName_user(string name_user)
        {
           return _dataContext.Staff.Any(x => x.Name_user == name_user );
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
                .Staff
                .FirstOrDefault(x => x.Id.ToString() == id);
        }

        public void Update(Staff staff)
        {
            _dataContext.Entry(staff).State = EntityState.Modified;
            _dataContext.SaveChanges();
        }
    }
}
