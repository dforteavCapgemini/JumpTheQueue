using System;
using System.Collections.Generic;
using System.Text;

namespace Devon4Net.WebAPI.Implementation.Domain.Entities
{
    public class AccessCode
    {
        public int AccessCodeId { get; set; }
        public int TicketNumber { get; set; }
        public DateTime CreationTime { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime Endtime { get; set; }
        public int VisitorId { get; set; }
        public Visitor Visitor { get; set; }
        public int DailyQueueId { get; set; }
        public DailyQueue DailyQueue { get; set; }
    }
}
