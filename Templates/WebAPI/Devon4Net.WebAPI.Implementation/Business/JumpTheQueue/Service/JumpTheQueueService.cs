using Devon4Net.Domain.UnitOfWork.Service;
using Devon4Net.Domain.UnitOfWork.UnitOfWork;
using Devon4Net.Infrastructure.Log;
using Devon4Net.WebAPI.Implementation.Business.JumpTheQueue.Dto;
using Devon4Net.WebAPI.Implementation.Domain.Database;
using Devon4Net.WebAPI.Implementation.Domain.Entities;
using Devon4Net.WebAPI.Implementation.Domain.RepositoryInterfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Devon4Net.WebAPI.Implementation.Business.JumpTheQueue.Service
{
   
    public class JumpTheQueueService : Service<JumpTheQueueContext>,IJumpTheQueueService
    {
        private readonly IVisitorRepository _VisitorRepository;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="uoW"></param>
        public JumpTheQueueService(IUnitOfWork<JumpTheQueueContext> uoW) : base(uoW)
        {
            _VisitorRepository = uoW.Repository<IVisitorRepository>();
        }
        public async Task<Visitor> CreateVisitor(VisitorDto visitor)
        {

            Devon4NetLogger.Debug($"SetTodo method from service JumpTheQueueService with value : {visitor}");

            if (string.IsNullOrEmpty(visitor.Name) )
            {
                throw new ArgumentException("The 'Name' field can not be null or empty.");
            }

            return await _VisitorRepository.Create(visitor);
        }
    }
}
