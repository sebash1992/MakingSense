namespace application.API.Definitions.Services
{
   public interface IService<T> : IReadonlyService<T> where T : class
    {
        /// <summary>
        /// Delete an entity
        /// </summary>
        /// <param name="id">entity Id</param>
        void Delete(object id);

        /// <summary>
        /// Create an entity
        /// </summary>
        /// <param name="entity">entity to create</param>
        void Create(T entity);

        /// <summary>
        /// Update an entity
        /// </summary>
        /// <param name="entity">entity to update</param>
        void Update(T entity);
    }
}
