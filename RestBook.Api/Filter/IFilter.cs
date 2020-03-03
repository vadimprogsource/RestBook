using System;
using System.Collections.Generic;
using System.Text;

namespace RestBook.Api.Filter
{
    public interface IFilter
    {
        string SearchText { get; }
        int PageSize { get; }
        int PageIndex { get; }
    }
}
