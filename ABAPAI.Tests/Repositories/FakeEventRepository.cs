using ABAPAI.Domain.Entities;
using ABAPAI.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ABAPAI.Tests.Repositories
{
    public class FakeEventRepository : IEventRepository
    {
        public int CountByEvent(string id_staff, int? category)
        {
            throw new NotImplementedException();
        }

        public string Create(Event @event)
        {
            return Guid.NewGuid().ToString();
        }

        public Task<bool> CreateAsync(Event @event)
        {
            return  Task.Run(()=> {
                return true;            
            });
        }

        public IEnumerable<Event> GetAllEvents(string id_staff)
        {
            throw new NotImplementedException();
        }

        public Task<Event> GetEventById(string id_event)
        {
            throw new NotImplementedException();
        }

        public Event GetEventWithAddressWithStaff(string id_staff)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateEvent(Event @event)
        {
            throw new NotImplementedException();
        }
    }
}
