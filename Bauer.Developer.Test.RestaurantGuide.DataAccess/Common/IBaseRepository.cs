﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace Bauer.Developer.Test.RestaurantGuide.DataAccess.Common
{
    public interface IBaseRepository<T> : IDisposable where T : class
    {
        /// <summary>
        /// Gets all objects from database
        /// </summary>
        IQueryable<T> All();

        IQueryable<T> GetAll(params Expression<Func<T, object>>[] includeExpressions);

        /// <summary>
        /// Gets objects from database by filter.
        /// </summary>
        /// <param name="predicate">Specified a filter</param>
        IQueryable<T> Filter(Expression<Func<T, bool>> predicate);

        IQueryable<T> Filter(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeExpressions);

        /// <summary>
        /// Gets objects from database with filting and paging.
        /// </summary>
        /// <typeparam name="Key"></typeparam>
        /// <param name="filter">Specified a filter</param>
        /// <param name="total">Returns the total records count of the filter.</param>
        /// <param name="index">Specified the page index.</param>
        /// <param name="size">Specified the page size</param>
        IQueryable<T> Filter<Key>(Expression<Func<T, bool>> filter,
            out int total, int index = 0, int size = 50);

        void Refresh(T entity);

        /// <summary>
        /// Gets the object(s) is exists in database by specified filter.
        /// </summary>
        /// <param name="predicate">Specified the filter expression</param>
        bool Contains(Expression<Func<T, bool>> predicate);

        /// <summary>
        /// Find object by keys.
        /// </summary>
        /// <param name="keys">Specified the search keys.</param>
        T Find(params object[] keys);

        /// <summary>
        /// Find object by specified expression.
        /// </summary>
        /// <param name="predicate"></param>
        T Find(Expression<Func<T, bool>> predicate);

        /// <summary>
        /// Create a new object to database.
        /// </summary>
        /// <param name="t">Specified a new object to create.</param>
        T Create(T t);

        /// <summary>
        /// Create a new object to database.
        /// </summary>
        /// <param name="t">Specified a new object to create.</param>
        /// <param name="userName">Current user name.</param>
        T Create(T t, string userName);

        /// <summary>
        /// Delete the object from database.
        /// </summary>
        /// <param name="t">Specified a existing object to delete.</param>        
        void Delete(T t);

        bool DeleteRange(IEnumerable<T> Ts);

        /// <summary>
        /// Delete objects from database by specified filter expression.
        /// </summary>
        /// <param name="predicate"></param>
        void Delete(Expression<Func<T, bool>> predicate);

        /// <summary>
        /// Update object changes and save to database.
        /// </summary>
        /// <param name="t">Specified the object to save.</param>
        int Update(T t);

        /// <summary>
        /// Update object changes and save to database.
        /// </summary>
        /// <param name="t">Specified the object to save.</param>
        /// <param name="userName">Current user name.</param>
        int Update(T t, string userName, string dnb = null);

        int UpdateExcludeSpecificProperties(T t, Action<DbContext, T> specificPropertiesUnmodified);
        int UpdateSpecificProperties(T t, Action<DbContext, T> specificPropertiesModified);

        /// <summary>
        /// Get the total objects count.
        /// </summary>
        int Count { get; }
    }
}
