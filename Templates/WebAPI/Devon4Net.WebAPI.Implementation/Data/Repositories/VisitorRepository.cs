using Devon4Net.Domain.UnitOfWork.Repository;
using Devon4Net.Infrastructure.Log;
using Devon4Net.WebAPI.Implementation.Business.JumpTheQueue.Dto;
using Devon4Net.WebAPI.Implementation.Business.JumpTheQueue.Validators;
using Devon4Net.WebAPI.Implementation.Domain.Database;
using Devon4Net.WebAPI.Implementation.Domain.Entities;
using Devon4Net.WebAPI.Implementation.Domain.RepositoryInterfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Devon4Net.WebAPI.Implementation.Data.Repositories
{
    public class VisitorRepository : Repository<Visitor>, IVisitorRepository
    {
        private readonly JumpTheQueueContext _jumpTheQueueContext;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="context"></param>
        public VisitorRepository(JumpTheQueueContext context, bool dbContextBehaviour = true) : base(context, dbContextBehaviour)
        {
            _jumpTheQueueContext = context;
        }
        /// <summary>
        /// Get Visitor by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Visitor> GetVisitorById(int id)
        {
            Devon4NetLogger.Debug($"GetVisitorById method from repository VisitorService with value : {id}");
            return await _jumpTheQueueContext.Visitors.FirstOrDefaultAsync(v => v.VisitorId == id);
        }
        /// <summary>
        /// Create a new Visitor
        /// </summary>
        /// <param name="visitorDto"></param>
        /// <returns></returns>
        public Task<Visitor> Create(VisitorDto visitorDto)
        {
            Devon4NetLogger.Debug($"Create method from repository JumpTheQueueService with value : {visitorDto}");


            Visitor visitor = new Visitor
            {
                Name = visitorDto.Name,
                Username = visitorDto.UserName,
                Password = visitorDto.Password,
                PhoneNumber = visitorDto.PhoneNumber,
                AcceptedTerms = visitorDto.AcceptedTerms,
                AcceptedCommercial = visitorDto.AcceptedCommercial,
                UserType = visitorDto.UserType
            };


            return Create(visitor,false);
        }
      
        public async Task<IList<Visitor>> GetVisitors(Expression<Func<Visitor, bool>> predicate = null)
        {
 
            Devon4NetLogger.Debug("GetVisitors method from VisitorRespository VisitorService");
            return await _jumpTheQueueContext.Visitors.Where(predicate).Include(v => v.AccessCode).ToListAsync();
        }

        public async Task DeleteVisitorById(int id)
        {

            var visitor = await _jumpTheQueueContext.Visitors.FirstOrDefaultAsync(v => v.VisitorId == id);

            if (visitor is null)
            {

                throw new ApplicationException($"The visitor {id} has not been found.");
            }

            _jumpTheQueueContext.Visitors.Remove(visitor);
        }
    }
}
