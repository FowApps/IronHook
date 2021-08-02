using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IronHook.Core.Primitives
{
    public struct HookResponse
    {
        public Dictionary<string, string> Headers { get; set; }
        public string Body { get; set; }
        public int StatusCode { get; set; }
        public bool IsExceeded { get; set; }
        public string EventName { get; set; }

        public string Url { get; set; }

        public Guid RequestId { get; set; }

        public string NotifyEmail { get; set; }
    }
}
