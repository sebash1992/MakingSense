using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using application.API.Definitions.Model;
using application.API.Definitions.Helpers;
using Microsoft.EntityFrameworkCore;

namespace application.API.DataAccess.Repositories
{
   public abstract class ReadOnlyRepository<T> where T : class,IModel
    {
        internal readonly DataContext context;
        internal DbSet<T> _dbSet;
        public ReadOnlyRepository(DataContext context)
        {
            this.context = context;
            _dbSet = context.Set<T>();
        }

        public virtual IEnumerable<T> Search(string filterExpression, string sortingExpression)
        {
            return Search(filterExpression, sortingExpression, null, null,"");
        }
        public virtual IEnumerable<T> Search(string filterExpression, string sortingExpression,string include)
        {
            return Search(filterExpression, sortingExpression, null, null, include);
        }

        public virtual IEnumerable<T> Search(string filterExpression, string sortingExpression, int? startIndex, int? count, string include)
        {
            IQueryable<T> query = _dbSet;
            if (!string.IsNullOrEmpty(filterExpression))
            {
                query = query.Where(filterExpression);
            }
            if (!string.IsNullOrEmpty(sortingExpression))
            {
                query = query.OrderBy(sortingExpression);
            }
            if (!string.IsNullOrEmpty(include))
            {
                string[] includes = include.Split(';');
                foreach (var inc in includes)
                {
                    query = query.Include(inc);
                }
            }
            if (startIndex.HasValue && count.HasValue)
            {
                query = query
                        .Skip((startIndex.Value - 1) * count.Value)
                        .Take(count.Value);
            }
            return query.ToList();
        }

        public virtual int Count(string filterExpression)
        {
            IQueryable<T> query = _dbSet;
            if (string.IsNullOrEmpty(filterExpression))
                return query.Count();
            return query.Where(filterExpression).Count();
        }

        public virtual T SearchById(string id)
        {
            return _dbSet.Where(x=> x.Id == id).FirstOrDefault();
        }

        public virtual T Read(string filterExpression)
        {
            IQueryable<T> query = _dbSet;
            if (!string.IsNullOrEmpty(filterExpression))
            {
                query = query.Where(filterExpression);
                return query.FirstOrDefault();
            }
            return null;
        }
    }
}