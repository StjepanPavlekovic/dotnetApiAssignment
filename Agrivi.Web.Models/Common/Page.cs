using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Agrivi.Web.Models.Common
{
    public class Page<T>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int TotalPages { get; set; }
        public int TotalItems { get; set; }
        public IEnumerable<T> Items { get; set; }
    }

    public static class Page
    {
        public const int FIRST = 1;
        public const int DEFAULT_SIZE = 10;

        public static Page<T> GetEmpty<T>(int pageSize = 0)
        {
            return new Page<T>
            {
                PageNumber = 1,
                PageSize = pageSize,
                TotalPages = 0,
                TotalItems = 0,
                Items = Enumerable.Empty<T>()
            };
        }
    }
}
