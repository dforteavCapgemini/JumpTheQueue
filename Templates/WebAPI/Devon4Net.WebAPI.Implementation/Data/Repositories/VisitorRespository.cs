using Devon4Net.Domain.UnitOfWork.Repository;
using Devon4Net.Infrastructure.Log;
using Devon4Net.WebAPI.Implementation.Business.JumpTheQueue.Dto;
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

        public Task<Visitor> Create(VisitorDto visitorDto)
        {
            Devon4NetLogger.Debug($"Create method from repository JumpTheQueueService with value : {visitorDto}");


            Visitor visitor = new Visitor 
                            { 
                              Name                  = visitorDto.Name,
                              Username              = visitorDto.UserName,                  
                              Password              = visitorDto.Password,
                              PhoneNumber           = visitorDto.PhoneNumber,
                              AcceptedTerms         = visitorDto.AcceptedTerms,
                              AcceptedCommercial    = visitorDto.AcceptedCommercial,
                              UserType              = visitorDto.UserType
                            };
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
