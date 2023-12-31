﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace data_access.Entities
{
    public class TicketStatus : IEntity
    {
        public int Id { get; set; }
        public string StatusName { get; set; }
        public List<Ticket> Tickets { get; set; } = new();
    }
}
