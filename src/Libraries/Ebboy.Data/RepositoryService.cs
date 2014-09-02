using Ebboy.Core;
using Ebboy.Core.Data;
using System;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;

namespace Ebboy.Data
{
    /// <summary>
    /// 仓储实现
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public partial class RepositoryService<T> : IRepository<T> where T : BaseEntity
    {
        #region Fields
        private readonly IDbContext _context;
        private IDbSet<T> _entities;
        #endregion

        #region Ctor
        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="context">context</param>
        /// 创 建 者：Loamen.com
        public RepositoryService(IDbContext context)
        {
            this._context = context;
        }
        #endregion

        #region Methods
        /// <summary>
        /// 获取实体主键
        /// </summary>
        /// <param name="id">Identifier</param>
        /// <returns>Entity</returns>
        /// 创 建 者：Loamen.com
        public virtual T GetById(object id)
        {
            return this.Entities.Find(id);
        }

        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="entity">Entity</param>
        /// 创 建 者：Loamen.com
        public virtual void Insert(T entity)
        {
            try
            {
                if (entity == null)
                    throw new ArgumentNullException("entity");

                this.Entities.Add(entity);

                this._context.SaveChanges();
            }
            catch (DbEntityValidationException dbEx)
            {
                var msg = string.Empty;

                foreach (var validationErrors in dbEx.EntityValidationErrors)
                    foreach (var validationError in validationErrors.ValidationErrors)
                        msg += string.Format("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage) + Environment.NewLine;

                var fail = new Exception(msg, dbEx);
                //Debug.WriteLine(fail.Message, fail);
                throw fail;
            }
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="entity">Entity</param>
        /// 创 建 者：Loamen.com
        public virtual void Update(T entity)
        {
            try
            {
                if (entity == null)
                    throw new ArgumentNullException("entity");

                this._context.SaveChanges();
            }
            catch (DbEntityValidationException dbEx)
            {
                var msg = string.Empty;

                foreach (var validationErrors in dbEx.EntityValidationErrors)
                    foreach (var validationError in validationErrors.ValidationErrors)
                        msg += Environment.NewLine + string.Format("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage);

                var fail = new Exception(msg, dbEx);
                //Debug.WriteLine(fail.Message, fail);
                throw fail;
            }
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="entity">Entity</param>
        /// 创 建 者：Loamen.com
        public virtual void Delete(T entity)
        {
            try
            {
                if (entity == null)
                    throw new ArgumentNullException("entity");

                this.Entities.Remove(entity);

                this._context.SaveChanges();
            }
            catch (DbEntityValidationException dbEx)
            {
                var msg = string.Empty;

                foreach (var validationErrors in dbEx.EntityValidationErrors)
                    foreach (var validationError in validationErrors.ValidationErrors)
                        msg += Environment.NewLine + string.Format("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage);

                var fail = new Exception(msg, dbEx);
                //Debug.WriteLine(fail.Message, fail);
                throw fail;
            }
        }

        /// <summary>
        /// 查询列表
        /// </summary>
        /// 创 建 者：Loamen.com
        public virtual IQueryable<T> Table
        {
            get
            {
                return this.Entities;
            }
        }

        /// <summary>
        /// 返回一个新查询，其中返回的实体将不会在 System.Data.Entity.DbContext 或 System.Data.Entity.Core.Objects.ObjectContext
        ///     中进行缓存。此方法通过调用基础查询对象的 AsNoTracking 方法来运行。如果基础查询对象没有 AsNoTracking 方法，则调用此方法将不会有任何影响。
        /// </summary>
        /// 创 建 者：Loamen.com
        public virtual IQueryable<T> TableNoTracking
        {
            get
            {
                return this.Entities.AsNoTracking();
            }
        }

        /// <summary>
        /// Entities
        /// </summary>
        /// 创 建 者：Loamen.com
        protected virtual IDbSet<T> Entities
        {
            get
            {
                if (_entities == null)
                    _entities = _context.Set<T>();
                return _entities;
            }
        }
        #endregion
    }
}
