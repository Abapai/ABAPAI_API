using ABAPAI.Domain.Entities;
using ABAPAI.Domain.Interfaces.Repositories;
using System;
using System.Threading.Tasks;

namespace ABAPAI.Tests.Repositories
{
    public class FakeEventRepository : IEventRepository
    {
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
    }
}
