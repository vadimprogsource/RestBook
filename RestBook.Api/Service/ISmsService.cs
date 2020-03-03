using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RestBook.Api.Service
{
    public interface ISmsService
    {
        Task<bool> Send(string cellular , string pinCode);
    }
}
