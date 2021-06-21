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
    public class QueueRepository : Repository<Queue>, IQueueRepository
    {
        private readonly JumpTheQueueContext _jumpTheQueueContext;
        public QueueRepository(JumpTheQueueContext jumpTheQueueContext, bool dbContextBehaviour = true) : base(jumpTheQueueContext, dbContextBehaviour)
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
            return await _jumpTheQueueContext.DailyQueues.FirstOrDefaultAsync(v => v.QueueId == id);
        }

        public async Task<Queue> UpdateQueue(Queue queue)
        {
            
            return await Update(queue);
        }
    }
}
