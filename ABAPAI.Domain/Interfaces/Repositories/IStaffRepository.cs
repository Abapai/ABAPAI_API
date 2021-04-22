using ABAPAI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ABAPAI.Domain.Interfaces.Repositories
{
    public interface IStaffRepository
    {
        void Create(Staff staff);
    }
}
