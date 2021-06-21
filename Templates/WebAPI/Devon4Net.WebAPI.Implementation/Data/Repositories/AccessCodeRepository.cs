using Devon4Net.Domain.UnitOfWork.Repository;
using Devon4Net.Infrastructure.Log;
using Devon4Net.WebAPI.Implementation.Business.JumpTheQueue.Service;
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
    public class AccessCodeRepository : Repository<AccessCode>, IAccessCodeRepository
    {
        private readonly JumpTheQueueContext _jumpTheQueueContext;

        public AccessCodeRepository(JumpTheQueueContext jumpTheQueueContext, bool dbContextBehaviour = true) : base(jumpTheQueueContext, dbContextBehaviour)
        {
            _jumpTheQueueContext = jumpTheQueueContext;
        }


        /// <summary>
        /// Get AccessCode  by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<AccessCode> GetAccessCodeById(int id)
        {
            Devon4NetLogger.Debug($"GetAccessCodeById method from repository JumpThequeueService with value : {id}");
            return await _jumpTheQueueContext.AccessCodes.FirstOrDefaultAsync(v => v.AccessCodeId == id);
        }


        public async Task DeleteAccessCodeById(int id)
        {

            var accessCode = await _jumpTheQueueContext.AccessCodes.FirstOrDefaultAsync(v => v.VisitorId == id);

            if (accessCode is null)
            {

                throw new ApplicationException($"The accessCode {id} has not been found.");
            }

            _jumpTheQueueContext.AccessCodes.Remove(accessCode);

        }

        public async Task<IList<AccessCode>> GetAccessCodes(Expression<Func<AccessCode, bool>> predicate = null)
        {
            return await _jumpTheQueueContext.AccessCodes.Where(predicate)
                .Include(v =>  v.DailyQueue)
                .Include(v => v.Visitor)
                .ToListAsync();
        }

        public async Task<AccessCode> CreateAccessCode(AccessCode accessCode)
        {
            Devon4NetLogger.Debug($"SaveAccessCode method from repository AccessCodeRepository");

            int accessCodeInQueue =  _jumpTheQueueContext.AccessCodes.Where(a => a.DailyQueue == accessCode.DailyQueue).Count();
            accessCode.TicketNumber = accessCodeInQueue + 1;
            accessCode.CreationTime = DateTime.Now;
            accessCode = await Update(accessCode,false);
            return accessCode;
        }

        /// <summary>
        /// Generates a new ticked code
        /// </summary>
        /// <param name="lastTicket"></param>
        /// <returns></returns>
        public int generateTicketCode(int lastTicket)
        {
            return lastTicket++;
        }
    }
}
