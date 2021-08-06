using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IronHook.Core.Primitives
{
    /// <summary>
    /// Header Parameter
    /// </summary>
    public class HeaderParameter
    {
        /// <summary>
        /// Name of Header element
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Value of Header element
        /// </summary>
        public string Value { get; set; }
    }
}
