using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace application.API.Definitions.Repositories
{
    public interface IRepository<T> : IReadOnlyRepository<T> where T : class
    {
        void Create(T entity);
        void Delete(object id);
        /// <summary>
        /// WARNING: multiple objects can be deleted
        /// </summary>
        /// <param name="filterExpression"></param>
        void Delete(string filterExpression);
        void Update(T entity);
        void SaveChanges();

    }
}
