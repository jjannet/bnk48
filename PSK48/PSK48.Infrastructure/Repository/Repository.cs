using Microsoft.EntityFrameworkCore;
using PSK48.Infrastructure.Entities;
using PSK48.Util.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PSK48.Infrastructure.Repository
{
    public class Repository<T> : IRepository<T> where T : BaseObject
    {
        private const string ENTITY_NULL_ERROR = "Entity is null value";

        private readonly ApplicationContext context;
        private DbSet<T> entities;
        private string errorMessage = string.Empty;

        public Repository(ApplicationContext context)
        {
            this.context = context;
            entities = context.Set<T>();
        }

        public IEnumerable<T> GetAll() => entities.AsEnumerable();

        public IQueryable<T> Gets() => entities;

        // public T Get(long id) => entities.SingleOrDefault(s => s.Id == id)

        public T Find(params Object[] keyValues) => entities.Find(keyValues);

        public void Insert(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException(ENTITY_NULL_ERROR);

            if (entity is BaseObject baseObj)
            {
                baseObj.CreatedDate = DateTime.Now;
                baseObj.LastModifiedDate = DateTime.Now;
            }

            entities.Add(entity);
        }

        public void Update(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException(ENTITY_NULL_ERROR);

            if (entity is BaseObject baseObj)
                baseObj.LastModifiedDate = DateTime.Now;

            context.Update(entity);
        }

        public void Delete(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException(ENTITY_NULL_ERROR);

            entities.Remove(entity);
        }

        public void Remove(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException(ENTITY_NULL_ERROR);

            entities.Remove(entity);
        }

        public async void SaveChangesAsync() => await context.SaveChangesAsync();

        public void SaveChanges() => context.SaveChanges();
    }
}
