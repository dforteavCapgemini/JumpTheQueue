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
    public class AccessCodeRepository :  IAccessCodeRepository
    {
        private readonly JumpTheQueueContext _jumpTheQueueContext;

        public AccessCodeRepository(JumpTheQueueContext jumpTheQueueContext, bool dbContextBehaviour = true) 
        {
            _jumpTheQueueContext = jumpTheQueueContext;
        }

        public async Task<AccessCode> GetAccessCodeById(int id)
        {
            return await _jumpTheQueueContext.AccessCodes
                .Include(a => a.DailyQueue)
                .Include(a => a.Visitor)
                .FirstOrDefaultAsync(v => v.AccessCodeId == id);
        }

        public Task DeleteAccessCode(AccessCode accessCode)
        {
            if (accessCode is null)
            {

                throw new ApplicationException($"The accessCode  can´t be null");
            }

            _jumpTheQueueContext.AccessCodes.Remove(accessCode);

            return Task.CompletedTask;
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
            //Get las ticket or 0 if there aren´t any access code in the queue
            int lastTicketNumber = (await _jumpTheQueueContext.AccessCodes
                                .Where(a => a.DailyQueue == accessCode.DailyQueue)
                                .OrderBy(accessCode => accessCode.TicketNumber)
                                .LastOrDefaultAsync())?.TicketNumber ?? 0;

            accessCode.TicketNumber = lastTicketNumber + 1;
            accessCode.CreationTime = DateTime.Now;

            var result =  (await _jumpTheQueueContext.AccessCodes.AddAsync(accessCode)).Entity;


            return result;
        }
    }
}
