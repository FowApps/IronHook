using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IronHook.Core.Entities
{
    /// <summary>
    /// Hook Request
    /// </summary>
    public class HookRequest : BaseEntity
    {
        /// <summary>
        /// PK of Hook Entity
        /// </summary>
        public Guid HookId { get; set; }

        /// <summary>
        /// Hook Url
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// Hook Method
        /// </summary>
        public string Method { get; set; }

        /// <summary>
        /// Headers of Request
        /// </summary>
        public string Headers { get; set; }

        /// <summary>
        /// Maximum Retry Count
        /// </summary>
        [Range(2, 5)]
        public int MaxRetryCount { get; set; } = 3;

        /// <summary>
        /// If defined hook exceeded inform email
        /// </summary>
        public string NotifiyEmail { get; set; }
    }
}
