using VanChi.Business.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace VanChi.Business.Concrete
{
    public partial class Business : IBusiness
    {
        #region GetItem
        public TDTO Shared_GetItem<TDTO, TEntity>() where TEntity : class
        {
            return this.UnitOfWork.GetItem<TDTO, TEntity>();
        }
        public TDTO Shared_GetItem<TDTO, TEntity>(Expression<Func<TEntity, bool>> filter) where TEntity : class
        {
            return this.UnitOfWork.GetItem<TDTO, TEntity>(filter);
        }
        public TDTO Shared_GetItem<TDTO, TEntity>(Expression<Func<TEntity, bool>> filter, List<Expression<Func<TEntity, object>>> includes) where TEntity : class
        {
            return this.UnitOfWork.GetItem<TDTO, TEntity>(filter, includes);
        }
        public async Task<TDTO> Shared_GetItemAsync<TDTO, TEntity>() where TEntity : class
        {
            return await this.UnitOfWork.GetItemAsync<TDTO, TEntity>();
        }
        public async Task<TDTO> Shared_GetItemAsync<TDTO, TEntity>(Expression<Func<TEntity, bool>> filter) where TEntity : class
        {
            return await this.UnitOfWork.GetItemAsync<TDTO, TEntity>(filter);
        }
        public async Task<TDTO> Shared_GetItemAsync<TDTO, TEntity>(Expression<Func<TEntity, bool>> filter, List<Expression<Func<TEntity, object>>> includes) where TEntity : class
        {
            return await this.UnitOfWork.GetItemAsync<TDTO, TEntity>(filter, includes);
        }

        #endregion

        #region GetItems
        public IList<TDTO> Shared_GetItems<TDTO, TEntity>() where TEntity : class
        {
            return this.UnitOfWork.GetItems<TDTO, TEntity>();
        }
        public IList<TDTO> Shared_GetItems<TDTO, TEntity>(Expression<Func<TEntity, bool>> filter) where TEntity : class
        {
            return this.UnitOfWork.GetItems<TDTO, TEntity>(filter);
        }
        public IList<TDTO> Shared_GetItems<TDTO, TEntity>(Expression<Func<TEntity, bool>> filter, List<Expression<Func<TEntity, object>>> includes) where TEntity : class
        {
            return this.UnitOfWork.GetItems<TDTO, TEntity>(filter, includes);
        }
        public IList<TDTO> Shared_GetItems<TDTO, TEntity>(out int total, Expression<Func<TEntity, bool>> filter = null, List<Expression<Func<TEntity, object>>> includes = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, int? pageIndex = null, int? pageSize = null) where TEntity : class
        {
            return this.UnitOfWork.GetItems<TDTO, TEntity>(out total, filter, includes, orderBy, pageIndex, pageSize);
        }
        public async Task<IList<TDTO>> Shared_GetItemsAsync<TDTO, TEntity>() where TEntity : class
        {
            return await this.UnitOfWork.GetItemsAsync<TDTO, TEntity>();
        }
        public async Task<IList<TDTO>> Shared_GetItemsAsync<TDTO, TEntity>(Expression<Func<TEntity, bool>> filter) where TEntity : class
        {
            return await this.UnitOfWork.GetItemsAsync<TDTO, TEntity>(filter);
        }
        public async Task<IList<TDTO>> Shared_GetItemsAsync<TDTO, TEntity>(Expression<Func<TEntity, bool>> filter, List<Expression<Func<TEntity, object>>> includes) where TEntity : class
        {
            return await this.UnitOfWork.GetItemsAsync<TDTO, TEntity>(filter, includes);
        }

        #endregion

        #region Insert
        public bool Shared_Insert<TDTO, TEntity>(TDTO m_DTO) where TEntity : class
        {
            return this.UnitOfWork.Insert<TDTO, TEntity>(m_DTO);
        }
        public object Shared_Insert<TDTO, TEntity>(TDTO m_DTO, Expression<Func<TEntity, object>> property) where TEntity : class
        {
            return this.UnitOfWork.Insert<TDTO, TEntity>(m_DTO, property);
        }
        public async Task<object> Shared_InsertAsync<TDTO, TEntity>(TDTO m_DTO) where TEntity : class
        {
            return await this.UnitOfWork.InsertAsync<TDTO, TEntity>(m_DTO);
        }

        #endregion

        #region Update
        public bool Shared_Update<TDTO, TEntity>(TDTO m_DTO) where TEntity : class
        {
            return this.UnitOfWork.Update<TDTO, TEntity>(m_DTO);
        }
        public bool Shared_Update<TDTO, TEntity>(TDTO m_DTO, List<Expression<Func<TEntity, object>>> properties) where TEntity : class
        {
            return this.UnitOfWork.Update<TDTO, TEntity>(m_DTO, properties);
        }
        public async Task<bool> Shared_UpdateAsync<TDTO, TEntity>(TDTO m_DTO) where TEntity : class, new()
        {
            return await this.UnitOfWork.UpdateAsync<TDTO, TEntity>(m_DTO);
        }

        #endregion

        #region Delete
        public bool Shared_Delete<TDTO, TEntity>(TDTO m_DTO) where TEntity : class
        {
            return this.UnitOfWork.Delete<TDTO, TEntity>(m_DTO);
        }
        public bool Shared_Delete<TDTO, TEntity>(Expression<Func<TEntity, bool>> filter) where TEntity : class
        {
            return this.UnitOfWork.Delete<TDTO, TEntity>(filter);
        }
        public async Task<bool> Shared_DeleteAsync<TDTO, TEntity>(TDTO m_DTO) where TEntity : class
        {
            return await this.UnitOfWork.DeleteAsync<TDTO, TEntity>(m_DTO);
        }

        #endregion

        #region Count
        public int Shared_Count<TDTO, TEntity>(Expression<Func<TEntity, bool>> filter, List<Expression<Func<TEntity, object>>> includes = null) where TEntity : class
        {
            return this.UnitOfWork.Count<TDTO, TEntity>(filter, includes);
        }
        public async Task<int> Shared_CountAsync<TDTO, TEntity>(Expression<Func<TEntity, bool>> filter, List<Expression<Func<TEntity, object>>> includes = null) where TEntity : class
        {
            return await this.UnitOfWork.CountAsync<TDTO, TEntity>(filter, includes);
        }

        #endregion

        #region Execute
        public DataSet Shared_ExecuteQuery(string procName, Dictionary<string, object> parameters)
        {
            return this.UnitOfWork.ExecuteQuery(procName, parameters);
        }
        public object Shared_ExecuteScalar(string procName, Dictionary<string, object> parameters)
        {
            return this.UnitOfWork.ExecuteScalar(procName, parameters);
        }
        public bool Shared_ExecuteNonQuery(string procName, Dictionary<string, object> parameters)
        {
            return this.UnitOfWork.ExecuteNonQuery(procName, parameters);
        }

        #endregion
    }
}
