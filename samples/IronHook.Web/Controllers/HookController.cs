using IronHook.Core.Abstractions;
using IronHook.Core.Entities;
using IronHook.PostgreSql.Context;
using IronHook.Web.Dtos;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
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
    }
}
