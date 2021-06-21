using Devon4Net.Domain.UnitOfWork.Service;
using Devon4Net.Domain.UnitOfWork.UnitOfWork;
using Devon4Net.Infrastructure.Log;
using Devon4Net.WebAPI.Implementation.Business.JumpTheQueue.Cmd;
using Devon4Net.WebAPI.Implementation.Business.JumpTheQueue.Converters;
using Devon4Net.WebAPI.Implementation.Business.JumpTheQueue.Dto;
using Devon4Net.WebAPI.Implementation.Data.Repositories;
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
   
    public class JumpTheQueueService : IJumpTheQueueService
    {
        private readonly IUnitOfWorkJumpTheQueue _unitOfWorkJumpTheQueue;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="uoW"></param>
        public JumpTheQueueService(IUnitOfWorkJumpTheQueue unitOfWorkJumpTheQueue) 
        {
            _unitOfWorkJumpTheQueue = unitOfWorkJumpTheQueue;
        }

        #region Visitor
        public async Task<Visitor> CreateVisitor(VisitorDto visitor)
        {

            Devon4NetLogger.Debug($"SetTodo method from service JumpTheQueueService with value : {visitor}");

            if (string.IsNullOrEmpty(visitor.Name) )
            {
                throw new ArgumentException("The 'Name' field can not be null or empty.");
            }

            var result = await _unitOfWorkJumpTheQueue.VisitorRepository.Create(visitor);
            await _unitOfWorkJumpTheQueue.SaveChanges();
            return result;
        }

        public async Task DeleteVisitorById(int id)
        {
            Devon4NetLogger.Debug($"DeleteVisitorById method from service VisitorService with value : {id}");
            var todo = await _unitOfWorkJumpTheQueue.VisitorRepository.GetFirstOrDefault(t => t.VisitorId == id).ConfigureAwait(false);

            if (todo == null)
            {
                throw new ArgumentException($"The provided Id {id} does not exists");
            }

            await _unitOfWorkJumpTheQueue.VisitorRepository.DeleteVisitorById(id).ConfigureAwait(false);
            await _unitOfWorkJumpTheQueue.SaveChanges();
        }

        public async Task<Visitor> GetVisitorById(int id)
        {
            return await _unitOfWorkJumpTheQueue.VisitorRepository.GetVisitorById(id);
        }

        public async Task<IEnumerable<VisitorDto>> GetVisitors()
        {
            var result = await _unitOfWorkJumpTheQueue.VisitorRepository.GetVisitors(v => v.UserType == true).ConfigureAwait(false);
            return result.Select(VisitorConverter.ModelToDto);
        }
        #endregion 

        #region Queue
        public async Task DecreaseQueueCustomer(int queueId)
        {
            Queue queueEntity = await _unitOfWorkJumpTheQueue.QueueRepository.GetFirstOrDefault(queue => queue.QueueId.Equals(queueId));

            // the customers gets increase by one
            queueEntity.Customers--;

            await _unitOfWorkJumpTheQueue.QueueRepository.UpdateQueue(queueEntity);
        }

        public async Task IncreaseQueueCustomer(int queueId)
        {
            Queue queueEntity = await _unitOfWorkJumpTheQueue.QueueRepository.GetQueueById(queueId); ;

            // the customers gets reduced by one
            queueEntity.Customers++;

            await _unitOfWorkJumpTheQueue.QueueRepository.UpdateQueue(queueEntity);
        }

        #endregion

        #region AccessCode
        public async Task<AccessCode> CreateAccessCode(AccessCodeCmd accessCodDto)
        {
            if (accessCodDto.VisitorId < 1 || accessCodDto.QueueId < 1)
            {
                throw new ArgumentException($"Falta información. VisitorId :{accessCodDto.VisitorId} QueueId: {accessCodDto.QueueId}");
            }

            var queueSearch = await _unitOfWorkJumpTheQueue.QueueRepository.GetQueueById(accessCodDto.QueueId);
         
            if(queueSearch is null)
            {
                throw new Exception($"No hemos podido localizar la queue con Id: {accessCodDto.QueueId}");
            }

            AccessCode accessCodeEToSearch = await _unitOfWorkJumpTheQueue.AccessCodeRepository.GetAccessCodeById(accessCodDto.VisitorId);

            if (accessCodeEToSearch != null)
            {
                throw new Exception($"No podemos assignar un codigo de acceso al visitorId{accessCodDto.VisitorId} ya que dispone de uno");
            }

            Visitor visitorSearch = await _unitOfWorkJumpTheQueue.VisitorRepository.GetVisitorById(accessCodDto.VisitorId);

            AccessCode accessCode = new AccessCode
            {
                Visitor = visitorSearch,
                DailyQueue = queueSearch
            };


            await _unitOfWorkJumpTheQueue.AccessCodeRepository.CreateAccessCode(accessCode);

            await IncreaseQueueCustomer(accessCode.DailyQueueId);

            await _unitOfWorkJumpTheQueue.SaveChanges();

            return accessCode;
        }
        public async Task<IList<AccessCode>> GetAccessCodes(Expression<Func<AccessCode, bool>> predicate = null)
        {
            return await _unitOfWorkJumpTheQueue.AccessCodeRepository.GetAccessCodes(predicate);
        }
        public async Task DeleteAccessCodeById(int accessCodeId)
        {
            // we get the queueId using the AccessCodeRepository
            int DailyQueueId = (await _unitOfWorkJumpTheQueue.AccessCodeRepository.GetFirstOrDefault(AccessCode => AccessCode.AccessCodeId.Equals(accessCodeId))).DailyQueueId;
            await DecreaseQueueCustomer(DailyQueueId);
            await _unitOfWorkJumpTheQueue.AccessCodeRepository.DeleteAccessCodeById(accessCodeId);
            await _unitOfWorkJumpTheQueue.SaveChanges();
        }
        #endregion
    }
}
