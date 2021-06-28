using Devon4Net.Domain.UnitOfWork.Service;
using Devon4Net.Domain.UnitOfWork.UnitOfWork;
using Devon4Net.Infrastructure.Common.Exceptions;
using Devon4Net.Infrastructure.Log;
using Devon4Net.WebAPI.Implementation.Business.JumpTheQueue.Cmd;
using Devon4Net.WebAPI.Implementation.Business.JumpTheQueue.Converters;
using Devon4Net.WebAPI.Implementation.Business.JumpTheQueue.Dto;
using Devon4Net.WebAPI.Implementation.Business.JumpTheQueue.Exceptions;
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
        public async Task<Visitor> CreateVisitor(VisitorCmd visitor)
        {
            var result = await _unitOfWorkJumpTheQueue.VisitorRepository.Create(visitor);
            await _unitOfWorkJumpTheQueue.SaveChanges();
            return result;
        }

        public async Task DeleteVisitorById(int id)
        {
            var visitorToDelete = await _unitOfWorkJumpTheQueue.VisitorRepository.GetVisitorById(id);

            if (visitorToDelete == null)
            {
                throw new ArgumentException($"The provided Id {id} does not exists");
            }

            if (visitorToDelete.AccessCode != null)
            {
                throw new JumpTheQueueException("You can´t delete a visitor if it has a AccessCode.");
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
            var result = await _unitOfWorkJumpTheQueue.VisitorRepository.GetVisitors(v => v.UserType.Equals(true));
            return result.Select(VisitorConverter.ModelToDto);
        }
        #endregion 

        #region Queue
        public async Task DecreaseQueueCustomer(AccessCode accessCode)
        {
            var queue = await _unitOfWorkJumpTheQueue.QueueRepository.GetQueueById(accessCode.DailyQueue.QueueId);

            queue.Customers = queue.AccessCodes.Count() - 1;
            queue.CurrentNumber = queue.AccessCodes
                                            .Where(a => a.AccessCodeId != accessCode.AccessCodeId)
                                            .OrderBy(a => a.TicketNumber)
                                            .FirstOrDefault()?.TicketNumber ?? 0;

            


             _unitOfWorkJumpTheQueue.QueueRepository.UpdateQueue(queue);

        }

        public async Task IncreaseQueueCustomer(AccessCode accessCode)
        {
            var queue = await _unitOfWorkJumpTheQueue.QueueRepository.GetQueueById(accessCode.DailyQueue.QueueId);

            queue.Customers = queue.AccessCodes.Count() +1;
            queue.CurrentNumber = accessCode.DailyQueue.AccessCodes
                                                    .OrderBy(a => a.TicketNumber)
                                                    .FirstOrDefault().TicketNumber;

            _unitOfWorkJumpTheQueue.QueueRepository.UpdateQueue(queue);

        }

        #endregion

        #region AccessCode
        public async Task<AccessCode> CreateAccessCode(AccessCodeCmd accessCodDto)
        {
            if (accessCodDto.VisitorId < 1 || accessCodDto.QueueId < 1)
            {
                throw new JumpTheQueueException($"Falta información. VisitorId :{accessCodDto.VisitorId} QueueId: {accessCodDto.QueueId}");
            }

            var queueSearch = await _unitOfWorkJumpTheQueue.QueueRepository.GetQueueById(accessCodDto.QueueId);
         
            if(queueSearch is null)
            {
                throw new JumpTheQueueException($"No hemos podido localizar la queue con Id: {accessCodDto.QueueId}");
            }

            AccessCode accessCodeEToSearch = await _unitOfWorkJumpTheQueue.AccessCodeRepository.GetAccessCodeById(accessCodDto.VisitorId);

            if (accessCodeEToSearch != null)
            {
                throw new JumpTheQueueException($"No podemos assignar un codigo de acceso al visitorId{accessCodDto.VisitorId} ya que dispone de uno");
            }

            Visitor visitorSearch = await _unitOfWorkJumpTheQueue.VisitorRepository.GetVisitorById(accessCodDto.VisitorId);

            if (visitorSearch == null)
            {
                throw new JumpTheQueueException($"Visitor not found");
            }

            if (!visitorSearch.UserType)
            {
                throw new JumpTheQueueException($"UserType not accepted");
            }

            AccessCode accessCode = new AccessCode
            {
                Visitor = visitorSearch,
                DailyQueue = queueSearch
            };


            await _unitOfWorkJumpTheQueue.AccessCodeRepository.CreateAccessCode(accessCode);

            await IncreaseQueueCustomer(accessCode);

            await _unitOfWorkJumpTheQueue.SaveChanges();

            return accessCode;
        }
        public async Task<IList<AccessCode>> GetAccessCodes(Expression<Func<AccessCode, bool>> predicate = null)
        {
            return await _unitOfWorkJumpTheQueue.AccessCodeRepository.GetAccessCodes(predicate);
        }
        public async Task DeleteAccessCodeById(int accessCodeId)
        {
             var AccessCode = await _unitOfWorkJumpTheQueue.AccessCodeRepository.GetAccessCodeById(accessCodeId);

            if (AccessCode?.DailyQueue?.QueueId == null)
            {
                throw new JumpTheQueueException("Access code is not found or it dont have a valid queue assigned");
            }

            await DecreaseQueueCustomer(AccessCode);
            await _unitOfWorkJumpTheQueue.AccessCodeRepository.DeleteAccessCode(AccessCode);
            await _unitOfWorkJumpTheQueue.SaveChanges();
        }
        #endregion
    }
}
