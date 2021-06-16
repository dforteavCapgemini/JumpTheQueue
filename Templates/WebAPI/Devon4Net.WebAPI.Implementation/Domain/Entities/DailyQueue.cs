using System;
using System.Collections.Generic;
using System.Text;

namespace Devon4Net.WebAPI.Implementation.Domain.Entities
{
    public class DailyQueue
    {
        public int DailyQueueId { get; set; }
        public string Name { get; set; }
        public string Logo { get; set; }
        public string Password { get; set; }
        public int CurrentNumber { get; set; }
        public DateTime AttentionTime { get; set; }
        public DateTime MinAttentionTime { get; set; }
        public bool Active { get; set; }
        public int Customers { get; set; }
        public ICollection<AccessCode> AccessCodes{ get; set; }
    }
}
