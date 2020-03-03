using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RestBook.Api.Service
{
    public interface IMailService
    {
        Task<bool> Send(string email, string pinCode);
    }
}
