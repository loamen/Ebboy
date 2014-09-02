using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ebboy.Core.Data
{
    /// <summary>
    /// 仓储接口
    /// </summary>
    public partial interface IRepository<T> where T : BaseEntity
    {
        /// <summary>
        /// 根据主键获取实体
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns>实体</returns>
        /// 创 建 者：Loamen.com
        T GetById(object id);

        /// <summary>
        /// 新增实体
        /// </summary>
        /// <param name="entity">实体</param>
        /// 创 建 者：Loamen.com
        void Insert(T entity);

        /// <summary>
        /// 更新实体
        /// </summary>
        /// <param name="entity">实体</param>
        /// 创 建 者：Loamen.com
        void Update(T entity);

        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="entity">实体</param>
        /// 创 建 者：Loamen.com
        void Delete(T entity);

        /// <summary>
        /// 获取实体列表
        /// </summary>
        /// 创 建 者：Loamen.com
        IQueryable<T> Table { get; }

        /// <summary>
        /// 返回一个新查询，其中返回的实体将不会在 System.Data.Entity.DbContext 或 System.Data.Entity.Core.Objects.ObjectContext
        ///     中进行缓存。此方法通过调用基础查询对象的 AsNoTracking 方法来运行。如果基础查询对象没有 AsNoTracking 方法，则调用此方法将不会有任何影响。
        /// </summary>
        /// 创 建 者：Loamen.com
        IQueryable<T> TableNoTracking { get; }
    }
}
