using System;
using System.Collections.Generic;
using System.Text;

namespace Devon4Net.WebAPI.Implementation.Business.JumpTheQueue.Dto
{
    public class AccessCodeDto
    {
        public int AccessCodeId { get; set; }
        public int TicketNumber { get; set; }
        public DateTime CreationTime { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime Endtime { get; set; }
    }
}
