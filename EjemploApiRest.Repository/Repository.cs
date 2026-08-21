using EjemploApiRest.Abstractions;

namespace EjemploApiRest.Repository
{
    public interface IRepository<T> : ICrud<T> 
    {

    }
    public class Repository<T> : IRepository<T> where T : IEntity // where T : IEntity indica que solo objetos de tipo IEtntity pueden acceder a esta capa
    {
        IDBContext<T> _ctx;
        public Repository(IDBContext<T> ctx)
        {
            _ctx = ctx;
        }

        public void Delete(int id)
        {
            _ctx.Delete(id);
        }

        public IList<T> GetAll()
        {
            return _ctx.GetAll();
        }

        public T GetbyId(int id)
        {
           return _ctx.GetbyId(id);
        }

        public T Save(T entity)
        {
            return  _ctx.Save(entity);
        }
    }
}
