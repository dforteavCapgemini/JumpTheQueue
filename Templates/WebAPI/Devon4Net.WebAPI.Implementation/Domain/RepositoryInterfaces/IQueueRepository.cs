using Devon4Net.Domain.UnitOfWork.Repository;
using Devon4Net.WebAPI.Implementation.Domain.Entities;
using System.Threading.Tasks;

namespace Devon4Net.WebAPI.Implementation.Domain.RepositoryInterfaces
{
    public interface IQueueRepository 
    {
        public Task<Queue> GetQueueById(int id);
        public void UpdateQueue(Queue queue);
    }
}