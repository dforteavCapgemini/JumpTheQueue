using Devon4Net.Domain.UnitOfWork.Repository;
using Devon4Net.Infrastructure.Log;
using Devon4Net.WebAPI.Implementation.Domain.Database;
using Devon4Net.WebAPI.Implementation.Domain.Entities;
using Devon4Net.WebAPI.Implementation.Domain.RepositoryInterfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Devon4Net.WebAPI.Implementation.Data.Repositories
{
    public class QueueRepository :  IQueueRepository
    {
        private readonly JumpTheQueueContext _jumpTheQueueContext;
        public QueueRepository(JumpTheQueueContext jumpTheQueueContext) 
        {
            _jumpTheQueueContext = jumpTheQueueContext;
        }

        /// <summary>
        /// Get Queue by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Queue> GetQueueById(int id)
        {
            Devon4NetLogger.Debug($"GetQueueById method from repository QueeuService with value : {id}");
            var queue=  await _jumpTheQueueContext.DailyQueues
                .Include(a => a.AccessCodes)
                .FirstOrDefaultAsync(q => q.QueueId == id);

            return queue;
        }

        public void UpdateQueue(Queue queue)
        {
              _jumpTheQueueContext.Update(queue);
        }
    }
}
