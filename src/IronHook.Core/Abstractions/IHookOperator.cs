using IronHook.Core.Entities;
using IronHook.Core.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IronHook.Core.Abstractions
{
    /// <summary>
    /// This interface includes Hook operator signature
    /// </summary>
    public interface IHookOperator
    {
        /// <summary>
        /// Send Hook
        /// </summary>
        /// <typeparam name="T">
        /// Hook Body
        /// </typeparam>
        /// <param name="hook">
        /// Defined Hook
        /// </param>
        /// <param name="data">
        /// Hook Data
        /// </param>
        /// <returns>
        /// List Of Hook Response
        /// </returns>
        Task<IList<HookResponse>> SendHookAsync<T>(Hook hook, T data = default(T));
    }
}
