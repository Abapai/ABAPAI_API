using ABAPAI.Domain.Entities;

namespace ABAPAI.Domain.Interfaces.Repositories
{
    public interface IEventRepository
    {
        string Create(Event @event);

    }
}
