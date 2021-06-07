using ABAPAI.Domain.Entities;
using ABAPAI.Domain.Interfaces.Repositories;
using ABAPAI.Infra.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ABAPAI.Infra.Repositories
{
    public class EventRepository : IEventRepository
    {

        private readonly DataContext _dataContext;

        public EventRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<bool> CreateAsync(Event @event)
        {
            _dataContext.Event.Add(@event);
            var status = await _dataContext.SaveChangesAsync();
            return Convert.ToBoolean(status);
        }

        public IEnumerable<Event> GetAllEvents(string id_staff)
        {
            var EventsList = _dataContext.Event.Where(x => x.Staff_ForeignKey.ToString() == id_staff);
            return EventsList;
        }

        public Event GetById(Guid id)
        {
            return _dataContext
                .Event
                .FirstOrDefault(x => x.Id == id);
        }
    }
}
