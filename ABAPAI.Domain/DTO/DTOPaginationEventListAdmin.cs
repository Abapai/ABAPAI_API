using System;
using System.Collections.Generic;
using System.Text;

namespace ABAPAI.Domain.DTO
{
    public class DTOPaginationEventListAdmin
    {
        public DTOPaginationEventListAdmin(int total, int limit, List<DTOEventListSimple> events)
        {
            this.total = total;
            this.limit = limit;
            this.events = events;
        }

        public int total { get; set; }
        public int limit { get; set; }
        public List<DTOEventListSimple> events { get; set; }    
    }
}
