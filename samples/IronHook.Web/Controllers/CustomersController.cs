using IronHook.Core.Abstractions;
using IronHook.Core.Primitives;
using IronHook.Web.Context;
using IronHook.Web.Dtos;
using IronHook.Web.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace IronHook.Web.Controllers
{
    /// <summary>
    /// Customers Endpoint
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly SampleDbContext sampleDbContext;
        private readonly IHookService hookService;

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="sampleDbContext">
        /// Sample Database Context
        /// </param>
        /// <param name="hookService">
        /// Hook Service
        /// </param>
        public CustomersController(SampleDbContext sampleDbContext, IHookService hookService)
        {
            this.sampleDbContext = sampleDbContext;
            this.hookService = hookService;
        }
        /// <summary>
        /// Customer Create
        /// </summary>
        /// <returns></returns>
        [HttpPost(Name = "AddCustomer")]
        [ProducesResponseType(typeof(HookResponse[]),200)]
        public async Task<IActionResult> AddCustomerAsync([FromBody] CustomerRequestDto model)
        {
            var entity = await sampleDbContext.Customers.AddAsync(new Customer
            {
                Name = model.Name,
                Surname = model.Surname,
                Phone = model.Phone
            });
            await sampleDbContext.SaveChangesAsync();
            var response = await hookService.RaiseHookAsync(EventNames.CUSTOMER_CREATED, "1", entity.Entity);
            return Ok(response);
        }

        /// <summary>
        /// Get All Customers
        /// </summary>
        /// <returns>
        /// Array of Customers
        /// </returns>
        [HttpGet(Name = "GetAllCustomers")]
        [ProducesResponseType(typeof(Customer[]), 200)]
        public async Task<IActionResult> GetAllAsync()
            => Ok(await sampleDbContext.Customers.Skip(0).Take(10).ToListAsync());
    }
}
