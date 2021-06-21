using ABAPAI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ABAPAI.Domain.Interfaces.Repositories
{
    public interface ITicketRepository
    {
        Task<bool> CreateTicketAsync(Ticket ticket);

        bool ExistByIdFan(string id_fan,string id_event);
    }
}
