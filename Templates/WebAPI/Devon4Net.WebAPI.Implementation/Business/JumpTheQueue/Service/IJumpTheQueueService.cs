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
        /// <summary>
        /// Create a Visitor
        /// </summary>
        /// <param name="visitor"></param>
        /// <returns></returns>
        public Task<Visitor> CreateVisitor(VisitorDto visitor);
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
        public Task<long> DeleteVisitorById(int id);
        /// <summary>
        /// Get All Visitors
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public Task<IEnumerable<VisitorDto>> GetVisitors();
    }
}
