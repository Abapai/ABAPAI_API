using ABAPAI.Domain.Entities;
using ABAPAI.Domain.Interfaces.Repositories;
using System;

namespace ABAPAI.Tests.Repositories
{
    public class FakeEventRepository : IEventRepository
    {
        public string Create(Event @event)
        {
            return Guid.NewGuid().ToString();
        }
    }
}
