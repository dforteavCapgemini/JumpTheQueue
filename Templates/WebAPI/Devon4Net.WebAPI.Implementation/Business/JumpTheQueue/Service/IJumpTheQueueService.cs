using Devon4Net.WebAPI.Implementation.Business.JumpTheQueue.Cmd;
using Devon4Net.WebAPI.Implementation.Business.JumpTheQueue.Dto;
using Devon4Net.WebAPI.Implementation.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Devon4Net.WebAPI.Implementation.Business.JumpTheQueue.Service
{
    public interface IJumpTheQueueService
    {
        #region Visitors
        /// <summary>
        /// Create a Visitor
        /// </summary>
        /// <param name="visitor"></param>
        /// <returns></returns>
        public Task<Visitor> CreateVisitor(VisitorCmd visitor);
        /// <summary>
        /// Get Visitor by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Task<Visitor> GetVisitorById(int id);
        /// <summary>
        /// DeleteVisitorById
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Task DeleteVisitorById(int id);
        /// <summary>
        /// Get All Visitors
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public Task<IEnumerable<VisitorDto>> GetVisitors();
        #endregion

        #region Queue

        public Task<Queue> GetQueueById(int id);
        /// <summary>
        /// Decrease number of customers of the queue and update the queue.
        /// </summary>
        /// <param name="queueId">id of the queue to decrease customer.</param>
        public Task DecreaseQueueCustomer(AccessCode accessCode);
        /// <summary>
        /// Increase number of customers of the queue and update the queue.
        /// </summary>
        /// <param name="queueId">id of the queue to increase customer.</param>
        public Task IncreaseQueueCustomer(AccessCode accessCode);
        #endregion

        #region AccessCode
        Task<IList<AccessCode>> GetAccessCodes(Expression<Func<AccessCode, bool>> predicate = null);
        Task DeleteAccessCodeById(int accessCodeId);
        Task<AccessCode> CreateAccessCode(AccessCodeCmd acessCodeCmd);
        #endregion
    }
}
