using Devon4Net.Domain.UnitOfWork.Repository;
using Devon4Net.WebAPI.Implementation.Business.JumpTheQueue.Dto;
using Devon4Net.WebAPI.Implementation.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Devon4Net.WebAPI.Implementation.Domain.RepositoryInterfaces
{
    public interface IVisitorRepository : IRepository<Visitor>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        Task<IList<Visitor>> GetTodo(Expression<Func<Visitor, bool>> predicate = null);

        /// <summary>
        /// GetTodoById
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Visitor> GetTodoById(long id);

        /// <summary>
        /// Create
        /// </summary>
        /// <param name="description"></param>
        /// <returns></returns>
        Task<Visitor> Create(VisitorDto visitor);

        /// <summary>
        /// DeleteTodoById
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<long> DeleteTodoById(long id);
    }
}
