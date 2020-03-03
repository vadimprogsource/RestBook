using RestBook.Api.Comparer;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace RestBook.App.Builder
{
    public class PasswordBuilder : IBytesComparer
    {
      
            private byte[] GetBytes(params object[] args)
            {
                StringBuilder sb = new StringBuilder();
                foreach (object arg in args)
                {
                    sb.Append(arg);
                }

                return Encoding.ASCII.GetBytes(sb.ToString());
            }


            public byte[] MakePasswordHash(params object[] args) => SHA256.Create().ComputeHash(GetBytes(args));
            public Guid MakeGuid(params object[] args) => new Guid(MD5.Create().ComputeHash(GetBytes(args)));



            public bool Compare(byte[] a, byte[] b)
            {

                if (a.Length == b.Length)
                {
                    for (int i = 0, j = b.Length - 1; i <= j; i++, j--)
                    {
                        if (b[i] != a[i] || b[j] != a[j])
                        {
                            return false;
                        }
                    }

                    return true;
                }

                return false;

            }
    }
}
