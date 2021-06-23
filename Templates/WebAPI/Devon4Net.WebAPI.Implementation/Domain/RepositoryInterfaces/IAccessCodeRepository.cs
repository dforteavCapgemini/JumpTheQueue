using Devon4Net.Domain.UnitOfWork.Pagination;
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
    public interface IAccessCodeRepository 
    {
        /// <summary>
        /// Get The AccessCode by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<AccessCode> GetAccessCodeById(int id);
        //public Task<PaginationResult<AccessCode>> Get(int currentPage, int pageSize, Expression<Func<AccessCode, bool>> predicate = null);
        /// <summary>
        /// Obtiene la lista de los visitantes
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public Task<IList<AccessCode>> GetAccessCodes(Expression<Func<AccessCode, bool>> predicate = null);
        /// <summary>
        /// SaveAccessCode
        /// </summary>
        /// <param name="accessCodeEto"></param>
        /// <returns></returns>
        Task<AccessCode> CreateAccessCode(AccessCode accessCodeEto);
        /// <summary>
        /// Delete AccessCode
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task DeleteAccessCode(AccessCode accessCode);
    }
}
