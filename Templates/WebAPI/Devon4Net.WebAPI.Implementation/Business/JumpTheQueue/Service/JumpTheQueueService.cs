using Devon4Net.Domain.UnitOfWork.Service;
using Devon4Net.Domain.UnitOfWork.UnitOfWork;
using Devon4Net.Infrastructure.Log;
using Devon4Net.WebAPI.Implementation.Business.JumpTheQueue.Converters;
using Devon4Net.WebAPI.Implementation.Business.JumpTheQueue.Dto;
using Devon4Net.WebAPI.Implementation.Domain.Database;
using Devon4Net.WebAPI.Implementation.Domain.Entities;
using Devon4Net.WebAPI.Implementation.Domain.RepositoryInterfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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

        public async Task<long> DeleteVisitorById(int id)
        {
            Devon4NetLogger.Debug($"DeleteVisitorById method from service VisitorService with value : {id}");
            var todo = await _VisitorRepository.GetFirstOrDefault(t => t.VisitorId == id).ConfigureAwait(false);

            if (todo == null)
            {
                throw new ArgumentException($"The provided Id {id} does not exists");
            }

            return await _VisitorRepository.DeleteVisitorById(id).ConfigureAwait(false);
        }

        public async Task<Visitor> GetVisitorById(int id)
        {
            Devon4NetLogger.Debug($"GetTodoById method from service TodoService with value : {id}");
            return await _VisitorRepository.GetVisitorById(id);
        }

        public async Task<IEnumerable<VisitorDto>> GetVisitors()
        {
            Devon4NetLogger.Debug("GetVisitors method from service VisitorService");
            var result = await _VisitorRepository.GetVisitors(v => v.UserType == false).ConfigureAwait(false);
            return result.Select(VisitorConverter.ModelToDto);
        }
    }
}
