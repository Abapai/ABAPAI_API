using ABAPAI.Domain.Entities;
using ABAPAI.Domain.Interfaces.Repositories;
using ABAPAI.Infra.Contexts;
using System;
using System.Collections.Generic;
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

        public void Create(Staff staff)
        {
            var id = _dataContext.Staff.Add(staff);
            _dataContext.SaveChanges();            
        }
    }
}
