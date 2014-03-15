using Gazallion.MigraineManager.Data.Extensions;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Linq.Expressions;

namespace Gazallion.MigraineManager.Data.I
{
    public interface IRepository
    {
        /// <summary>
        /// Set connection string
        /// </summary>
        /// <param name="=">”</param>
        void SetConnectionString(string connectionStringName);
        /// <summary>
        /// Select data from database using a where clause
        /// </summary>
        /// <typeparam name="=">”</typeparam>
        IEnumerable<TItem> Select<TItem>(Expression<Func<TItem, bool>> whereClause = null, OrderByClause<TItem>[] orderBy = null, int skip = 0, int top = 0, string[] include = null)
            where TItem : class, new();
        /// <summary>
        /// Insert new item into database
        /// </summary>
        /// <typeparam name="=">”</typeparam>
        TItem Insert<TItem>(TItem item, bool saveImmediately = true)
            where TItem : class, new();
        /// <summary>
        /// Update an item
        /// </summary>
        /// <typeparam name="=">”</typeparam>
        TItem Update<TItem>(TItem item, bool saveImmediately = true)
            where TItem : class, new();
        /// <summary>
        /// Delete an item
        /// </summary>
        /// <typeparam name="=">”</typeparam>
        void Delete<TItem>(TItem item, bool saveImmediately = true)
            where TItem : class, new();
        /// <summary>
        /// Save all pending changes
        /// </summary>
        void Save();
    }
}
