﻿using ABAPAI.Domain.Entities;
using ABAPAI.Domain.Interfaces.Repositories;
using ABAPAI.Infra.Contexts;
using Microsoft.EntityFrameworkCore;
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

        public Event GetById(string id_user, string id_event)
        {
            return _dataContext
                .Event
                .FirstOrDefault(x => x.Id.ToString() == id_event && x.Staff_ForeignKey.ToString() == id_user);
        }

        public async Task<bool> UpdateAsync(Event @event)
        {
            _dataContext.Entry(@event).State = EntityState.Modified;
            var status = await _dataContext.SaveChangesAsync();
            return Convert.ToBoolean(status);
        }
    }
}
