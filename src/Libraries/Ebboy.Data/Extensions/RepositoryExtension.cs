using Ebboy.Core;
using Ebboy.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

using EntityFramework.Extensions;
using System.Linq.Dynamic;
using EntityFramework.Batch;
using System.Data.Entity.Core.Objects;
using EntityFramework.Mapping;
using EntityFramework;

namespace Ebboy.Data.Extensions
{
    public static class RepositoryExtension
    {
        /// <summary>
        /// The API was refactored to no longer need this extension method. Use query.Where(expression).Delete() syntax instead.
        /// </summary>
        /// <typeparam name="TEntity">The type of the entity.</typeparam>
        /// <param name="source">The source used to determine the table to delete from.</param>
        /// <param name="query">The IQueryable used to generate the where clause for the delete statement.</param>
        /// <returns>The number of row deleted.</returns>
        /// <remarks>
        /// When executing this method, the statement is immediately executed on the database provider
        /// and is not part of the change tracking system.  Also, changes will not be reflected on 
        /// any entities that have already been materialized in the current context.        
        /// </remarks>
        [Obsolete("The API was refactored to no longer need this extension method. Use query.Where(expression).Delete() syntax instead.")]
        public static int Deletes<TEntity>(
           this IQueryable<TEntity> source,
           IQueryable<TEntity> query)
           where TEntity : class
        {
            return query.Delete();
        }

        /// <summary>
        /// Executes a delete statement using an expression to filter the rows to be deleted.
        /// </summary>
        /// <typeparam name="TEntity">The type of the entity.</typeparam>
        /// <param name="source">The source used to determine the table to delete from.</param>
        /// <param name="filterExpression">The filter expression used to generate the where clause for the delete statement.</param>
        /// <returns>The number of row deleted.</returns>
        /// <example>Delete all users with email domain @test.com.
        /// <code><![CDATA[
        /// var db = new TrackerContext();
        /// string emailDomain = "@test.com";
        /// int count = db.Users.Delete(u => u.Email.EndsWith(emailDomain));
        /// ]]></code>
        /// </example>
        /// <remarks>
        /// When executing this method, the statement is immediately executed on the database provider
        /// and is not part of the change tracking system.  Also, changes will not be reflected on 
        /// any entities that have already been materialized in the current context.        
        /// </remarks>
        [Obsolete("The API was refactored to no longer need this extension method. Use query.Where(expression).Delete() syntax instead.")]
        public static int Deletes<TEntity>(
            this IQueryable<TEntity> source,
            Expression<Func<TEntity, bool>> filterExpression)
            where TEntity : class
        {
            return source.Where(filterExpression).Delete();
        }


        /// <summary>
        /// Executes a delete statement using the query to filter the rows to be deleted.
        /// </summary>
        /// <typeparam name="TEntity">The type of the entity.</typeparam>
        /// <param name="source">The <see cref="IQueryable`1"/> used to generate the where clause for the delete statement.</param>
        /// <returns>The number of row deleted.</returns>
        /// <example>Delete all users with email domain @test.com.
        /// <code><![CDATA[
        /// var db = new TrackerContext();
        /// string emailDomain = "@test.com";
        /// int count = db.Users.Where(u => u.Email.EndsWith(emailDomain)).Delete();
        /// ]]></code>
        /// </example>
        /// <remarks>
        /// When executing this method, the statement is immediately executed on the database provider
        /// and is not part of the change tracking system.  Also, changes will not be reflected on 
        /// any entities that have already been materialized in the current context.        
        /// </remarks>
        public static int Deletes<TEntity>(this IQueryable<TEntity> source)
            where TEntity : class
        {
            var runner = ResolveRunner();
            return runner.Delete(source.ToObjectQuery().Context, source.ToObjectQuery().GetEntityMap<TEntity>(), source.ToObjectQuery());
        }

        /// <summary>
        /// The API was refactored to no longer need this extension method. Use query.Where(expression).Update(updateExpression) syntax instead.
        /// </summary>
        /// <typeparam name="TEntity">The type of the entity.</typeparam>
        /// <param name="source">The source used to determine the table to update.</param>
        /// <param name="query">The query used to generate the where clause.</param>
        /// <param name="updateExpression">The MemberInitExpression used to indicate what is updated.</param>
        /// <returns>The number of row updated.</returns>
        /// <remarks>
        /// When executing this method, the statement is immediately executed on the database provider
        /// and is not part of the change tracking system.  Also, changes will not be reflected on 
        /// any entities that have already been materialized in the current context.        
        /// </remarks>
        [Obsolete("The API was refactored to no longer need this extension method. Use query.Where(expression).Update(updateExpression) syntax instead.")]
        public static int Updates<TEntity>(
            this IQueryable<TEntity> source,
            IQueryable<TEntity> query,
            Expression<Func<TEntity, TEntity>> updateExpression)
            where TEntity : class
        {
   
            ObjectQuery<TEntity> sourceQuery = source.ToObjectQuery();
            ObjectContext objectContext = sourceQuery.Context;
            EntityMap entityMap = sourceQuery.GetEntityMap<TEntity>();
            ObjectQuery<TEntity> objectQuery = query.ToObjectQuery();
            var runner = ResolveRunner();
            return runner.Update(objectContext, entityMap, objectQuery, updateExpression);
        }

        /// <summary>
        /// Executes an update statement using an expression to filter the rows that are updated.
        /// </summary>
        /// <typeparam name="TEntity">The type of the entity.</typeparam>
        /// <param name="source">The source used to determine the table to update.</param>
        /// <param name="filterExpression">The filter expression used to generate the where clause.</param>
        /// <param name="updateExpression">The <see cref="MemberInitExpression"/> used to indicate what is updated.</param>
        /// <returns>The number of row updated.</returns>
        /// <example>Update all users in the test.com domain to be inactive.
        /// <code><![CDATA[
        /// var db = new TrackerContext();
        /// string emailDomain = "@test.com";
        /// int count = db.Users.Update(
        ///   u => u.Email.EndsWith(emailDomain),
        ///   u => new User { IsApproved = false, LastActivityDate = DateTime.Now });
        /// ]]></code>
        /// </example>
        /// <remarks>
        /// When executing this method, the statement is immediately executed on the database provider
        /// and is not part of the change tracking system.  Also, changes will not be reflected on 
        /// any entities that have already been materialized in the current context.        
        /// </remarks>
        [Obsolete("The API was refactored to no longer need this extension method. Use query.Where(expression).Update(updateExpression) syntax instead.")]
        public static int Updates<TEntity>(
            this IQueryable<TEntity> source,
            Expression<Func<TEntity, bool>> filterExpression,
            Expression<Func<TEntity, TEntity>> updateExpression)
            where TEntity : class
        {
            return source.Where(filterExpression).Update(updateExpression);
        }

        /// <summary>
        /// Executes an update statement using the query to filter the rows to be updated.
        /// </summary>
        /// <typeparam name="TEntity">The type of the entity.</typeparam>
        /// <param name="source">The query used to generate the where clause.</param>
        /// <param name="updateExpression">The <see cref="MemberInitExpression"/> used to indicate what is updated.</param>
        /// <returns>The number of row updated.</returns>
        /// <example>Update all users in the test.com domain to be inactive.
        /// <code><![CDATA[
        /// var db = new TrackerContext();
        /// string emailDomain = "@test.com";
        /// int count = db.Users
        ///   .Where(u => u.Email.EndsWith(emailDomain))
        ///   .Update(u => new User { IsApproved = false, LastActivityDate = DateTime.Now });
        /// ]]></code>
        /// </example>
        /// <remarks>
        /// When executing this method, the statement is immediately executed on the database provider
        /// and is not part of the change tracking system.  Also, changes will not be reflected on 
        /// any entities that have already been materialized in the current context.        
        /// </remarks>
        public static int Updates<TEntity>(
            this IQueryable<TEntity> source,
            Expression<Func<TEntity, TEntity>> updateExpression)
            where TEntity : class
        {
            if (source == null)
                throw new ArgumentNullException("source");
            if (updateExpression == null)
                throw new ArgumentNullException("updateExpression");

            ObjectQuery<TEntity> sourceQuery = source.ToObjectQuery();
            if (sourceQuery == null)
                throw new ArgumentException("The query must be of type ObjectQuery or DbQuery.", "source");

            ObjectContext objectContext = sourceQuery.Context;
            if (objectContext == null)
                throw new ArgumentException("The ObjectContext for the query can not be null.", "source");

            EntityMap entityMap = sourceQuery.GetEntityMap<TEntity>();
            if (entityMap == null)
                throw new ArgumentException("Could not load the entity mapping information for the source.", "source");

            var runner = ResolveRunner();
            return runner.Update(objectContext, entityMap, sourceQuery, updateExpression);
        }

        private static IBatchRunner ResolveRunner()
        {
            var provider = Locator.Current.Resolve<IBatchRunner>();
            if (provider == null)
                throw new InvalidOperationException("Could not resolve the IBatchRunner. Make sure IBatchRunner is registered in the Locator.Current container.");

            return provider;
        }

    }
}
