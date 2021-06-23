using System;

namespace Devon4Net.WebAPI.Implementation.Business.JumpTheQueue.Dto
{
    public class AccessCodeCto
    {
        public int PositionAtQueue { get; set; }
        public int AccessCodeId { get; set; }
        public int TicketNumber { get; set; }
        public DateTime CreationTime { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime Endtime { get; set; }
    }
}
