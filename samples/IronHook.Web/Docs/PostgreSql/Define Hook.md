## Usage
Get `IHookService<IronHookPostgreSqlDbContext>` from Dependency Injection.

### Add Hook
```csharp
var hook = new Hook
{
    TenantId = "xx",
    Key = "hook.key",
    Name = "name of hook",
    HookRequests = new List<HookRequest>
    {
        new HookRequest
        {
            Url = "https://google.com/search?q=ironhook",
            MaxRetryCount = 3,
            NotifiyEmail = "mail@ironhook.com",
            Method = "GET",
            Headers = JsonSerializer.Serialize(new List<HeaderParameter>
            {
                new HeaderParameter
                {
                    Name = "Authorization",
                    Value = "Bearer xxx"
                },
                new HeaderParameter
                {
                    Name = "ApiKey",
                    Value = "xxxxx"
                },
            })
        },
        new HookRequest
        {
            Url = "https://google.com/search?q=github",
            MaxRetryCount = 4,
            NotifiyEmail = "help@github.com",
            Method = "GET",
            Headers = JsonSerializer.Serialize(new List<HeaderParameter>
            {
                new HeaderParameter
                {
                    Name = "Authorization",
                    Value = "Bearer xxx"
                }
            })
        }
    }
};

await hookService.AddAsync(hook);

```

### Swagger SS

![image](https://user-images.githubusercontent.com/47147484/128686323-2bbb74a7-4669-40bc-9ca0-a2411d19b28b.png)