using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Objects;
using System.Linq.Expressions;
using System.Data;

namespace FacturaElectronica.Business.Core
{
    /// <summary>

    /// A generic repository for working with data in the database

    /// </summary>

    /// <typeparam name="T">A POCO that represents an Entity Framework entity</typeparam>

    public class Repository<T, TKey> : IRepository<T, TKey> where T : class
    {

        /// <summary>
        /// The context object for the database
        /// </summary>
        private ObjectContext _context;



        /// <summary>
        /// The IObjectSet that represents the current entity.
        /// </summary>
        private IObjectSet<T> _objectSet;

        public Repository()
            : this(new FacturaElectronica.Data.FacturaElectronicaEntities())
        { }

        /// <summary>
        /// Initializes a new instance of the DataRepository class
        /// </summary>
        /// <param name="context">The Entity Framework ObjectContext</param>
        public Repository(ObjectContext context)
        {
            _context = context;
            _objectSet = _context.CreateObjectSet<T>();
        }

        /// <summary>
        /// Gets all records as an IQueryable
        /// </summary>
        /// <returns>An IQueryable object containing the results of the query</returns>
        public IQueryable<T> Fetch()
        {
            return _objectSet;
        }



        /// <summary>
        /// Gets all records as an IEnumberable
        /// </summary>
        /// <returns>An IEnumberable object containing the results of the query</returns>
        public IEnumerable<T> GetAll()
        {
            return _objectSet.ToList();
        }

        public T GetById(TKey id)
        {
            var itemParameter = Expression.Parameter(typeof(T), "item");

            var whereExpression = Expression.Lambda<Func<T, bool>>
                (
                Expression.Equal(
                    Expression.Property(
                        itemParameter,
                        "Id"
                        ),
                    Expression.Constant(id)
                    ),
                new[] { itemParameter }
                );

            return _objectSet.Where<T>(whereExpression).SingleOrDefault();

        }

        /// <summary>
        /// Finds a record with the specified criteria
        /// </summary>
        /// <param name="predicate">Criteria to match on</param>
        /// <returns>A collection containing the results of the query</returns>
        public IEnumerable<T> Find(Func<T, bool> predicate)
        {
            return _objectSet.Where<T>(predicate);
        }



        /// <summary>
        /// Gets a single record by the specified criteria (usually the unique identifier)
        /// </summary>
        /// <param name="predicate">Criteria to match on</param>
        /// <returns>A single record that matches the specified criteria</returns>
        public T Single(Func<T, bool> predicate)
        {
            return _objectSet.Single<T>(predicate);
        }



        /// <summary>
        /// The first record matching the specified criteria
        /// </summary>
        /// <param name="predicate">Criteria to match on</param>
        /// <returns>A single record containing the first record matching the specified criteria</returns>
        public T First(Func<T, bool> predicate)
        {
            return _objectSet.First<T>(predicate);
        }

        /// <summary>
        /// Deletes the specified entitiy
        /// </summary>
        /// <param name="entity">Entity to delete</param>
        /// <exception cref="ArgumentNullException"> if <paramref name="entity"/> is null</exception>
        public void Delete(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }

            _objectSet.DeleteObject(entity);

        }



        /// <summary>

        /// Deletes records matching the specified criteria

        /// </summary>

        /// <param name="predicate">Criteria to match on</param>

        public void Delete(Func<T, bool> predicate)
        {

            IEnumerable<T> records = from x in _objectSet.Where<T>(predicate) select x;



            foreach (T record in records)
            {

                _objectSet.DeleteObject(record);

            }

        }



        /// <summary>

        /// Adds the specified entity

        /// </summary>

        /// <param name="entity">Entity to add</param>

        /// <exception cref="ArgumentNullException"> if <paramref name="entity"/> is null</exception>

        public void Add(T entity)
        {

            if (entity == null)
            {

                throw new ArgumentNullException("entity");

            }



            _objectSet.AddObject(entity);

        }



        /// <summary>

        /// Attaches the specified entity

        /// </summary>

        /// <param name="entity">Entity to attach</param>

        public void Attach(T entity)
        {

            _objectSet.Attach(entity);

        }



        /// <summary>

        /// Saves all context changes

        /// </summary>

        public void SaveChanges()
        {

            _context.SaveChanges();

        }



        /// <summary>

        /// Saves all context changes with the specified SaveOptions

        /// </summary>

        /// <param name="options">Options for saving the context</param>

        public void SaveChanges(SaveOptions options)
        {

            _context.SaveChanges(options);

        }



        /// <summary>

        /// Releases all resources used by the WarrantManagement.DataExtract.Dal.ReportDataBase

        /// </summary>

        public void Dispose()
        {

            Dispose(true);

            GC.SuppressFinalize(this);

        }



        /// <summary>

        /// Releases all resources used by the WarrantManagement.DataExtract.Dal.ReportDataBase

        /// </summary>

        /// <param name="disposing">A boolean value indicating whether or not to dispose managed resources</param>

        protected virtual void Dispose(bool disposing)
        {

            if (disposing)
            {

                if (_context != null)
                {

                    _context.Dispose();

                    _context = null;

                }

            }

        }

    }

}
