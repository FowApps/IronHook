using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace IronHook.Core.Entities
{
    /// <summary>
    /// HookLog Entity
    /// </summary>
    public class HookLog
    {
        /// <summary>
        /// PK of Hook Log
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// PK of HookRequest Entity
        /// </summary>
        public Guid RequestId { get; set; }

        /// <summary>
        /// Request Detail
        /// </summary>
        public string Request { get; set; }

        /// <summary>
        /// Response Detail
        /// </summary>
        public string Response { get; set; }

        /// <summary>
        /// Date of Request
        /// </summary>
        public DateTime RequestDate { get; set; }

        /// <summary>
        /// Date of Response
        /// </summary>
        public DateTime ResponseDate { get; set; }

        /// <summary>
        /// Relation of between HookLog to HookRequest
        /// </summary>
        [JsonIgnore]
        public virtual HookRequest HookRequest { get; set; }
    }
}
