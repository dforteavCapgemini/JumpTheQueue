using Devon4Net.Domain.UnitOfWork.Repository;
using Devon4Net.Infrastructure.Log;
using Devon4Net.WebAPI.Implementation.Business.JumpTheQueue.Validators;
using Devon4Net.WebAPI.Implementation.Domain.Database;
using Devon4Net.WebAPI.Implementation.Domain.Entities;
using Devon4Net.WebAPI.Implementation.Domain.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Devon4Net.WebAPI.Implementation.Data.Repositories
{
    public class VisitorRespository : Repository<Visitor>, IVisitorRepository
    {
        private VisitorFluentValidator VisitorValidator { get; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="context"></param>
        public VisitorRespository(JumpTheQueueContext context, VisitorFluentValidator visitorValidator) : base(context)
        {
            VisitorValidator = visitorValidator;
        }

        public Task<Visitor> Create(string name)
        {
            Devon4NetLogger.Debug($"SetTodo method from repository JumpTheQueueService with value : {name}");


            Visitor visitor = new Visitor { Name = name };
            var result = VisitorValidator.Validate(visitor);

            if (!result.IsValid)
            {
                throw new ArgumentException($"The 'name' field can not be null.{result.Errors}");
            }

            return Create(visitor);
        }

        public Task<long> DeleteTodoById(long id)
        {
            throw new NotImplementedException();
        }

        public Task<IList<Visitor>> GetTodo(Expression<Func<Visitor, bool>> predicate = null)
        {
            throw new NotImplementedException();
        }

        public Task<Visitor> GetTodoById(long id)
        {
            throw new NotImplementedException();
        }
    }
}
