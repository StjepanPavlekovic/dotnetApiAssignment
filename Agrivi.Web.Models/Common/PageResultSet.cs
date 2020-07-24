using System;
using System.Collections.Generic;
using System.Text;

namespace Agrivi.Web.Models.Common
{
    public class PageResultSet
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int TotalPages { get; set; }
        public int TotalItems { get; set; }
    }
}
