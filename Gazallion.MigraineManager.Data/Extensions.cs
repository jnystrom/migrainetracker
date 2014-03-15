using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Gazallion.MigraineManager.Data.Extensions
{

    public enum SortDirection
    {
        Ascending,
        Descending
    }


    public class OrderByClause<T>
    where T : class, new()
    {
        private OrderByClause()
        {
        }
        public OrderByClause(
        Expression<Func<T, object>> orderBy,
        SortDirection sortDirection = SortDirection.Ascending)
        {
            OrderBy = orderBy;
            SortDirection = sortDirection;
        }
        /// <summary>
        /// Order by expression
        /// </summary>
        public Expression<Func<T, object>> OrderBy { get; private set; }
        /// <summary>
        /// Sort direction
        /// </summary>
        public SortDirection SortDirection { get; private set; }
    }
}
