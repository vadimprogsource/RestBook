using System;
using System.Collections.Generic;
using System.Text;

namespace RestBook.Api.Comparer
{
    public interface IBytesComparer
    {
        bool Compare(byte[] a, byte[] b);
    }
}
