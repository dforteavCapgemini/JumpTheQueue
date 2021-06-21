using Devon4Net.Domain.UnitOfWork.Repository;
using Devon4Net.WebAPI.Implementation.Domain.Entities;
using System.Threading.Tasks;

namespace Devon4Net.WebAPI.Implementation.Domain.RepositoryInterfaces
{
    public interface IQueueRepository : IRepository<Queue>
    {
        public Task<Queue> GetQueueById(int id);
        public Task<Queue> UpdateQueue(Queue queue);
    }
}