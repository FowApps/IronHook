using IronHook.Core.Abstractions;
using IronHook.Core.Entities;
using IronHook.PostgreSql.Context;
using IronHook.Web.Dtos;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace IronHook.Web.Controllers
{
    /// <summary>
    /// Hook Endpoints
    /// </summary>
    [ApiController]
    [Route("hooks")]
    public class HookController : ControllerBase
    {
        private readonly IHookService<IronHookPostgreSqlDbContext> hookService;

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="hookService">
        /// Hook Operation Service
        /// </param>
        public HookController(IHookService<IronHookPostgreSqlDbContext> hookService)
        {
            this.hookService = hookService;
        }

        /// <summary>
        /// Add Hook
        /// </summary>
        /// <param name="model">
        /// Hook Request Data Transfer Object
        /// </param>
        /// <returns>
        /// Hook Entity
        /// </returns>
        [HttpPost(Name = "AddHook")]
        [ProducesResponseType(typeof(Hook), 200)]
        public async Task<IActionResult> AddHookAsync([FromBody] HookRequestDto model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var response = await hookService.AddAsync(new Hook
            {
                Name = model.Name,
                TenantId = "1",
                Key = model.Key
            });
            return Ok(response);
        }

        /// <summary>
        /// Get Hook Types
        /// </summary>
        /// <returns>
        /// Array of string
        /// </returns>
        [HttpGet("types", Name = "GetTypes")]
        [ProducesResponseType(typeof(string[]), 200)]
        public IActionResult GetTypes()
        {
            var result = GetFieldValuesFromType(typeof(EventNames));
            return Ok(result.ToList());
            static IEnumerable<string> GetFieldValuesFromType(Type type)
            {
                foreach (var field in type.GetProperties().Where(x => x.PropertyType == typeof(string)))
                {
                    yield return field.GetValue(null) as string;
                }
            }
        }

        /// <summary>
        /// Get All
        /// </summary>
        /// <returns>
        /// Array of Hook
        /// </returns>
        [HttpGet(Name = "GetAll")]
        [ProducesResponseType(typeof(Hook[]), 200)]
        public async Task<IActionResult> GetAllAsync()
            => Ok(await hookService.GetAsync(a => a.TenantId == "1" && a.IsActive));

        /// <summary>
        /// Find
        /// </summary>
        /// <param name="id">
        /// PK of Hook
        /// </param>
        /// <returns>
        /// Hook Entity
        /// </returns>
        [HttpGet("{id}", Name = "Find")]
        [ProducesResponseType(typeof(Hook), 200)]
        public async Task<IActionResult> FindAsync([FromRoute] Guid id)
            => Ok(await hookService.GetAsync(a => a.Id == id && a.TenantId == "1" && a.IsActive));

        /// <summary>
        /// Define Hook
        /// </summary>
        /// <param name="name">
        /// Event Name
        /// </param>
        /// <param name="model">
        /// Hook Data Transfer Object
        /// </param>
        /// <returns>
        /// Hook Entity
        /// </returns>
        [HttpPost("events/{name}", Name = "DefineHook")]
        [ProducesResponseType(typeof(Hook), 200)]
        public async Task<IActionResult> DefineHookAsync([FromRoute] string name, [FromBody] HookDto model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var hook = new Hook
            {
                TenantId = "1",
                Key = name,
                HookRequests = model.HookRequests.Select(s => new HookRequest
                {
                    Url = model.HookRequests.FirstOrDefault().Url,
                    Method = model.HookRequests.FirstOrDefault().Method,
                    Headers = JsonSerializer.Serialize(model.HookRequests.FirstOrDefault().HeaderParameters),
                    MaxRetryCount = model.HookRequests.FirstOrDefault().MaxRetryCount,
                    NotifiyEmail = model.HookRequests.FirstOrDefault()?.NotifyEmail
                }).ToList(),
                IsActive = model.IsActive,
                Name = model.Name
            };
            await hookService.AddAsync(hook);
            return Ok(hook);
        }

        /// <summary>
        /// Delete Hook
        /// </summary>
        /// <param name="id">
        /// PK of Hook entity
        /// </param>
        /// <returns>
        /// NoContent
        /// </returns>
        [HttpDelete("{id}", Name = "DeleteHook")]
        [ProducesResponseType(204)]
        public async Task<IActionResult> DeleteHookAsync([FromRoute] Guid id)
        {
            await hookService.RemoveAsync(hookId: id);
            return NoContent();
        }

        /// <summary>
        /// Add Request To Hook
        /// </summary>
        /// <param name="id">
        /// PK of Hook Entity
        /// </param>
        /// <param name="model">
        /// Hook Request Data Transfer Object
        /// </param>
        /// <returns>
        /// OkObjectResult(Hook)
        /// </returns>
        [HttpPost("{id}/requests", Name = "AddRequestToHook")]
        [ProducesResponseType(typeof(Hook), 200)]
        public async Task<IActionResult> AddRequestToHookAsync([FromRoute] Guid id, [FromBody] HookRequestDefineDto model)
        {
            var hook = await hookService.GetAsync(x => x.Id == id && x.TenantId == "1" && x.IsDeleted == false);
            var hookData = hook.FirstOrDefault();
            hookData.HookRequests.Add(new HookRequest
            {
                Method = model.Method,
                Url = model.Url,
                NotifiyEmail = model.NotifyEmail,
                MaxRetryCount = model.MaxRetryCount,
                Headers = JsonSerializer.Serialize(model.HeaderParameters)
            });

            await hookService.UpdateAsync(hookData);

            return Ok(hookData);
        }

        /// <summary>
        /// Delete Hook Request
        /// </summary>
        /// <param name="id">
        /// PK of Hook Request Entity
        /// </param>
        /// <returns></returns>
        [HttpDelete("requests/{id}", Name = "DeleteHookRequest")]
        [ProducesResponseType(204)]
        public async Task<IActionResult> DeleteHookRequestAsync([FromRoute] Guid id)
        {
            await hookService.RemoveRequestAsync(id);
            return NoContent();
        }

        /// <summary>
        /// Get Hook Requests
        /// </summary>
        /// <param name="id">
        /// PK of Hook
        /// </param>
        /// <returns>
        /// List of Hook Request
        /// </returns>
        [HttpGet("requests/{id}", Name = "GetRequests")]
        [ProducesResponseType(typeof(HookRequest[]), 200)]
        public async Task<IActionResult> GetRequestsAsync([FromRoute] Guid id)
        {
            var response = await hookService.GetHookRequestsAsync(id);
            return Ok(response);
        }
    }
}
