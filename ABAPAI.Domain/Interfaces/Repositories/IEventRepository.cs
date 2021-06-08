using ABAPAI.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ABAPAI.Domain.Interfaces.Repositories
{
    public interface IEventRepository
    {
        Task<bool> CreateAsync(Event @event);

        IEnumerable<Event> GetAllEvents(string id_staff);

        Event GetById(string id_user, string id_event);

        Task<bool> UpdateAsync(Event @event);

    }
}
