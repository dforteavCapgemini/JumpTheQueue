using Devon4Net.WebAPI.Implementation.Domain.RepositoryInterfaces;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Devon4Net.WebAPI.Implementation.Data.Repositories
{
    public interface IUnitOfWorkJumpTheQueue : IDisposable
    {
        IVisitorRepository VisitorRepository { get; }
        IAccessCodeRepository AccessCodeRepository { get; }
        IQueueRepository QueueRepository { get; }

        /// <summary>
        /// Hace persistentes los cambios en el repositorio.
        /// </summary>
        //void GuardarCambios();
        Task<bool> SaveChanges(CancellationToken cancellationToken = default(CancellationToken));


    }
}