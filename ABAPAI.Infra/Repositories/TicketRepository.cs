using ABAPAI.Domain.Entities;
using ABAPAI.Domain.Interfaces.Repositories;
using ABAPAI.Infra.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABAPAI.Infra.Repositories
{
    public class TicketRepository : ITicketRepository
    {

        private readonly DataContext _dataContext;

        public TicketRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<bool> CreateTicketAsync(Ticket ticket)
        {
            _dataContext.Ticket.Add(ticket);
            var status = await _dataContext.SaveChangesAsync();
            return Convert.ToBoolean(status); 
        }

        public bool ExistByIdFan(string id_fan, string id_event)
        {
           return _dataContext.Ticket.Any(x => x.Cpf == id_fan && x.Id_eventFK.ToString() == id_event);
        }
    }
}
