using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Objects;

namespace FacturaElectronica.Business.Core
{
    public interface IRepository<T,TKey> : IDisposable where T : class
    {
        IQueryable<T> Fetch();

        T GetById(TKey id);

        IEnumerable<T> GetAll();

        IEnumerable<T> Find(Func<T, bool> predicate);

        T Single(Func<T, bool> predicate);

        T First(Func<T, bool> predicate);

        void Add(T entity);

        void Delete(T entity);

        void Attach(T entity);

        void SaveChanges();

        void SaveChanges(SaveOptions options);

    }

 
}
