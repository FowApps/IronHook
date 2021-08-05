using IronHook.Core.Primitives;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IronHook.Web.Dtos
{
    /// <summary>
    /// Hook Define Data Transfer Object
    /// </summary>
    public class HookDto
    {
        /// <summary>
        /// Is Active
        /// </summary>
        public bool IsActive { get; set; }

        /// <summary>
        /// Name of Hook
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Requests
        /// </summary>
        public IList<HookRequestDefineDto> HookRequests { get; set; }
    }

    /// <summary>
    /// Hook Request Define Data Transfer Object
    /// </summary>
    public class HookRequestDefineDto
    {
        /// <summary>
        /// Url
        /// </summary>
        [Required]
        public string Url { get; set; }

        /// <summary>
        /// HTTP method
        /// </summary>
        [Required]
        public string Method { get; set; }

        /// <summary>
        /// Header Parameters
        /// </summary>
        public List<HeaderParameter> HeaderParameters { get; set; } = new List<HeaderParameter>();

        /// <summary>
        /// Max Retry Count
        /// </summary>
        [Range(2, 5)]
        [Required]
        public int MaxRetryCount { get; set; } = 3;

        /// <summary>
        /// Notify Email
        /// </summary>
        public string NotifyEmail { get; set; }
    }
}
