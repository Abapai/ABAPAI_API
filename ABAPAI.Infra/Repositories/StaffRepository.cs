using ABAPAI.Domain.Entities;
using ABAPAI.Domain.Interfaces.Repositories;
using ABAPAI.Infra.Contexts;
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

        public bool ExistName_user(string name_user)
        {
            return _dataContext.Staff.Any(x => x.Name_user == name_user);
        }

        public Staff FindStaff(string email, string password)
        {
            return _dataContext.Staff.Where(x => x.Email == email && x.Password == password).FirstOrDefault();
        }
    }
}
