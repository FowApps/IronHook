using IronHook.Core.Entities;
using IronHook.Core.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace IronHook.Core.Abstractions
{
    /// <summary>
    /// This interface includes business endpoints for Hook
    /// </summary>
    public interface IHookService<TDbContext> where TDbContext : IIronHookContext
    {
        /// <summary>
        /// Add Hook
        /// </summary>
        /// <param name="hook">
        /// Hook Entity
        /// </param>
        /// <returns>
        /// Task
        /// </returns>
        Task<Hook> AddAsync(Hook hook);

        /// <summary>
        /// Add Hook
        /// </summary>
        /// <param name="hook">
        /// Hook Entity
        /// </param>
        /// <returns>
        /// Task
        /// </returns>
        Task<HookRequest> AddRequestAsync(HookRequest request);

        /// <summary>
        /// Update Hook
        /// </summary>
        /// <param name="hook">
        /// Hook Entity
        /// </param>
        /// <returns>
        /// Task
        /// </returns>
        Task<Hook> UpdateAsync(Hook hook);

        /// <summary>
        /// Remove Hook
        /// </summary>
        /// <param name="hookId">
        /// PK of Hook Entity
        /// </param>
        /// <returns>
        /// Task
        /// </returns>
        Task RemoveAsync(Guid hookId);

        /// <summary>
        /// Get All Hook
        /// </summary>
        /// <param name="expression"></param>
        /// <returns>
        /// List of Hook
        /// </returns>
        Task<List<Hook>> GetAsync(Expression<Func<Hook, bool>> expression);


        /// <summary>
        /// Find Hook By Key
        /// </summary>
        /// <param name="key"></param>
        /// <param name="tenantId"></param>
        /// <returns></returns>
        Task<Hook> FindHookAsync(string key, string tenantId);

        /// <summary>
        /// Raise Hook
        /// </summary>
        /// <param name="key"></param>
        /// <param name="tenantId"></param>
        /// <param name="data"></param>
        /// <returns>
        /// List of Hook Response
        /// </returns>
        Task<IList<HookResponse>> RaiseHookAsync(string key, string tenantId, object data);

        /// <summary>
        /// Remove Hook Request
        /// </summary>
        /// <param name="hookRequestId">
        /// PK of Hook Request Entity
        /// </param>
        /// <returns>
        /// Task
        /// </returns>
        Task RemoveRequestAsync(Guid hookRequestId);

        /// <summary>
        /// Get Hook Requests by HookId
        /// </summary>
        /// <param name="hookId"></param>
        /// <returns>
        /// List of Hook Request
        /// </returns>
        Task<List<HookRequest>> GetHookRequestsAsync(Guid hookId);

        /// <summary>
        /// Get Hook Logs
        /// </summary>
        /// <param name="hookRequestId">
        /// PK of Hook Request
        /// </param>
        /// <returns>
        /// List of HookLog
        /// </returns>
        Task<List<HookLog>> GetHookLogsAsync(Guid hookRequestId);
    }
}
