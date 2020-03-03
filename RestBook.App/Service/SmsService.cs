using RestBook.Api.Service;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RestBook.App.Service
{
    public class SmsService : ISmsService
    {
        public Task<bool> Send(string cellular, string pinCode)
        {
            Console.WriteLine($"Sent pind code {pinCode} to sms cellular {cellular}!");
            return Task.FromResult(true);
        }
    }
}
