using Agrivi.Web.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Agrivi.Web.Helpers.Pagination
{
    public static class PaginationHelper
    {
        public static Page<T> GetPage<T>(IQueryable<T> queryiable, int pageNumber, int pageSize)
        {
            int totalItems = queryiable.Count();
            int totalPages = (int)Math.Ceiling((decimal)totalItems / pageSize);
            int skip = (pageNumber - 1) * pageSize;
            IEnumerable<T> items = queryiable.Skip(skip).Take(pageSize).ToArray();

            return new Page<T>
            {
                PageNumber = pageNumber,
                PageSize = pageSize,
                TotalPages = totalPages,
                TotalItems = totalItems,
                Items = items
            };
        }
    }
}
