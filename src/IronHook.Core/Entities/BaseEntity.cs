using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IronHook.Core.Entities
{
    /// <summary>
    /// This class includes base properties for Entities
    /// </summary>
    public class BaseEntity
    {
        /// <summary>
        /// PK of Entity
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Create Date of Row
        /// </summary>
        public DateTime CreateDate { get; set; }

        /// <summary>
        /// Update Date of Row
        /// </summary>
        public DateTime UpdateDate { get; set; }

        /// <summary>
        /// Is Active of Row
        /// </summary>
        public bool IsActive { get; set; } = true;

        /// <summary>
        /// Is Deleted of Row
        /// </summary>
        public bool IsDeleted { get; set; }
    }
}
