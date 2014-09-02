using Ebboy.Core;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Reflection;

namespace Ebboy.Data
{
    /// <summary>
    /// 数据上下文
    /// </summary>
    public class DataContext : DbContext, IDbContext
    {
        /// <summary>
        /// 设置
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <returns></returns>
        // 创 建 者：Loamen.com
        public new IDbSet<TEntity> Set<TEntity>() where TEntity : BaseEntity
        {
            return base.Set<TEntity>();
        }

        /// <summary>
        /// 重新实体创建
        /// </summary>
        /// <param name="modelBuilder"></param>
        // 创 建 者：Loamen.com
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            var typesToRegister = Assembly.GetExecutingAssembly().GetTypes()
            .Where(type => !String.IsNullOrEmpty(type.Namespace))
            .Where(type => type.BaseType != null && type.BaseType.IsGenericType && type.BaseType.GetGenericTypeDefinition() == typeof(EntityTypeConfiguration<>));
            foreach (var type in typesToRegister)
            {
                dynamic configurationInstance = Activator.CreateInstance(type);
                modelBuilder.Configurations.Add(configurationInstance);
            }
            base.OnModelCreating(modelBuilder);
        }

        /// <summary>
        /// 执行SQL
        /// </summary>
        /// <typeparam name="TElement"></typeparam>
        /// <param name="sql"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        // 创 建 者：Loamen.com
        public IEnumerable<TElement> SqlQuery<TElement>(string sql, params object[] parameters)
        {
            return this.Database.SqlQuery<TElement>(sql, parameters);
        }

        /// <summary>
        /// 事务命令
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="doNotEnsureTransaction"></param>
        /// <param name="timeout"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        // 创 建 者：Loamen.com
        public int ExecuteSqlCommand(string sql, bool doNotEnsureTransaction = false, int? timeout = null, params object[] parameters)
        {
            int? previousTimeout = null;
            if (timeout.HasValue)
            {
                //store previous timeout
                previousTimeout = ((IObjectContextAdapter)this).ObjectContext.CommandTimeout;
                ((IObjectContextAdapter)this).ObjectContext.CommandTimeout = timeout;
            }

            var transactionalBehavior = doNotEnsureTransaction
                ? TransactionalBehavior.DoNotEnsureTransaction
                : TransactionalBehavior.EnsureTransaction;
            var result = this.Database.ExecuteSqlCommand(transactionalBehavior, sql, parameters);

            if (timeout.HasValue)
            {
                //Set previous timeout back
                ((IObjectContextAdapter)this).ObjectContext.CommandTimeout = previousTimeout;
            }

            //return result
            return result;
        }
        #region Code First
        //public DbSet<Ebboy.Core.Domain.Users.SystemUser> SystemUsers { get; set; }
        //public System.Data.Entity.DbSet<Ebboy.Core.Domain.Tasks.Task> Tasks { get; set; }
        //public System.Data.Entity.DbSet<Ebboy.Core.Domain.Applications.Application> Applications { get; set; }
        //public System.Data.Entity.DbSet<Ebboy.Core.Domain.Companies.Company> Companies { get; set; }
        //public System.Data.Entity.DbSet<Ebboy.Core.Domain.Companies.CompanyEmployee> CompanyEmployees { get; set; }
        #endregion

      

    }
}
