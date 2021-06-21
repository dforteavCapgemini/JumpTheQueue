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
        /// Obtiene la lista de los visitantes
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public Task<IList<Visitor>> GetVisitors(Expression<Func<Visitor, bool>> predicate = null);

        /// <summary>
        /// Obtiene el visitante por identificador
        /// </summary>
        /// <param name="id">identificador del visitante</param>
        /// <returns></returns>
        public Task<Visitor> GetVisitorById(int id);

        /// <summary>
        /// Create
        /// </summary>
        /// <param name="description"></param>
        /// <returns></returns>
        Task<Visitor> Create(VisitorDto visitor);

        /// <summary>
        /// Delete visitor ById
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task DeleteVisitorById(int id);
    }
}
