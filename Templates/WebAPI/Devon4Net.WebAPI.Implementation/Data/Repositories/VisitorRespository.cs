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
        public VisitorRespository(JumpTheQueueContext context, VisitorFluentValidator visitorValidator) : base(context,true)
        {
            VisitorValidator = visitorValidator;
        }
        /// <summary>
        /// Get Visitor by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Task<Visitor> GetVisitorById(int id)
        {
            Devon4NetLogger.Debug($"GetTodoById method from repository VisitorService with value : {id}");
            return GetFirstOrDefault(t => t.VisitorId == id);
        }
        /// <summary>
        /// Create a new Visitor
        /// </summary>
        /// <param name="visitorDto"></param>
        /// <returns></returns>
        public Task<Visitor> Create(VisitorDto visitorDto)
        {
            Devon4NetLogger.Debug($"Create method from repository JumpTheQueueService with value : {visitorDto}");


            Visitor visitor = new Visitor
            {
                Name = visitorDto.Name,
                Username = visitorDto.UserName,
                Password = visitorDto.Password,
                PhoneNumber = visitorDto.PhoneNumber,
                AcceptedTerms = visitorDto.AcceptedTerms,
                AcceptedCommercial = visitorDto.AcceptedCommercial,
                UserType = visitorDto.UserType
            };
            var result = VisitorValidator.Validate(visitor);

            if (!result.IsValid)
            {
                throw new ArgumentException($"The 'name' field can not be null.{result.Errors}");
            }

            return Create(visitor);
        }
        /// <summary>
        /// Deletes the Visitor by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<long> DeleteVisitorById(long id)
        {
            Devon4NetLogger.Debug($"DeleteVisitorById method from repository VisitorService with value : {id}");
            var deleted = await Delete(t => t.VisitorId == id).ConfigureAwait(false);

            if (deleted)
            {
                return id;
            }

            throw new ApplicationException($"The Todo entity {id} has not been deleted.");
        }

        public Task<IList<Visitor>> GetVisitors(Expression<Func<Visitor, bool>> predicate = null)
        {
            Devon4NetLogger.Debug("GetVisitors method from VisitorRespository VisitorService");
            return Get(predicate);
        }
    }
}
