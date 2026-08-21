namespace EjemploApiRest.Abstractions
{
    public interface ICrud <T>
    {
        /// <summary>
        /// Para guardar y actualizar
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public T Save(T entity);

        /// <summary>
        /// Para obtener todos los items
        /// </summary>
        /// <returns></returns>
        public IList<T> GetAll();

        /// <summary>
        /// para obtener por id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public T GetbyId(int id);

        /// <summary>
        /// para eliminar por id
        /// </summary>
        /// <param name="id"></param>
        public void Delete(int id);
    }
}
