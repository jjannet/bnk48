using PSK48.Util.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PSK48.Infrastructure.Repository
{
    public interface IRepository<T> where T : BaseObject
    {
        IEnumerable<T> GetAll();

        IQueryable<T> Gets();

        // T Get(long id);
        T Find(params Object[] keyValues);

        void Insert(T entity);

        void Update(T entity);

        void Delete(T entity);

        void Remove(T entity);

        void SaveChangesAsync();

        void SaveChanges();
    }
}
