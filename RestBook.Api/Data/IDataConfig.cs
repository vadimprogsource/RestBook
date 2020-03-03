using System;
using System.Collections.Generic;
using System.Text;

namespace RestBook.Api.Data
{
    public interface IDataConfig
    {
        bool IsLogToConsole { get; }

        string Connection { get; }
    }
}
