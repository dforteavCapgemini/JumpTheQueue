using Devon4Net.WebAPI.Implementation.Business.JumpTheQueue.Dto;
using Devon4Net.WebAPI.Implementation.Domain.Entities;
using System.Threading.Tasks;

namespace Devon4Net.WebAPI.Implementation.Business.JumpTheQueue.Service
{
    public interface IJumpTheQueueService
    {
        public Task<Visitor> CreateVisitor(VisitorDto visitor);
    }
}
