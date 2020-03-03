using System;
using System.Collections.Generic;
using System.Text;

namespace RestBook.Api.Entity
{
    public interface IProduct : IBussnessEntity
    {

       ICatalog Catalog { get; }
       IGroup Group { get; }
       string UnitCode { get; }
       decimal ListPrice { get; }
       decimal NetCost { get; }
       decimal UnitWeight { get; }
        decimal UnitVolume { get; }
       decimal UnitEnergy { get; }

        string Weights { get; }
    }
}
