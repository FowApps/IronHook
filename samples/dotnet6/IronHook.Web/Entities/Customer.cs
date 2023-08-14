using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IronHook.Web.Entities
{
    /// <summary>
    /// Customer Entity
    /// </summary>
    public class Customer
    {
        /// <summary>
        /// PK of Customer Entity
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Name of Customer
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Name of Surname
        /// </summary>
        public string Surname { get; set; }

        /// <summary>
        /// Name of Phone
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// Create Date of row
        /// </summary>
        public DateTime CreateDate { get; set; }

        /// <summary>
        /// Update date of row
        /// </summary>
        public DateTime UpdateDate { get; set; }
    }
}
