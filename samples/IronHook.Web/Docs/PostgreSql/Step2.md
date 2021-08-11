## Startup Configuration

Initalize `Startup` configuration.

```csharp
services.AddIronHook(options =>
{
   options.UseNpgsql(Configuration.GetConnectionString("{YOUR_CONNECTION_STRING}"));
});
```

after

```csharp
public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
{
  app.UseIronHook();
  // ...
}
```

Now you can start hook operations.