using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IronHook.Web.Dtos
{
    /// <summary>
    /// Customer Request Data Transfer Object
    /// </summary>
    public class CustomerRequestDto
    {
        /// <summary>
        /// Name of Customer
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Name of Surname
        /// </summary>
        [Required]
        public string Surname { get; set; }

        /// <summary>
        /// Name of Phone
        /// </summary>
        [Required]
        public string Phone { get; set; }
    }
}
