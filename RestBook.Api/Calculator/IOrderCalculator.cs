using RestBook.Api.Entity;
using System;
using System.Collections.Generic;
using System.Text;

using System.Threading.Tasks;

namespace RestBook.Api.Calculator
{
    public interface IOrderCalculator
    {
        decimal CalculateTotalPrice(IEnumerable<IOrderItem> items);
        Task<IRetailOrder> Calculate(IRetailOrder order);
    }
}
