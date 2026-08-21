using EjemploApiRest.Abstractions;
using EjemploApiRest.Repository;

namespace EjemploApiRest.Application
{
    public interface IApplication<T>: ICrud<T>
    {

    }
    public class Application<T> : IApplication<T> where T : IEntity // where T : IEntity indica que solo objetos de tipo IEtntity pueden acceder a esta capa
    {

        IRepository<T> _repository;
        public Application( IRepository<T> repository)
        {
            _repository = repository;

        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }

        public IList<T> GetAll()
        {
            return _repository.GetAll();
        }

        public T GetbyId(int id)
        {
            return _repository.GetbyId(id);
        }

        public T Save(T entity)
        {
            return _repository.Save(entity);
        }
    }
}
