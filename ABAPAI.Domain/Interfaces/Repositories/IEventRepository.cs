using ABAPAI.Domain.Entities;
using ABAPAI.Domain.Enums;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ABAPAI.Domain.Interfaces.Repositories
{
    public interface IEventRepository
    {
        Task<bool> CreateAsync(Event @event);

        IEnumerable<Event> GetAllEvents(string id_staff);
        IEnumerable<Event> GetAllEvents();

        int CountByEvent(string id_staff,int? category);
        Event GetEventWithAddressWithStaff(string id_staff);

        Task<Event> GetEventById(string id_event );

        public Task<bool> UpdateEvent(Event @event);
    }
}
