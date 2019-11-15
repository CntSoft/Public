using AutoMapper;
using VanChi.Logs;
using VanChi.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace VanChi.Repository.EF
{
    public class UnitOfWork : IUnitOfWork
    {
        #region Properties
        protected DbContext Context { get; set; }

        #endregion

        #region Constructors
        public UnitOfWork(DbContext context)
        {
            context.Configuration.LazyLoadingEnabled = false;
            context.Configuration.ProxyCreationEnabled = false;
            this.Context = context;
        }

        #endregion

        #region Methods

        #region Transaction

        public DbContextTransaction BeginTransaction()
        {
            return this.Context.Database.BeginTransaction();
        }

        public void Rollback(DbContextTransaction transaction)
        {
            transaction.Rollback();
        }
        public void Commit(DbContextTransaction transaction)
        {
            try
            {
                transaction.Commit();
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
        }

        #endregion

        #region GetItem
        public TDTO GetItem<TDTO, TEntity>() where TEntity : class
        {
            try
            {
                DbSet<TEntity> dbSet = this.Context.Set<TEntity>();
                return Mapper.Map<TDTO>(dbSet.FirstOrDefault<TEntity>());
            }
            catch (Exception ex)
            {
                Logging.LogError("LacViet.HPS.EDO.Repository.EF-UnitOfWork-GetItem()", ex);
                return default(TDTO);
            }
        }
        public TDTO GetItem<TDTO, TEntity>(Expression<Func<TEntity, bool>> filter) where TEntity : class
        {
            try
            {
                DbSet<TEntity> dbSet = this.Context.Set<TEntity>();
                IQueryable<TEntity> queryDb = dbSet;
                queryDb = queryDb.Where(filter);
                return Mapper.Map<TDTO>(queryDb.FirstOrDefault());
            }
            catch (Exception ex)
            {
                Logging.LogError("LacViet.HPS.EDO.Repository.EF-UnitOfWork-GetItem(Expression<Func<TEntity, bool>> filter)", ex);
                return default(TDTO);
            }
        }
        public TDTO GetItem<TDTO, TEntity>(Expression<Func<TEntity, bool>> filter, List<Expression<Func<TEntity, object>>> includes) where TEntity : class
        {
            try
            {
                DbSet<TEntity> dbSet = this.Context.Set<TEntity>();
                IQueryable<TEntity> queryDb = dbSet;
                if (includes != null)
                {
                    queryDb = includes.Aggregate(queryDb, (current, include) => current.Include(include));
                }
                if (filter != null)
                {
                    queryDb = queryDb.Where(filter);
                }
                return Mapper.Map<TDTO>(queryDb.FirstOrDefault());
            }
            catch (Exception ex)
            {
                Logging.LogError("LacViet.HPS.EDO.Repository.EF-UnitOfWork-GetItem(Expression<Func<TEntity, bool>> filter, List<Expression<Func<TEntity, object>>> includes)", ex);
                return default(TDTO);
            }
        }
        public async Task<TDTO> GetItemAsync<TDTO, TEntity>() where TEntity : class
        {
            try
            {
                DbSet<TEntity> dbSet = this.Context.Set<TEntity>();
                return Mapper.Map<TDTO>(await dbSet.FirstOrDefaultAsync<TEntity>());
            }
            catch (Exception ex)
            {
                Logging.LogError("LacViet.HPS.EDO.Repository.EF-UnitOfWork-GetItemAsync()", ex);
                return default(TDTO);
            }
        }
        public async Task<TDTO> GetItemAsync<TDTO, TEntity>(Expression<Func<TEntity, bool>> filter) where TEntity : class
        {
            try
            {
                DbSet<TEntity> dbSet = this.Context.Set<TEntity>();
                IQueryable<TEntity> queryDb = dbSet;
                queryDb = queryDb.Where(filter);
                return Mapper.Map<TDTO>(await queryDb.FirstOrDefaultAsync());
            }
            catch (Exception ex)
            {
                Logging.LogError("LacViet.HPS.EDO.Repository.EF-UnitOfWork-GetItemAsync(Expression<Func<TEntity, bool>> filter)", ex);
                return default(TDTO);
            }
        }
        public async Task<TDTO> GetItemAsync<TDTO, TEntity>(Expression<Func<TEntity, bool>> filter, List<Expression<Func<TEntity, object>>> includes) where TEntity : class
        {
            try
            {
                DbSet<TEntity> dbSet = this.Context.Set<TEntity>();
                IQueryable<TEntity> queryDb = dbSet;
                if (includes != null)
                {
                    queryDb = includes.Aggregate(queryDb, (current, include) => current.Include(include));
                }
                if (filter != null)
                {
                    queryDb = queryDb.Where(filter);
                }
                return Mapper.Map<TDTO>(await queryDb.FirstOrDefaultAsync());
            }
            catch (Exception ex)
            {
                Logging.LogError("LacViet.HPS.EDO.Repository.EF-UnitOfWork-GetItemAsync(Expression<Func<TEntity, bool>> filter, List<Expression<Func<TEntity, object>>> includes)", ex);
                return default(TDTO);
            }
        }

        #endregion

        #region GetItems
        public IList<TDTO> GetItems<TDTO, TEntity>() where TEntity : class
        {
            try
            {
                DbSet<TEntity> dbSet = this.Context.Set<TEntity>();
                return Mapper.Map<IList<TDTO>>(dbSet.ToList<TEntity>());
            }
            catch (Exception ex)
            {
                Logging.LogError("LacViet.HPS.EDO.Repository.EF-UnitOfWork-GetItems()", ex);
                return default(IList<TDTO>);
            }
        }
        public IList<TDTO> GetItems<TDTO, TEntity>(Expression<Func<TEntity, bool>> filter) where TEntity : class
        {
            try
            {
                DbSet<TEntity> dbSet = this.Context.Set<TEntity>();
                IQueryable<TEntity> queryDb = dbSet;
                queryDb = queryDb.Where(filter);
                return Mapper.Map<IList<TDTO>>(queryDb.ToList());
            }
            catch (Exception ex)
            {
                Logging.LogError("LacViet.HPS.EDO.Repository.EF-UnitOfWork-GetItems(Expression<Func<TEntity, bool>> filter)", ex);
                return default(IList<TDTO>);
            }
        }
        public IList<TDTO> GetItems<TDTO, TEntity>(Expression<Func<TEntity, bool>> filter, List<Expression<Func<TEntity, object>>> includes) where TEntity : class
        {
            try
            {
                DbSet<TEntity> dbSet = this.Context.Set<TEntity>();
                IQueryable<TEntity> queryDb = dbSet;
                if (includes != null)
                {
                    queryDb = includes.Aggregate(queryDb, (current, include) => current.Include(include));
                }
                if (filter != null)
                {
                    queryDb = queryDb.Where(filter);
                }
                return Mapper.Map<IList<TDTO>>(queryDb.ToList());
            }
            catch (Exception ex)
            {
                Logging.LogError("LacViet.HPS.EDO.Repository.EF-UnitOfWork-GetItems(Expression<Func<TEntity, bool>> filter, List<Expression<Func<TEntity, object>>> includes)", ex);
                return default(IList<TDTO>);
            }
        }
        public IList<TDTO> GetItems<TDTO, TEntity>(out int total, Expression<Func<TEntity, bool>> filter = null, List<Expression<Func<TEntity, object>>> includes = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, int? pageIndex = null, int? pageSize = null) where TEntity : class
        {
            try
            {
                DbSet<TEntity> dbSet = this.Context.Set<TEntity>();
                IQueryable<TEntity> queryDb = dbSet;
                if (includes != null)
                {
                    queryDb = includes.Aggregate(queryDb, (current, include) => current.Include(include));
                }
                if (orderBy != null)
                {
                    queryDb = orderBy(queryDb);
                }
                if (filter != null)
                {
                    queryDb = queryDb.Where(filter);
                }
                total = queryDb.Count();
                if (pageIndex != null && pageSize != null)
                {
                    queryDb = queryDb.Skip((pageIndex.Value - 1) * pageSize.Value).Take(pageSize.Value);
                }
                return Mapper.Map<IList<TDTO>>(queryDb.ToList());
            }
            catch (Exception ex)
            {
                Logging.LogError("LacViet.HPS.EDO.Repository.EF-UnitOfWork-GetItems(out int total, Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, List<Expression<Func<TEntity, object>>> includes = null, int? pageIndex = null, int? pageSize = null)", ex);
                total = 0;
                return default(IList<TDTO>);
            }
        }
        public async Task<IList<TDTO>> GetItemsAsync<TDTO, TEntity>() where TEntity : class
        {
            try
            {
                DbSet<TEntity> dbSet = this.Context.Set<TEntity>();
                return Mapper.Map<IList<TDTO>>(await dbSet.ToListAsync<TEntity>());
            }
            catch (Exception ex)
            {
                Logging.LogError("LacViet.HPS.EDO.Repository.EF-UnitOfWork-GetItemsAsync()", ex);
                return default(IList<TDTO>);
            }
        }
        public async Task<IList<TDTO>> GetItemsAsync<TDTO, TEntity>(Expression<Func<TEntity, bool>> filter) where TEntity : class
        {
            try
            {
                DbSet<TEntity> dbSet = this.Context.Set<TEntity>();
                IQueryable<TEntity> queryDb = dbSet;
                queryDb = queryDb.Where(filter);
                return Mapper.Map<IList<TDTO>>(await queryDb.ToListAsync());
            }
            catch (Exception ex)
            {
                Logging.LogError("LacViet.HPS.EDO.Repository.EF-UnitOfWork-GetItemsAsync(Expression<Func<TEntity, bool>> filter)", ex);
                return default(IList<TDTO>);
            }
        }
        public async Task<IList<TDTO>> GetItemsAsync<TDTO, TEntity>(Expression<Func<TEntity, bool>> filter, List<Expression<Func<TEntity, object>>> includes) where TEntity : class
        {
            try
            {
                DbSet<TEntity> dbSet = this.Context.Set<TEntity>();
                IQueryable<TEntity> queryDb = dbSet;
                if (includes != null)
                {
                    queryDb = includes.Aggregate(queryDb, (current, include) => current.Include(include));
                }
                if (filter != null)
                {
                    queryDb = queryDb.Where(filter);
                }
                return Mapper.Map<IList<TDTO>>(await queryDb.ToListAsync());
            }
            catch (Exception ex)
            {
                Logging.LogError("LacViet.HPS.EDO.Repository.EF-UnitOfWork-GetItemsAsync(Expression<Func<TEntity, bool>> filter, List<Expression<Func<TEntity, object>>> includes)", ex);
                return default(IList<TDTO>);
            }
        }
        public IQueryable<TEntity> GetAll<TEntity>() where TEntity : class, new()
        {
            try
            {
                DbSet<TEntity> dbSet = this.Context.Set<TEntity>();
                return dbSet;
            }
            catch (Exception ex) { throw ex; }

        }
        public async Task<TEntity> GetSingle<TEntity>(Expression<Func<TEntity, bool>> filter) where TEntity : class, new()
        {
            return await this.GetAll<TEntity>().Where(filter).FirstOrDefaultAsync();
        }
        public async Task<TEntity> GetSingleLast<TEntity>(Expression<Func<TEntity, bool>> filter) where TEntity : class, new()
        {
            TEntity rs = null;
            try
            {
                await Task.Run(() =>
                {
                    rs = GetAll<TEntity>().Where(filter).ToList()?.LastOrDefault();

                });
            }
            catch (Exception)
            {

                throw;
            }
            return rs;
        }

        #endregion

        #region Insert
        public bool Insert<TDTO, TEntity>(TDTO m_DTO) where TEntity : class
        {
            try
            {
                DbSet<TEntity> dbSet = Context.Set<TEntity>();
                TEntity entity = Mapper.Map<TEntity>(m_DTO);
                dbSet.Add(entity);
                Context.SaveChanges();
                return true;
            }
            catch (Exception ex)// (DbEntityValidationException dbex)
            {
                Logging.LogError("LacViet.HPS.EDO.Repository.EF-UnitOfWork-Insert(TDTO m_DTO)", ex);
                return false;
            }
        }
        public object Insert<TDTO, TEntity>(TDTO m_DTO, Expression<Func<TEntity, object>> property) where TEntity : class
        {
            try
            {
                DbSet<TEntity> dbSet = this.Context.Set<TEntity>();
                TEntity entity = Mapper.Map<TEntity>(m_DTO);
                dbSet.Add(entity);
                this.Context.SaveChanges();
                this.Context.Entry(entity).GetDatabaseValues();
                var entry = this.Context.Entry(entity);
                return entry.Property(property).CurrentValue;
            }
            catch (Exception ex)
            {
                Logging.LogError("LacViet.HPS.EDO.Repository.EF-UnitOfWork-Insert(TDTO m_DTO, Expression<Func<TEntity, object>> property)", ex);
                return null;
            }
        }
        public async Task<object> InsertAsync<TDTO, TEntity>(TDTO m_DTO) where TEntity : class
        {
            try
            {
                DbSet<TEntity> dbSet = Context.Set<TEntity>();
                TEntity entity = Mapper.Map<TEntity>(m_DTO);
                dbSet.Add(entity);
                await Context.SaveChangesAsync();
                return entity;
            }
            catch (Exception ex)// (DbEntityValidationException dbex)
            {
                Logging.LogError("LacViet.HPS.EDO.Repository.EF-UnitOfWork-InsertAsync(TDTO m_DTO)", ex);
                return null;
            }
        }
        public List<object> InsertToList<TDTO, TEntity>(List<TDTO> lstDTO) where TEntity : class
        {
            try
            {
                var lstEntity = new List<object>();
                foreach (var item in lstDTO)
                {
                    DbSet<TEntity> dbSet = Context.Set<TEntity>();
                    TEntity entity = Mapper.Map<TEntity>(item);
                    dbSet.Add(entity);
                    lstEntity.Add(entity);
                }
                Context.SaveChanges();
                return lstEntity;
            }
            catch (Exception ex)// (DbEntityValidationException dbex)
            {
                Logging.LogError("LacViet.HPS.EDO.Repository.EF-UnitOfWork-InsertToList(TDTO lstDTO)", ex);
                return new List<object>();
            }
        }
        public async Task<TEntity> InsertEntityAsync<TEntity>(TEntity entity) where TEntity : class, new()
        {
            try
            {
                this.Context.Set<TEntity>().Add(entity);
                await this.Context.SaveChangesAsync();
                return entity;
            }
            catch (Exception ex)// (DbEntityValidationException dbex)
            {
                Logging.LogError("LacViet.HPS.EDO.Repository.EF-UnitOfWork-InsertAsync(TDTO m_DTO)", ex);
                return null;
            }
        }
        public async Task<List<object>> InsertToListAsync<TDTO, TEntity>(List<TDTO> lstDTO) where TEntity : class
        {
            try
            {
                var lstEntity = new List<object>();
                foreach (var item in lstDTO)
                {
                    DbSet<TEntity> dbSet = Context.Set<TEntity>();
                    TEntity entity = Mapper.Map<TEntity>(item);
                    dbSet.Add(entity);
                    lstEntity.Add(entity);
                }
                await Context.SaveChangesAsync();
                return lstEntity;
            }
            catch (Exception ex)// (DbEntityValidationException dbex)
            {
                Logging.LogError("LacViet.HPS.EDO.Repository.EF-UnitOfWork-InsertToListAsync(TDTO lstDTO)", ex);
                return new List<object>();
            }
        }
        public async Task<List<TEntity>> InsertToListEntityAsync<TEntity>(List<TEntity> lstEntity) where TEntity : class, new()
        {
            try
            {
                foreach (var item in lstEntity)
                {
                    this.Context.Set<TEntity>().Add(item);
                }
                await this.Context.SaveChangesAsync();
                return lstEntity;
            }
            catch (Exception ex)// (DbEntityValidationException dbex)
            {
                Logging.LogError("LacViet.HPS.EDO.Repository.EF-UnitOfWork-InsertAsync(TDTO m_DTO)", ex);
                return null;
            }
        }

        #endregion

        #region Update
        public bool Update<TDTO, TEntity>(TDTO m_DTO) where TEntity : class
        {
            try
            {
                DbSet<TEntity> dbSet = this.Context.Set<TEntity>();
                TEntity entity = Mapper.Map<TEntity>(m_DTO);
                dbSet.Attach(entity);
                this.Context.Entry(entity).State = System.Data.Entity.EntityState.Modified;
                this.Context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Logging.LogError("LacViet.HPS.EDO.Repository.EF-UnitOfWork-Update(TDTO m_DTO)", ex);
                return false;
            }
        }
        public bool Update<TDTO, TEntity>(TDTO m_DTO, List<Expression<Func<TEntity, object>>> properties) where TEntity : class
        {
            try
            {
                DbSet<TEntity> dbSet = this.Context.Set<TEntity>();
                TEntity entity = Mapper.Map<TEntity>(m_DTO);
                dbSet.Attach(entity);
                var entry = this.Context.Entry(entity);
                foreach (var property in properties)
                {
                    entry.Property(property).IsModified = true;
                }
                this.Context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Logging.LogError("LacViet.HPS.EDO.Repository.EF-UnitOfWork-Update(TDTO m_DTO, List<Expression<Func<TEntity, object>>> properties)", ex);
                return false;
            }
        }
        public bool UpdateToList<TDTO, TEntity>(List<TDTO> lstDTO) where TEntity : class
        {
            try
            {
                foreach (var item in lstDTO)
                {
                    DbSet<TEntity> dbSet = this.Context.Set<TEntity>();
                    TEntity entity = Mapper.Map<TEntity>(item);
                    dbSet.Attach(entity);
                    this.Context.Entry(entity).State = System.Data.Entity.EntityState.Modified;
                }
                this.Context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Logging.LogError("LacViet.HPS.EDO.Repository.EF-UnitOfWork-UpdateToList(TDTO lstDTO)", ex);
                return false;
            }
        }
        public async Task<bool> UpdateAsync<TDTO, TEntity>(TDTO m_DTO) where TEntity : class, new()
        {
            try
            {
                DbSet<TEntity> dbSet = this.Context.Set<TEntity>();
                TEntity entity = Mapper.Map<TEntity>(m_DTO);
                dbSet.Attach(entity);
                this.Context.Entry(entity).State = EntityState.Modified;
                await this.Context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                Logging.LogError("LacViet.HPS.EDO.Repository.EF-UnitOfWork-UpdateAsync(TDTO m_DTO)", ex);
                return false;
            }
        }
        public async Task<bool> UpdateEntityAsync<T>(T updateEntity) where T : class, new()
        {
            var result = false;
            try
            {
                this.Context.Entry(updateEntity).State = EntityState.Modified;
                await this.Context.SaveChangesAsync();
                result = true;
            }
            catch (Exception ex)
            {
                result = false;
                throw new Exception("Update Entity in Repository error", ex);
            }
            return result;
        }
        public async Task<bool> UpdateToListAsync<TDTO, TEntity>(List<TDTO> lstDTO) where TEntity : class
        {
            try
            {
                foreach (var item in lstDTO)
                {
                    DbSet<TEntity> dbSet = this.Context.Set<TEntity>();
                    TEntity entity = Mapper.Map<TEntity>(item);
                    dbSet.Attach(entity);
                    this.Context.Entry(entity).State = System.Data.Entity.EntityState.Modified;
                }
                await this.Context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                Logging.LogError("LacViet.HPS.EDO.Repository.EF-UnitOfWork-UpdateToListAsync(TDTO lstDTO)", ex);
                return false;
            }
        }
        public async Task<bool> UpdateToListEntityAsync<TEntity>(List<TEntity> lstEntity) where TEntity : class, new()
        {
            var result = false;
            try
            {
                foreach (var item in lstEntity)
                {
                    this.Context.Entry(item).State = EntityState.Modified;
                }
                await this.Context.SaveChangesAsync();
                result = true;
            }
            catch (Exception ex)
            {
                result = false;
                throw new Exception("Update Entity in Repository error", ex);
            }
            return result;
        }

        #endregion

        #region Delete
        public bool Delete<TDTO, TEntity>(TDTO m_DTO) where TEntity : class
        {
            try
            {
                DbSet<TEntity> dbSet = this.Context.Set<TEntity>();
                TEntity entity = Mapper.Map<TEntity>(m_DTO);
                if (this.Context.Entry(entity).State == System.Data.Entity.EntityState.Detached)
                {
                    dbSet.Attach(entity);
                }
                dbSet.Remove(entity);
                this.Context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Logging.LogError("LacViet.HPS.EDO.Repository.EF-UnitOfWork-Delete(TDTO m_DTO)", ex);
                return false;
            }
        }
        public bool Delete<TDTO, TEntity>(Expression<Func<TEntity, bool>> filter) where TEntity : class
        {
            try
            {
                DbSet<TEntity> dbSet = this.Context.Set<TEntity>();
                IQueryable<TEntity> queryDb = dbSet;
                queryDb = queryDb.Where(filter);
                TEntity entity = queryDb.FirstOrDefault();
                if (this.Context.Entry(entity).State == System.Data.Entity.EntityState.Detached)
                {
                    dbSet.Attach(entity);
                }
                dbSet.Remove(entity);
                this.Context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Logging.LogError("LacViet.HPS.EDO.Repository.EF-UnitOfWork-Delete(Expression<Func<TEntity, bool>> filter)", ex);
                return false;
            }
        }
        public bool DeleteToList<TDTO, TEntity>(List<TDTO> lstDTO) where TEntity : class
        {
            try
            {
                foreach (var item in lstDTO)
                {
                    DbSet<TEntity> dbSet = this.Context.Set<TEntity>();
                    TEntity entity = Mapper.Map<TEntity>(item);
                    if (this.Context.Entry(entity).State == System.Data.Entity.EntityState.Detached)
                    {
                        dbSet.Attach(entity);
                    }
                    dbSet.Remove(entity);
                }
                this.Context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Logging.LogError("LacViet.HPS.EDO.Repository.EF-UnitOfWork-DeleteToList(TDTO lstDTO)", ex);
                return false;
            }
        }
        public async Task<bool> DeleteAsync<TDTO, TEntity>(TDTO m_DTO) where TEntity : class
        {
            try
            {
                DbSet<TEntity> dbSet = this.Context.Set<TEntity>();
                TEntity entity = Mapper.Map<TEntity>(m_DTO);
                if (this.Context.Entry(entity).State == System.Data.Entity.EntityState.Detached)
                {
                    dbSet.Attach(entity);
                }
                dbSet.Remove(entity);
                await this.Context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                Logging.LogError("LacViet.HPS.EDO.Repository.EF-UnitOfWork-DeleteAsync(TDTO m_DTO)", ex);
                return false;
            }
        }
        public async Task<bool> DeleteAsync<TEntity>(TEntity deleteEntity) where TEntity : class, new()
        {
            try
            {
                //deleteEntity.ActiveFag = AppValues.ActiveFag.StatusDelete;
                this.Context.Set<TEntity>().Attach(deleteEntity);
                var entry = this.Context.Entry(deleteEntity);
                // entry.Property(x => x.ActiveFag).IsModified = true;
                await this.Context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Delete Entity in Repository", ex);
                //Logger.Error(ex);
                //return false;
            }

        }
        public async Task<bool> DeleteAsync<T>(Expression<Func<T, bool>> expression, string id = null) where T : class, new()
        {
            T entity;
            //Find PrimaryKey ID
            if (!string.IsNullOrEmpty(id))
                entity = this.Context.Set<T>().Find(id);
            else
                entity = this.Context.Set<T>().SingleOrDefault(expression);
            return await this.DeleteAsync(entity);


        }
        public async Task<bool> DeleteToListAsync<TEntity>(List<TEntity> lstEntity) where TEntity : class, new()
        {
            try
            {
                foreach (var item in lstEntity)
                {
                    //deleteEntity.ActiveFag = AppValues.ActiveFag.StatusDelete;
                    this.Context.Set<TEntity>().Attach(item);
                    var entry = this.Context.Entry(item);
                    // entry.Property(x => x.ActiveFag).IsModified = true;
                }
                await this.Context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
                throw ex;

            }
        }

        #endregion

        #region Count
        public int Count<TDTO, TEntity>(Expression<Func<TEntity, bool>> filter, List<Expression<Func<TEntity, object>>> includes = null) where TEntity : class
        {
            try
            {
                DbSet<TEntity> dbSet = this.Context.Set<TEntity>();
                IQueryable<TEntity> queryDb = dbSet;
                if (includes != null)
                {
                    queryDb = includes.Aggregate(queryDb, (current, include) => current.Include(include));
                }
                queryDb = queryDb.Where(filter);
                return queryDb.Count();
            }
            catch (Exception ex)
            {
                Logging.LogError("LacViet.HPS.EDO.Repository.EF-UnitOfWork-Count(Expression<Func<TEntity, bool>> filter, List<Expression<Func<TEntity, object>>> includes = null)", ex);
                return 0;
            }
        }
        public async Task<int> CountAsync<TDTO, TEntity>(Expression<Func<TEntity, bool>> filter, List<Expression<Func<TEntity, object>>> includes = null) where TEntity : class
        {
            try
            {
                DbSet<TEntity> dbSet = this.Context.Set<TEntity>();
                IQueryable<TEntity> queryDb = dbSet;
                if (includes != null)
                {
                    queryDb = includes.Aggregate(queryDb, (current, include) => current.Include(include));
                }
                queryDb = queryDb.Where(filter);
                return await queryDb.CountAsync();
            }
            catch (Exception ex)
            {
                Logging.LogError("LacViet.HPS.EDO.Repository.EF-UnitOfWork-CountAsync(Expression<Func<TEntity, bool>> filter, List<Expression<Func<TEntity, object>>> includes = null)", ex);
                return 0;
            }
        }

        #endregion

        #region Execute
        public DataSet ExecuteQuery(string sql, Dictionary<string, object> parameters)
        {
            DataSet ds = new DataSet();
            DbConnection conn = this.Context.Database.Connection;
            ConnectionState initialState = conn.State;
            try
            {
                if (initialState != ConnectionState.Open)
                    conn.Open();
                using (DbCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = sql;
                    cmd.CommandTimeout = 120;
                    if (parameters != null && parameters.Count() > 0)
                    {
                        foreach (var item in parameters)
                        {
                            cmd.Parameters.Add(new SqlParameter(item.Key, item.Value));
                        }
                    }
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (DbDataAdapter ad = new SqlDataAdapter())
                    {
                        ad.SelectCommand = cmd;
                        ad.Fill(ds);
                    }
                }
            }
            catch (Exception ex)
            {
                Logging.LogError("LacViet.HPS.EDO.Repository.EF-UnitOfWork-ExecuteQuery(string sql, params object[] parameters)", ex);
            }
            finally
            {
                if (initialState != ConnectionState.Open)
                    conn.Close();
            }
            return ds;
        }
        public async Task<DataSet> ExecuteQueryAsync(string sql, Dictionary<string, object> parameters)
        {
            DataSet ds = new DataSet();
            DbConnection conn = this.Context.Database.Connection;
            ConnectionState initialState = conn.State;
            try
            {
                if (initialState != ConnectionState.Open)
                    conn.Open();
                using (DbCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = sql;
                    cmd.CommandTimeout = 120;
                    if (parameters != null && parameters.Count() > 0)
                    {
                        foreach (var item in parameters)
                        {
                            cmd.Parameters.Add(new SqlParameter(item.Key, item.Value));
                        }
                    }
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (DbDataAdapter ad = new SqlDataAdapter())
                    {
                        ad.SelectCommand = cmd;
                        await Task.Run(() => { ad.Fill(ds); });
                    }
                }
            }
            catch (Exception ex)
            {
                Logging.LogError("LacViet.HPS.EDO.Repository.EF-UnitOfWork-ExecuteQueryAsync(string sql, params object[] parameters)", ex);
            }
            finally
            {
                if (initialState != ConnectionState.Open)
                    conn.Close();
            }
            return ds;
        }
        public async Task<DataSet> ExecuteQueryAsyncConvertStringEmtyToNull(string sql, Dictionary<string, object> parameters)
        {
            DataSet ds = new DataSet();
            DbConnection conn = this.Context.Database.Connection;
            ConnectionState initialState = conn.State;
            try
            {
                if (initialState != ConnectionState.Open)
                    conn.Open();
                using (DbCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = sql;
                    cmd.CommandTimeout = 120;
                    if (parameters != null && parameters.Count() > 0)
                    {
                        foreach (var item in parameters)
                        {
                            if (item.Value?.ToString() == string.Empty || item.Value == null)
                            {
                                cmd.Parameters.Add(new SqlParameter(item.Key, DBNull.Value));
                            }
                            else
                            {
                                cmd.Parameters.Add(new SqlParameter(item.Key, item.Value));
                            }
                        }
                    }
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (DbDataAdapter ad = new SqlDataAdapter())
                    {
                        ad.SelectCommand = cmd;
                        await Task.Run(() => { ad.Fill(ds); });
                    }
                }
            }
            catch (Exception ex)
            {
                Logging.LogError("LacViet.HPS.EDO.Repository.EF-UnitOfWork-ExecuteQueryAsyncConvertStringEmtyToNull(string sql, params object[] parameters)", ex);
            }
            finally
            {
                if (initialState != ConnectionState.Open)
                    conn.Close();
            }
            return ds;
        }
        public object ExecuteScalar(string sql, Dictionary<string, object> parameters)
        {
            DbConnection conn = this.Context.Database.Connection;
            ConnectionState initialState = conn.State;
            try
            {
                if (initialState != ConnectionState.Open)
                    conn.Open();
                using (DbCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = sql;
                    cmd.CommandTimeout = 120;
                    if (parameters != null && parameters.Count() > 0)
                    {
                        foreach (var item in parameters)
                        {
                            cmd.Parameters.Add(new SqlParameter(item.Key, item.Value));
                        }
                    }
                    cmd.CommandType = CommandType.StoredProcedure;
                    return cmd.ExecuteScalar();
                }
            }
            catch (Exception ex)
            {
                Logging.LogError("LacViet.HPS.EDO.Repository.EF-UnitOfWork-ExecuteScalar(string sql, params object[] parameters)", ex);
            }
            finally
            {
                if (initialState != ConnectionState.Open)
                    conn.Close();
            }
            return null;
        }
        public async Task<object> ExecuteScalarAsync(string sql, Dictionary<string, object> parameters)
        {
            DbConnection conn = this.Context.Database.Connection;
            ConnectionState initialState = conn.State;
            try
            {
                if (initialState != ConnectionState.Open)
                    conn.Open();
                using (DbCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = sql;
                    cmd.CommandTimeout = 120;
                    if (parameters != null && parameters.Count() > 0)
                    {
                        foreach (var item in parameters)
                        {
                            cmd.Parameters.Add(new SqlParameter(item.Key, item.Value));
                        }
                    }
                    cmd.CommandType = CommandType.StoredProcedure;
                    object result = await Task.Run(() => cmd.ExecuteScalar());
                    return result;
                }
            }
            catch (Exception ex)
            {
                Logging.LogError("LacViet.HPS.EDO.Repository.EF-UnitOfWork-ExecuteScalarAsync(string sql, params object[] parameters)", ex);
            }
            finally
            {
                if (initialState != ConnectionState.Open)
                    conn.Close();
            }
            return null;
        }
        public bool ExecuteNonQuery(string sql, Dictionary<string, object> parameters)
        {
            DbConnection conn = this.Context.Database.Connection;
            ConnectionState initialState = conn.State;
            try
            {
                if (initialState != ConnectionState.Open)
                    conn.Open();
                using (DbCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = sql;
                    cmd.CommandTimeout = 120;
                    if (parameters != null && parameters.Count() > 0)
                    {
                        foreach (var item in parameters)
                        {
                            cmd.Parameters.Add(new SqlParameter(item.Key, item.Value));
                        }
                    }
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                    return true;
                }
            }
            catch (Exception ex)
            {
                Logging.LogError("LacViet.HPS.EDO.Repository.EF-UnitOfWork-ExecuteNonQuery(string sql, params object[] parameters)", ex);
            }
            finally
            {
                if (initialState != ConnectionState.Open)
                    conn.Close();
            }
            return false;
        }
        public async Task<bool> ExecuteNonQueryAsync(string sql, Dictionary<string, object> parameters)
        {
            DbConnection conn = this.Context.Database.Connection;
            ConnectionState initialState = conn.State;
            try
            {
                if (initialState != ConnectionState.Open)
                    conn.Open();
                using (DbCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = sql;
                    cmd.CommandTimeout = 120;
                    if (parameters != null && parameters.Count() > 0)
                    {
                        foreach (var item in parameters)
                        {
                            cmd.Parameters.Add(new SqlParameter(item.Key, item.Value));
                        }
                    }
                    cmd.CommandType = CommandType.StoredProcedure;
                    var result = await cmd.ExecuteNonQueryAsync();
                    return true;
                }
            }
            catch (Exception ex)
            {
                Logging.LogError("LacViet.HPS.EDO.Repository.EF-UnitOfWork-ExecuteNonQuery(string sql, params object[] parameters)", ex);
            }
            finally
            {
                if (initialState != ConnectionState.Open)
                    conn.Close();
            }
            return false;
        }
        public async Task<bool> ExecuteNonQueryAsyncConvertStringEmtyToNull(string sql, Dictionary<string, object> parameters)
        {
            DbConnection conn = this.Context.Database.Connection;
            ConnectionState initialState = conn.State;
            try
            {
                if (initialState != ConnectionState.Open)
                    conn.Open();
                using (DbCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = sql;
                    cmd.CommandTimeout = 120;
                    if (parameters != null && parameters.Count() > 0)
                    {
                        foreach (var item in parameters)
                        {
                            if (item.Value.ToString() == string.Empty)
                            {
                                cmd.Parameters.Add(new SqlParameter(item.Key, DBNull.Value));
                            }
                            else
                            {
                                cmd.Parameters.Add(new SqlParameter(item.Key, item.Value));
                            }
                        }
                    }
                    cmd.CommandType = CommandType.StoredProcedure;
                    var result = await cmd.ExecuteNonQueryAsync();
                    return true;
                }
            }
            catch (Exception ex)
            {
                Logging.LogError("LacViet.HPS.EDO.Repository.EF-UnitOfWork-ExecuteNonQueryAsyncConvertStringEmtyToNull(string sql, params object[] parameters)", ex);
            }
            finally
            {
                if (initialState != ConnectionState.Open)
                    conn.Close();
            }
            return false;
        }

        #endregion

        #endregion

        #region Constants

        #endregion
    }
}
