using RestBook.Api.Filter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestBook.Models
{
    public class FilterModel : IFilter
    {
        public string SearchText { get; set; }

        public int PageSize { get; set; }

        public int PageIndex { get; set; }
    }
}
