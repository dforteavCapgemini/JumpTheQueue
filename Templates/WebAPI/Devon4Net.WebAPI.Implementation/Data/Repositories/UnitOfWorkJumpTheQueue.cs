using Devon4Net.WebAPI.Implementation.Domain.Database;
using Devon4Net.WebAPI.Implementation.Domain.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Devon4Net.WebAPI.Implementation.Data.Repositories
{
    public class UnitOfWorkJumpTheQueue : IUnitOfWorkJumpTheQueue
    {
        private readonly JumpTheQueueContext _jumpTheQueueContext;

        private VisitorRepository _visitorRepository ;

        private AccessCodeRepository _accessCodeRepository;

        private QueueRepository _queueRepository ;

        private bool _disposed = false;

        public UnitOfWorkJumpTheQueue(JumpTheQueueContext jumpTheQueueContext)
        {
            _jumpTheQueueContext = jumpTheQueueContext;
        }


        public IVisitorRepository VisitorRepository
        {
            get
            {
                if (_visitorRepository == null)
                {
                    _visitorRepository = new VisitorRepository(_jumpTheQueueContext);
                }
                return _visitorRepository;
            }
        }

        public IAccessCodeRepository AccessCodeRepository
        {
            get
            {
                if (_accessCodeRepository == null)
                {
                    _accessCodeRepository = new AccessCodeRepository(_jumpTheQueueContext);
                }
                return _accessCodeRepository;
            }
        }

        public IQueueRepository QueueRepository
        {
            get
            {
                if (_queueRepository == null)
                {
                    _queueRepository = new QueueRepository(_jumpTheQueueContext);
                }
                return _queueRepository;
            }
        }

        public bool Disposed
        {
            get
            {
                return _disposed;
            }
        }

        public async Task<bool> SaveChanges(CancellationToken cancellationToken = default(CancellationToken))
        {
            //Persistimos los cambios
            await _jumpTheQueueContext.SaveChangesAsync();
            return true;

        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _jumpTheQueueContext.Dispose();
                }
            }
            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

    }
}
