using System;
using System.Collections.Generic;

namespace application.API.Definitions.Repositories
{
    public interface IReadOnlyRepository<T> where T : class
    {
        /// <summary>
        /// Search for entities
        /// </summary>
        /// <param name="filterExpression">expression used to filter the entities</param>
        /// <param name="sortingExpression">expression used to sort the result</param>
        /// <param name="startIndex">Optional: number of entities to skipe</param>
        /// <param name="count">Optional: max number of entities to return</param>
        /// <param name="fields">Optional: coma separated list of fields to retrieve</param>
        /// <returns>collection of entities</returns>
        IEnumerable<T> Search(string filterExpression, string sortingExpression, int? page, int? rows, string include);
        
        /// <summary>
        /// Search for entities
        /// </summary>
        /// <param name="filterExpression">expression used to filter the entities</param>
        /// <param name="sortingExpression">expression used to sort the result</param>
        /// <param name="fields">Optional: coma separated list of fields to retrieve</param>
        /// <returns>collection of entities</returns>
        IEnumerable<T> Search(string filterExpression, string sortingExpression);
        /// <summary>
        /// Search for entities
        /// </summary>
        /// <param name="filterExpression">expression used to filter the entities</param>
        /// <param name="sortingExpression">expression used to sort the result</param>
        /// <param name="fields">Optional: coma separated list of fields to retrieve</param>
        /// <returns>collection of entities</returns>
        IEnumerable<T> Search(string filterExpression, string sortingExpression, string include);
        /// <summary>
        /// Count entities
        /// </summary>
        /// <param name="filterExpression">expression used to filter the entities</param>
        /// <returns>number of entities that maches the filter</returns>
        int Count(string filterExpression);

        /// <summary>
        /// Read an entity
        /// </summary>
        /// <param name="id">entity Id</param>
        /// <returns>an entity, null if the entity is not found</returns>
        T SearchById(string id);

        /// <summary>
        /// Read an entity
        /// </summary>
        /// <param name="filterExpression">expression used to filter the entities</param>
        /// <returns>returns the first entity that mach the filter, null if the entity is not found</returns>
        T Read(string filterExpression);
	}
}