using Devon4Net.WebAPI.Implementation.Business.JumpTheQueue.Dto;
using Devon4Net.WebAPI.Implementation.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Devon4Net.WebAPI.Implementation.Business.JumpTheQueue.Converters
{
    public class VisitorConverter
    {
        /// <summary>
        /// ModelToDto Visitor transformation
        /// </summary>
        /// <param name="visitor"></param>
        /// <returns></returns>
        public static VisitorDto ModelToDto(Visitor visitor)
        {
            if (visitor == null) return new VisitorDto();
            AccessCodeCto accessCodeDto = null;

                if (visitor.AccessCode != null)
                {
                     accessCodeDto = new AccessCodeCto
                    {
                        AccessCodeId    = visitor.AccessCode.AccessCodeId,
                        PositionAtQueue = PositionAtQueue(visitor.AccessCode.TicketNumber,visitor.AccessCode.DailyQueue),
                        TicketNumber    = visitor.AccessCode.TicketNumber,
                        CreationTime    = visitor.AccessCode.CreationTime,
                        StartTime       = visitor.AccessCode.StartTime,
                        Endtime         = visitor.AccessCode.Endtime
                    };
                }



            return new VisitorDto
            {
                Id = visitor.VisitorId,
                UserName = visitor.Username,
                Name = visitor.Name,
                AccessCode = accessCodeDto
            };
        }

        private static int PositionAtQueue(int ticketNumber, Queue dailyQueue)
        {
            return dailyQueue.AccessCodes.Where(a => a.TicketNumber <= ticketNumber).Count();
        }
    }
}
