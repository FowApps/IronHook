using IronHook.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IronHook.Core.Abstractions
{
    /// <summary>
    /// Abstraction of Iron Hook Db Context
    /// </summary>
    public interface IIronHookContext
    {
        /// <summary>
        /// Get Queryable Entity
        /// </summary>
        /// <typeparam name="T">
        /// Type of Entity
        /// </typeparam>
        /// <returns>
        /// Type of IQueryable
        /// </returns>
        IQueryable<T> Get<T>() where T : class;

        /// <summary>
        /// Insert Entity
        /// </summary>
        /// <typeparam name="T">
        /// Type of Entity
        /// </typeparam>
        /// <param name="entity">
        /// Entity
        /// </param>
        /// <returns>
        /// Task
        /// </returns>
        Task InsertAsync<T>(T entity) where T : class;

        /// <summary>
        /// Update Entity
        /// </summary>
        /// <typeparam name="T">
        /// Type of Entity
        /// </typeparam>
        /// <param name="entity">
        /// Entity
        /// </param>
        /// <returns>
        /// Task
        /// </returns>
        Task UpdateAsync<T>(T entity) where T : class;

        /// <summary>
        /// Delete
        /// </summary>
        /// <typeparam name="T">
        /// Type of Entity
        /// </typeparam>
        /// <param name="entity">
        /// Entity
        /// </param>
        /// <returns>
        /// Task
        /// </returns>
        Task DeleteAsync<T>(T entity) where T : class;
    }
}
