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
        /// <param name="item"></param>
        /// <returns></returns>
        public static VisitorDto ModelToDto(Visitor item)
        {
            if (item == null) return new VisitorDto();

            return new VisitorDto
            {
                Id = item.Id,
                UserName  = item.Username,
                Name = item.Name
            };
        }
    }
}
