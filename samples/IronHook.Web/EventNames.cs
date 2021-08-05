using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IronHook.Web
{
    /// <summary>
    /// All Events
    /// </summary>
    public static class EventNames
    {
        /// <summary>
        /// All Event
        /// </summary>
        public static string ALL_EVENT { get => "*"; }

        /// <summary>
        /// Customer Created Event
        /// </summary>
        public static string CUSTOMER_CREATED { get => "customer.created"; }

        /// <summary>
        /// Customer Update Event
        /// </summary>
        public static string CUSTOMER_UPDATED { get => "customer.updated"; }

        /// <summary>
        /// Customer Delete Event
        /// </summary>
        public static string CUSTOMER_DELETED { get => "customer.deleted"; }
    }
}
