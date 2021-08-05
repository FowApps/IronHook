using IronHook.Core.Abstractions;
using IronHook.Core.Entities;
using IronHook.Core.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace IronHook.Core.Concrete
{
    public class DefaultHookService<TDbContext> : IHookService<TDbContext> where TDbContext : IIronHookContext
    {
        private readonly TDbContext dbContext;
        private readonly IHookOperator hookOperator;

        public DefaultHookService(TDbContext dbContext, IHookOperator hookOperator)
        {
            this.dbContext = dbContext;
            this.hookOperator = hookOperator;
        }
        public async Task<Hook> AddAsync(Hook hook)
        {
            var response = await dbContext.InsertAsync<Hook>(hook);
            foreach (var request in hook.HookRequests.ToList())
            {
                request.HookId = response.Id;
                await dbContext.InsertAsync<HookRequest>(request);
            }
            return response;
        }

        public async Task<HookRequest> AddRequestAsync(HookRequest request)
        {
            return await dbContext.InsertAsync<HookRequest>(request);
        }

        public Task<Hook> FindHookAsync(string key, string tenantId)
        {
            var response = dbContext.Get<Hook>().FirstOrDefault(a => a.Key == key && a.TenantId == tenantId);
            return Task.FromResult(response);
        }

        public Task<List<Hook>> GetAsync(Expression<Func<Hook, bool>> expression)
        {
            var response = dbContext.Get<Hook>().Where(expression).ToList();
            return Task.FromResult(response);
        }

        public Task<List<HookRequest>> GetHookRequestsAsync(Guid hookId)
        {
            var response = dbContext.Get<HookRequest>().Where(a => a.HookId == hookId).ToList();
            return Task.FromResult(response);
        }

        public async Task<IList<HookResponse>> RaiseHookAsync(string key, string tenantId, object data)
        {
            var hooks = dbContext.Get<Hook>().Where(a => a.Key == key && a.TenantId == tenantId && a.IsActive && !a.IsDeleted).ToList();
            var requests = dbContext.Get<HookRequest>().Where(a => hooks.Select(s => s.Id).ToList().Contains(a.HookId)).ToList();
            List<HookResponse> responses = new List<HookResponse>();
            foreach (var hook in hooks)
            {
                var result = await hookOperator.SendHookAsync(hook, requests, data);
                responses.AddRange(result);
            }
            return responses;
        }

        public async Task RemoveAsync(Guid hookId)
        {
            var entities = await GetAsync(a => a.Id == hookId);
            await dbContext.DeleteAsync<Hook>(entities.FirstOrDefault());
        }

        public async Task RemoveRequestAsync(Guid hookRequestId)
        {
            var entity = dbContext.Get<HookRequest>().FirstOrDefault(a => a.Id == hookRequestId);
            await dbContext.DeleteAsync<HookRequest>(entity);
        }

        public async Task<Hook> UpdateAsync(Hook hook)
        {
            var response = await dbContext.UpdateAsync<Hook>(hook);
            return response;
        }
    }
}
