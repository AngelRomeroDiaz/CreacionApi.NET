using EjemploApiRest.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace EjemploApiRest.Entities
{
    public abstract class Entity: IEntity
    {
        public int id {  get; set; }
    }
}
