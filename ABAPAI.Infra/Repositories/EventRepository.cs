using ABAPAI.Domain.Entities;
using ABAPAI.Domain.Interfaces.Repositories;
using System;

namespace ABAPAI.Infra.Repositories
{
    public class EventRepository : IEventRepository
    {
        public string Create(Event @event)
        {
            return Guid.NewGuid().ToString();
        }
    }
}
