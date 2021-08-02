using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IronHook.Core.Entities
{
    /// <summary>
    /// Hook Entity
    /// </summary>
    public class Hook : BaseEntity
    {
        /// <summary>
        /// PK of Tenant for Authentication
        /// </summary>
        public string TenantId { get; set; }

        /// <summary>
        /// Event Name
        /// </summary>
        public string Key { get; set; }

        /// <summary>
        /// Custom Name of Hook
        /// </summary>
        public string Name { get; set; }
    }
}
