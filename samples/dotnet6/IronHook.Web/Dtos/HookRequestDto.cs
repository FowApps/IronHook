using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IronHook.Web.Dtos
{
    /// <summary>
    /// Hook Request Data Transfer Object
    /// </summary>
    public class HookRequestDto
    {
        /// <summary>
        /// Key of Hook
        /// </summary>
        [Required]
        public string Key { get; set; }

        /// <summary>
        /// Name of Hook
        /// </summary>
        [Required]
        public string Name { get; set; }
    }
}
