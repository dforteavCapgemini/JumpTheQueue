using Devon4Net.WebAPI.Implementation.Business.JumpTheQueue.Dto;
using Devon4Net.WebAPI.Implementation.Domain.Entities;
using System;
using System.Collections.Generic;
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
            AccessCodeDto accessCodeDto = null;

                if (visitor.AccessCode != null)
                {
                     accessCodeDto = new AccessCodeDto
                    {
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
    }
}
