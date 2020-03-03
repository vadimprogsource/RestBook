using RestBook.Api.Service;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RestBook.App.Service
{
    public class MailService : IMailService
    {
        public Task<bool> Send(string email, string pinCode)
        {
            Console.WriteLine($"Sent pind code {pinCode} to mail address {email} !");
            return Task.FromResult(true);
        }
    }
}
