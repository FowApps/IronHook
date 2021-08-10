## Raise Hook

### Sample Code

```csharp
/// <summary>
/// Customers Endpoint
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class CustomersController : ControllerBase
{
    private readonly SampleDbContext sampleDbContext;
    private readonly IHookService<IronHookPostgreSqlDbContext> hookService;

    /// <summary>
    /// Ctor
    /// </summary>
    /// <param name="sampleDbContext">
    /// Sample Database Context
    /// </param>
    /// <param name="hookService">
    /// Hook Service
    /// </param>
    public CustomersController(SampleDbContext sampleDbContext, IHookService<IronHookPostgreSqlDbContext> hookService)
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
        var response = await hookService.RaiseHookAsync(EventNames.CUSTOMER_CREATED, "1", entity.Entity);  // <---
        return Ok(response);
    }
}
```

### Sample Response
```json
[
  {
    "headers": {
      "Date": "Mon, 09 Aug 2021 09:31:47 GMT",
      "Location": "http://www.xxx.com/v1/customers",
      "Server": "Caddy"
    },
    "body": "<html>\r\n<head><title>301 Moved Permanently</title></head>\r\n<body bgcolor=\"white\">\r\n<center><h1>301 Moved Permanently</h1></center>\r\n<hr><center>nginx</center>\r\n</body>\r\n</html>\r\n",
    "statusCode": 301,
    "isExceeded": false,
    "eventName": "Hook of Customer Created",
    "url": "https://xxx.com/v1/customers",
    "requestId": "5a3c6001-70fb-44e0-bf44-bd7562267c81",
    "notifyEmail": "info@ironhook.com"
  },
  {
    "headers": {
      "Date": "Mon, 09 Aug 2021 09:31:48 GMT",
      "Location": "http://www.xxx.com/v1/customers",
      "Server": "Caddy"
    },
    "body": "<html>\r\n<head><title>301 Moved Permanently</title></head>\r\n<body bgcolor=\"white\">\r\n<center><h1>301 Moved Permanently</h1></center>\r\n<hr><center>nginx</center>\r\n</body>\r\n</html>\r\n",
    "statusCode": 301,
    "isExceeded": false,
    "eventName": "Hook of Customer Created",
    "url": "https://xxx.com/v1/customers",
    "requestId": "5a3c6001-70fb-44e0-bf44-bd7562267c81",
    "notifyEmail": "info@ironhook.com"
  },
  {
    "headers": {
      "Date": "Mon, 09 Aug 2021 09:31:48 GMT",
      "Location": "http://www.xxx.com/v1/customers",
      "Server": "Caddy"
    },
    "body": "<html>\r\n<head><title>301 Moved Permanently</title></head>\r\n<body bgcolor=\"white\">\r\n<center><h1>301 Moved Permanently</h1></center>\r\n<hr><center>nginx</center>\r\n</body>\r\n</html>\r\n",
    "statusCode": 301,
    "isExceeded": false,
    "eventName": "Hook of Customer Created",
    "url": "https://xxx.com/v1/customers",
    "requestId": "5a3c6001-70fb-44e0-bf44-bd7562267c81",
    "notifyEmail": "info@ironhook.com"
  },
  {
    "headers": {
      "Date": "Mon, 09 Aug 2021 09:31:48 GMT",
      "Location": "http://www.xxx.com/v1/customers",
      "Server": "Caddy"
    },
    "body": "<html>\r\n<head><title>301 Moved Permanently</title></head>\r\n<body bgcolor=\"white\">\r\n<center><h1>301 Moved Permanently</h1></center>\r\n<hr><center>nginx</center>\r\n</body>\r\n</html>\r\n",
    "statusCode": 301,
    "isExceeded": true,
    "eventName": "Hook of Customer Created",
    "url": "https://xxx.com/v1/customers",
    "requestId": "5a3c6001-70fb-44e0-bf44-bd7562267c81",
    "notifyEmail": "info@ironhook.com"
  }
]
```

See [Hook Service Extensions](https://github.com/FowApps/IronHook/wiki/Hook-Extensions) for more information.
