using application.API.Definitions.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace application.API.DataAccess.Repositories
{
    public class Repository<T> : ReadOnlyRepository<T> where T : class, IModel
    {
        DbContext _context;
        public Repository(DataContext context) : base(context)
        {
            _context = context;
        }

        public virtual void Create(T entityToInsert)
        {
            _dbSet.Add(entityToInsert);
        }

        public virtual void Delete(object id)
        {
            T entityToDelete = _dbSet.Find(id);
            Delete(entityToDelete);
        }

        public virtual void Delete(string filterExpression)
        {
            var idsToDelete = Search(filterExpression, string.Empty).Select(x => x.Id);
            foreach (var id in idsToDelete)
            {
                Delete(id);
            }
        }

        public virtual void Delete(T entityToDelete)
        {
            if (_context.Entry(entityToDelete).State == EntityState.Detached)
            {
                _dbSet.Attach(entityToDelete);
            }
            _dbSet.Remove(entityToDelete);
        }

        public virtual void Update(T entityToUpdate)
        {
            _dbSet.Attach(entityToUpdate);
            _context.Entry(entityToUpdate).State = EntityState.Modified;
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}