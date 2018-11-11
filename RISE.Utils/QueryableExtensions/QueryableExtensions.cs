namespace RISE.Utils.QueryableExtensions
{
    using System.Linq;

    public static class QueryableExtensions
    {
        /// <summary>
        /// Paginates the query
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="query">Query</param>
        /// <param name="pageSize">Size of the page</param>
        /// <param name="pageIndex">Index of the page</param>
        /// <returns></returns>
        public static IQueryable<T> Paginate<T>(this IQueryable<T> query, int pageSize, int pageIndex)
        {
            return query
                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize);
        } 
    }
}