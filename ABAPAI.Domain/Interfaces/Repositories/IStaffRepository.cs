using ABAPAI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ABAPAI.Domain.Interfaces.Repositories
{
    public interface IStaffRepository
    {
        Guid Create(Staff staff);
    }
}
