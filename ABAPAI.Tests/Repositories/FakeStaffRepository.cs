using ABAPAI.Domain.Entities;
using ABAPAI.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace ABAPAI.Tests.Repositories
{
    public class FakeStaffRepository : IStaffRepository
    {
        public Guid Create(Staff staff)
        {
            return Guid.NewGuid();
        }
    }
}
