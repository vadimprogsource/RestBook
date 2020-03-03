using System;
using System.Collections.Generic;
using System.Text;

namespace RestBook.Api.Entity
{

    public interface IContactData
    {
        string Title { get; }
        string Cellular { get; }
        string Phone { get; }
        string Email { get; }
        string Skype { get; }
    }

    public interface IContactEntity : IContactData, IBussnessEntity
    {
   
    }
}
