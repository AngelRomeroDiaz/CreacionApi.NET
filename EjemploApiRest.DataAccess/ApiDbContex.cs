using EjemploApiRest.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EjemploApiRest.DataAccess
{
    public class ApiDbContex : DbContext
    {
        public DbSet<FutbolTeam> Teams { get; set; }
        public ApiDbContex(DbContextOptions<ApiDbContex> options) : base(options)
        {
        }

        /// <summary>
        /// Nos permite configurar el modelo de datos y las relaciones entre las entidades. Se llama cuando se crea el modelo de datos y se utiliza para definir la estructura de la base de datos.
        /// </summary>
        /// <param name="modelBuilder"></param>
        override protected void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Ignore<Entity>();//Evitamos que la clase Entity se mapee a una tabla en la base de datos
            base.OnModelCreating(modelBuilder);
            

        }
    }
}
