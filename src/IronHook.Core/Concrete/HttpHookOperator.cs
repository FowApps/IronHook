using IronHook.Core.Abstractions;
using IronHook.Core.Entities;
using IronHook.Core.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace IronHook.Core.Concrete
{
    public class HttpHookOperator : IHookOperator
    {
        private readonly IIronHookContext ironHookContext;

        public HttpHookOperator(IIronHookContext ironHookContext)
        {
            this.ironHookContext = ironHookContext;
        }
        public async Task<IList<HookResponse>> SendHookAsync<T>(Hook hook, List<HookRequest> requests, T data = default)
        {
            var responses = new List<HookResponse>();
            int errorCount = 0;
            foreach (var req in hook.HookRequests)
            {
                if (errorCount > req.MaxRetryCount)
                {
                    errorCount = 0;
                    continue;
                }
            Loop:
                using (var client = new HttpClient())
                using (var content = new StringContent(data.ToString(), Encoding.UTF8, "application/json"))
                using (var message = new HttpRequestMessage(new HttpMethod(req.Method), req.Url))
                {
                    if (req.Method != "GET" && req.Method != "DELETE")
                        message.Content = content;
                    if (!string.IsNullOrEmpty(req.Headers))
                    {
                        var headers = JsonSerializer.Deserialize<List<HeaderParameter>>(req.Headers);
                        foreach (var header in headers)
                        {
                            message.Headers.Add(header.Name, header.Value);
                        }
                    }
                    DateTime requestDate = DateTime.UtcNow;
                    using (var response = await client.SendAsync(message))
                    {
                        if (!response.IsSuccessStatusCode)
                            errorCount = errorCount + 1;
                        DateTime responseDate = DateTime.UtcNow;
                        bool isExceeded = !response.IsSuccessStatusCode && errorCount == req.MaxRetryCount ? true : false;
                        responses.Add(new HookResponse
                        {
                            Body = await response.Content?.ReadAsStringAsync(),
                            Headers = response.Headers.ToDictionary(k => k.Key, v => v.Value?.FirstOrDefault()),
                            StatusCode = (int)response.StatusCode,
                            IsExceeded = isExceeded,
                            EventName = hook.Name,
                            Url = req.Url,
                            RequestId = req.Id,
                            NotifyEmail = req.NotifiyEmail
                        });
                        
                        await ironHookContext.InsertAsync<HookLog>(new HookLog
                        {
                            RequestId = req.Id,
                            RequestDate = requestDate,
                            Request = JsonSerializer.Serialize(message),
                            Response = JsonSerializer.Serialize(responses),
                            ResponseDate = responseDate,
                        });

                        if (!isExceeded)
                            goto Loop;
                    }
                }
            }

            return responses;
        }
    }
}
