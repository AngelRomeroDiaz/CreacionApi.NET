using System;
using System.Collections.Generic;
using System.Text;

namespace EjemploApiRest.Abstractions
{
    public interface IDBContext<T> : ICrud<T>
    {
    }
}
