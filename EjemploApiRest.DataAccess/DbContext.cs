using EjemploApiRest.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace EjemploApiRest.DataAccess
{
    /// <summary>
    /// Toda la logica de base de datos
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class DbContext<T> : IDBContext<T> where T : class, IEntity // where T : class, IEntity indica que solo objetos de tipo IEtntity pueden acceder a esta capa 
    {
        DbSet<T> _items;// DbSet es una clase de Entity Framework que representa una colección de entidades en la base de datos. En este caso, _items es una colección de entidades del tipo T, que se utilizará para realizar operaciones CRUD (Crear, Leer, Actualizar, Eliminar) en la base de datos.
        ApiDbContex _ctx;// ApiDbContex es la clase que representa el contexto de la base de datos y se utiliza para acceder a la base de datos. En este caso, _ctx es una instancia de ApiDbContex que se utilizará para realizar operaciones en la base de datos.
        
        /// <summary>
        /// Constructor de la clase DbContext. Recibe una instancia de ApiDbContex y la asigna a la variable _ctx. Luego, inicializa la variable _items con el conjunto de entidades del tipo T en el contexto de la base de datos.
        /// </summary>
        /// <param name="ctx"></param>
        public DbContext(ApiDbContex ctx) 
        {
            
            _ctx = ctx;
            _items = ctx.Set<T>();


        }
        public void Delete(int id)
        {
            
        }

        public IList<T> GetAll()
        {
            return _items.ToList();// ToList() es un método de LINQ que convierte una colección en una lista. En este caso, se utiliza para convertir el DbSet<T> _items en una lista de entidades del tipo T y devolverla como resultado del método GetAll().
        }

        public T GetbyId(int id)
        {
            return _items.Where(i => i.id.Equals(id)).FirstOrDefault();// Where() es un método de LINQ que filtra una colección según una condición. En este caso, se utiliza para filtrar el DbSet<T> _items y obtener la entidad del tipo T que tenga el Id igual al parámetro id. Luego, se utiliza FirstOrDefault() para devolver la primera entidad que cumpla con la condición o null si no se encuentra ninguna.

        }

        public T Save(T entity)
        {
           _items.Add(entity);
            _ctx.SaveChanges();
            return entity;
        }
    }
}
