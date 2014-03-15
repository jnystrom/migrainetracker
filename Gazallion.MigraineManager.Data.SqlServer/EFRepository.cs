using Gazallion.MigraineManager.Data.Extensions;
using Gazallion.MigraineManager.Data.I;
using Gazallion.MigraineManager.Data.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace Gazallion.MigraineManager.Data.SqlServer
{
    public class EFRepository<TContext> : IDisposable, IRepository
    where TContext : DbContext, new()
    {
        private TContext context;
        /// <summary>
        /// Create new instance of repository
        /// </summary>
        public EFRepository()
        {
            context = new TContext();
            context.Configuration.ProxyCreationEnabled = false;
        }
        /// <summary>
        /// Set connection string
        /// </summary>
        /// <param name=”connectionStringName”>Connection string name from .config file</param>
        public void SetConnectionString(string connectionStringName)
        {
            context.Database.Connection.ConnectionString =
            ConfigurationManager.ConnectionStrings[connectionStringName].ConnectionString;
        }
        /// <summary>
        /// Select data from database using a where clause
        /// </summary>
        /// <typeparam name=”TItem”>Type of data to select</typeparam>
        /// <param name=”whereClause”>Where clause / function</param>
        /// <param name=”orderBy”>Order by clause</param>
        /// <param name=”skip”>Paging implementation = number of records to skip</param>
        /// <param name=”top”>Paging implementation = number of records to return</param>
        /// <param name=”include”>Navigation properties to include</param>
        /// <returns>Items selected</returns>
        public IEnumerable<TItem> Select<TItem>(
        Expression<Func<TItem, bool>> whereClause = null,
        OrderByClause<TItem>[] orderBy = null,
        int skip = 0,
        int top = 0,
        string[] include = null)
        where TItem : class, new()
        {
            IQueryable<TItem> data = context.Set<TItem>();
            // handle where
            if (whereClause != null)
            {
                data = data.Where(whereClause);
            }
            //handle order by
            if (orderBy != null)
            {
                int iteration = 0;
                orderBy.ToList().ForEach(one =>
                {
                    if (iteration == 0)
                    {
                        if (one.SortDirection == SortDirection.Ascending)
                        {
                            data = data.OrderBy(one.OrderBy);
                        }
                        else
                        {
                            data = data.OrderByDescending(one.OrderBy);
                        }
                    }
                    else
                    {
                        if (one.SortDirection == SortDirection.Ascending)
                        {
                            data = ((IOrderedQueryable<TItem>)data).ThenBy(one.OrderBy);
                        }
                        else
                        {
                            data = ((IOrderedQueryable<TItem>)data).ThenByDescending(one.OrderBy);
                        }
                    }
                    iteration++;
                });
            }
            // handle paging
            if (skip > 0)
            {
                data = data.Skip(skip);
            }
            if (top > 0)
            {
                data = data.Take(top);
            }
            //handle includes
            if (include != null)
            {
                include.ToList().ForEach(one => data = data.Include(one));
            }
            foreach (var item in data)
            {
                yield return item;
            }
        }
        /// <summary>
        /// Insert new item into database
        /// </summary>
        /// <typeparam name=”TItem”>Type of item to insert</typeparam>
        /// <param name=”item”>Item to insert</param>
        /// <param name=”saveImmediately”>If set to true, saved occurs right away</param>
        /// <returns>Inserted item</returns>
        public TItem Insert<TItem>(TItem item, bool saveImmediately = true)
        where TItem : class, new()
        {
            DbSet<TItem> set = context.Set<TItem>();
            set.Add(item);
            if (saveImmediately)
            {
                context.SaveChanges();
            }
            return item;
        }
        /// <summary>
        /// Update an item
        /// </summary>
        /// <typeparam name=”TItem”>Type of item to update</typeparam>
        /// <param name=”item”>Item to update</param>
        /// <param name=”saveImmediately”>If set to true, saved occurs right away</param>
        /// <returns>Updated item</returns>
        public TItem Update<TItem>(TItem item, bool saveImmediately = true)
        where TItem : class, new()
        {
            DbSet<TItem> set = context.Set<TItem>();
            var entry = context.Entry(item);
            if (entry != null)
            {
                // entity is already in memory
                entry.State = System.Data.EntityState.Modified;
            }
            else
            {
                set.Attach(item);
                context.Entry(item).State = System.Data.EntityState.Modified;
            }
            if (saveImmediately)
            {
                context.SaveChanges();
            }
            return item;
        }
        /// <summary>
        /// Delete an item
        /// </summary>
        /// <typeparam name=”TItem”>Type of item to delete</typeparam>
        /// <param name=”saveImmediately”>If set to true, saved occurs right away</param>
        /// <param name=”item”>Item to delete</param>
        public void Delete<TItem>(TItem item, bool saveImmediately = true)
        where TItem : class, new()
        {
            DbSet<TItem> set = context.Set<TItem>();
            var entry = context.Entry(item);
            if (entry != null)
            {
                // entity is already in memory
                entry.State = System.Data.EntityState.Deleted;
            }
            else
            {
                set.Attach(item);
                context.Entry(item).State = System.Data.EntityState.Deleted;
            }
            if (saveImmediately)
            {
                context.SaveChanges();
            }
        }
        /// <summary>
        /// Save all pending changes
        /// </summary>
        public void Save()
        {
            context.SaveChanges();
        }
        /// <summary>
        /// Dispose context
        /// </summary>
        public void Dispose()
        {
            if (context != null)
            {
                context.Dispose();
            }
        }
    }
}

